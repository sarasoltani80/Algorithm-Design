#include<iostream>
#include<vector>
using namespace std;
long long int a[5000][5000];
long long int max(long long int a,long long int b)
{
	if (a > b)
		return a;
	else
		return b;
}
long long int min(long long int a, long long  int b)
{
	if (a < b)
		return a;
	else
		return b;
}
int main() {
	int n; long long int tmp;
	cin >> n;
	vector<long long int> arr;
	long long int even = 0, odd = 0;
	for (int i = 0; i < n; i++) {
		cin >> tmp; arr.push_back(tmp);
	}
	for (int i = 0; i < n; i++) {
		a[i][i] = arr[i];
		if (i != n - 1) {
			a[i][i + 1] = (arr[i] > arr[i + 1]) ? arr[i] : arr[i + 1];
		}
	}
	for (int len = 2; len < n; len++) {
		for (int i = 0, j = len; j < n; i++, j++) {
			a[i][j] = max(arr[i] + min(a[i + 2][j], a[i + 1][j - 1]), arr[j] + min(a[i + 1][j - 1], a[i][j - 2]));
		}
	}
	cout << a[0][n - 1];
	return 0;
}