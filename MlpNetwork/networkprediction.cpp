#include "stdafx.h"
#include "networkprediction.h"

namespace mlp_network
{
	// Подготавливает данные для прогноза, разбивая их на выборки с учётом коэффициента отношения обучающей и тестирующей выборок.
	NetworkPrediction::NetworkPrediction(const vector<double> &rawData, size_t networkInputsCount, size_t networkOutputsCount,
		double divideFactor)
		: fullDataset_((rawData.size() - (networkInputsCount - 1)) / networkOutputsCount, networkInputsCount, networkOutputsCount),
		learningDataset_(fullDataset_.size() * divideFactor, networkInputsCount, networkOutputsCount),
		testingDataset_(fullDataset_.size() - learningDataset_.size(), networkInputsCount, networkOutputsCount)
	{
		sampleData(rawData, networkInputsCount, networkOutputsCount);
		divideSamples(divideFactor);
	}

	// Возвращает полный набор данных.
	const NetworkDataset& NetworkPrediction::fullDataset() const
	{
		return fullDataset_;
	}

	// Возвращает обучающий набор данных.
	const NetworkDataset& NetworkPrediction::learningDataset() const
	{
		return learningDataset_;
	}

	// Возвращает тестирующий набор данных.
	const NetworkDataset& NetworkPrediction::testingDataset() const
	{
		return testingDataset_;
	}

	// Загружает данные из указанного файла.
	vector<double> NetworkPrediction::loadData(const std::string &filename)
	{
		std::ifstream file;
		file.open(filename);
		if (file.is_open())
		{
			vector<double> data;

			while (!file.eof())
			{
				double value;
				file >> value;
				data.push_back(value);
			}

			return data;
		}
		else
		{
			throw std::runtime_error("Error opening file.");
		}
	}

	// Сохраняет данные в указанный файл.
	void NetworkPrediction::saveData(const std::string &filename, const vector<double> &data)
	{
		std::ofstream file;
		file.open(filename);
		if (file.is_open())
		{
			size_t i;
			for (i = 0; i < data.size() - 1; ++i)
			{
				file << data[i] << std::endl;
			}
			file << data[i];
		}
		else
		{
			throw std::runtime_error("Error opening file.");
		}
	}

	// Разбивает данные на входные и выходные.
	void NetworkPrediction::sampleData(const vector<double> &rawData, size_t networkInputsCount, size_t networkOutputsCount)
	{
		matrix<double> inputData = fullDataset_.inputData();
		matrix<double> outputData = fullDataset_.outputData();
		for (size_t i = 0, step = 0; i < fullDataset_.size(); ++i, step += networkOutputsCount)
		{
			inputData[i][0] = 1;
			for (size_t j = 1; j < networkInputsCount; ++j)
			{
				inputData[i][j] = rawData[step + (j - 1)];
			}

			for (size_t k = 0; k < networkOutputsCount; ++k)
			{
				outputData[i][k] = rawData[step + (networkInputsCount - 1) + k];
			}
		}

		fullDataset_.setInputData(inputData);
		fullDataset_.setOutputData(outputData);
	}

	// Разбивает выборки на обучающие и тестирующие.
	void NetworkPrediction::divideSamples(double divideFactor)
	{
		const matrix<double>& inputData = fullDataset_.inputData();
		const matrix<double>& outputData = fullDataset_.outputData();
		matrix<double> learningInputData = learningDataset_.inputData();
		matrix<double> learningOutputData = learningDataset_.outputData();
		matrix<double> testingInputData = testingDataset_.inputData();
		matrix<double> testingOutputData = testingDataset_.outputData();

		size_t learningSize = learningDataset_.size();
		for (size_t i = 0; i < fullDataset_.size(); ++i)
		{
			if (i < learningSize)
			{
				learningInputData[i] = inputData[i];
				learningOutputData[i] = outputData[i];
			}
			else
			{
				testingInputData[i - learningSize] = inputData[i];
				testingOutputData[i - learningSize] = outputData[i];
			}
		}

		learningDataset_.setInputData(learningInputData);
		learningDataset_.setOutputData(learningOutputData);
		testingDataset_.setInputData(testingInputData);
		testingDataset_.setOutputData(testingOutputData);
	}
}
