#include "Serialization.h"

namespace Serialization {
	void Serialize(char* filePath, bool* boolean, int size) {

		fstream writer(filePath, ios::out);

		if (!writer.is_open()) {
			cout << "Не удалось открыть файл." << endl;
			return;
		}
		for (int i = 0; i < size; i++)
		{
			writer << "0x01" << "0x" << setfill('0') << setw(2) << hex << boolean[i];
			writer << '\n';
		}

		writer.close();
	}

	void Serialize(char* filePath, char symbols[][10], int size, int sizes[]) {

		fstream writer(filePath, ios::app);

		if (!writer.is_open()) {
			cout << "Не удалось открыть файл." << endl;
			return;
		}
		for (int j = 0; j < size; j++)
		{
			if (sizes[j] > 10)
			{
				cout << "Размер одного из массивов больше 10" << endl;
				return;
			}
			writer << "0x02" << "0x" << setfill('0') << setw(2) << hex << sizes[j];

			for (unsigned char i = 0; i < sizes[j]; i++) {
				writer << "0x" << setfill('0') << setw(2) << hex << (int)symbols[j][i];
			}
			writer << '\n';
		}
		writer.close();
	}
	
}