#include "stdafx.h"
#include "backpropagation.h"
#include "matrixhelper.h"

namespace mlp_network
{
	BackPropagation::BackPropagation(MlpNetwork &network, const NetworkDataset &dataset, double learningRate, double momentum)
		: Propagation(network, dataset), learningRate_(learningRate), momentum_(momentum),
		previousInputHiddenWeightDeltas_(MatrixHelper::createMatrix<double>(numInput_, numHidden_)),
		previousHiddenOutputWeightDeltas_(MatrixHelper::createMatrix<double>(numHidden_ + 1, numOutput_))
	{
	}

	BackPropagation::~BackPropagation()
	{
	}

	// Сбрасывает параметры обучения на начальные.
	void BackPropagation::reset()
	{
		reinitParams();
		randomizeWeights();
	}

	// Обнуляет параметры обучения.
	void BackPropagation::reinitParams()
	{
		reinitGradients();
		reinitDeltas();

		//error_ = 100.0;
		numEpoch_ = 0;
	}

	// Обнуляет изменения весов.
	void BackPropagation::reinitDeltas()
	{
		MatrixHelper::fillMatrix(previousInputHiddenWeightDeltas_, 0.0);
		MatrixHelper::fillMatrix(previousHiddenOutputWeightDeltas_, 0.0);
	}

	// Пересчитывает значения весов входного-скрытого слоёв сети.
	void BackPropagation::updateInputHiddenWeights()
	{
		auto inputHiddenWeights = network_.inputHiddenWeights();

		for (size_t i = 0; i < numHidden_; ++i)
		{
			for (size_t j = 0; j < numInput_; ++j)
			{
				double deltaW = -learningRate_ * hiddenGradients_[j][i];
				inputHiddenWeights[j][i] += deltaW;
				inputHiddenWeights[j][i] += momentum_ * previousInputHiddenWeightDeltas_[j][i];
				previousInputHiddenWeightDeltas_[j][i] = deltaW;
			}
		}

		network_.setInputHiddenWeights(inputHiddenWeights);
	}

	// Пересчитывает значения весов скрытого-выходного слоёв сети.
	void BackPropagation::updateHiddenOutputWeights()
	{
		auto hiddenOutputWeights = network_.hiddenOutputWeights();

		for (size_t s = 0; s < numOutput_; ++s)
		{
			for (size_t i = 0; i < numHidden_ + 1; ++i)
			{
				double deltaW = -learningRate_ * outputGradients_[i][s];
				hiddenOutputWeights[i][s] += deltaW;
				hiddenOutputWeights[i][s] += momentum_ * previousHiddenOutputWeightDeltas_[i][s];
				previousHiddenOutputWeightDeltas_[i][s] = deltaW;
			}
		}

		network_.setHiddenOutputWeights(hiddenOutputWeights);
	}
}


