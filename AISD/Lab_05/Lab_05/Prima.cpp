#include <Windows.h>
#include <iostream>
using namespace std;
#define V 8

void PrimaFunct();
void Kraskl();
int interconnected(int i);
void unionCompos(int i, int j);
int infCost = 10000;
int visited[V];
int number_of_edges();


int Matrix[V][V] =
{
    {0, 2, 0, 8, 2, 0, 0, 0 },
    {2, 0, 3, 10, 5, 0, 0, 0},
    {0, 3, 0, 0, 12, 0, 0, 7},
    {8, 10, 0, 0, 14, 3, 1, 0},
    {2, 5, 12, 14, 0, 11, 4, 8},
    {0, 0, 0, 3, 11, 0, 6, 0},
    {0, 0, 0, 1, 4, 6, 0, 9},
    {0, 0, 7, 0, 8, 0, 9, 0}
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    PrimaFunct();
    Kraskl();
}

void PrimaFunct()
{
    cout << "Алгоритм Прима: \n";
    bool visited[V];
    for (int i = 0; i < V; i++)
    {
        visited[i] = false;
    }
    visited[0] = true;

    for (int l = 0; l < number_of_edges(); l++) {
        int minHor = infCost;
        int minVer = infCost;
        for (int i = 0; i < V; i++)
        {
            if (visited[i])
            {
                for (int j = 0; j < V; j++)
                {
                    if (!visited[j] && Matrix[i][j] > 0 && (minVer == infCost || Matrix[i][j] < Matrix[minVer][minHor]))
                    {
                        minVer = i, minHor = j;
                    }
                }
            }
        }
        visited[minHor] = true;
        cout << minVer + 1 << ' ' << minHor + 1 << endl;
    }
    cout << "\n\n";
}

void Kraskl()
{
    int min;
    int edgesCount = 0;
    for (int i = 0; i < V; i++)
    {
        visited[i] = i;
    }

    while (edgesCount < number_of_edges())
    {
        min = infCost;
        int a = infCost, b = infCost;
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                if (interconnected(i) != interconnected(j) && Matrix[i][j] < min && Matrix[i][j] != 0)
                {
                    min = Matrix[i][j];
                    a = i;
                    b = j;
                }
            }
        }
        unionCompos(a, b);
        edgesCount++;
        cout << a + 1 << "---" << b + 1 << endl;
    }
}

int interconnected(int i)
{
    while (visited[i] != i)
    {
        i = visited[i];
    }
    return i;
}

void unionCompos(int i, int j)
{
    int a = interconnected(i);
    int b = interconnected(j);
    visited[a] = b;
}

int number_of_edges()
{
    int count = 0;
    for (int i = 0; i < V; i++)
    {
        for (int j = 0; j < V; j++)
        {
            if (Matrix[i][j] > 0)
                count++;
        }
    }
    return count / 2 - (count / 2 - V + 1);
}