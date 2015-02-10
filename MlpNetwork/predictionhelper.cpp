#include "stdafx.h"
#include "predictionhelper.h"

namespace mlp_network
{
	PredictionHelper::PredictionHelper()
	{
	}

	// Возвращает выборку входных данных.
	matrix<double> PredictionHelper::inputData() const
	{
		return inputData_;
	}

	// Возвращает выборку выходных данных.
	matrix<double> PredictionHelper::outputData() const
	{
		return outputData_;
	}

	// Возвращает обучающую выборку входных данных.
	matrix<double> PredictionHelper::learningInputData() const
	{
		return learningInputData_;
	}

	// Возвращает обучающую выборку выходных данных.
	matrix<double> PredictionHelper::learningOutputData() const
	{
		return learningOutputData_;
	}

	// Возвращает тестирующую выборку входных данных.
	matrix<double> PredictionHelper::testingInputData() const
	{
		return testingInputData_;
	}

	// Возвращает тестирующую выборку выходных данных.
	matrix<double> PredictionHelper::testingOutputData() const
	{
		return testingOutputData_;
	}

	// Загружает выборку данных из указанного файла.
	vector<double> PredictionHelper::loadData(const string &filename) const
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

	// Сохраняет выборку данных в указанный файл.
	void PredictionHelper::saveData(const string &filename, const vector<double> &data) const
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

	// Подготавливает данные для прогноза, разбивая их на выборки с учётом коэффициента отношения обучающей и тестирующей выборок.
	void PredictionHelper::prepareData(const vector<double> &rawData, size_t networkInputsCount, size_t networkOutputsCount,
		double divideFactor)
	{
		sampleData(rawData, networkInputsCount, networkOutputsCount);
		divideSamples(divideFactor);
	}

	//// Разбивает данные на входные и выходные.
	//void PredictionHelper::sampleData(const vector<double> &rawData, uint networkInputsCount, uint networkOutputsCount)
	//{
	//	const uint resultSize = (rawData.size() - networkInputsCount) / networkOutputsCount;

	//	inputData_.resize(resultSize);
	//	outputData_.resize(resultSize);

	//	for (uint i = 0, step = 0; i < resultSize; ++i, step += networkOutputsCount)
	//	{
	//		inputData_[i].resize(networkInputsCount);
	//		outputData_[i].resize(networkOutputsCount);

	//		for (uint j = 0; j < networkInputsCount; ++j)
	//		{
	//			inputData_[i][j] = rawData[step + j];
	//		}

	//		for (uint k = 0; k < networkOutputsCount; ++k)
	//		{
	//			outputData_[i][k] = rawData[step + networkInputsCount + k];
	//		}
	//	}
	//}
	// Разбивает данные на входные и выходные.
	void PredictionHelper::sampleData(const vector<double> &rawData, size_t networkInputsCount, size_t networkOutputsCount)
	{
		const size_t resultSize = (rawData.size() - networkInputsCount) / networkOutputsCount;

		inputData_.resize(resultSize);
		outputData_.resize(resultSize);

		for (size_t i = 0, step = 0; i < resultSize; ++i, step += networkOutputsCount)
		{
			inputData_[i].resize(networkInputsCount + 1);
			outputData_[i].resize(networkOutputsCount);

			inputData_[i][0] = 1;
			for (size_t j = 1; j < networkInputsCount + 1; ++j)
			{
				inputData_[i][j] = rawData[step + (j - 1)];
			}

			for (size_t k = 0; k < networkOutputsCount; ++k)
			{
				outputData_[i][k] = rawData[step + networkInputsCount + k];
			}
		}
	}

	// Разбивает выборки на обучающие и тестирующие.
	void PredictionHelper::divideSamples(double divideFactor)
	{
		const size_t learningSize = inputData_.size() * divideFactor;
		const size_t testingSize = inputData_.size() - learningSize;

		learningInputData_.resize(learningSize);
		learningOutputData_.resize(learningSize);
		testingInputData_.resize(testingSize);
		testingOutputData_.resize(testingSize);

		for (size_t i = 0; i < inputData_.size(); ++i)
		{
			if (i < learningSize)
			{
				learningInputData_[i] = inputData_[i];
				learningOutputData_[i] = outputData_[i];
			}
			else
			{
				testingInputData_[i - learningSize] = inputData_[i];
				testingOutputData_[i - learningSize] = outputData_[i];
			}
		}
	}
}
