using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace MlpNetwork
{
    [Serializable]
    public class NetworkPredictionManager
    {
        // Network structure
        private int networkNumInput;
        private int networkNumHidden;
        private int networkNumOutput;
        private ActivationFunctionType networkHiddenFunctionType;
        private ActivationFunctionType networkOutputFunctionType;

        //// Input data params
        private string predictionDataFilePath;
        private string predictionDataSeparator;
        private float learningDataPercentage;

        // Learning params
        private float maxLearningRms;
        private int maxNumEpoch;
        private float learningRate;
        private float momentum;
        private LearningAlgorithmType learningAlgorithmType;

        // Params changed flags
        private bool networkParamsChanged;
        private bool inputDataParamsChanged;
        private bool learningDataPercentageChanged;

        // Other private members
        private MlpNetwork network;
        private float[] predictionData;
        private NetworkDataSet fullDataSet;
        private NetworkDataSet learningDataSet;
        private NetworkDataSet testingDataSet;

        public NetworkPredictionManager()
        {
            InitializeNetworkParams();
            InitializeInputDataParams();
            InitializeLearningParams();
            ResetChangeFlags();
        }

        public int NetworkNumInput
        {
            get
            {
                return networkNumInput;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Network num input must be > 0");
                }

                networkNumInput = value;

                networkParamsChanged = true;
            }
        }

        public int NetworkNumHidden
        {
            get
            {
                return networkNumHidden;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Network num hidden must be > 0");
                }

                networkNumHidden = value;

                networkParamsChanged = true;
            }
        }

        public int NetworkNumOutput
        {
            get
            {
                return networkNumOutput;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Network num output must be > 0");
                }

                networkNumOutput = value;

                networkParamsChanged = true;
            }
        }

        public ActivationFunctionType NetworkHiddenFunctionType
        {
            get
            {
                return networkHiddenFunctionType;
            }
            set
            {
                networkHiddenFunctionType = value;

                networkParamsChanged = true;
            }
        }

        public ActivationFunctionType NetworkOutputFunctionType
        {
            get
            {
                return networkOutputFunctionType;
            }
            set
            {
                networkOutputFunctionType = value;

                networkParamsChanged = true;
            }
        }

        public string PredictionDataFilePath
        {
            get
            {
                return predictionDataFilePath;
            }
            set
            {
                predictionDataFilePath = value;

                inputDataParamsChanged = true;
            }
        }

        public string PredictionDataSeparator
        {
            get
            {
                return predictionDataSeparator;
            }
            set
            {
                predictionDataSeparator = value;

                inputDataParamsChanged = true;
            }
        }

        public float LearningDataPercentage
        {
            get
            {
                return learningDataPercentage;
            }
            set
            {
                if (value < 5.0f || value > 95.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Learning data percentage must be from 5 to 95%");
                }

                learningDataPercentage = value;

                learningDataPercentageChanged = true;
            }
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
                    throw new ArgumentOutOfRangeException("value", "Max learning rms must be > 0");
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
                    throw new ArgumentOutOfRangeException("value", "Max num epoch must be > 1");
                }

                maxNumEpoch = value;
            }
        }

        public float LearningRate
        {
            get
            {
                return learningRate;
            }
            set
            {
                if (value < 0.0f || value > 1.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Learning rate must be from 0 to 1");
                }

                learningRate = value;
            }
        }

        public float Momentum
        {
            get
            {
                return momentum;
            }
            set
            {
                if (value < 0.0f || value > 1.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Momentum must be from 0 to 1");
                }

                momentum = value;
            }
        }

        public LearningAlgorithmType LearningAlgorithmType { get; set; }

        public int NumEpoch { get; private set; }

        public float[] LearningRms { get; private set; }

        public float[] TestingRms { get; private set; }

        public float[] PredictedOutput { get; private set; }

        public float[] TargetOutput { get; private set; }

        public void LearnNetwork(IProgress<float> progress, CancellationToken token)
        {
            UpdateStatus();

            NumEpoch = 0;
            float error = Single.MaxValue;
            List<float> learningRmsList = new List<float>();
            using (CudaErrorPropagation propagation = new CudaErrorPropagation(network, learningDataSet))
            {
                propagation.RandomizeNetworkWeights();

                while (NumEpoch < maxNumEpoch && error > maxLearningRms)
                {
                    if (token.IsCancellationRequested)
                    {
                        propagation.Dispose();
                        LearningRms = learningRmsList.ToArray();
                        return;
                    }

                    switch (LearningAlgorithmType)
                    {
                        case LearningAlgorithmType.BackPropagation:
                            error = propagation.PerformBackPropEpoch(learningRate, momentum);
                            break;
                        case LearningAlgorithmType.ResilientBackPropagation:
                            error = propagation.PerformResilientPropEpoch();
                            break;
                    }

                    learningRmsList.Add(error);

                    progress.Report(error);

                    ++NumEpoch;
                }

                propagation.UpdateNetworkWeights();
            }

            LearningRms = learningRmsList.ToArray();

            ResetChangeFlags();
        }

        public void TestNetwork()
        {
            if(network == null || fullDataSet == null)
            {
                throw new NetworkNotTrainedException("Сеть не обучена");
            }

            float[][] predictedOutputSamples = network.ComputeOutput(fullDataSet.GetInputData());
            float[][] targetOutputSamples = fullDataSet.GetOutputData();

            TestingRms = MatrixHelper.Rms(targetOutputSamples, predictedOutputSamples);

            PredictedOutput = MatrixHelper.Convert2DArrayTo1D(predictedOutputSamples);
            TargetOutput = MatrixHelper.Convert2DArrayTo1D(targetOutputSamples);
        }

        public static NetworkPredictionManager LoadFromFile(string fileName)
        {
            NetworkPredictionManager predictionManager = null;
            using (var loader = new FileStream(fileName, FileMode.Open))
            {
                predictionManager = (NetworkPredictionManager)new BinaryFormatter().Deserialize(loader);
            }

            return predictionManager;
        }

        public static void SaveToFile(string fileName, NetworkPredictionManager predictionManager)
        {
            using (var saver = new FileStream(fileName, FileMode.Create))
            {
                new BinaryFormatter().Serialize(saver, predictionManager);
            }
        }

        public void SaveToFile(string fileName)
        {
            SaveToFile(fileName, this);
        }

        private void InitializeNetworkParams()
        {
            NetworkNumInput = 30;
            NetworkNumHidden = 15;
            NetworkNumOutput = 1;
            NetworkHiddenFunctionType = ActivationFunctionType.UnipolarSigmoid;
            NetworkOutputFunctionType = ActivationFunctionType.UnipolarSigmoid;
        }

        private void InitializeInputDataParams()
        {
            PredictionDataFilePath = @"\InputData.txt";
            PredictionDataSeparator = Environment.NewLine;
            LearningDataPercentage = 70.0f;
        }

        private void InitializeLearningParams()
        {
            MaxLearningRms = 0.01f;
            MaxNumEpoch = 10000;
            LearningRate = 0.05f;
            Momentum = 1.0f;
            learningAlgorithmType = LearningAlgorithmType.BackPropagation;
        }

        private void ResetChangeFlags()
        {
            networkParamsChanged = false;
            inputDataParamsChanged = false;
            learningDataPercentageChanged = false;
        }

        private void UpdateStatus()
        {
            if (predictionData == null || inputDataParamsChanged)
            {
                predictionData = NetworkPredictionData.LoadFromFile(PredictionDataFilePath, PredictionDataSeparator);
            }

            if (network == null || networkParamsChanged)
            {
                network = new MlpNetwork(NetworkNumInput, NetworkNumHidden, NetworkNumOutput,
                    NetworkHiddenFunctionType, NetworkOutputFunctionType);
            }

            if (fullDataSet == null || learningDataPercentageChanged || inputDataParamsChanged || networkParamsChanged)
            {
                fullDataSet = NetworkPredictionData.Sample(predictionData, NetworkNumInput, NetworkNumOutput);
                NetworkDataSet[] dataSets = NetworkPredictionData.DivideSamples(fullDataSet, LearningDataPercentage);
                learningDataSet = dataSets[0];
                testingDataSet = dataSets[1];
            }
        }
    }
}
