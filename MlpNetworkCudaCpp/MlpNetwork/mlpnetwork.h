#ifndef MLP_NETWORK_H
#define MLP_NETWORK_H

#include "stdafx.h"
#include "cudaerrorpropagation.h"

namespace mlp_network
{
	class MlpNetwork
	{
	public:
		MlpNetwork(int numInput, int numHidden, int numOutput,
			ActivationFuncType hiddenFuncType = ActivationFuncType::UNIPOLAR_SIGMOID,
			ActivationFuncType outputFuncType = ActivationFuncType::UNIPOLAR_SIGMOID);

		int numInput() const
		{
			return numInput_;
		}

		int numHidden() const
		{
			return numHidden_;
		}

		int numOutput() const
		{
			return numOutput_;
		}

		ActivationFuncType hiddenFuncType() const
		{
			return hiddenFuncType_;
		}

		ActivationFuncType outputFuncType() const
		{
			return outputFuncType_;
		}

		const vector<float>& inputs() const
		{
			return inputs_;
		}

		const matrix<float>& inputHiddenWeights() const
		{
			return inputHiddenWeights_;
		}

		const vector<float>& hiddenOutputs() const
		{
			return hiddenOutputs_;
		}

		const matrix<float>& hiddenOutputWeights() const
		{
			return hiddenOutputWeights_;
		}

		const vector<float>& outputs() const
		{
			return outputs_;
		}

		void setHiddenFunction(ActivationFuncType type)
		{
			setLayerFunction(hiddenFunc_, type);
		}

		void setOutputFunction(ActivationFuncType type)
		{
			setLayerFunction(outputFunc_, type);
		}

		void setInputs(const vector<float> &inputs)
		{
			if (inputs.size() != numInput_)
				throw std::runtime_error("Bad number of inputs");

			inputs_ = inputs;
		}

		void setInputHiddenWeights(const matrix<float> &inputHiddenWeights)
		{
			if (inputHiddenWeights.size() != (numInput_ + 1) || inputHiddenWeights[0].size() != numHidden_)
				throw std::runtime_error("Bad number of weights");

			inputHiddenWeights_ = inputHiddenWeights;
		}

		void setHiddenOutputWeights(const matrix<float> &hiddenOutputWeights)
		{
			if (hiddenOutputWeights.size() != (numHidden_ + 1) || hiddenOutputWeights[0].size() != numOutput_)
				throw std::runtime_error("Bad number of weights");

			hiddenOutputWeights_ = hiddenOutputWeights;
		}

		void computeOutput()
		{
			computeLayerOutput(inputHiddenWeights_, inputs_, hiddenOutputs_, numInput_, numHidden_);
			computeLayerOutput(hiddenOutputWeights_, hiddenOutputs_, outputs_, numHidden_, numOutput_);
		}

		const vector<float>& computeOutput(const vector<float> &inputs)
		{
			setInputs(inputs);

			computeOutput();

			return outputs_;
		}

		matrix<float> computeOutput(const matrix<float> &inputData);

	private:
		void setLayerFunction(std::function<float(float)> &layerFunc, ActivationFuncType type);

		static void computeLayerOutput(const matrix<float> &layerWeights, const vector<float> &layerInputs,
			vector<float> &layerOutputs, int numLayerInput, int numLayerOutput);

		static float unipolarSigmoidFunction(float x)
		{
			return 1.0f / (1.0f + (float) expf(-x));
		}

		int numInput_;
		int numHidden_;
		int numOutput_;
		ActivationFuncType hiddenFuncType_;
		ActivationFuncType outputFuncType_;
		std::function<float(float)> hiddenFunc_;
		std::function<float(float)> outputFunc_;

		vector<float> inputs_;
		matrix<float> inputHiddenWeights_;
		vector<float> hiddenOutputs_;
		matrix<float> hiddenOutputWeights_;
		vector<float> outputs_;
	};
}

#endif // MLP_NETWORK_H

