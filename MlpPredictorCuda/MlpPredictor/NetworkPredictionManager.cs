using System;
using System.Threading;

namespace MlpPredictor
{
    public class NetworkPredictionManager
    {
        public NetworkPredictionManager()
        {
            StartNewPrediction();
        }

        public NetworkPrediction Prediction { get; private set; }

        public void StartNewPrediction()
        {
            Prediction = new NetworkPrediction();
        }

        public void CreateNetwork(int numInput, int numHidden, int numOutput,
            ActivationFunctionType hiddenFunctionType, ActivationFunctionType outputFunctionType)
        {
            Prediction.Network = new MlpNetwork(numInput, numHidden, numOutput,
                new ActivationFunction(hiddenFunctionType), new ActivationFunction(outputFunctionType));
        }

        public void LoadPredictionData(string predictionDataFilePath)
        {
            Prediction.Data = new NetworkPredictionData(predictionDataFilePath);
        }

        public void LearnNetwork(float learningDataPercentage, LearningAlgorithmType algorithmType,
            float maxLearningRms, int maxNumEpoch, float learningRate, float momentum)
        {
            if (Prediction.Network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (Prediction.Data == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");

            if (NeedDataResampling())
            {
                Prediction.Data.ResampleAll(Prediction.Network.NumInput, Prediction.Network.NumOutput, learningDataPercentage);
            }
            else if (NeedDataRedividing(learningDataPercentage))
            {
                Prediction.Data.RedivideSamples(learningDataPercentage);
            }

            Prediction.Learning = CreateNetworkLearning(algorithmType, maxLearningRms, maxNumEpoch, learningRate, momentum);
            Prediction.Learning.Start();
        }

        public void LearnNetwork(IProgress<float> progress, CancellationToken token, float learningDataPercentage,
            LearningAlgorithmType algorithmType, float maxLearningRms, int maxNumEpoch, float learningRate, float momentum)
        {
            if (progress == null)
                throw new ArgumentNullException("progress");
            if (token == null)
                throw new ArgumentNullException("token");
            if (Prediction.Network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (Prediction.Data == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");

            if (NeedDataResampling())
            {
                Prediction.Data.ResampleAll(Prediction.Network.NumInput, Prediction.Network.NumOutput, learningDataPercentage);
            }
            else if (NeedDataRedividing(learningDataPercentage))
            {
                Prediction.Data.RedivideSamples(learningDataPercentage);
            }

            Prediction.Learning = CreateNetworkLearning(algorithmType, maxLearningRms, maxNumEpoch, learningRate, momentum);
            Prediction.Learning.Start(progress, token);
        }

        public void TestNetwork(float testingDataPercentage)
        {
            if (Prediction.Network == null)
                throw new InvalidOperationException("Сеть не создана.");
            if (Prediction.Data == null)
                throw new InvalidOperationException("Данные для прогноза не загружены.");
            if (Prediction.Learning == null)
                throw new InvalidOperationException("Сеть не обучена.");

            float learningDataPercentage = 100.0f - testingDataPercentage;
            if (NeedDataResampling())
            {
                Prediction.Data.ResampleAll(Prediction.Network.NumInput, Prediction.Network.NumOutput, learningDataPercentage);
            }
            else if (NeedDataRedividing(learningDataPercentage))
            {
                Prediction.Data.RedivideSamples(learningDataPercentage);
            }

            //prediction.Testing = new NetworkTesting(Network, PredictionData.TestingDataSet);
            Prediction.Testing = new NetworkTesting(Prediction.Network, Prediction.Data.FullDataSet);
            Prediction.Testing.Start();
        }

        public void LoadPredictionFromBinaryFile(string filePath)
        {
            Prediction = NetworkPrediction.LoadFromBinaryFile(filePath);
        }

        public void SavePredictionToBinaryFile(string filePath)
        {
            Prediction.SaveToBinaryFile(filePath);
        }

        private INetworkLearning CreateNetworkLearning(LearningAlgorithmType algorithmType, float maxLearningRms, int maxNumEpoch,
            float learningRate, float momentum)
        {
            switch (algorithmType)
            {
                case LearningAlgorithmType.BackPropagation:
                    return new CudaBackPropagationLearning(Prediction.Network, Prediction.Data.LearningDataSet,
                        maxLearningRms, maxNumEpoch, learningRate, momentum);
                case LearningAlgorithmType.ResilientBackPropagation:
                    return new CudaResilientPropagationLearning(Prediction.Network, Prediction.Data.LearningDataSet,
                        maxLearningRms, maxNumEpoch);
                default:
                    throw new ArgumentException("Неизвестный алгоритм обучения.", "learningAlgorithmType");
            }
        }

        private bool NeedDataResampling()
        {
            if (Prediction.Network.NumInput != Prediction.Data.InputWindowSize ||
                Prediction.Network.NumOutput != Prediction.Data.OutputWindowSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool NeedDataRedividing(float learningDataPercentage)
        {
            if (Prediction.Data.LearningDataPercentage != learningDataPercentage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
