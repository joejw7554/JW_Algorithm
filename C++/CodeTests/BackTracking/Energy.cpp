//https://www.acmicpc.net/problem/16198

#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

int getMaxEnergy(int N, std::vector<int>& weights)
{
	if (N == 2) return 0;

	int maxEnergy = 0;
	for (int i = 1; i < N - 1; ++i)
	{
		int energy = weights[i - 1] * weights[i + 1];
		int removed = weights[i];
		weights.erase(weights.begin() + i);
		// maxEnergy = max(maxEnergy, energy + getMaxEnergy(N - 1, weights));
		int currentEnergy = energy + getMaxEnergy(N - 1, weights);
		if (currentEnergy > maxEnergy) {
			maxEnergy = currentEnergy;
		}
		weights.insert(weights.begin() + i, removed); 
	}
	return maxEnergy;
}

int main() {
	int N = 5;
	vector<int> weights = {100, 2, 1, 3, 100};
	cout << getMaxEnergy(N, weights) << endl;
	return 0;
}
