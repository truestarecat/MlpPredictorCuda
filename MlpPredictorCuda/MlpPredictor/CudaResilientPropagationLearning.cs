using System;

namespace MlpPredictor
{
    [Serializable]
    public class CudaResilientPropagationLearning : CudaErrorPropagationLearning
    {
        public CudaResilientPropagationLearning(MlpNetwork network, NetworkDataSet dataSet,
            float maxRms, int maxNumEpoch) : base(network, dataSet, maxRms, maxNumEpoch)
        {
        }

        protected override float PerformEpoch()
        {
            if (disposed)
            {
                InitializeNativeResources();
            }

            return NativeMethods.PerformResilientPropEpoch(propagationHandle);
        }
    }
}
