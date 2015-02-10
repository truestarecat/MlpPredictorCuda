#ifndef PROPAGATION_H
#define PROPAGATION_H

#include "inetworktraining.h"
#include "mlpnetwork.h"
#include "networkdataset.h"

namespace mlp_network
{
	class Propagation : public INetworkTraining
	{
	public:
		Propagation(MlpNetwork &network, const NetworkDataset &dataset);
		virtual ~Propagation();

		double error() const override;
		size_t numEpoch() const override;

		void doIteration() override;
		vector<double> train(size_t maxNumEpoch = 10000, double maxError = 0.01) override;

	protected:
		void reinitGradients();
		void randomizeWeights();
		double errorOnline();
		double errorOffline();
		void computeOutputGradients();
		void computeHiddenGradients();
		virtual void updateInputHiddenWeights() = 0;
		virtual void updateHiddenOutputWeights() = 0;

		MlpNetwork &network_;
		NetworkDataset dataset_;

		size_t numInput_;
		size_t numHidden_;
		size_t numOutput_;

		vector<double> idealOutputs_;

		vector<double> outputDeltas_;
		matrix<double> outputGradients_;
		vector<double> hiddenDeltas_;
		matrix<double> hiddenGradients_;

		matrix<double> previousHiddenGradients_;
		matrix<double> previousOutputGradients_;

		double error_;
		size_t numEpoch_;
	};
}

#endif // PROPAGATION_H

