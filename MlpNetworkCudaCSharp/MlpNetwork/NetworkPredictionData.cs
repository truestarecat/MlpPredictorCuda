using System;
using System.IO;
using System.Linq;

namespace MlpNetwork
{
    public class NetworkPredictionData
    {
        public static float[] LoadFromFile(string fileName, string dataSeparator)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (dataSeparator == null)
            {
                throw new ArgumentNullException("dataSeparator");
            }

            return File.ReadAllText(fileName)
                       .Split(new string[] { dataSeparator }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(value => Single.Parse(value.Trim()))
                       .ToArray();
        }

        public static void SaveToFile(string fileName, float[] predictionData, string dataSeparator)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (predictionData == null)
            {
                throw new ArgumentNullException("predictionData");
            }
            if (dataSeparator == null)
            {
                throw new ArgumentNullException("dataSeparator");
            }

            File.WriteAllText(fileName, String.Join(dataSeparator, predictionData.Select(value => value.ToString())));
        }

        public static NetworkDataSet Sample(float[] predictionData, int networkNumInput, int networkNumOutput)
        {
            if (predictionData == null)
            {
                throw new ArgumentNullException("predictionData");
            }
            if (networkNumInput < 1)
            {
                throw new ArgumentOutOfRangeException("networkNumInput", "Network num input must be > 0");
            }
            if (networkNumOutput < 1)
            {
                throw new ArgumentOutOfRangeException("networkNumOutput", "Network num output must be > 0");
            }

            int numSamples = (predictionData.Length - networkNumInput) / networkNumOutput;

            float[][] inputData = new float[numSamples][];
            float[][] outputData = new float[numSamples][];
            for (int i = 0, step = 0; i < numSamples; i++, step += networkNumOutput)
            {
                inputData[i] = new float[networkNumInput];
                for (int j = 0; j < networkNumInput; j++)
                {
                    inputData[i][j] = predictionData[step + j];
                }

                outputData[i] = new float[networkNumOutput];
                for (int k = 0; k < networkNumOutput; k++)
                {
                    outputData[i][k] = predictionData[step + networkNumInput + k];
                }
            }

            return new NetworkDataSet(inputData, outputData);
        }

        public static NetworkDataSet[] DivideSamples(NetworkDataSet fullDataSet, float learningDataPercentage)
        {
            if (fullDataSet == null)
            {
                throw new ArgumentNullException("fullDataSet");
            }
            if (learningDataPercentage < 5.0f || learningDataPercentage > 95.0f)
            {
                throw new ArgumentOutOfRangeException("learningDataPercentage",
                    "Learning data percentage must be from 5 to 95%");
            }

            int numInput = fullDataSet.NumInput;
            int numOutput = fullDataSet.NumOutput;
            int fullNumSamples = fullDataSet.NumSamples;
            int learningNumSamples = (int)(fullDataSet.NumSamples * (learningDataPercentage / 100.0f));
            int testingNumSamples = fullDataSet.NumSamples - learningNumSamples;

            float[][] fullInputData = fullDataSet.GetInputData();
            float[][] fullOutputData = fullDataSet.GetOutputData();
            float[][] learningInputData = new float[learningNumSamples][];
            float[][] learningOutputData = new float[learningNumSamples][];
            float[][] testingInputData = new float[testingNumSamples][];
            float[][] testingOutputData = new float[testingNumSamples][];

            for (int i = 0; i < fullNumSamples; i++)
            {
                if (i < learningNumSamples)
                {
                    learningInputData[i] = fullInputData[i];
                    learningOutputData[i] = fullOutputData[i];
                }
                else
                {
                    testingInputData[i - learningNumSamples] = fullInputData[i];
                    testingOutputData[i - learningNumSamples] = fullOutputData[i];
                }
            }

            return new NetworkDataSet[] { new NetworkDataSet(learningInputData, learningOutputData),
                                          new NetworkDataSet(testingInputData, testingOutputData) };
        }
    }
}
