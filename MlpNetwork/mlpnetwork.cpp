#include "stdafx.h"
#include "mlpnetwork.h"
#include "matrixhelper.h"

namespace mlp_network
{
	// Создаёт новый экземплар многослойного персептрона.
	MlpNetwork::MlpNetwork(size_t numInput, size_t numHidden, size_t numOutput,
		const ActivationFunction &hiddenFunction, const ActivationFunction &outputFunction)
		: numInput_(numInput), numHidden_(numHidden), numOutput_(numOutput),
		hiddenFunction_(hiddenFunction), outputFunction_(outputFunction),
		inputs_(numInput),
		inputHiddenWeights_(MatrixHelper::createMatrix<double>(numInput, numHidden)),
		hiddenOutputs_(numHidden + 1),
		hiddenOutputWeights_(MatrixHelper::createMatrix<double>(numHidden + 1, numOutput)),
		outputs_(numOutput)
	{
	}

	// Возвращает число входов сети (с учётом порогового сигнала).
	size_t MlpNetwork::numInput() const
	{
		return numInput_;
	}

	// Возвращает число нейронов в скрытом слое сети (без учёта порогового сигнала).
	size_t MlpNetwork::numHidden() const
	{
		return numHidden_;
	}

	// Возвращает число нейронов в выходном слое сети.
	size_t MlpNetwork::numOutput() const
	{
		return numOutput_;
	}

	// Возвращает вид функции активации нейронов скрытого слоя сети.
	const ActivationFunction& MlpNetwork::hiddenFunction() const
	{
		return hiddenFunction_;
	}

	// Задаёт вид функции активации нейронов скрытого слоя сети.
	void MlpNetwork::setHiddenFunction(const ActivationFunction &hiddenFunction)
	{
		hiddenFunction_ = hiddenFunction;
	}

	// Возвращает вид функции активации нейронов выходного слоя сети.
	const ActivationFunction& MlpNetwork::outputFunction() const
	{
		return outputFunction_;
	}

	// Задаёт вид функции активации нейронов выходного слоя сети.
	void MlpNetwork::setOutputFunction(const ActivationFunction &outputFunction)
	{
		outputFunction_ = outputFunction;
	}

	// Возвращает значения входов сети.
	const vector<double>& MlpNetwork::inputs() const
	{
		return inputs_;
	}

	// Задаёт значения входов сети.
	void MlpNetwork::setInputs(const vector<double> &inputs)
	{
		inputs_ = inputs;
	}

	// Возвращает матрицу весов входного-скрытого слоёв сети.
	const matrix<double>& MlpNetwork::inputHiddenWeights() const
	{
		return inputHiddenWeights_;
	}

	// Задаёт матрицу весов входного-скрытого слоёв сети.
	void MlpNetwork::setInputHiddenWeights(const matrix<double> &inputHiddenWeights)
	{
		inputHiddenWeights_ = inputHiddenWeights;
	}

	// Возвращает выходные сигналы скрытого слоя сети.
	const vector<double>& MlpNetwork::hiddenOutputs() const
	{
		return hiddenOutputs_;
	}

	// Возвращает матрицу весов скрытого-выходного слоёв сети.
	const matrix<double>& MlpNetwork::hiddenOutputWeights() const
	{
		return hiddenOutputWeights_;
	}

	// Задаёт матрицу весов скрытого-выходного слоёв сети.
	void MlpNetwork::setHiddenOutputWeights(const matrix<double> &hiddenOutputWeights)
	{
		hiddenOutputWeights_ = hiddenOutputWeights;
	}

	// Возвращает значения выходов сети.
	const vector<double>& MlpNetwork::outputs() const
	{
		return outputs_;
	}

	// Рассчитывает значения выходов сети.
	void MlpNetwork::computeOutputs()
	{
		computeHiddenSignal();
		computeOutputSignal();
	}

	// Рассчитывает и возвращает вектор значений выходов сети при заданных вектором входах.
	const vector<double>& MlpNetwork::computeOutputs(const vector<double> &inputs)
	{
		inputs_ = inputs;

		computeOutputs();

		return outputs_;
	}

	// Рассчитывает и возвращает матрицу значений выходов сети при заданных матрицей входах.
	matrix<double> MlpNetwork::computeOutputs(const matrix<double> &inputData)
	{
		matrix<double> matrix = MatrixHelper::createMatrix<double>(inputData.size(), inputData[0].size());
		for (size_t t = 0; t < inputData.size(); ++t)
		{
			matrix[t] =	computeOutputs(inputData[t]);
		}

		return matrix;
	}

	// Рассчитывает значения выходов скрытого слоя сети.
	void MlpNetwork::computeHiddenSignal()
	{
		hiddenOutputs_[0] = 1;
		for (size_t i = 1; i < numHidden_ + 1; ++i)
		{
			double sum = 0;
			for (size_t j = 0; j < numInput_; ++j)
			{
				sum += inputHiddenWeights_[j][i - 1] * inputs_[j];
			}

			hiddenOutputs_[i] = hiddenFunction_.value(sum);
		}
	}

	// Рассчитывает значения выходов выходного слоя сети.
	void MlpNetwork::computeOutputSignal()
	{
		for (size_t s = 0; s < numOutput_; ++s)
		{
			double sum = 0;
			for (size_t i = 0; i < numHidden_ + 1; ++i)
			{
				sum += hiddenOutputWeights_[i][s] * hiddenOutputs_[i];
			}

			outputs_[s] = outputFunction_.value(sum);
		}
	}
}
