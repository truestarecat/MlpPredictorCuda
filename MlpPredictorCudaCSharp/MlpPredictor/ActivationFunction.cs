using System;

namespace MlpPredictor
{
    public enum ActivationFunctionType
    {
        UnipolarSigmoid = 0,
        BipolarSigmoid = 1,
        Sinusoid = 2,
        Linear = 3
    }

    [Serializable]
    public class ActivationFunction
    {
        private Func<float, float> function;
        private Func<float, float> derivative;

        public ActivationFunction(ActivationFunctionType type)
        {
            switch (type)
            {
                case ActivationFunctionType.UnipolarSigmoid:
                    function = x => 1.0f / (1.0f + (float)Math.Exp(-x));
                    derivative = fX => fX * (1.0f - fX);
                    break;
                case ActivationFunctionType.BipolarSigmoid:
                    function = x => (float)Math.Tanh(x);
                    derivative = fX => 1.0f - fX * fX;
                    break;
                case ActivationFunctionType.Sinusoid:
                    function = x => (float)Math.Sin(x);
                    derivative = fX => (float)Math.Sqrt(1.0f - fX * fX);
                    break;
                case ActivationFunctionType.Linear:
                    function = x => x;
                    derivative = fX => 1.0f;
                    break;
                default:
                    throw new ArgumentException("Неизвестная функция активации.", "type");
            }

            Type = type;
        }

        public ActivationFunctionType Type { get; private set; }

        public float Value(float argument)
        {
            return function(argument);
        }

        public float Derivative(float functionValue)
        {
            return derivative(functionValue);
        }
    }
}
