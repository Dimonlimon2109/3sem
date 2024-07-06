#pragma once
#define IN_MAX_LEN_TEXT 1024*1024 // ������������ ������ ��������� ����
#define IN_CODE_ENDL '\n' // ������ ����� ������

// ������� �������� ������� ����������, ������ = ��� (Windows-1251) �������
// �������� IN::F - ����������� ������, IN::T = ����������� ������, IN::I - ������������ (�� �������),
// ���� 0 <= �������� < 256 - �� �������� ������ ��������

#define MAX_LEN_LINE 1000
namespace In
{
	void dell_in(char* str, int index);
	struct IN
	{
		enum
		{
			T = 1024, // ���������� ������
			F = 2048, // ������������
			I = 4096 // ������������, ����� ��������
		};

		int size, // ������ ��������� ����
			lines, // ���������� �����
			ignore; // ���������� ����������������� ��������

		unsigned char* text; // �������� ���(Windows-1251);

		int code[256] =
		{
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 0
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 16
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 32
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 48
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 64
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 80
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 96
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 112

			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 128
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 144
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 160
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 176
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 192
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 208
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 224
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F
		}; // ������� ��������: T, F, I ����� ��������

		IN()
		{ //   ������     0          2          4         D           M           I         T         R          Y
			code[32] = code[48] = code[50] = code[52] = code[68] = code[77] = code[73] = code[84] = code[82] = code[89]
				//   K         H           A          C         O           N
				= code[75] = code[72] = code[65] = code[67] = code[79] = code[78] =
				//     d         m            i            t           r          y
				code[100] = code[109] = code[105] = code[116] = code[114] = code[121] =
				//    k          h           a            c           o          n 
				code[107] = code[104] = code[97] = code[99] = code[111] = code[110] =
				//     �           �           �           �           �             �
				code[196] = code[204] = code[200] = code[210] = code[208] = code[201] =
				//  �          �           �           �            �           �           �  
				code[213] = code[192] = code[215] = code[197] = code[205] = code[206] = code[202] =
				//   �         �           �            �          �           �
				code[228] = code[236] = code[232] = code[242] = code[240] = code[233] = 
				//  �          �           �            �          �           �           �
				code[245] = code[224] = code[247] = code[229] = code[237] = code[238] = code[234] = IN::T;

			code[192] = '-';
			code[88] = IN::I;
		}
	};

	IN getin(wchar_t infile[]);
}