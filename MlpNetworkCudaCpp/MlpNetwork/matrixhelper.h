#ifndef MATRIX_HELPER_H
#define MATRIX_HELPER_H

#include "stdafx.h"

namespace mlp_network
{
	class MatrixHelper
	{
	public:
		template <typename T> static matrix<T> createVectorMatrix(size_t rowCount, size_t columnCount)
		{
			matrix<T> matrix(rowCount);
			for (size_t i = 0; i < rowCount; ++i)
			{
				matrix[i].resize(columnCount);
			}

			return matrix;
		}

		template <typename T> static T* convertMatrixToArray(const matrix<T> &matrix)
		{
			T *array = new T[matrix.size() * matrix[0].size()];
			for (size_t i = 0; i < matrix.size(); i++)
			{
				for (size_t j = 0; j < matrix[i].size(); j++)
				{
					array[get1DIndexFrom2D(i, j, matrix[i].size())] = matrix[i][j];
				}
			}

			return array;
		}

		template <typename T> static matrix<T> convertArrayToMatrix(const T *array, size_t rows, size_t columns)
		{
			matrix<T> matrix = createVectorMatrix<T>(rows, columns);
			for (size_t i = 0; i < matrix.size(); ++i)
			{
				for (size_t j = 0; j < matrix[i].size(); ++j)
				{
					matrix[i][j] = array[get1DIndexFrom2D(i, j, matrix[i].size())];
				}
			}

			return matrix;
		}

		// Вычисляет СКО двух векторов.
		template <typename T> static T rms(const vector<T> &a, const vector<T> &b)
		{
			T sum = 0;
			for (size_t i = 0; i < a.size(); ++i)
			{
				sum += (a[i] - b[i]) * (a[i] - b[i]);
			}

			return sqrtf(sum / a.size());
		}

		// Вычисляет СКО одной матрицы от другой.
		template <typename T> static vector<T> rms(const matrix<T> &a, const matrix<T> &b)
		{
			vector<T> errorVector(a.size());
			for (size_t i = 0; i < errorVector.size(); ++i)
			{
				errorVector[i] = rms(a[i], b[i]);
			}

			return errorVector;
		}

		// Преобразует матрицу в вектор.
		template <typename T> static vector<T> convertMatrixToVector(const matrix<T> &matrix)
		{
			vector<T> result;
			for (size_t i = 0; i < matrix.size(); ++i)
			{
				for (size_t j = 0; j < matrix[i].size(); ++j)
				{
					result.push_back(matrix[i][j]);
				}
			}

			return result;
		}

		static long get1DIndexFrom2D(int i, int j, int width)
		{
			return i * width + j;
		}
	};
}

#endif // MATRIX_HELPER_H

