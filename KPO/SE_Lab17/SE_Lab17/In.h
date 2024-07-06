#pragma once
#include <vector>

#define IN_MAX_LEN_TEXT 1024*1024
#define IN_CODE_ENDL '\n'
#define MAX_LEXEM_LENGTH 16

#define IN_CODE_TABLE {\
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::SPACE, IN::LINE, IN::F, IN::F, IN::F, IN::F, IN::F,\
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
	IN::SPACE, IN::F, IN::C, IN::F, IN::F, IN::F, IN::F, IN::F, IN::SINGLE, IN::SINGLE, IN::SINGLE, IN::SINGLE, IN::SINGLE, IN::SINGLE, IN::SINGLE, IN::SINGLE,\
	IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::F, IN::SINGLE, IN::F, IN::SINGLE, IN::F, IN::F,\
	IN::F, IN::T, IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F,\
	IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::F, IN::I, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
	IN::F, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,\
	IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::SINGLE, IN::F, IN::SINGLE, IN::F, IN::F,\
																												   \
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
	  '-', IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::F,\
	IN::T, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
	IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::F,\
	IN::T, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
}
namespace In {
	struct LEXEM {
		int line;
		int col;
		char* lexem;
	};
	struct IN {
		enum {C = 64, LINE = 128, SINGLE = 256, SPACE = 512, T = 1024, F = 2048, I = 4096};
		int size;
		int lines;
		int ignor;
		wchar_t* text;
		int code[256] = IN_CODE_TABLE;
		std::vector<LEXEM> lexems;
	};
	IN getin(wchar_t infile[]);
}