#ifndef RPROP_TRAINING_H
#define RPROP_TRAINING_H

#include "propagation.h"
#include "mlpnetwork.h"
#include "networkdataset.h"

namespace mlp_network
{
	class ResilientPropagation : public Propagation
	{
	public:
		ResilientPropagation(MlpNetwork &network, const NetworkDataset &dataset);
		~ResilientPropagation();

	private:
		void reset();
		void reinitParams();
		void randomizeParams();
		void randomizeLearningRates();
		void updateInputHiddenWeights() override;
		void updateHiddenOutputWeights() override;
		int sign(double x);

		static const double A;
		static const double B;
		static const double MIN_LEARNING_RATE;
		static const double MAX_LEARNING_RATE;

		matrix<double> inputHiddenLearningRates_;
		matrix<double> hiddenOutputLearningRates_;
	};
}

#endif // RPROP_TRAINING_H

