#ifndef CUDA_ERROR_PROPAGATION_H
#define CUDA_ERROR_PROPAGATION_H

//#define CUDALUB_EXPORTS

#ifdef CUDALUB_EXPORTS
#define CULIBAPI __declspec(dllexport)
#else
#define CULIBAPI __declspec(dllimport)
#endif

struct CudaErrorPropagation
{
	// Network and data
	int numInput;
	int numHidden;
	int numOutput;
	int numSamples;

	float *d_inputsBatch /*2d*/;
	float *d_inputHiddenWeights /*2d*/;
	float *d_hiddenOutputsBatch /*2d*/;
	float *d_hiddenOutputWeights /*2d*/;
	float *d_outputsBatch /*2d*/;

	// Propagation
	float *d_targetOutputsBatch /*2d*/;
	float *d_outputDeltasBatch /*2d*/;
	float *d_hiddenOutputGradients /*2d*/;
	float *d_hiddenDeltasBatch /*2d*/;
	float *d_inputHiddenGradients /*2d*/;
	float *d_errorsOutputsBatch /*2d*/;
	float *d_errorsBatch;
	float *d_error; /* Single value */

	float *d_hiddenOutputGradientsBatch /*3d*/;
	float *d_inputHiddenGradientsBatch /*3d*/;

	// BackPropagation
	float *d_previousInputHiddenWeightDeltas /*2d*/;
	float *d_previousHiddenOutputWeightDeltas /*2d*/;

	// ResilientPropagation
	float *d_previousInputHiddenGradients /*2d*/;
	float *d_previousHiddenOutputGradients /*2d*/;
	float *d_inputHiddenLearningRates /*2d*/;
	float *d_hiddenOutputLearningRates /*2d*/;

	// Computed weights
	float *h_inputHiddenWeights /*2d*/;
	float *h_hiddenOutputWeights /*2d*/;
};

#ifdef __cplusplus
extern "C" {
#endif

	CULIBAPI CudaErrorPropagation* createErrorPropagation(float *hostInputData /*2d*/, float *hostOutputData /*2d*/,
		float *hostInputHiddenWeights /*2d*/, float *hostHiddenOutputWeights /*2d*/,
		int numInput, int numHidden, int numOutput, int numSamples);

	CULIBAPI void destroyErrorPropagation(CudaErrorPropagation *propagation);

	CULIBAPI const float* getInputHiddenWeights(CudaErrorPropagation *propagation);

	CULIBAPI const float* getHiddenOutputWeights(CudaErrorPropagation *propagation);

	CULIBAPI void randomizeWeights(CudaErrorPropagation *propagation);

	CULIBAPI float performBackPropEpoch(CudaErrorPropagation *propagation, float learningRate, float momentum);

#ifdef __cplusplus
}
#endif

#endif // CUDA_ERROR_PROPAGATION_H