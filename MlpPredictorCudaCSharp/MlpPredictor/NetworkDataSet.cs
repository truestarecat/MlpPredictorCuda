using System;

namespace MlpPredictor
{
    [Serializable]
    public class NetworkDataSet
    {
        private int numInput;
        private int numOutput;
        private int numSamples;
        private float[][] inputData;
        private float[][] outputData;

        public NetworkDataSet(int numInput, int numOutput, int numSamples)
        {
            NumInput = numInput;
            NumOutput = numOutput;
            NumSamples = numSamples;

            inputData = new float[numSamples][];
            outputData = new float[numSamples][];
            for (int i = 0; i < numSamples; i++)
			{
                inputData[i] = new float[numInput];
                outputData[i] = new float[numOutput];
			}
        }

        public NetworkDataSet(float[][] inputData, float[][] outputData)
            : this(inputData[0].Length, outputData[0].Length, inputData.Length)
        {
            SetInputData(inputData);
            SetOutputData(outputData);
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
                    throw new ArgumentOutOfRangeException("value", "Число входов должно быть больше 0.");
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
                    throw new ArgumentOutOfRangeException("value", "Число выходов должно быть больше 0.");
                }

                numOutput = value;
            }
        }

        public int NumSamples
        {
            get
            {
                return numSamples;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Число выборок в наборе должно быть больше 0.");
                }

                numSamples = value;
            }
        }

        public float[][] GetInputData()
        {
            float[][] inputDataCopy = new float[NumSamples][];
            for (int i = 0; i < inputDataCopy.Length; i++)
            {
                inputDataCopy[i] = (float[])this.inputData[i].Clone();
            }

            return inputDataCopy;
        }

        public float[][] GetOutputData()
        {
            float[][] outputDataCopy = new float[NumSamples][];
            for (int i = 0; i < outputDataCopy.Length; i++)
            {
                outputDataCopy[i] = (float[])this.outputData[i].Clone();
            }

            return outputDataCopy;
        }

        public void SetInputData(float[][] inputData)
		{
			if (inputData.Length != NumSamples || inputData[0].Length!= NumInput)
                throw new ArgumentException("Неверная размерность входных данных.", "inputData");

            for (int i = 0; i < inputData.Length; i++)
            {
                Array.Copy(inputData[i], this.inputData[i], NumInput);
            }
		}

		public void SetOutputData(float[][] outputData)
		{
			if (outputData.Length != NumSamples || outputData[0].Length != NumOutput)
                throw new ArgumentException("Неверная размерность выходных данных.", "outputData");

            for (int i = 0; i < outputData.Length; i++)
            {
                Array.Copy(outputData[i], this.outputData[i], NumOutput);
            }
		}
    }
}
