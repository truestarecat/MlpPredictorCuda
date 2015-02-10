#ifndef NETWORK_DATASET_H
#define NETWORK_DATASET_H

namespace mlp_network
{
	class NetworkDataset
	{
	public:
		NetworkDataset();
		NetworkDataset(const matrix<double> &inputData, const matrix<double> &outputData);
		NetworkDataset(size_t size, size_t inputSize, size_t outputSize);

		size_t size() const;

		const matrix<double>& inputData() const;
		void setInputData(const matrix<double> &inputData);

		const matrix<double>& outputData() const;
		void setOutputData(const matrix<double> &outputData);

	private:
		size_t size_;
		size_t inputSize_;
		size_t outputSize_;

		matrix<double> inputData_;
		matrix<double> outputData_;
	};
}

#endif // NETWORK_DATASET_H

