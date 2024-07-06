
extern "C" {
	int getmin(int* mas, int len)
	{
		int min = mas[0];
		for (int i = 0; i < len; i++) {
			if (mas[i] < min) {
				min = mas[i];
			}
		}
		return min;
	}

	int getmax(int* mas, int len)
	{
		int max = mas[0];
		for (int i = 0; i < len; i++) {
			if (mas[i] > max) {
				max = mas[i];
			}
		}
		return max;
	}
}
