#include "stdafx.h"
#include "resilientpropagation.h"
#include "matrixhelper.h"

namespace mlp_network
{
	const double ResilientPropagation::A = 1.2;
	const double ResilientPropagation::B = 0.5;
	//const double ResilientPropagation::MIN_LEARNING_RATE = DBL_MIN;
	const double ResilientPropagation::MIN_LEARNING_RATE = 0.000001;
	const double ResilientPropagation::MAX_LEARNING_RATE = 50.0;

	// Создаёт новый экземплар обучения для заданной нейронной сети и обучающего набора данных.
	ResilientPropagation::ResilientPropagation(MlpNetwork &network, const NetworkDataset &dataset)
		: Propagation(network, dataset),
		inputHiddenLearningRates_(MatrixHelper::createMatrix<double>(numInput_, numHidden_)),
		hiddenOutputLearningRates_(MatrixHelper::createMatrix<double>(numHidden_ + 1, numOutput_))
	{
		randomizeLearningRates();
	}

	ResilientPropagation::~ResilientPropagation()
	{
	}

	// Сбрасывает параметры обучения на начальные.
	void ResilientPropagation::reset()
	{
		reinitParams();
		randomizeParams();
	}

	// Обнуляет параметры обучения.
	void ResilientPropagation::reinitParams()
	{
		reinitGradients();

		//error_ = 100.0;
		numEpoch_ = 0;
	}

	// Заполняет случайными значениями параметры обучения.
	void ResilientPropagation::randomizeParams()
	{
		randomizeWeights();
		randomizeLearningRates();
	}

	// Заполняет случайными значениями коэффициенты обучения.
	void ResilientPropagation::randomizeLearningRates()
	{
		MatrixHelper::randomizeMatrix(inputHiddenLearningRates_, 0.0, 1.0);
		MatrixHelper::randomizeMatrix(hiddenOutputLearningRates_, 0.0, 1.0);
	}

	// Пересчитывает значения весов входного-скрытого слоёв сети.
	void ResilientPropagation::updateInputHiddenWeights()
	{
		auto inputHiddenWeights = network_.inputHiddenWeights();

		for (size_t i = 0; i < numHidden_; ++i)
		{
			for (size_t j = 0; j < numInput_; ++j)
			{
				double previousGradient = previousHiddenGradients_[j][i];
				double currentGradient = hiddenGradients_[j][i];
				double change = previousGradient * currentGradient;

				if (change > 0)
				{
					inputHiddenLearningRates_[j][i] = std::min(A * inputHiddenLearningRates_[j][i], MAX_LEARNING_RATE);
				}
				else if (change < 0)
				{
					inputHiddenLearningRates_[j][i] = std::max(B * inputHiddenLearningRates_[j][i], MIN_LEARNING_RATE);
				}

				double deltaW = -inputHiddenLearningRates_[j][i] * sign(currentGradient);
				inputHiddenWeights[j][i] += deltaW;
			}
		}

		network_.setInputHiddenWeights(inputHiddenWeights);
	}

	// Пересчитывает значения весов скрытого-выходного слоёв сети.
	void ResilientPropagation::updateHiddenOutputWeights()
	{
		auto hiddenOutputWeights = network_.hiddenOutputWeights();

		for (size_t s = 0; s < numOutput_; ++s)
		{
			for (size_t i = 0; i < numHidden_ + 1; ++i)
			{
				double previousGradient = previousOutputGradients_[i][s];
				double currentGradient = outputGradients_[i][s];
				double change = previousGradient * currentGradient;

				if (change > 0)
				{
					hiddenOutputLearningRates_[i][s] = std::min(A * hiddenOutputLearningRates_[i][s], MAX_LEARNING_RATE);
				}
				else if (change < 0)
				{
					hiddenOutputLearningRates_[i][s] = std::max(B * hiddenOutputLearningRates_[i][s], MIN_LEARNING_RATE);
				}

				double deltaW = -hiddenOutputLearningRates_[i][s] * sign(currentGradient);
				hiddenOutputWeights[i][s] += deltaW;
			}
		}

		network_.setHiddenOutputWeights(hiddenOutputWeights);
	}

	// Рассчитывает функцию знака signum.
	int ResilientPropagation::sign(double x)
	{
		if (x > 0) return 1;
		if (x < 0) return -1;
		return 0;
	}
}