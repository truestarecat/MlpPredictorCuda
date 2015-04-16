using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace MlpPredictor
{
    [Serializable]
    public class NetworkPrediction
    {
        public NetworkPrediction()
        {
        }

        public MlpNetwork Network { get; private set; }

        public NetworkPredictionData PredictionData { get; private set; }

        public INetworkLearning Learning { get; private set; }

        public NetworkTesting Testing { get; private set; }

        public void CreateNetwork(int networkNumInput,
                                  int networkNumHidden,
                                  int networkNumOutput,
                                  ActivationFunctionType networkHiddenFunctionType,
                                  ActivationFunctionType networkOutputFunctionType)
        {
            Network = new MlpNetwork(networkNumInput, networkNumHidden, networkNumOutput,
                new ActivationFunction(networkHiddenFunctionType), new ActivationFunction(networkOutputFunctionType));
        }

        public void LoadPredictionData(string filePath, int inputWindowSize, int outputWindowSize, float learningDataPercentage)
        {
            PredictionData = new NetworkPredictionData(filePath, inputWindowSize, outputWindowSize, learningDataPercentage);
        }

        public void LearnNetwork(float maxLearningRms,
                                 int maxNumEpoch,
                                 float learningRate,
                                 float momentum,
                                 LearningAlgorithmType learningAlgorithmType)
        {
            if (Network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (PredictionData == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");

            Learning = CreateLearning(learningAlgorithmType, maxLearningRms, maxNumEpoch, learningRate, momentum);

            Learning.Start();
        }

        public void LearnNetwork(IProgress<float> progress, CancellationToken token,
                                 float maxLearningRms,
                                 int maxNumEpoch,
                                 float learningRate,
                                 float momentum,
                                 LearningAlgorithmType learningAlgorithmType)
        {
            if (progress == null)
                throw new ArgumentNullException("progress");
            if (token == null)
                throw new ArgumentNullException("token");
            if (Network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (PredictionData == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");

            Learning = CreateLearning(learningAlgorithmType, maxLearningRms, maxNumEpoch, learningRate, momentum);

            Learning.Start(progress, token);
        }

        public void TestNetwork()
        {
            if (Network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (PredictionData == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");
            if (Learning == null)
                throw new InvalidOperationException("Сеть не обучена.");

            Testing = new NetworkTesting(Network, PredictionData.TestingDataSet);

            Testing.TestNetwork();
        }

        public static NetworkPrediction LoadFromBinaryFile(string fileName)
        {
            NetworkPrediction predictionManager = null;
            using (var loader = new FileStream(fileName, FileMode.Open))
            {
                predictionManager = (NetworkPrediction)new BinaryFormatter().Deserialize(loader);
            }

            return predictionManager;
        }

        public static void SaveToBinaryFile(string fileName, NetworkPrediction predictionManager)
        {
            using (var saver = new FileStream(fileName, FileMode.Create))
            {
                new BinaryFormatter().Serialize(saver, predictionManager);
            }
        }

        public void SaveToBinaryFile(string fileName)
        {
            SaveToBinaryFile(fileName, this);
        }

        private INetworkLearning CreateLearning(LearningAlgorithmType learningAlgorithmType,
            float maxLearningRms, int maxNumEpoch, float learningRate, float momentum)
        {
            switch (learningAlgorithmType)
            {
                case LearningAlgorithmType.BackPropagation:
                    return new CudaBackPropagationLearning(Network, PredictionData.LearningDataSet,
                        maxLearningRms, maxNumEpoch, learningRate, momentum);
                case LearningAlgorithmType.ResilientBackPropagation:
                    return new CudaResilientPropagationLearning(Network, PredictionData.LearningDataSet,
                        maxLearningRms, maxNumEpoch);
                default:
                    throw new ArgumentException("Неизвестный алгоритм обучения.", "learningAlgorithmType");
            }
        }
    }
}
