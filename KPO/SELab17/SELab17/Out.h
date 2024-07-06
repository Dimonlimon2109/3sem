#pragma once

#include "stdafx.h"

namespace Out {

	struct OUT								
	{
		wchar_t outFile[PARM_MAX_SIZE];
		std::ofstream* stream;
	};

	static const OUT INITOUT{ L"", NULL };					// ��������� ������ ��� ��������� ������
	OUT getOut(wchar_t outFile[]);							// �������� ��������� ������
	void WriteOut(OUT out, unsigned char* outText);			// ����� ������������� ������ � ������� ����
	void WriteOutError(OUT out, Error::ERROR error);		// ����� ������ � �������� ����
	void Close(OUT out);									// �������� ��������� ������
}