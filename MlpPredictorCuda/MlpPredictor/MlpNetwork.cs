using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MlpPredictor
{
    [Serializable]
    public class MlpNetwork
    {
        private int numInput;
        private int numHidden;
        private int numOutput;
        private ActivationFunction hiddenFunction;
        private ActivationFunction outputFunction;

        private float[] inputs;
        private float[][] inputHiddenWeights;
        private float[] hiddenOutputs;
        private float[][] hiddenOutputWeights;
        private float[] outputs;

        public MlpNetwork(int numInput, int numHidden, int numOutput)
        {
            NumInput = numInput;
            NumHidden = numHidden;
            NumOutput = numOutput;
            HiddenFunction = new ActivationFunction(ActivationFunctionType.UnipolarSigmoid);
            OutputFunction = new ActivationFunction(ActivationFunctionType.UnipolarSigmoid);

            inputs = new float[numInput];

            inputHiddenWeights = new float[numInput + 1][];
            for (int i = 0; i < inputHiddenWeights.Length; i++)
            {
                inputHiddenWeights[i] = new float[numHidden];
            }

            hiddenOutputs = new float[numHidden];

            hiddenOutputWeights = new float[numHidden + 1][];
            for (int i = 0; i < hiddenOutputWeights.Length; i++)
            {
                hiddenOutputWeights[i] = new float[numOutput];
            }

            outputs = new float[numOutput];

            RandomizeWeights();
        }

        public MlpNetwork(int numInput, int numHidden, int numOutput,
            ActivationFunction hiddenFunction, ActivationFunction outputFunction)
        {
            NumInput = numInput;
            NumHidden = numHidden;
            NumOutput = numOutput;
            HiddenFunction = hiddenFunction;
            OutputFunction = outputFunction;

            inputs = new float[numInput];

            inputHiddenWeights = new float[numInput + 1][];
            for (int i = 0; i < inputHiddenWeights.Length; i++)
            {
                inputHiddenWeights[i] = new float[numHidden];
            }

            hiddenOutputs = new float[numHidden];

            hiddenOutputWeights = new float[numHidden + 1][];
            for (int i = 0; i < hiddenOutputWeights.Length; i++)
            {
                hiddenOutputWeights[i] = new float[numOutput];
            }

            outputs = new float[numOutput];

            RandomizeWeights();
        }

        public int NumInput
        {
            get
            {
                return numInput;
            }
            private set
            {
                if(value < 1)
                    throw new ArgumentOutOfRangeException("value", "Число входов сети должно быть больше 0.");

                numInput = value;
            }
        }

        public int NumHidden
        {
            get
            {
                return numHidden;
            }
            private set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value", "Число нейронов в скрытом слое сети должно быть больше 0.");

                numHidden = value;
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
                    throw new ArgumentOutOfRangeException("value", "Число выходов сети должно быть больше 0.");

                numOutput = value;
            }
        }

        public ActivationFunction HiddenFunction
        {
            get
            {
                return hiddenFunction;
            }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("value");

                hiddenFunction = value;
            }
        }

        public ActivationFunction OutputFunction
        {
            get
            {
                return outputFunction;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                outputFunction = value;
            }
        }

        public float[] GetInputs()
        {
            return (float[])inputs.Clone();
        }

        public float[][] GetInputHiddenWeights()
        {
            float[][] inputHiddenWeightsCopy = new float[NumInput + 1][];
            for (int i = 0; i < inputHiddenWeightsCopy.Length; i++)
            {
                inputHiddenWeightsCopy[i] = (float[])this.inputHiddenWeights[i].Clone();
            }

            return inputHiddenWeightsCopy;
        }

        public float[] GetHiddenOutputs()
        {
            return (float[])hiddenOutputs.Clone();
        }

        public float[][] GetHiddenOutputWeights()
        {
            float[][] hiddenOutputWeightsCopy = new float[NumHidden + 1][];
            for (int i = 0; i < hiddenOutputWeightsCopy.Length; i++)
            {
                hiddenOutputWeightsCopy[i] = (float[])this.hiddenOutputWeights[i].Clone();
            }

            return hiddenOutputWeightsCopy;
        }

        public float[] GetOutputs()
        {
            return (float[])outputs.Clone();
        }

        public void SetInputs(float[] newInputs)
        {
            if(newInputs.Length != NumInput)
                throw new ArgumentException("Bad number of inputs");

            Array.Copy(newInputs, this.inputs, newInputs.Length);
        }

        public void SetInputHiddenWeights(float[][] newInputHiddenWeights)
        {
            if (newInputHiddenWeights.Length != (NumInput + 1) || newInputHiddenWeights[0].Length != NumHidden)
                throw new ArgumentException("Bad number of weights");

            for (int i = 0; i < newInputHiddenWeights.Length; i++)
            {
                Array.Copy(newInputHiddenWeights[i], this.inputHiddenWeights[i], NumHidden);
            }
        }

        public void SetHiddenOutputWeights(float[][] newHiddenOutputWeights)
        {
            if (newHiddenOutputWeights.Length != (NumHidden + 1) || newHiddenOutputWeights[0].Length != NumOutput)
                throw new ArgumentException("Bad number of weights");

            for (int i = 0; i < newHiddenOutputWeights.Length; i++)
            {
                Array.Copy(newHiddenOutputWeights[i], this.hiddenOutputWeights[i], NumOutput);
            }
        }

        public void RandomizeWeights()
        {
            RandomizeLayerWeights(inputHiddenWeights, -0.5f, 0.5f);
            RandomizeLayerWeights(hiddenOutputWeights, -0.5f, 0.5f);
        }

        public static MlpNetwork LoadFromBinaryFile(string fileName)
        {
            MlpNetwork network = null;
            using(var loader = new FileStream(fileName, FileMode.Open))
            {
                network = (MlpNetwork)new BinaryFormatter().Deserialize(loader);
            }

            return network;
        }

        public static void SaveToBinaryFile(string fileName, MlpNetwork network)
        {
            using (var saver = new FileStream(fileName, FileMode.Create))
            {
                new BinaryFormatter().Serialize(saver, network);
            }
        }

        public void SaveToBinaryFile(string fileName)
        {
            SaveToBinaryFile(fileName, this);
        }

        public void ComputeOutput()
        {
            ComputeLayerOutput(hiddenFunction, inputHiddenWeights, inputs, hiddenOutputs, NumInput, NumHidden);
            ComputeLayerOutput(outputFunction, hiddenOutputWeights, hiddenOutputs, outputs, NumHidden, NumOutput);
        }

        public float[] ComputeOutput(float[] inputs)
        {
            Array.Copy(inputs, this.inputs, NumInput);

            ComputeOutput();

            return (float[])outputs.Clone();
        }

        public float[][] ComputeOutput(float[][] inputs)
        {
            float[][] outputsBatch = new float[inputs.Length][];
            for (int i = 0; i < inputs.Length; i++)
            {
                outputsBatch[i] = ComputeOutput(inputs[i]);
            }

            return outputsBatch;
        }

        private void RandomizeLayerWeights(float[][] layerWeights, float minimum, float maximum)
        {
            Random random = new Random();
            for (int i = 0; i < layerWeights.Length; i++)
            {
                for (int j = 0; j < layerWeights[i].Length; j++)
                {
                    layerWeights[i][j] = GetRandomNumberFromRange(random, minimum, maximum);
                }
            }
        }

        private static void ComputeLayerOutput(ActivationFunction layerActivationFunction, float[][] layerWeights,
            float[] layerInputs, float[] layerOutputs, int numLayerInput, int numLayerOutput)
        {
            for (int j = 0; j < numLayerOutput; j++)
            {
                float sum = layerWeights[0][j] * 1.0f;
                for (int i = 0; i < numLayerInput; i++)
                {
                    sum += layerWeights[i + 1][j] * layerInputs[i];
                }

                layerOutputs[j] = layerActivationFunction.Value(sum);
            }
        }

        private static float GetRandomNumberFromRange(Random random, float minimum, float maximum)
        {
            return (float)random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
