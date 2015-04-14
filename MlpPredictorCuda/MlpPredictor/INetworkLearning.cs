using System;
using System.Threading;

namespace MlpPredictor
{
    public interface INetworkLearning : IDisposable
    {
        float MaxLearningRms { get; set; }

        int MaxNumEpoch { get; set; }

        int NumEpoch { get; }

        float[] Rms { get; }

        void LearnNetwork();

        void LearnNetwork(IProgress<float> progress, CancellationToken token);
    }
}
