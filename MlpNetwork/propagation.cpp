#include "stdafx.h"
#include "propagation.h"
#include "matrixhelper.h"

namespace mlp_network
{
	// Создаёт новый экземплар обучения для заданной нейронной сети и обучающего набора данных.
	Propagation::Propagation(MlpNetwork &network, const NetworkDataset &dataset)
		: network_(network), dataset_(dataset),
		numInput_(network.numInput()), numHidden_(network.numHidden()), numOutput_(network.numOutput()),
		idealOutputs_(numOutput_), outputDeltas_(numOutput_),
		outputGradients_(MatrixHelper::createMatrix<double>(numHidden_ + 1, numOutput_)),
		hiddenDeltas_(numHidden_),
		hiddenGradients_(MatrixHelper::createMatrix<double>(numInput_, numHidden_)),
		previousHiddenGradients_(MatrixHelper::createMatrix<double>(numInput_, numHidden_)),
		previousOutputGradients_(MatrixHelper::createMatrix<double>(numHidden_ + 1, numOutput_))
	{
		randomizeWeights();
	}

	Propagation::~Propagation()
	{
	}

	// Возвращает текущую ошибку обучения.
	double Propagation::error() const
	{
		return error_;
	}

	// Возвращает текущее число итераций обучения.
	size_t Propagation::numEpoch() const
	{
		return numEpoch_;
	}

	// Совершает итерацию обучения.
	void Propagation::doIteration()
	{
		network_.computeOutputs();

		computeOutputGradients();
		computeHiddenGradients();

		updateInputHiddenWeights();
		updateHiddenOutputWeights();

		previousHiddenGradients_ = hiddenGradients_;
		previousOutputGradients_ = outputGradients_;
	}

	// Выполняет обучение сети и возвращает вектор ошибок обучения.
	vector<double> Propagation::train(size_t maxNumEpoch, double maxError)
	{
		vector<double> errors;
		numEpoch_ = 0;

		matrix<double> networkOutput = network_.computeOutputs(dataset_.inputData());
		error_ = MatrixHelper::rms(networkOutput, dataset_.outputData());
		errors.push_back(error_);

		while (numEpoch_ < maxNumEpoch && error_ > maxError)
		{
			for (size_t t = 0; t < dataset_.size(); ++t)
			{
				network_.setInputs(dataset_.inputData()[t]);
				idealOutputs_ = dataset_.outputData()[t];

				doIteration();
			}

			networkOutput = network_.computeOutputs(dataset_.inputData());
			error_ = MatrixHelper::rms(networkOutput, dataset_.outputData());
			errors.push_back(error_);

			++numEpoch_;
		}

		return errors;
	}

	// Обнуляет параметры обучения.
	void Propagation::reinitGradients()
	{
		MatrixHelper::fillVector(outputDeltas_, 0.0);
		MatrixHelper::fillMatrix(outputGradients_, 0.0);
		MatrixHelper::fillVector(hiddenDeltas_, 0.0);
		MatrixHelper::fillMatrix(hiddenGradients_, 0.0);
		MatrixHelper::fillMatrix(previousHiddenGradients_, 0.0);
		MatrixHelper::fillMatrix(previousOutputGradients_, 0.0);
	}

	// Заполняет случайными значениями параметры обучения.
	void Propagation::randomizeWeights()
	{
		srand(time(NULL));

		auto inputHiddenWeights = network_.inputHiddenWeights();
		MatrixHelper::randomizeMatrix(inputHiddenWeights, -1.0, 1.0);
		//MatrixHelper::randomizeMatrix(inputHiddenWeights, -0.5, 0.5);
		network_.setInputHiddenWeights(inputHiddenWeights);

		auto hiddenOutputWeights = network_.hiddenOutputWeights();
		MatrixHelper::randomizeMatrix(hiddenOutputWeights, -1.0, 1.0);
		//MatrixHelper::randomizeMatrix(inputHiddenWeights, -0.5, 0.5);
		network_.setHiddenOutputWeights(hiddenOutputWeights);
	}

	// Рассчитывает ошибку обучения "онлайн".
	double Propagation::errorOnline()
	{
		auto &networkOutputs = network_.outputs();

		double sum = 0;
		for (size_t s = 0; s < numOutput_; ++s)
		{
			sum += (networkOutputs[s] - idealOutputs_[s]) * (networkOutputs[s] - idealOutputs_[s]);
		}

		return 0.5 * sum;
	}

	// Рассчитывает ошибку обучения "оффлайн".
	double Propagation::errorOffline()
	{
		double sum = 0;
		for (size_t t = 0; t < dataset_.size(); ++t)
		{
			network_.setInputs(dataset_.inputData()[t]);
			idealOutputs_ = dataset_.outputData()[t];

			network_.computeOutputs();

			auto &networkOutputs = network_.outputs();
			for (size_t s = 0; s < numOutput_; ++s)
			{
				sum += (networkOutputs[s] - idealOutputs_[s]) * (networkOutputs[s] - idealOutputs_[s]);
			}
		}

		return 0.5 * sum;
	}

	// Рассчитывает градиенты выходного слоя сети.
	void Propagation::computeOutputGradients()
	{
		auto &outputFunction = network_.outputFunction();
		auto &networkOutputs = network_.outputs();
		auto &hiddenOutputs = network_.hiddenOutputs();

		for (size_t s = 0; s < numOutput_; ++s)
		{
			outputDeltas_[s] = (networkOutputs[s] - idealOutputs_[s]) * outputFunction.derivative(networkOutputs[s]);
			for (size_t i = 0; i < numHidden_ + 1; ++i)
			{
				outputGradients_[i][s] = outputDeltas_[s] * hiddenOutputs[i];
			}
		}
	}

	// Рассчитывает градиенты скрытого слоя сети.
	void Propagation::computeHiddenGradients()
	{
		auto &hiddenOutputWeights = network_.hiddenOutputWeights();
		auto &hiddenFunction = network_.hiddenFunction();
		auto &hiddenOutputs = network_.hiddenOutputs();
		auto &networkInputs = network_.inputs();

		for (size_t i = 0; i < numHidden_; ++i)
		{
			for (size_t j = 0; j < numInput_; ++j)
			{
				double sum = 0;
				for (size_t s = 0; s < numOutput_; ++s)
				{
					sum += outputDeltas_[s] * hiddenOutputWeights[i + 1][s];
				}

				hiddenDeltas_[i] = sum * hiddenFunction.derivative(hiddenOutputs[i + 1]);
				hiddenGradients_[j][i] = hiddenDeltas_[i] * networkInputs[j];
			}
		}
	}
}
