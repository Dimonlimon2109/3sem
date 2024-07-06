﻿#include <iostream>
#include <string>
#include <Windows.h>

using namespace std;

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int N, M = 3;
	do
	{
		cout << "Введите вместительность рюкзака: ";
		cin >> N;
		cin.clear();
		cin.ignore(32767, '\n');
	} while (N <= 0);


	string name[] = {"Мяч", "Пиво", "Гиря"};
	int cost[] = {25, 19, 10};
	int ves[] = {6, 3, 4};
	for (int i = 0; i < M; i++)
	{
		cout << name[i] << ", " << cost[i] << ", " << ves[i] << endl;
	}

	int** A = new int* [M + 1]; // Матрица для хранения максимальной стоимости предметов
	for (int i = 0; i < M + 1; i++)
	{
		A[i] = new int[N + 1];
	}

	for (int i = 0; i < M + 1; i++)
	{
		for (int j = 0; j < N + 1; j++)
		{
			A[i][j] = 0;
		}
	}

	for (int i = 1; i < M + 1; i++)
	{
		for (int j = 1; j < N + 1; j++)
		{
			if (j < ves[i - 1])
			{
				A[i][j] = A[i - 1][j]; // Если вес предмета больше вместимости рюкзака, то стоимость предмета не учитывается
			}
			else
			{
				A[i][j] = max(A[i - 1][j], A[i - 1][j - ves[i - 1]] + cost[i - 1]);
			}
		}
	}
	cout << "Максимальная стоимость предметов, положенных в рюкзак: " << A[M][N] << "\n"
		<< "Предметы, положенные в рюкзак: \n";
	int i = M, j = N;
	while (i > 0 && j > 0)
	{
		if (A[i][j] != A[i - 1][j])
		{
			cout << name[i - 1] << "\n";
			j -= ves[i - 1];
		}
		i--;
	}
	cout << endl;
	for (int i = 0; i < M + 1; i++)
	{
		delete[] A[i];
	}
	delete[] A;
}