#include "stdafx.h"
#include "cudapropagation.h"
#include "matrixhelper.h"

namespace mlp_network
{
	CudaPropagation::CudaPropagation(MlpNetwork &network, const NetworkDataset &dataset)
		: network_(network), dataset_(dataset), propagation_(nullptr)
	{
		float *inputDataFlatten = MatrixHelper::convertMatrixToArray<float>(dataset.inputData());
		float *outputDataFlatten = MatrixHelper::convertMatrixToArray<float>(dataset.outputData());
		float *inputHiddenWeightsFlatten = MatrixHelper::convertMatrixToArray<float>(network.inputHiddenWeights());
		float *hiddenOutputWeightsFlatten = MatrixHelper::convertMatrixToArray<float>(network.hiddenOutputWeights());
		int numInput = network.numInput();
		int numHidden = network.numHidden();
		int numOutput = network.numOutput();
		int numSamples = dataset.numSamples();

		propagation_ = ::createErrorPropagation(inputDataFlatten, outputDataFlatten,
			inputHiddenWeightsFlatten, hiddenOutputWeightsFlatten, numInput, numHidden, numOutput, numSamples,
			network.hiddenFuncType(), network.outputFuncType());

		delete [] inputDataFlatten;
		delete [] outputDataFlatten;
		delete [] inputHiddenWeightsFlatten;
		delete [] hiddenOutputWeightsFlatten;
	}

	void CudaPropagation::updateNetworkWeights()
	{
		const float *ihWeightsFlatten = ::getInputHiddenWeights(propagation_);
		const float *hoWeightsFlatten = ::getHiddenOutputWeights(propagation_);

		int ihWeightsX = network_.numInput() + 1;
		int ihWeightsY = network_.numHidden();
		int hoWeightsX = network_.numHidden() + 1;
		int hoWeightsY = network_.numOutput();

		matrix<float> ihWeights = MatrixHelper::convertArrayToMatrix(ihWeightsFlatten, ihWeightsX, ihWeightsY);
		matrix<float> hoWeights = MatrixHelper::convertArrayToMatrix(hoWeightsFlatten, hoWeightsX, hoWeightsY);

		network_.setInputHiddenWeights(ihWeights);
		network_.setHiddenOutputWeights(hoWeights);
	}
}