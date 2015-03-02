#ifndef NETWORK_PREDICTION_H
#define NETWORK_PREDICTION_H

#include "networkdataset.h"

namespace mlp_network
{
	class NetworkPrediction
	{
	public:
		NetworkPrediction(const vector<float> &rawData, int networkInputsCount, int networkOutputsCount, float divideFactor = 0.7f);

		const NetworkDataset& fullDataset() const
		{
			return fullDataset_;
		}

		const NetworkDataset& learningDataset() const
		{
			return learningDataset_;
		}

		const NetworkDataset& testingDataset() const
		{
			return testingDataset_;
		}

		static vector<float> loadData(const std::string &filename);

		static void saveData(const std::string &filename, const vector<float> &data);

	private:
		void sampleData(const vector<float> &rawData, int networkInputsCount, int networkOutputsCount);

		void divideSamples(float divideFactor);

		NetworkDataset fullDataset_;
		NetworkDataset learningDataset_;
		NetworkDataset testingDataset_;
	};
}

#endif // NETWORK_PREDICTION_H

