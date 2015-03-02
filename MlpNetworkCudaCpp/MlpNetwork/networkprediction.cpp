#include "stdafx.h"
#include "networkprediction.h"
#include "matrixhelper.h"

namespace mlp_network
{
	// Подготавливает данные для прогноза, разбивая их на выборки с учётом коэффициента отношения обучающей и тестирующей выборок.
	NetworkPrediction::NetworkPrediction(const vector<float> &rawData, int networkInputsCount, int networkOutputsCount,
		float divideFactor)
		//: fullDataset_((rawData.size() - (networkInputsCount - 1)) / networkOutputsCount, networkInputsCount, networkOutputsCount),
		: fullDataset_(networkInputsCount, networkOutputsCount, (rawData.size() - networkInputsCount) / networkOutputsCount),
		learningDataset_(networkInputsCount, networkOutputsCount, fullDataset_.numSamples() * divideFactor),
		testingDataset_(networkInputsCount, networkOutputsCount, fullDataset_.numSamples() - learningDataset_.numSamples())
	{
		sampleData(rawData, networkInputsCount, networkOutputsCount);
		divideSamples(divideFactor);
	}

	// Загружает данные из указанного файла.
	vector<float> NetworkPrediction::loadData(const std::string &filename)
	{
		std::ifstream file;
		file.open(filename);
		if (file.is_open())
		{
			vector<float> data;

			while (!file.eof())
			{
				float value;
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
	void NetworkPrediction::saveData(const std::string &filename, const vector<float> &data)
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
	void NetworkPrediction::sampleData(const vector<float> &rawData, int networkInputsCount, int networkOutputsCount)
	{
		const int numInput = fullDataset_.numInput();
		const int numOutput = fullDataset_.numOutput();
		const int numSamples = fullDataset_.numSamples();

		matrix<float> inputData = MatrixHelper::createVectorMatrix<float>(numSamples, numInput);
		matrix<float> outputData = MatrixHelper::createVectorMatrix<float>(numSamples, numOutput);
		for (size_t i = 0, step = 0; i < numSamples; ++i, step += networkOutputsCount)
		{
			for (size_t j = 0; j < networkInputsCount; ++j)
			{
				inputData[i][j] = rawData[step + j];
			}

			for (size_t k = 0; k < networkOutputsCount; ++k)
			{
				outputData[i][k] = rawData[step + networkInputsCount + k];
			}
		}

		fullDataset_.setInputData(inputData);
		fullDataset_.setOutputData(outputData);
	}

	// Разбивает выборки на обучающие и тестирующие.
	void NetworkPrediction::divideSamples(float divideFactor)
	{
		const matrix<float> &inputData = fullDataset_.inputData();
		const matrix<float> &outputData = fullDataset_.outputData();

		const int numInput = fullDataset_.numInput();
		const int numOutput = fullDataset_.numOutput();
		const int numSamplesFull = fullDataset_.numSamples();
		const int numSamplesLearning = learningDataset_.numSamples();
		const int numSamplesTesting = testingDataset_.numSamples();

		matrix<float> learningInputData = MatrixHelper::createVectorMatrix<float>(numSamplesLearning, numInput);
		matrix<float> learningOutputData = MatrixHelper::createVectorMatrix<float>(numSamplesLearning, numOutput);
		matrix<float> testingInputData = MatrixHelper::createVectorMatrix<float>(numSamplesTesting, numInput);
		matrix<float> testingOutputData = MatrixHelper::createVectorMatrix<float>(numSamplesTesting, numOutput);
		
		for (size_t i = 0; i < numSamplesFull; ++i)
		{
			if (i < numSamplesLearning)
			{
				learningInputData[i] = inputData[i];
				learningOutputData[i] = outputData[i];
			}
			else
			{
				testingInputData[i - numSamplesLearning] = inputData[i];
				testingOutputData[i - numSamplesLearning] = outputData[i];
			}
		}

		learningDataset_.setInputData(learningInputData);
		learningDataset_.setOutputData(learningOutputData);
		testingDataset_.setInputData(testingInputData);
		testingDataset_.setOutputData(testingOutputData);
	}
}
