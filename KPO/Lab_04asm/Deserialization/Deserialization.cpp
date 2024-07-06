#pragma once
#include "Deserialization.h"

namespace Deserialization {
	void Deserialize(char* filePath) {

		ifstream reader(filePath);
		string type_bool = "0x01";
		string type_char = "0x02";
		int var_count = 0;
		if (reader.is_open()) {
			ofstream out("D:\\study\\3_sem\\KPO\\Lab_04asm\\Lab_04\\asm4.asm");
			if (out.is_open()) {
				out ASM_HEAD;

				while (!reader.eof()) {
					string buff;
					reader >> buff;
					bool resultBool = 0;
					char* resultChar = nullptr;
					if (buff.substr(0, 4).c_str() == type_bool)
					{
						buff.erase(0, 6);
						sscanf_s(buff.c_str(), "%hhd", &resultBool);
						var_count++;
						std::string name = "var" + std::to_string(var_count);
						out << name << " db " << std::hex << resultBool << "h\n";
					}
					if (buff.substr(0, 4).c_str() == type_char)
					{
						buff.erase(0, 6);
						int charLength;
						sscanf_s(buff.substr(0, 2).c_str(), "%x", &charLength);
						buff.erase(0, 2);

						resultChar = new char[charLength];
						string buffChar;

						for (unsigned char i = 0; i < charLength; i++) {
							buffChar = buff.substr(0, 4);
							buff.erase(0, 4);
							sscanf_s(buffChar.c_str(), "%x", &resultChar[i]);
						}
						var_count++;
						std::string name = "var" + std::to_string(var_count);
						out << name << " DB \"" << resultChar << "\", 0" << "\n";
					}
				}
				out ASM_FOOTER;
				reader.close();
				out.close();
			}
			else {
				std::cout << "Не удалось открыть файл для записи исходного кода\n";
			}
		}
		else {
			std::cout << "Не удалось открыть файл для чтения\n";
		}
	}
	/*ofstream fileAsm("D:\\study\\3_sem\\KPO\\Lab_04asm\\Lab_04\\asm4.asm");
	string str;
	if (!reader.is_open()) {
		cout << "Не удалось открыть файл." << endl;
		return;
	}

	bool resultBool = 0;
	char* resultChar = nullptr;
	string type_bool = "0x01";
	string type_char = "0x02";
	while (!reader.eof())
	{
		string buff;
		reader >> buff;
		if (buff.substr(0, 4).c_str() == type_bool)
		{
			buff.erase(0, 6);
			sscanf_s(buff.c_str(), "%hhd", &resultBool);
		}
		if (buff.substr(0, 4).c_str() == type_char)
		{
			buff.erase(0, 6);
			int charLength;
			sscanf_s(buff.substr(0, 2).c_str(), "%x", &charLength);
			buff.erase(0, 2);

			resultChar = new char[charLength];
			string buffChar;

			for (unsigned char i = 0; i < charLength; i++) {
				buffChar = buff.substr(0, 4);
				buff.erase(0, 4);
				sscanf_s(buffChar.c_str(), "%x", &resultChar[i]);
			}
		}
	}

	reader.close();*/
}