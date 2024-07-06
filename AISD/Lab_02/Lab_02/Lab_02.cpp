#include <iostream>
#include <queue>

using namespace std;

const int N = 10;
bool* visited = new bool[N];

//матрица смежности графа
int graph[N][N] =
{
{0, 1, 0, 0, 1, 0, 0, 0, 0, 0},
{1, 0, 0, 0, 0, 0, 1, 1, 0, 0},
{0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
{0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
{1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
{0, 0, 0, 1, 1, 0, 0, 0, 1, 0},
{0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
{0, 1, 1, 0, 0, 0, 1, 0, 0, 0},
{0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
{0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
};
//поиск в глубину
void DFS(int beg)
{
	cout << beg + 1 << " ";
	visited[beg] = true;

	for (int r = 0; r <= N; r++) {
		if ((graph[beg][r] != 0) && (!visited[r]))
			DFS(r);
	}
}

//поиск в ширину
void BFS(int start)
{
	queue <int> q; // очередь для хранения номеров вершин
	bool visited[N]; //false - вершина не рассмотрена, true - рассмотрена
	bool inqueue[N]; //false - вершина не в очереди, true - в очереди
	int view_cell; // номер посещаемой вершины


	for (int i = 0; i < N; i++)
	{
		visited[i] = inqueue[i] = false;
	}

	q.push(start); // записываем начальную вершину в очередь
	visited[start] = inqueue[start] = true; //рассмотрели первую вершину

	while (!q.empty())
	{
		view_cell = q.front(); //обращение к первому элементу очереди
		cout << view_cell + 1 << " ";

		visited[view_cell] = true;
		q.pop();

		for (int i = 0; i < N; i++)
		{
			if (!inqueue[i] && graph[view_cell][i])
			{
				q.push(i);
				inqueue[i] = true;
			}
		}
	}
}

int main()
{
	setlocale(LC_ALL, "Rus");
	cout << "Матрица смежности графа: " << endl;
	for (int i = 0; i < N; i++)
	{
		visited[i] = false;
		for (int j = 0; j < N; j++)
			cout << " " << graph[i][j];
		cout << endl;
	}
	//список ребер
	cout << "\n-----------------------------" << endl;
	cout << "\nСписок рёбер: " << endl;
	int arr_1[11] = {1,1,2,2,3,4,4,5,6,7,9};
	int arr_2[11] = { 2,5,7,8,8,6,9,6,9,8,10 };
	for (int i = 0; i < N; i++)
	{
		cout << '{' << arr_1[i] << ", " << arr_2[i] << '}';
		cout << '{' << arr_2[i] << ", " << arr_1[i] << '}' << endl;
	}	//список смежности
	cout << "\n-----------------------------" << endl;
	cout << "\nСписок смежности: " << endl;
	int arr_3[N][N] =
	{ {2,5}, {7,8}, {8}, {6,9}, {1,6}, {4,5,9}, {1,2,8}, {2,3,7},{4,6,10},{9} };
	for (int i = 0; i < N; i++)
	{
		cout << i << "->";
		for (int j = 0; j < N; j++)
		{
			if (arr_3[i][j] == 0)
				break;
			cout << arr_3[i][j] << " ";
		}
		cout << endl;
	}

	cout << endl;

	int start;
	cout << "\n" << endl;
	cout << "Поиск в глубину" << endl;
	cout << "Стартовая вершина >> "; cin >> start;
	cout << "Порядок обхода: ";
	DFS(start - 1);
	cout << "\n" << endl;
	cout << "\nПоиск в ширину" << endl;
	cout << "Стартовая вершина >> "; cin >> start;
	cout << "Порядок обхода: ";
	BFS(start - 1);
	delete[]visited;
	cout << endl;
	return 0;
}