#ifndef NETWORK_PREDICTION_H
#define NETWORK_PREDICTION_H

#include "networkdataset.h"

namespace mlp_network
{
	class NetworkPrediction
	{
	public:
		NetworkPrediction(const vector<double> &rawData, size_t networkInputsCount, size_t networkOutputsCount,
			double divideFactor = 0.7);

		const NetworkDataset& fullDataset() const;
		const NetworkDataset& learningDataset() const;
		const NetworkDataset& testingDataset() const;

		static vector<double> loadData(const std::string &filename);
		static void saveData(const std::string &filename, const vector<double> &data);

	private:
		void sampleData(const vector<double> &rawData, size_t networkInputsCount, size_t networkOutputsCount);
		void divideSamples(double divideFactor);

		NetworkDataset fullDataset_;
		NetworkDataset learningDataset_;
		NetworkDataset testingDataset_;
	};
}

#endif // NETWORK_PREDICTION_H

