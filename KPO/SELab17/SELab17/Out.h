#pragma once

#include "stdafx.h"

namespace Out {

	struct OUT								
	{
		wchar_t outFile[PARM_MAX_SIZE];
		std::ofstream* stream;
	};

	static const OUT INITOUT{ L"", NULL };					// Начальные данные для выходного потока
	OUT getOut(wchar_t outFile[]);							// Создание выходного потока
	void WriteOut(OUT out, unsigned char* outText);			// Вывод обработанного текста в выодной файл
	void WriteOutError(OUT out, Error::ERROR error);		// Вывод ошибки в выходной файл
	void Close(OUT out);									// Закрытие выходного потока
}