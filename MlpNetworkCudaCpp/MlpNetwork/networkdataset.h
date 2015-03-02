#ifndef NETWORK_DATASET_H
#define NETWORK_DATASET_H

#include "stdafx.h"

namespace mlp_network
{
	class NetworkDataset
	{
	public:
		NetworkDataset(int numInput, int numOutput, int numSamples);
		NetworkDataset(const matrix<float> &inputData, const matrix<float> &outputData);

		int numInput() const
		{
			return numInput_;
		}

		int numOutput() const
		{
			return numOutput_;
		}

		int numSamples() const
		{
			return numSamples_;
		}

		const matrix<float>& inputData() const
		{
			return inputData_;
		}

		const matrix<float>& outputData() const
		{
			return outputData_;
		}

		void setInputData(const matrix<float> &inputData)
		{
			if (inputData.size() != numSamples_ || inputData[0].size() != numInput_)
				throw std::runtime_error("Bad number of inputData");

			inputData_ = inputData;
		}

		void setOutputData(const matrix<float> &outputData)
		{
			if (outputData.size() != numSamples_ || outputData[0].size() != numOutput_)
				throw std::runtime_error("Bad number of outputData");

			outputData_ = outputData;
		}

	private:
		int numInput_;
		int numOutput_;
		int numSamples_;
		matrix<float> inputData_;
		matrix<float> outputData_;
	};
}

#endif // NETWORK_DATASET_H

