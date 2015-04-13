using System;

namespace MlpPredictor
{
    public static class MatrixHelper
    {
		public static float Rms(float[] a, float[] b)
		{
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            if (a.Length == 0)
                throw new ArgumentException("Пустой массив.", "a");
            if (b.Length == 0)
                throw new ArgumentException("Пустой массив.", "b");

			float sum = 0.0f;
			for (int i = 0; i < a.Length; i++)
			{
				sum += (a[i] - b[i]) * (a[i] - b[i]);
			}

			return (float)Math.Sqrt(sum / a.Length);
		}

		public static float[] Rms(float[][] a, float[][] b)
		{
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            if (a.Length == 0)
                throw new ArgumentException("Пустой массив.", "a");
            if (b.Length == 0)
                throw new ArgumentException("Пустой массив.", "b");

			float[] rmsArray = new float[a.Length];
			for (int i = 0; i < rmsArray.Length; i++)
			{
				rmsArray[i] = Rms(a[i], b[i]);
			}

			return rmsArray;
		}

        public static T[] Convert2DArrayTo1D<T>(T[][] array2D)
        {
            if (array2D == null)
                throw new ArgumentNullException("array2D");
            if (array2D.Length == 0)
                throw new ArgumentException("Пустой массив.", "array2D");

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
            if (array1D == null)
                throw new ArgumentNullException("array1D");
            if (xLength < 1)
                throw new ArgumentException("Размерность массива должна быть больше 1.", "xLength");
            if (yLength < 1)
                throw new ArgumentException("Размерность массива должна быть больше 1.", "yLength");
            if (array1D.Length == 0)
                throw new ArgumentException("Пустой массив.", "array1D");

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
            if (i < 0)
                throw new ArgumentOutOfRangeException("i", "Индекс должен быть больше или равен 0.");
            if (j < 0)
                throw new ArgumentOutOfRangeException("j", "Индекс должен быть больше или равен 0.");
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", "Ширина массива должна быть больше 0.");

            return i * width + j;
        }
    }
}
