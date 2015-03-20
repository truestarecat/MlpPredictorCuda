using System;

namespace MlpNetwork
{
    public class MatrixHelper
    {
		public static float Rms(float[] a, float[] b)
		{
			float sum = 0.0f;
			for (int i = 0; i < a.Length; i++)
			{
				sum += (a[i] - b[i]) * (a[i] - b[i]);
			}

			return (float)Math.Sqrt(sum / a.Length);
		}

		public static float[] Rms(float[][] a, float[][] b)
		{
			float[] rmsArray = new float[a.Length];
			for (int i = 0; i < rmsArray.Length; i++)
			{
				rmsArray[i] = Rms(a[i], b[i]);
			}

			return rmsArray;
		}

        public static T[] Convert2DArrayTo1D<T>(T[][] array2D)
        {
            T[] array1D = new T[array2D.Length * array2D[0].Length];
            for (int i = 0; i < array2D.Length; i++)
            {
                for (int j = 0; j < array2D[i].Length; j++)
                {
                    array1D[Get1DIndexFrom2D(i, j, array2D[i].Length)] = array2D[i][j];
                }
            }

            return array1D;
        }

        public static T[][] Convert1DArrayTo2D<T>(T[] array1D, int xLength, int yLength)
        {
            T[][] array2D = new T[xLength][];
            for (int i = 0; i < array2D.Length; i++)
            {
                array2D[i] = new T[yLength];
                for (int j = 0; j < array2D[i].Length; j++)
                {
                    array2D[i][j] = array1D[Get1DIndexFrom2D(i, j, array2D[i].Length)];
                }
            }

            return array2D;
        }

        private static long Get1DIndexFrom2D(int i, int j, int width)
        {
            return i * width + j;
        }
    }
}
