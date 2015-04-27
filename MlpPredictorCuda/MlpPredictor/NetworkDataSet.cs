using System;
using System.Collections.Generic;

namespace MlpPredictor
{
    [Serializable]
    public class NetworkDataSet
    {
        private int numInput;
        private int numOutput;

        public NetworkDataSet(int numInput, int numOutput)
        {
            NumInput = numInput;
            NumOutput = numOutput;
            Samples = new List<DataSample>();
        }

        public int NumInput
        {
            get
            {
                return numInput;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Число входов набора данных должно быть больше 0.");
                }

                numInput = value;
            }
        }

        public int NumOutput
        {
            get
            {
                return numOutput;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Число выходов набора данных должно быть больше 0.");
                }

                numOutput = value;
            }
        }

        public int NumSamples
        {
            get
            {
                return Samples.Count;
            }
        }

        public List<DataSample> Samples { get; private set; }

        public void AddSample(DataSample sample)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            if (sample.NumInput != this.NumInput || sample.NumOutput != this.NumOutput)
                throw new ArgumentException("Неверное число входов или выходов выборки.");

            Samples.Add(sample);
        }

        public float[][] GetInputData()
        {
            float[][] inputData = new float[NumSamples][];
            for (int i = 0; i <  inputData.Length; i++)
            {
                inputData[i] = Samples[i].Inputs;
            }

            return inputData;
        }

        public float[][] GetOutputData()
        {
            float[][] outputData = new float[NumSamples][];
            for (int i = 0; i < outputData.Length; i++)
            {
                outputData[i] = Samples[i].Outputs;
            }

            return outputData;
        }

        //public void SetInputData(float[][] inputData)
        //{
        //    if (inputData.Length != NumSamples || (inputData.Length != 0 && inputData[0].Length != NumInput))
        //        throw new ArgumentException("Неверная размерность входных данных.", "inputData");

        //    for (int i = 0; i < inputData.Length; i++)
        //    {
        //        Array.Copy(inputData[i], this.inputData[i], NumInput);
        //    }
        //}

        //public void SetOutputData(float[][] outputData)
        //{
        //    if (outputData.Length != NumSamples || (outputData.Length != 0 && outputData[0].Length != NumOutput))
        //        throw new ArgumentException("Неверная размерность выходных данных.", "outputData");

        //    for (int i = 0; i < outputData.Length; i++)
        //    {
        //        Array.Copy(outputData[i], this.outputData[i], NumOutput);
        //    }
        //}
    }
}
