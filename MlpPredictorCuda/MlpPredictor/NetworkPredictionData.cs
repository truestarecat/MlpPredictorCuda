using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MlpPredictor
{
    [Serializable]
    public class NetworkPredictionData
    {
        private float[] data;
        private string filePath;
        private int inputWindowSize;
        private int outputWindowSize;
        private float learningDataPercentage;

        public NetworkPredictionData(string filePath, int inputWindowSize = 1, int outputWindowSize = 1, float learningDataPercentage = 70.0f)
        {
            data = LoadDataFromCsvFile(filePath);
            FilePath = filePath;
            InputWindowSize = inputWindowSize;
            OutputWindowSize = outputWindowSize;
            LearningDataPercentage = learningDataPercentage;

            ResampleAll();
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value.Length == 0)
                    throw new ArgumentException("Пустой путь к файлу.", "value");

                filePath = value;
            }
        }

        public int InputWindowSize
        {
            get
            {
                return inputWindowSize;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value", "Размер входного окна прогноза должнен быть больше 0.");

                inputWindowSize = value;
            }
        }

        public int OutputWindowSize
        {
            get
            {
                return outputWindowSize;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value", "Размер выходного окна прогноза должнен быть больше 0.");

                outputWindowSize = value;
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
                if (value < 0.0f || value > 100.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Процент обучающих данных в выборке должен быть от 0% до 100%.");
                }

                learningDataPercentage = value;
            }
        }

        public NetworkDataSet FullDataSet { get; private set; }

        public NetworkDataSet LearningDataSet { get; private set; }

        public NetworkDataSet TestingDataSet { get; private set; }

        public void ResampleAll()
        {
            FullDataSet = Sample(data, InputWindowSize, OutputWindowSize);
            RedivideSamples();
        }

        public void ResampleAll(int inputWindowSize, int outputWindowSize, float learningDataPercentage)
        {
            InputWindowSize = inputWindowSize;
            OutputWindowSize = outputWindowSize;

            FullDataSet = Sample(data, InputWindowSize, OutputWindowSize);
            RedivideSamples(learningDataPercentage);
        }

        public void RedivideSamples()
        {
            NetworkDataSet[] dataSets = DivideSamples(FullDataSet, LearningDataPercentage);
            LearningDataSet = dataSets[0];
            TestingDataSet = dataSets[1];
        }

        public void RedivideSamples(float learningDataPercentage)
        {
            LearningDataPercentage = learningDataPercentage;

            NetworkDataSet[] dataSets = DivideSamples(FullDataSet, LearningDataPercentage);
            LearningDataSet = dataSets[0];
            TestingDataSet = dataSets[1];
        }

        public static float[] LoadDataFromCsvFile(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (filePath.Length == 0)
                throw new ArgumentException("Пустой путь к файлу.", "filePath");

            int lineCount = 0;
            string line;

            List<float> values = new List<float>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineCount > 1000)
                        throw new Exception("Слишком много данных для прогноза. В файле должно находиться не более 1000 значений.");

                    float value = Single.Parse(line/*, CultureInfo.InvariantCulture*/);
                    values.Add(value);

                    lineCount++;
                }
            }

            if (values.Count < 100)
                throw new Exception("Слишком мало данных для прогноза. В файле должно находиться как минимум 100 значений.");

            return values.ToArray();
        }

        public static void SaveDataToCsvFile(string filePath, float[] predictionData)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (predictionData == null)
                throw new ArgumentNullException("predictionData");
            if (filePath.Length == 0)
                throw new ArgumentException("Пустой путь к файлу.", "filePath");
            if (predictionData.Length == 0)
                throw new ArgumentException("Пустой массив данных для прогноза.", "predictionData");

            File.WriteAllLines(filePath, predictionData.Select(value => Convert.ToString(value/*, CultureInfo.InvariantCulture*/)));
        }

        public static NetworkDataSet Sample(float[] predictionData, int inputWindowSize, int outputWindowSize)
        {
            if (predictionData == null)
                throw new ArgumentNullException("predictionData");
            if (inputWindowSize < 1)
                throw new ArgumentOutOfRangeException("inputWindowSize", "Размер входного окна прогноза должнен быть больше 0.");
            if (outputWindowSize < 1)
                throw new ArgumentOutOfRangeException("outputWindowSize", "Размер выходного окна прогноза должнен быть больше 0.");

            int numSamples = (predictionData.Length - inputWindowSize) / outputWindowSize;

            if (numSamples < 1)
                throw new ArgumentException("Слишком мало данных для прогноза.", "predictionData");

            NetworkDataSet fullDataSet = new NetworkDataSet(inputWindowSize, outputWindowSize);
            for (int i = 0, step = 0; i < numSamples; i++, step += outputWindowSize)
            {
                float[] inputData = new float[inputWindowSize];
                for (int j = 0; j < inputWindowSize; j++)
                {
                    inputData[j] = predictionData[step + j];
                }

                float[] outputData = new float[outputWindowSize];
                for (int k = 0; k < outputWindowSize; k++)
                {
                    outputData[k] = predictionData[step + inputWindowSize + k];
                }

                fullDataSet.AddSample(new DataSample(inputData, outputData));
            }

            return fullDataSet;
        }

        public static NetworkDataSet[] DivideSamples(NetworkDataSet fullDataSet, float learningDataPercentage)
        {
            if (fullDataSet == null)
                throw new ArgumentNullException("fullDataSet");
            if (fullDataSet.NumSamples < 1)
                throw new ArgumentException("Слишком мало данных в наборе.", "fullDataSet");
            if (learningDataPercentage < 0.0f || learningDataPercentage > 100.0f)
                throw new ArgumentOutOfRangeException("learningDataPercentage", "Процент обучающих данных в выборке должен быть от 0% до 100%.");

            float divideFactor = learningDataPercentage / 100.0f;
            int learningNumSamples = (int)(fullDataSet.NumSamples * divideFactor);
            int testingNumSamples = fullDataSet.NumSamples - learningNumSamples;

            int inputWindowSize = fullDataSet.NumInput;
            int outputWindowSize = fullDataSet.NumOutput;
            NetworkDataSet learningDataSet = new NetworkDataSet(inputWindowSize, outputWindowSize);
            NetworkDataSet testingDataSet = new NetworkDataSet(inputWindowSize, outputWindowSize);
            for (int i = 0; i < fullDataSet.NumSamples; i++)
            {
                DataSample currentSample = fullDataSet.Samples[i];

                if (i < learningNumSamples)
                {
                    learningDataSet.AddSample(new DataSample(currentSample.Inputs, currentSample.Outputs));
                }
                else
                {
                    testingDataSet.AddSample(new DataSample(currentSample.Inputs, currentSample.Outputs));
                }
            }

            return new NetworkDataSet[] { learningDataSet, testingDataSet };
        }

        public static float[] NormalizeLinearly(float[] predictionData, float min, float max)
        {
            if (predictionData == null)
                throw new ArgumentNullException("predictionData");
            if (predictionData.Length == 0)
                throw new ArgumentException("Недостаточно исходных данных.", "predictionData.Length");
            if (min >= max)
                throw new ArgumentException("Минимальное значение должно быть меньше максимального.");

            float newRange = max - min;
            float dataMin = predictionData.Min();
            float dataMax = predictionData.Max();
            float dataRange = dataMax - dataMin;

            return predictionData.Select(value => min + (value - dataMin) * newRange / dataRange).ToArray();
        }
    }
}
