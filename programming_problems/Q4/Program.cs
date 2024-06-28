
using System;

class REC
{

	public static int[] kadane(int[] a)
	{
		int[] result = new int[] { int.MinValue, 0, -1 };
		int currentSum = 0;
		int localStart = 0;

		for (int i = 0; i < a.Length; i++)
		{
			currentSum += a[i];
			if (currentSum < 0)
			{
				currentSum = 0;
				localStart = i + 1;
			}
			else if (currentSum > result[0])
			{
				result[0] = currentSum;
				result[1] = localStart;
				result[2] = i;
			}
		}

		if (result[2] == -1)
		{
			result[0] = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] > result[0])
				{
					result[0] = a[i];
					result[1] = i;
					result[2] = i;
				}
			}
		}
		return result;
	}

	public static void findMaxSubMatrix(int[,] a)
	{
		int cols = a.GetLength(1);
		int rows = a.GetLength(0);
		int[] currentResult;
		int maxSum = int.MinValue;
		int left = 0;
		int top = 0;
		int right = 0;
		int bottom = 0;

		for (int leftCol = 0; leftCol < cols; leftCol++)
		{
			int[] tmp = new int[rows];

			for (int rightCol = leftCol; rightCol < cols;
				rightCol++)
			{

				for (int i = 0; i < rows; i++)
				{
					tmp[i] += a[i, rightCol];

				}
				currentResult = kadane(tmp);
				if (currentResult[0] > maxSum)
				{
					maxSum = currentResult[0];
					left = leftCol;
					top = currentResult[1];
					right = rightCol;
					bottom = currentResult[2];
				}
			}
		}

		Console.Write(maxSum);
	}

	public static void Main()
	{

		
		
		
		int n = Convert.ToInt32(Console.ReadLine());
		int[,] array = new int[n, n];
		for (int i = 0; i < n; i++)
		{
			string[] tokens = Console.ReadLine().Split();
			for (int j = 0; j < n; j++)
			{
				array[i, j] = Convert.ToInt32(tokens[j]);
			}
		}

		findMaxSubMatrix(array);
	}
}

