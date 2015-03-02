#ifndef CUDA_PROPAGATION_H
#define CUDA_PROPAGATION_H

#include "mlpnetwork.h"
#include "networkdataset.h"
#include "cudaerrorpropagation.h" 

namespace mlp_network
{
	class CudaPropagation
	{
	public:
		CudaPropagation(MlpNetwork &network, const NetworkDataset &dataset);

		~CudaPropagation()
		{
			::destroyErrorPropagation(propagation_);
		}

		void randomizeNetworkWeights()
		{
			::randomizeWeights(propagation_);
		}

		float performBackPropEpoch(float learningRate, float momentum)
		{
			return ::performBackPropEpoch(propagation_, learningRate, momentum);
		}

		void updateNetworkWeights();

	private:
		MlpNetwork &network_;
		NetworkDataset dataset_;

		::CudaErrorPropagation *propagation_;
	};
}

#endif // CUDA_PROPAGATION_H