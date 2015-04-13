using System;
using System.Runtime.InteropServices;

namespace MlpPredictor
{
    internal static class NativeMethods
    {
        [DllImport(@"CudaLib.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "createErrorPropagation")]
        internal static extern IntPtr CreateErrorPropagation(
            [In, MarshalAs(UnmanagedType.LPArray)] float[] inputDataFlatten,
            [In, MarshalAs(UnmanagedType.LPArray)] float[] outputDataFlatten,
            [In, MarshalAs(UnmanagedType.LPArray)] float[] inputHiddenWeightsFlatten,
            [In, MarshalAs(UnmanagedType.LPArray)] float[] hiddenOutputWeightsFlatten,
            int numInput,
            int numHidden,
            int numOutput,
            int numSamples,
            ActivationFunctionType hiddenFunctionType, ActivationFunctionType outputFunctionType);

        [DllImport(@"CudaLib.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "destroyErrorPropagation")]
        internal static extern void DestroyErrorPropagation(IntPtr propagation);

        [DllImport(@"CudaLib.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "randomizeWeights")]
        internal static extern void RandomizeWeights(IntPtr propagation);

        [DllImport(@"CudaLib.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "performBackPropEpoch")]
        internal static extern float PerformBackPropEpoch(IntPtr propagation, float learningRate, float momentum);

        [DllImport(@"CudaLib.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "performResilientPropEpoch")]
        internal static extern float PerformResilientPropEpoch(IntPtr propagation);

        [DllImport(@"CudaLib.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "getInputHiddenWeights")]
        internal static extern IntPtr GetInputHiddenWeights(IntPtr propagation);

        [DllImport(@"CudaLib.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "getHiddenOutputWeights")]
        internal static extern IntPtr GetHiddenOutputWeights(IntPtr propagation);
    }
}
