using System;
using System.Threading;

namespace MlpPredictor
{
    public interface INetworkLearning
    {
        float MaxRms { get; set; }

        int MaxNumEpoch { get; set; }

        int NumEpoch { get; }

        float[] Rms { get; }

        void Start();

        void Start(IProgress<float> progress, CancellationToken token);
    }
}
