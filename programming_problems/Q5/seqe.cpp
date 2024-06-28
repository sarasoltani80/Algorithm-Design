#pragma warning(disable:4996)
#include <iostream>
 
using namespace std;

long long int cashsystem(int coins[], int row, long long int col)
{
    long long int k, j, x, y;

    long long int dp[col + 1][row];

    for (j = 0; j < row; j++)
        dp[0][j] = 1;

    for (k = 1; k < col + 1; k++)
    {
        for (j = 0; j < row; j++)
        {

            if (k - coins[j] >= 0)
            {
                x = dp[k - coins[j]][j] % 1000000007;
            }
            else {
                x = 0;
            }

            if (j >= 1)
            {
                y = dp[k][j - 1] % 1000000007;
            }
            else
            {
                y = 0;
            }
            dp[k][j] = x + y;
        }
    }
    return dp[col][row - 1];
}


int main()
{
    int coins[100];
    int n;
    long long int x;
    cin >> n >> x;
    for (int i = 0; i < n; i++)
        cin >> coins[i];
    cout << cashsystem(coins, n, x);
    return 0;
}