#ifndef PREDICTION_HELPER_H
#define PREDICTION_HELPER_H

namespace mlp_network
{
	class PredictionHelper
	{
	public:
		PredictionHelper();

		matrix<double> inputData() const;
		matrix<double> outputData() const;
		matrix<double> learningInputData() const;
		matrix<double> learningOutputData() const;
		matrix<double> testingInputData() const;
		matrix<double> testingOutputData() const;

		vector<double> loadData(const string &filename) const;
		void saveData(const string &filename, const vector<double> &data) const;
		void prepareData(const vector<double> &rawData, size_t networkInputsCount, size_t networkOutputsCount,
			double divideFactor);
	private:
		void sampleData(const vector<double> &rawData, size_t networkInputsCount, size_t networkOutputsCount);
		void divideSamples(double divideFactor);

		matrix<double> inputData_;
		matrix<double> outputData_;
		matrix<double> learningInputData_;
		matrix<double> learningOutputData_;
		matrix<double> testingInputData_;
		matrix<double> testingOutputData_;
	};
}

#endif // PREDICTION_HELPER_H

