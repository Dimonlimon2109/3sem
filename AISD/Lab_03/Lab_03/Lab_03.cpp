#include <iostream>
using namespace std;
#define V 9

void Dijkstra(int GR[V][V], int st, char vertex[])
{
	int distance[V], index, u;
	bool visited[V];
	for (int i = 0; i < V; i++)
	{
		distance[i] = INT_MAX;
		visited[i] = false;
	}
	distance[st] = 0;
	for (int count = 0; count < V - 1; count++)
	{
		int min = INT_MAX;
		for (int i = 0; i < V; i++)
		{
			if (!visited[i] && distance[i] <= min)
			{
				min = distance[i]; index = i;
			}
		}
		u = index;
		visited[u] = true;
		for (int i = 0; i < V; i++)
		{
			if (!visited[i] && GR[u][i] && distance[u] != INT_MAX && distance[u] + GR[u][i] < distance[i])
				distance[i] = distance[u] + GR[u][i];
		}
	}
	cout << "Кратчайшие расстяния ко всем вершинам от заданной:\n";
	for (int i = 0; i < V; i++)
	{
			cout << vertex[st] << " > " << vertex[i] << " = " << distance[i] << endl;
	}
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int start;
	int GR[V][V] = {
			{0, 7, 10, 0, 0, 0, 0, 0, 0},
			{7, 0, 0, 0, 0, 9, 27, 0, 0},
			{10, 0, 0, 0, 31, 8, 0, 0, 0},
			{0, 0, 0, 0, 32, 0, 0, 17, 21},
			{0, 0, 31, 32, 0, 0, 0, 0, 0},
			{0, 9, 8, 0, 0, 0, 0, 11, 0},
			{0, 27, 0, 0, 0, 0, 0, 0, 15},
			{0, 0, 0, 17, 0, 11, 0, 0, 15},
			{0, 0, 0, 21, 0, 0, 15, 15, 0} };
	char start_vert;
	char letters[V] = {'A','B','C','D','E','F','G','H','I'};
	cout << "Введите начальную вершину:"; cin >> start_vert;
	for (int i = 0; i < V; i++)
	{
		if (start_vert == letters[i])
		{
			start = i;
		}
	}
	Dijkstra(GR, start, letters);
	return 0;
}