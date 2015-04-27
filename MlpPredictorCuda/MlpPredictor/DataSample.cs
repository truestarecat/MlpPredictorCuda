using System;

namespace MlpPredictor
{
    [Serializable]
    public class DataSample
    {
        private float[] inputs;
        private float[] outputs;

        public DataSample(float[] inputs, float[] outputs)
        {
            Inputs = inputs;
            Outputs = outputs;
        }

        public int NumInput
        {
            get
            {
                return inputs.Length;
            }
        }

        public int NumOutput
        {
            get
            {
                return outputs.Length;
            }
        }

        public float[] Inputs
        {
            get
            {
                return inputs;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value.Length == 0)
                    throw new ArgumentException("Число входов выборки должно быть больше 0.", "value.Length");

                inputs = value;
            }
        }

        public float[] Outputs
        {
            get
            {
                return outputs;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value.Length == 0)
                    throw new ArgumentException("Число выходов выборки должно быть больше 0.", "value.Length");

                outputs = value;
            }
        }
    }
}
