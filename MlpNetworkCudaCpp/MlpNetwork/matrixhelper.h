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

		template <typename T> static T** newMatrix(size_t rowCount, size_t columnCount)
		{
			T** matrix = new T*[rowCount];
			for (size_t i = 0; i < rowCount; ++i)
			{
				matrix[i] = new T[columnCount];
			}

			return matrix;
		}

		template <typename T> static void deleteMatrix(T **matrix, size_t rowCount)
		{
			for (size_t i = 0; i < rowCount; ++i)
			{
				delete [] matrix[i];
			}

			delete [] matrix;
		}

		template <typename T> static vector<T> convert2DArrayToVector(T **matrix, size_t rows, size_t columns)
		{
			vector<T> result;
			for (size_t i = 0; i < rows; ++i)
			{
				for (size_t j = 0; j < columns; ++j)
				{
					result.push_back(matrix[i][j]);
				}
			}

			return result;
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

		// Заполняет матрицу случайными числами из заданного диапазона.
		static void randomizeMatrix(matrix<double> &matrix, double minValue, double maxValue)
		{
			// Формула для генерации случайных чисел в диапазоне: _min + double(rand()) / RAND_MAX * (_max - _min).
			for (size_t i = 0; i < matrix.size(); ++i)
			{
				for (size_t j = 0; j < matrix[i].size(); ++j)
				{
					matrix[i][j] = minValue + double(rand()) / RAND_MAX * (maxValue - minValue);
				}
			}
		}

		// Вычисляет функцию ошибки двух векторов.
		template <typename T> static T error(const vector<T> &a, const vector<T> &b)
		{
			T sum = 0;
			for (size_t i = 0; i < a.size(); ++i)
			{
				sum += (a[i] - b[i]) * (a[i] - b[i]);
			}

			return sum;
		}

		// Вычисляет разницу двух векторов.
		template <typename T> static T distance(const vector<T> &a, const vector<T> &b)
		{
			return sqrt(error(a, b));
		}

		// Вычисляет СреднеКвадратичное Отклонение одного вектора от другого.
		template <typename T> static T rms(const vector<T> &a, const vector<T> &b)
		{
			//return distance(a, b) / sqrt(a.size() - 1);
			return distance(a, b) / sqrt(a.size());
		}

		// Вычисляет функцию ошибки одной матрицы от другой.
		template <typename T> static vector<T> error(const matrix<T> &a, const matrix<T> &b)
		{
			vector<T> errorVector(a.size());
			for (size_t i = 0; i < errorVector.size(); ++i)
			{
				errorVector[i] = error(a[i], b[i]);
			}

			return errorVector;
		}

		// Вычисляет СреднеКвадратичние Отклонение ошибки.
		template <typename T> static T rms(const vector<T> &errorVector)
		{
			T rmsValue = 0;
			for (size_t i = 0; i < errorVector.size(); ++i)
			{
				rmsValue += errorVector[i];
			}

			//return rmsValue / sqrt(errorVector.size());
			return sqrt(rmsValue / errorVector.size());
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

		// Заполняет вектор заданными значениями.
		template <typename T> static void fillVector(vector<T> &vector, const T &value)
		{
			std::fill(vector.begin(), vector.end(), value);
		}

		// Заполняет матрицу заданными значениями.
		template <typename T> static void fillMatrix(matrix<T> &matrix, const T &value)
		{
			for (vector<T> &vector : matrix)
			{
				std::fill(vector.begin(), vector.end(), value);
			}
		}

		static long get1DIndexFrom2D(int i, int j, int width)
		{
			return i * width + j;
		}
	};
}

#endif // MATRIX_HELPER_H

