#include "stdafx.h"
#include "activationfunction.h"

namespace mlp_network
{
	ActivationFunction::ActivationFunction(const ActivationFunction::Type &type)
	{
		switch (type)
		{
		case Type::UNIPOLAR_SIGMOID:
			function_ = [](double x) { return 1 / (1 + exp(-x)); };
			derivative_ = [](double fX) { return fX * (1 - fX); };
			break;
		case Type::BIPOLAR_SIGMOID:
			function_ = [](double x) { return tanh(x); };
			derivative_ = [](double fX) { return 1 - fX * fX; };
			break;
		case Type::SINUSOID:
			function_ = [](double x) { return sin(x); };
			derivative_ = [](double fX) { return sqrt(1 - fX * fX); };
			break;
		case Type::LINEAR:
			function_ = [](double x) { return x; };
			derivative_ = [](double fX) { return 1.0; };
			break;
		default:
			function_ = [](double x) { return 0.0; };
			derivative_ = [](double fX) { return 0.0; };
			break;
		}
	}

	double ActivationFunction::value(double x) const
	{
		return function_(x);
	}

	double ActivationFunction::derivative(double fX) const
	{
		return derivative_(fX);
	}
}
