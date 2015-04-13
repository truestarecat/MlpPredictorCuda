using System;

namespace MlpPredictor
{
    [Serializable]
    public class CudaResilientPropagationLearning : CudaErrorPropagationLearning
    {
        public CudaResilientPropagationLearning(MlpNetwork network, NetworkDataSet dataSet)
            : base(network, dataSet)
        {
        }

        public override float PerformEpoch()
        {
            if (disposed)
            {
                InitializeNativeResources();
            }

            return NativeMethods.PerformResilientPropEpoch(propagationHandle);
        }
    }
}
