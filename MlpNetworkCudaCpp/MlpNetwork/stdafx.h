#ifndef STDAFX_H
#define STDAFX_H

#include <string>
#include <vector>
#include <stdexcept>
#include <cmath>
#include <ctime>
#include <algorithm>
#include <fstream>
#include <functional>
#include <memory>

namespace mlp_network
{
	using std::vector;

	template <typename T> using matrix = vector < vector<T> >;
}

#endif // STDAFX_H