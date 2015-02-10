#include "stdafx.h"
#include "networkdataset.h"
#include "matrixhelper.h"

namespace mlp_network
{
	// Создаёт пустой новый набор данных для сети.
	NetworkDataset::NetworkDataset() : size_(0), inputSize_(0), outputSize_(0)
	{
	}

	// Создаёт новый набор данных для сети, используя матрицы входных и выходных данных.
	NetworkDataset::NetworkDataset(const matrix<double> &inputData, const matrix<double> &outputData)
		: size_(inputData.size()), inputSize_(inputData[0].size()), outputSize_(outputData[0].size()),
		inputData_(inputData), outputData_(outputData)
	{
	}

	// Создаёт новый набор данных для сети, используя размер набора данных, а также размеры входной и выходной выборки данных.
	NetworkDataset::NetworkDataset(size_t size, size_t inputSize, size_t outputSize)
		: size_(size), inputSize_(inputSize), outputSize_(outputSize),
		inputData_(MatrixHelper::createMatrix<double>(size, inputSize)),
		outputData_(MatrixHelper::createMatrix<double>(size, outputSize))
	{	
	}

	// Возвращает размер набора данных для сети.
	size_t NetworkDataset::size() const
	{
		return size_;
	}

	// Возвращает матрицу входных данных сети.
	const matrix<double>& NetworkDataset::inputData() const
	{
		return inputData_;
	}

	// Задаёт матрицу входных данных сети.
	void NetworkDataset::setInputData(const matrix<double> &inputData)
	{
		inputData_ = inputData;
	}

	// Возвращает матрицу выходных данных сети.
	const matrix<double>& NetworkDataset::outputData() const
	{
		return outputData_;
	}

	// Задаёт матрицу выходных данных сети.
	void NetworkDataset::setOutputData(const matrix<double> &outputData)
	{
		outputData_ = outputData;
	}
}
