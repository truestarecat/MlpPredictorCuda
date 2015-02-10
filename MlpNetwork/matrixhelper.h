#ifndef MATRIX_HELPER_H
#define MATRIX_HELPER_H

namespace mlp_network
{
	class MatrixHelper
	{
	public:
		// Создаёт матрицу заданного размера.
		template <typename T> static matrix<T> createMatrix(size_t rowCount, size_t columnCount)
		{
			matrix<T> matrix(rowCount);
			for (size_t i = 0; i < rowCount; ++i)
			{
				matrix[i].resize(columnCount);
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

		// Вычисляет разницу двух векторов.
		template <typename T> static double distance(const vector<T> &a, const vector<T> &b)
		{
			T sum = 0;
			for (size_t i = 0; i < a.size(); ++i)
			{
				sum += (a[i] - b[i]) * (a[i] - b[i]);
			}

			return sqrt(sum);
		}

		// Вычисляет СреднеКвадратичное Отклонение одного вектора от другого.
		template <typename T> static double rms(const vector<T> &a, const vector<T> &b)
		{
			//return distance(a, b) / sqrt(a.size() - 1);
			return distance(a, b) / sqrt(a.size());
		}

		// Вычисляет СреднеКвадратичное Отклонение одной матрицы от другой.
		template <typename T> static double rms(const matrix<T> &a, const matrix<T> &b)
		{
			T sum = 0;
			for (size_t i = 0; i < a.size(); ++i)
			{
				sum += distance(a[i], b[i]) * distance(a[i], b[i]);
			}

			//return sqrt(sum / (a.size() - 1));
			return sqrt(sum / a.size());
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
	};
}

#endif // MATRIX_HELPER_H

