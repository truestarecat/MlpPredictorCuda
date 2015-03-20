using System;
using System.IO;
using System.Linq;

namespace MlpNetwork
{
    public class NetworkPrediction
    {
        public NetworkDataSet FullDataSet { get; private set; }
        public NetworkDataSet LearningDataSet { get; private set; }
        public NetworkDataSet TestingDataSet { get; private set; }

        public NetworkPrediction(float[] rawData, int networkInputsCount, int networkOutputsCount, float divideFactor = 0.7f)
        {
            FullDataSet = new NetworkDataSet(networkInputsCount, networkOutputsCount, (rawData.Length - networkInputsCount) / networkOutputsCount);
            LearningDataSet = new NetworkDataSet(networkInputsCount, networkOutputsCount, (int)(FullDataSet.NumSamples * divideFactor));
            TestingDataSet = new NetworkDataSet(networkInputsCount, networkOutputsCount, FullDataSet.NumSamples - LearningDataSet.NumSamples);
		    SampleData(rawData, networkInputsCount, networkOutputsCount);
		    DivideSamples(divideFactor);
        }

		public static float[] LoadData(string fileName)
        {
            return File.ReadAllLines(fileName).Select(value => Single.Parse(value)).ToArray();
        }

		public static void SaveData(string fileName, float[] data)
        {
            File.WriteAllLines(fileName, data.Select(value => value.ToString()));
        }

        private void SampleData(float[] rawData, int networkInputsCount, int networkOutputsCount)
        {
            int numInput = FullDataSet.NumInput;
		    int numOutput = FullDataSet.NumOutput;
		    int numSamples = FullDataSet.NumSamples;

            float[][] inputData = new float[numSamples][];
		    float[][] outputData = new float[numSamples][];
		    for (int i = 0, step = 0; i < numSamples; i++, step += networkOutputsCount)
		    {
                inputData[i] = new float[numInput];
			    for (int j = 0; j < networkInputsCount; j++)
			    {
				    inputData[i][j] = rawData[step + j];
			    }

                outputData[i] = new float[numOutput];
			    for (int k = 0; k < networkOutputsCount; k++)
			    {
				    outputData[i][k] = rawData[step + networkInputsCount + k];
			    }
		    }

            FullDataSet.SetInputData(inputData);
            FullDataSet.SetOutputData(outputData);
        }

		private void DivideSamples(float divideFactor)
        {
            float[][] inputData = FullDataSet.GetInputData();
            float[][] outputData = FullDataSet.GetOutputData();

            int numInput = FullDataSet.NumInput;
            int numOutput = FullDataSet.NumOutput;
            int numSamplesFull = FullDataSet.NumSamples;
            int numSamplesLearning = LearningDataSet.NumSamples;
            int numSamplesTesting = TestingDataSet.NumSamples;

            float[][] learningInputData = new float[numSamplesLearning][];
            float[][] learningOutputData = new float[numSamplesLearning][];
            float[][] testingInputData = new float[numSamplesTesting][];
            float[][] testingOutputData = new float[numSamplesTesting][];
		
            for (int i = 0; i < numSamplesFull; i++)
            {
                if (i < numSamplesLearning)
                {
                    learningInputData[i] = inputData[i];
                    learningOutputData[i] = outputData[i];
                }
                else
                {
                    testingInputData[i - numSamplesLearning] = inputData[i];
                    testingOutputData[i - numSamplesLearning] = outputData[i];
                }
            }

            LearningDataSet.SetInputData(learningInputData);
            LearningDataSet.SetOutputData(learningOutputData);
            TestingDataSet.SetInputData(testingInputData);
            TestingDataSet.SetOutputData(testingOutputData);
        }
    }
}
