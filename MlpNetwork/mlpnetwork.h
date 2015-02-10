#ifndef MLP_NETWORK_H
#define MLP_NETWORK_H

#include "activationfunction.h"

namespace mlp_network
{
	class MlpNetwork
	{
	public:
		MlpNetwork(size_t numInput, size_t numHidden, size_t numOutput,
			const ActivationFunction &hiddenFunction = ActivationFunction(ActivationFunction::Type::UNIPOLAR_SIGMOID),
			const ActivationFunction &outputFunction = ActivationFunction(ActivationFunction::Type::UNIPOLAR_SIGMOID));

		size_t numInput() const;
		size_t numHidden() const;
		size_t numOutput() const;

		const ActivationFunction& hiddenFunction() const;
		void setHiddenFunction(const ActivationFunction &hiddenFunction);

		const ActivationFunction& outputFunction() const;
		void setOutputFunction(const ActivationFunction &outputFunction);

		const vector<double>& inputs() const;
		void setInputs(const vector<double> &inputs);

		const matrix<double>& inputHiddenWeights() const;
		void setInputHiddenWeights(const matrix<double> &inputHiddenWeights);

		const vector<double>& hiddenOutputs() const;

		const matrix<double>& hiddenOutputWeights() const;
		void setHiddenOutputWeights(const matrix<double> &hiddenOutputWeights);

		const vector<double>& outputs() const;

		void computeOutputs();
		const vector<double>& computeOutputs(const vector<double> &inputs);
		matrix<double> computeOutputs(const matrix<double> &inputData);

	private:
		void computeHiddenSignal();
		void computeOutputSignal();

		size_t numInput_;
		size_t numHidden_;
		size_t numOutput_;
		ActivationFunction hiddenFunction_;
		ActivationFunction outputFunction_;

		vector<double> inputs_;
		matrix<double> inputHiddenWeights_;
		vector<double> hiddenOutputs_;
		matrix<double> hiddenOutputWeights_;
		vector<double> outputs_;
	};
}

#endif // MLP_NETWORK_H
