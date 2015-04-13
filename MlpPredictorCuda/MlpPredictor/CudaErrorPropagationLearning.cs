using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace MlpPredictor
{
    public enum LearningAlgorithmType
    {
        BackPropagation = 0,
        ResilientBackPropagation = 1
    }

    [Serializable]
    public abstract class CudaErrorPropagationLearning : INetworkLearning, IDisposable
    {
        private MlpNetwork network;
        private NetworkDataSet dataSet;

        protected float maxLearningRms;
        protected int maxNumEpoch;

        [NonSerialized]
        protected IntPtr propagationHandle;

        [NonSerialized]
        protected bool disposed;

        public CudaErrorPropagationLearning(MlpNetwork network, NetworkDataSet dataSet,
            float maxLearningRms = 0.01f, int maxNumEpoch = 10000)
        {
            if (network == null)
                throw new ArgumentNullException("network");
            if (dataSet == null)
                throw new ArgumentNullException("dataSet");

            this.network = network;
            this.dataSet = dataSet;

            MaxLearningRms = maxLearningRms;
            MaxNumEpoch = maxNumEpoch;

            this.propagationHandle = IntPtr.Zero;
            this.disposed = true;
        }

        public float MaxLearningRms
        {
            get
            {
                return maxLearningRms;
            }
            set
            {
                if (value < 0.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Максимальное СКО ошибки обучения должно быть больше 0.");
                }

                maxLearningRms = value;
            }
        }

        public int MaxNumEpoch
        {
            get
            {
                return maxNumEpoch;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Максимальное число эпох обучения должно быть больше 1.");
                }

                maxNumEpoch = value;
            }
        }

        public int NumEpoch { get; protected set; }

        public float[] Rms { get; protected set; }

        public abstract float PerformEpoch();

        public void LearnNetwork()
        {
            if (disposed)
            {
                InitializeNativeResources();
            }

            NumEpoch = 0;
            float error = Single.MaxValue;
            List<float> learningRmsList = new List<float>();

            while (NumEpoch < maxNumEpoch && error > maxLearningRms)
            {
                error = PerformEpoch();

                learningRmsList.Add(error);

                ++NumEpoch;
            }

            UpdateNetworkWeights();

            Rms = learningRmsList.ToArray();
        }

        public void LearnNetwork(IProgress<float> progress, CancellationToken token)
        {
            if (progress == null)
                throw new ArgumentNullException("progress");
            if (token == null)
                throw new ArgumentNullException("token");

            if (disposed)
            {
                InitializeNativeResources();
            }

            NumEpoch = 0;
            float error = Single.MaxValue;
            List<float> learningRmsList = new List<float>();

            while (NumEpoch < maxNumEpoch && error > maxLearningRms)
            {
                if (token.IsCancellationRequested)
                {
                    Dispose();
                    Rms = learningRmsList.ToArray();
                    return;
                }

                error = PerformEpoch();

                learningRmsList.Add(error);

                progress.Report(error);

                ++NumEpoch;
            }

            UpdateNetworkWeights();

            Rms = learningRmsList.ToArray();
        }

        public void RandomizeNetworkWeights()
        {
            if(disposed)
            {
                InitializeNativeResources();
            }

            NativeMethods.RandomizeWeights(propagationHandle);
        }

        public void UpdateNetworkWeights()
        {
            if (disposed)
            {
                InitializeNativeResources();
            }

            IntPtr ihWeightsFlattenPtr = this.GetInputHiddenWeightsPtr();
            IntPtr hoWeightsFlattenPtr = this.GetHiddenOutputWeightsPtr();

            int ihWeightsX = network.NumInput + 1;
            int ihWeightsY = network.NumHidden;
            int hoWeightsX = network.NumHidden + 1;
            int hoWeightsY = network.NumOutput;

            int ihWeightsXY = ihWeightsX * ihWeightsY;
            int hoWeightsXY = hoWeightsX * hoWeightsY;

            float[] ihWeightsFlatten = new float[ihWeightsXY];
            float[] hoWeightsFlatten = new float[hoWeightsXY];
            Marshal.Copy(ihWeightsFlattenPtr, ihWeightsFlatten, 0, ihWeightsFlatten.Length);
            Marshal.Copy(hoWeightsFlattenPtr, hoWeightsFlatten, 0, hoWeightsFlatten.Length);
            float[][] ihWeights = Convert1DArrayTo2D(ihWeightsFlatten, ihWeightsX,
                ihWeightsY);
            float[][] hoWeights = Convert1DArrayTo2D(hoWeightsFlatten, hoWeightsX,
                hoWeightsY);

            network.SetInputHiddenWeights(ihWeights);
            network.SetHiddenOutputWeights(hoWeights);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                NativeMethods.DestroyErrorPropagation(propagationHandle);

                propagationHandle = IntPtr.Zero;
                disposed = true;
            }
        }

        protected void InitializeNativeResources()
        {
            float[] inputDataFlatten = Convert2DArrayTo1D(dataSet.GetInputData());
            float[] outputDataFlatten = Convert2DArrayTo1D(dataSet.GetOutputData());
            float[] inputHiddenWeightsFlatten = Convert2DArrayTo1D(network.GetInputHiddenWeights());
            float[] hiddenOutputWeightsFlatten = Convert2DArrayTo1D(network.GetHiddenOutputWeights());

            propagationHandle = NativeMethods.CreateErrorPropagation(inputDataFlatten, outputDataFlatten,
                inputHiddenWeightsFlatten, hiddenOutputWeightsFlatten,
                network.NumInput, network.NumHidden, network.NumOutput, dataSet.NumSamples,
                network.HiddenFunction.Type, network.OutputFunction.Type);

            disposed = false;
        }

        private IntPtr GetInputHiddenWeightsPtr()
        {
            if (disposed)
            {
                InitializeNativeResources();
            }

            return NativeMethods.GetInputHiddenWeights(propagationHandle);
        }

        private IntPtr GetHiddenOutputWeightsPtr()
        {
            if (disposed)
            {
                InitializeNativeResources();
            }

            return NativeMethods.GetHiddenOutputWeights(propagationHandle);
        }

        private static long Get1DIndexFrom2D(int i, int j, int width)
        {
            return i * width + j;
        }

        private static T[] Convert2DArrayTo1D<T>(T[][] array2D)
        {
            T[] array1D = new T[array2D.Length * array2D[0].Length];
            for (int i = 0; i < array2D.Length; i++)
            {
                for (int j = 0; j < array2D[i].Length; j++)
                {
                    array1D[Get1DIndexFrom2D(i, j, array2D[i].Length)] = array2D[i][j];
                }
            }

            return array1D;
        }

        private static T[][] Convert1DArrayTo2D<T>(T[] array1D, int xLength, int yLength)
        {
            T[][] array2D = new T[xLength][];
            for (int i = 0; i < array2D.Length; i++)
            {
                array2D[i] = new T[yLength];
                for (int j = 0; j < array2D[i].Length; j++)
                {
                    array2D[i][j] = array1D[Get1DIndexFrom2D(i, j, array2D[i].Length)];
                }
            }

            return array2D;
        }

        ~CudaErrorPropagationLearning()
        {
            Dispose(false);
        }
    }
}
