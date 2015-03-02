#include "stdafx.h"
#include "networkdataset.h"
#include "matrixhelper.h"

namespace mlp_network
{
	NetworkDataset::NetworkDataset(int numInput, int numOutput, int numSamples)
		: numInput_(numInput), numOutput_(numOutput), numSamples_(numSamples),
		inputData_(MatrixHelper::createVectorMatrix<float>(numSamples, numInput)),
		outputData_(MatrixHelper::createVectorMatrix<float>(numSamples, numOutput))
	{
	}

	NetworkDataset::NetworkDataset(const matrix<float> &inputData, const matrix<float> &outputData)
		: NetworkDataset(inputData[0].size(), outputData[0].size(), inputData.size())
	{
		setInputData(inputData);
		setOutputData(outputData);		
	}
}
