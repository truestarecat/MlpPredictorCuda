#ifndef ACTIVATION_FUNCTION_H
#define ACTIVATION_FUNCTION_H

namespace mlp_network
{
	class ActivationFunction
	{
	public:
		static enum Type
		{
			UNIPOLAR_SIGMOID = 0,
			BIPOLAR_SIGMOID = 1,
			SINUSOID = 2,
			LINEAR = 3
		};

		ActivationFunction(const ActivationFunction::Type &type);
		double value(double x) const;
		double derivative(double fX) const;

	private:
		std::function< double(double) > function_;
		std::function< double(double) > derivative_;
	};
}

#endif // ACTIVATION_FUNCTION_H

