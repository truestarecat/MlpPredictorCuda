#include "stdafx.h"
#include "mlpnetwork.h"
#include "matrixhelper.h"

namespace mlp_network
{
	MlpNetwork::MlpNetwork(int numInput, int numHidden, int numOutput,
		ActivationFuncType hiddenFuncType, ActivationFuncType outputFuncType)
		: numInput_(numInput), numHidden_(numHidden), numOutput_(numOutput),
		hiddenFuncType_(hiddenFuncType), outputFuncType_(outputFuncType),
		inputs_(numInput),
		inputHiddenWeights_(MatrixHelper::createVectorMatrix<float>(numInput + 1, numHidden)),
		hiddenOutputs_(numHidden),
		hiddenOutputWeights_(MatrixHelper::createVectorMatrix<float>(numHidden + 1, numOutput)),
		outputs_(numOutput)
	{
		setLayerFunction(hiddenFunc_, hiddenFuncType);
		setLayerFunction(outputFunc_, outputFuncType);
	}

	void MlpNetwork::computeLayerOutput(const matrix<float> &layerWeights, const vector<float> &layerInputs,
		vector<float> &layerOutputs, int numLayerInput, int numLayerOutput)
	{
		for (int j = 0; j < numLayerOutput; j++)
		{
			float sum = layerWeights[0][j] * 1.0f;
			for (int i = 0; i < numLayerInput; i++)
			{
				sum += layerWeights[i + 1][j] * layerInputs[i];
			}

			layerOutputs[j] = unipolarSigmoidFunction(sum);
		}
	}

	matrix<float> MlpNetwork::computeOutput(const matrix<float> &inputData)
	{
		matrix<float> result = MatrixHelper::createVectorMatrix<float>(inputData.size(), inputData[0].size());
		for (size_t i = 0; i < result.size(); ++i)
		{
			result[i] = computeOutput(inputData[i]);
		}

		return result;
	}

	void MlpNetwork::setLayerFunction(std::function<float(float)> &layerFunc, ActivationFuncType type)
	{
		switch (type)
		{
		case ActivationFuncType::UNIPOLAR_SIGMOID:
			layerFunc = [](float x) { return 1.0f / (1.0f + expf(-x)); };
			break;
		case ActivationFuncType::BIPOLAR_SIGMOID:
			layerFunc = [](float x) { return tanhf(x); };
			break;
		case ActivationFuncType::SINUSOID:
			layerFunc = [](float x) { return sinf(x); };
			break;
		case ActivationFuncType::LINEAR:
			layerFunc = [](float x) { return x; };
			break;
		default:
			layerFunc = [](float x) { return 0.0f; };
			break;
		}
	}
}
