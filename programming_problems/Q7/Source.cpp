#include<iostream>
#include<vector>
using namespace std;
long long int max(long long int a, long long int b) {
    if (a >= b)
        return a;
    else
        return b;
}
int main() {
    long long int n, m, temp, result = 0;
    cin >> n >> m;
    long long int a = 1;
    vector<vector<long long int>> matrix(n, vector<long long int>(m, 0));
    for (long long int i = 0; i < n; i++) {
        for (long long int j = 0; j < m; j++) {
            cin >> temp; matrix[i][j] = temp;
        }
    }
    for (long long int i = 0; i < m; i++) {
        int c = 0;
        for (long long int j = 0; j < n; j++) {
            c += matrix[j][i] ^ matrix[j][0];
        }
        result += max(c, n - c) * (a << (m - 1 - i));
    }
    cout << result;
    return 0;
}