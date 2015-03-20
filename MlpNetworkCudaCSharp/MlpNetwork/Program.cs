using System;
using System.Windows.Forms;

namespace MlpNetwork
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        //static void Main(string[] args)
        //{
        //    int numInput = 2;
        //    int numHidden = 4;
        //    int numOutput = 1;
        //    int numSamples = 4;

        //    const int maxNumEpoch = 50000;
        //    const float maxError = 0.001f;

        //    float[][] inputData = new float[][] { new float[] { 1.0f, 1.0f },
        //                                          new float[] {	1.0f, 0.0f },
        //                                          new float[] { 0.0f, 1.0f },
        //                                          new float[] { 0.0f, 0.0f } };

        //    float[][] outputData = new float[][] { new float[] { 0.0f },
        //                                           new float[] { 1.0f },
        //                                           new float[] { 1.0f },
        //                                           new float[] { 0.0f } };

        //    NetworkDataSet learningSet = new NetworkDataSet(inputData, outputData);
        //    MlpNetwork network = new MlpNetwork(numInput, numHidden, numOutput);

        //    using (CudaErrorPropagation propagation = new CudaErrorPropagation(network, learningSet))
        //    {
        //        propagation.RandomizeNetworkWeights();

        //        int numEpoch = 0;
        //        float error = Single.MaxValue;
        //        while (numEpoch < maxNumEpoch && error > maxError)
        //        {
        //            error = propagation.PerformBackPropEpoch(1.0f, 1.0f);

        //            Console.WriteLine("Epoch: {0}. Error: {1}.", numEpoch, error);

        //            ++numEpoch;
        //        }

        //        propagation.UpdateNetworkWeights();
        //    }

        //    float[][] outputs = new float[learningSet.NumSamples][];
        //    for (int i = 0; i < learningSet.NumSamples; i++)
        //    {
        //        outputs[i] = network.ComputeOutput(inputData[i]);
        //    }

        //    Console.ReadKey();
        //}
    }
}
