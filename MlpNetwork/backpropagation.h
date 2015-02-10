#ifndef BACK_PROPAGATION_H
#define BACK_PROPAGATION_H

#include "inetworktraining.h"
#include "propagation.h"

namespace mlp_network
{
	class BackPropagation : public Propagation
	{
	public:
		BackPropagation(MlpNetwork &network, const NetworkDataset &dataset, double learningRate, double momentum);
		~BackPropagation();

	private:
		void reset();
		void reinitParams();
		void reinitDeltas();
		void updateInputHiddenWeights() override;
		void updateHiddenOutputWeights() override;

	private:
		double learningRate_;
		double momentum_;

		matrix<double> previousInputHiddenWeightDeltas_;
		matrix<double> previousHiddenOutputWeightDeltas_;
	};
}

#endif // BACK_PROPAGATION_H

