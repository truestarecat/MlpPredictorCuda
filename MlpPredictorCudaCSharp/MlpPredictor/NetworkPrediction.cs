using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace MlpPredictor
{
    [Serializable]
    public class NetworkPrediction
    {
        private int networkNumInput;
        private int networkNumHidden;
        private int networkNumOutput;
        private ActivationFunctionType networkHiddenFunctionType;
        private ActivationFunctionType networkOutputFunctionType;
        private string predictionDataFilePath;
        private float learningDataPercentage;
        private float maxLearningRms;
        private int maxNumEpoch;
        private float learningRate;
        private float momentum;
        private LearningAlgorithmType learningAlgorithmType;

        private MlpNetwork network;
        private NetworkPredictionData predictionData;
        private INetworkLearning learning;
        private NetworkTesting testing;

        public NetworkPrediction(int networkNumInput,
                                 int networkNumHidden,
                                 int networkNumOutput,
                                 ActivationFunctionType networkHiddenFunctionType,
                                 ActivationFunctionType networkOutputFunctionType,
                                 string predictionDataFilePath,
                                 float learningDataPercentage,
                                 float maxLearningRms,
                                 int maxNumEpoch,
                                 float learningRate,
                                 float momentum,
                                 LearningAlgorithmType learningAlgorithmType)
        {
            NetworkNumInput = networkNumInput;
            NetworkNumHidden = networkNumHidden;
            NetworkNumOutput = networkNumOutput;
            NetworkHiddenFunctionType = networkHiddenFunctionType;
            NetworkOutputFunctionType = networkOutputFunctionType;
            PredictionDataFilePath = predictionDataFilePath;
            LearningDataPercentage = learningDataPercentage;
            MaxLearningRms = maxLearningRms;
            MaxNumEpoch = maxNumEpoch;
            LearningRate = learningRate;
            Momentum = momentum;
            LearningAlgorithmType = learningAlgorithmType;
        }

        public int NetworkNumInput
        {
            get
            {
                return networkNumInput;
            }
            private set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value", "Число входов сети должно быть больше 0.");

                networkNumInput = value;
            }
        }

        public int NetworkNumHidden
        {
            get
            {
                return networkNumHidden;
            }
            private set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value", "Число нейронов в скрытом слое сети должно быть больше 0.");

                networkNumHidden = value;
            }
        }

        public int NetworkNumOutput
        {
            get
            {
                return networkNumOutput;
            }
            private set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value", "Число выходов сети должно быть больше 0.");

                networkNumOutput = value;
            }
        }

        public ActivationFunctionType NetworkHiddenFunctionType
        {
            get
            {
                return networkHiddenFunctionType;
            }
            set
            {
                networkHiddenFunctionType = value;
            }
        }

        public ActivationFunctionType NetworkOutputFunctionType
        {
            get
            {
                return networkOutputFunctionType;
            }
            set
            {
                networkOutputFunctionType = value;
            }
        }

        public string PredictionDataFilePath
        {
            get
            {
                return predictionDataFilePath;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value.Length == 0)
                    throw new ArgumentException("Пустой путь к файлу.", "value");

                predictionDataFilePath = value;
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
                if (value < 1.0f || value > 99.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Процент обучающих данных в выборке должен быть от 1% до 99%.");
                }

                learningDataPercentage = value;
            }
        }

        public float MaxLearningRms
        {
            get
            {
                return maxLearningRms;
            }
            set
            {
                if (value < 0.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Максимальное СКО ошибки обучения должно быть больше 0.");
                }

                maxLearningRms = value;
            }
        }

        public int MaxNumEpoch
        {
            get
            {
                return maxNumEpoch;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Максимальное число эпох обучения должно быть больше 1.");
                }

                maxNumEpoch = value;
            }
        }

        public float LearningRate
        {
            get
            {
                return learningRate;
            }
            set
            {
                if (value < 0.0f || value > 1.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Коэффициент обучения должен лежать в диапазоне [0; 1].");
                }

                learningRate = value;
            }
        }

        public float Momentum
        {
            get
            {
                return momentum;
            }
            set
            {
                if (value < 0.0f || value > 1.0f)
                {
                    throw new ArgumentOutOfRangeException("value", "Момент должен лежать в диапазоне [0; 1].");
                }

                momentum = value;
            }
        }

        public LearningAlgorithmType LearningAlgorithmType
        {
            get
            {
                return learningAlgorithmType;
            }
            set
            {
                learningAlgorithmType = value;
            }
        }

        public int LearningNumEpoch { get; private set; }

        public float[] LearningRms { get; private set; }

        public float[] TestingRms { get; private set; }

        public float[] TestingPredictedOutput { get; private set; }

        public float[] TestingTargetOutput { get; private set; }

        public void CreateNetwork()
        {
            network = new MlpNetwork(NetworkNumInput, NetworkNumHidden, NetworkNumOutput,
                new ActivationFunction(NetworkHiddenFunctionType), new ActivationFunction(NetworkOutputFunctionType));
        }

        public void LoadPredictionData()
        {
            predictionData = new NetworkPredictionData(PredictionDataFilePath, NetworkNumInput, NetworkNumOutput, LearningDataPercentage);
        }

        public void LearnNetwork()
        {
            if (network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (predictionData == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");

            learning = CreateLearning(LearningAlgorithmType);

            learning.LearnNetwork();

            LearningNumEpoch = learning.NumEpoch;
            LearningRms = learning.Rms;
        }

        public void LearnNetwork(IProgress<float> progress, CancellationToken token)
        {
            if (progress == null)
                throw new ArgumentNullException("progress");
            if (token == null)
                throw new ArgumentNullException("token");
            if (network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (predictionData == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");

            learning = CreateLearning(LearningAlgorithmType);

            learning.LearnNetwork(progress, token);

            LearningNumEpoch = learning.NumEpoch;
            LearningRms = learning.Rms;
        }

        public void TestNetwork()
        {
            if (network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (predictionData == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");
            if (learning == null)
                throw new InvalidOperationException("Сеть не обучена.");

            testing = new NetworkTesting(network, predictionData.TestingDataSet);

            testing.TestNetwork();

            TestingRms = testing.Rms;
            TestingPredictedOutput = testing.PredictedOutput;
            TestingTargetOutput = testing.TargetOutput;
        }

        public static NetworkPrediction LoadFromFile(string fileName)
        {
            NetworkPrediction predictionManager = null;
            using (var loader = new FileStream(fileName, FileMode.Open))
            {
                predictionManager = (NetworkPrediction)new BinaryFormatter().Deserialize(loader);
            }

            return predictionManager;
        }

        public static void SaveToFile(string fileName, NetworkPrediction predictionManager)
        {
            using (var saver = new FileStream(fileName, FileMode.Create))
            {
                new BinaryFormatter().Serialize(saver, predictionManager);
            }
        }

        public void SaveToFile(string fileName)
        {
            SaveToFile(fileName, this);
        }

        private INetworkLearning CreateLearning(LearningAlgorithmType learningAlgorithmType)
        {
            switch (learningAlgorithmType)
            {
                case LearningAlgorithmType.BackPropagation:
                    return new CudaBackPropagationLearning(network, predictionData.LearningDataSet, LearningRate, Momentum);
                case LearningAlgorithmType.ResilientBackPropagation:
                    return new CudaResilientPropagationLearning(network, predictionData.LearningDataSet);
                default:
                    throw new ArgumentException("Неизвестный алгоритм обучения.", "learningAlgorithmType");
            }
        }
    }
}
