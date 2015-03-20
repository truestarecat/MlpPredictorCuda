using System;
using System.ComponentModel;

namespace MlpNetwork
{
    enum ActivationFunctionType
    {
        [EnumDescription("Логистическая")]
        UnipolarSigmoid = 0,

        [EnumDescription("Гипертангенс")]
        BipolarSigmoid = 1,

        [EnumDescription("Синус")]
        Sinusoid = 2,

        [EnumDescription("Линейная")]
        Linear = 3
    }

    delegate float Function(float x);

    class MlpNetwork
    {
        private ActivationFunctionType hiddenFunctionType;
        private ActivationFunctionType outputFunctionType;
        private Function hiddenFunction;
        private Function outputFunction;

        private float[] inputs;
        private float[][] inputHiddenWeights;
        private float[] hiddenOutputs;
        private float[][] hiddenOutputWeights;
        private float[] outputs;

        public int NumInput { get; private set; }
        public int NumHidden { get; private set; }
        public int NumOutput { get; private set; }

        public MlpNetwork(int numInput, int numHidden, int numOutput,
            ActivationFunctionType hiddenFunctionType = ActivationFunctionType.UnipolarSigmoid,
            ActivationFunctionType outputFunctionType = ActivationFunctionType.UnipolarSigmoid)
        {
            NumInput = numInput;
            NumHidden = numHidden;
            NumOutput = numOutput;

            HiddenFunctionType = hiddenFunctionType;
            OutputFunctionType = outputFunctionType;

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
        }

        public ActivationFunctionType HiddenFunctionType
        {
            get
            {
                return hiddenFunctionType;
            }
            set
            {
                hiddenFunctionType = value;
                SetLayerFunction(ref hiddenFunction, value);
            }
        }

        public ActivationFunctionType OutputFunctionType
        {
            get
            {
                return outputFunctionType;
            }
            set
            {
                outputFunctionType = value;
                SetLayerFunction(ref outputFunction, value);
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

        private static void ComputeLayerOutput(Function layerActivationFunction, float[][] layerWeights, float[] layerInputs, float[] layerOutputs,
            int numLayerInput, int numLayerOutput)
        {
            for (int j = 0; j < numLayerOutput; j++)
            {
                float sum = layerWeights[0][j] * 1.0f;
                for (int i = 0; i < numLayerInput; i++)
                {
                    sum += layerWeights[i + 1][j] * layerInputs[i];
                }

                layerOutputs[j] = layerActivationFunction(sum);
            }
        }

        private void SetLayerFunction(ref Function layerFunction, ActivationFunctionType type)
        {
            switch (type)
            {
                case ActivationFunctionType.UnipolarSigmoid:
                    layerFunction = x => 1.0f / (1.0f + (float)Math.Exp(-x));
                    break;
                case ActivationFunctionType.BipolarSigmoid:
                    layerFunction = x => (float)Math.Tanh(x);
                    break;
                case ActivationFunctionType.Sinusoid:
                    layerFunction = x => (float)Math.Sin(x);
                    break;
                case ActivationFunctionType.Linear:
                    layerFunction = x => x;
                    break;
                default:
                    layerFunction = x => 0.0f;
                    break;
            }
        }
    }
}
