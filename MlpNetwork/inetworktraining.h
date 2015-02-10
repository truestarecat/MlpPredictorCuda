#ifndef INETWORK_TRAINING_H
#define INETWORK_TRAINING_H

namespace mlp_network
{
	class INetworkTraining
	{
	public:
		virtual double error() const = 0;
		virtual size_t numEpoch() const = 0;
		virtual void doIteration() = 0;
		virtual vector<double> train(size_t maxNumEpoch = 10000, double maxError = 0.01) = 0;
		virtual ~INetworkTraining() = 0 {};
	};
}

#endif // INETWORK_TRAINING_H