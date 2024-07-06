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
//a, b, c, d, e, f, g, h, i, l, m, n, o, p, r, s, t, u, x, y, z, {, }, (, ), ;, =, +, *, ,, ', 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, ������
		IN()
		{
			code['a'] = code['b'] = code['c'] = code['d'] = code['e'] = code['f'] = code['g'] = code['h'] = code['i'] =
				code['l'] = code['m'] = code['n'] = code['o'] = code['p'] = code['r'] = code['s'] = code['t'] = code['u'] = 
				code['x'] = code['y'] = code['z'] = code['{'] = code['}'] = code['('] = code[')'] = code[';'] = code['='] =
				code['+'] = code['*'] = code[','] = code['\''] = code['0'] = code['1'] = code['2'] = code['3'] = code['4'] = code['5'] =
				code['6'] = code['7'] = code['8'] = code['9'] = code['0'] = code[234] = code[238] = code[237] = code[242] = code[240] =
				code[235] = code[252] = code[251] = code[233] = code[' '] = code[239] = code[232] = code[236] = code[229]= code[241] = IN::T;
		}
	};

	IN getin(wchar_t infile[]);
}