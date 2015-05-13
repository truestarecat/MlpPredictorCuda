using System;

namespace MlpPredictor
{
    [Serializable]
    public class CudaBackPropagationLearning : CudaErrorPropagationLearning
    {
        private float learningRate;
        private float momentum;

        public CudaBackPropagationLearning(MlpNetwork network, NetworkDataSet dataSet,
            float maxRms, int maxNumEpoch, float learningRate, float momentum)
            : base(network, dataSet, maxRms, maxNumEpoch)
        {
            LearningRate = learningRate;
            Momentum = momentum;
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
                    throw new ArgumentOutOfRangeException("value", "Коэффициент обучения должен лежать в диапазоне [0; 1].");
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
                    throw new ArgumentOutOfRangeException("value", "Момент должен лежать в диапазоне [0; 1].");
                }

                momentum = value;
            }
        }

        protected override float PerformEpoch()
        {
            if (disposed)
            {
                InitializeNativeResources();
            }

            return NativeMethods.PerformBackPropEpoch(propagationHandle, learningRate, momentum);
        }
    }
}
