using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MlpPredictor
{
    [Serializable]
    public class NetworkPrediction
    {
        public MlpNetwork Network { get; set; }

        public NetworkPredictionData PredictionData { get; set; }

        public INetworkLearning Learning { get; set; }

        public NetworkTesting Testing { get; set; }

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
    }
}
