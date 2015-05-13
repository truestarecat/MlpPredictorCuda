using System;

namespace MlpPredictor
{
    [Serializable]
    public class NetworkTesting
    {
        private MlpNetwork network;
        private NetworkDataSet testingDataSet;

        public NetworkTesting(MlpNetwork network, NetworkDataSet testingDataSet)
        {
            if(network == null)
                throw new ArgumentNullException("network");
            if(testingDataSet == null)
                throw new ArgumentNullException("testingDataSet");

            this.network = network;
            this.testingDataSet = testingDataSet;
        }

        public float[] Rms { get; private set; }

        public float[] PredictedOutput { get; private set; }

        public float[] TargetOutput { get; private set; }

        public void Start()
        {
            float[][] predictedOutputSamples = network.ComputeOutput(testingDataSet.GetInputData());
            float[][] targetOutputSamples = testingDataSet.GetOutputData();

            Rms = MatrixHelper.Rms(targetOutputSamples, predictedOutputSamples);

            PredictedOutput = MatrixHelper.Convert2DArrayTo1D(predictedOutputSamples);
            TargetOutput = MatrixHelper.Convert2DArrayTo1D(targetOutputSamples);
        }
    }
}
