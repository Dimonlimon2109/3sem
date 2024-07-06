#define _CRT_SECURE_NO_WARNINGS
#include "In.h"
#include "Error.h"
#include "LT.h"
#include "IT.h"
#include <fstream>
#include <iostream>

using namespace std;

namespace In {
	IN getin(wchar_t infile[]) {
		std::wifstream fin(infile);
		if (!fin) {
			throw ERROR_THROW(110);
		}
		fin.imbue(std::locale("ru_RU.UTF-8"));
		fin >> std::noskipws;
		fin.seekg(0, std::ios_base::end);
		int size = (int)fin.tellg();
		fin.seekg(0, std::ios_base::beg);
		if (size > IN_MAX_LEN_TEXT) {
			ERROR_THROW(112);
		}
		IN in;
		in.size = 0;
		in.lines = 1;
		in.ignor = 0;
		in.text = new wchar_t[size];
		LEXEM lexem;
		char* lexemContainer = new char[MAX_LEXEM_LENGTH];
		int lexemContainerLen = 0;

		int col = 1;
		wchar_t prev;
		wchar_t ch;
		while (fin >> ch) {
			if (ch == L' ' && prev == L' ') {
				continue;
			}
			if (fin.fail()) {
				break;
			}
			wchar_t wstr[3]{};
			wstr[0] = ch;
			char str[3]{};
			wcstombs(str, wstr, sizeof(wstr));
			int ich = (int)str[0];
			if (ich < 0) {
				ich = ich + 256;
			}
			if (ch != '\n')
			{
				in.text[in.size] = ch;
			}
			else
			{
				in.text[in.size] = '|';
			}
			switch (in.code[ich]) {
			case IN::T: {
				col++;
				in.size++;
				if (lexemContainerLen == 0) {
					lexem.line = in.lines;
					lexem.col = col;
				}
				if (lexemContainerLen > MAX_LEXEM_LENGTH - 1) {
					throw ERROR_THROW_IN(113, in.lines, col);
				}
				lexemContainer[lexemContainerLen] = str[0];
				lexemContainerLen++;
				break;
			}
			case IN::F: {
				col++;
				throw ERROR_THROW_IN(111, in.lines, col);
				break;
			}
			case IN::I: {
				in.ignor++;
				break;
			}
			case IN::SPACE: {
				in.size++;
				col++;
				if (lexemContainerLen != 0) {
					lexemContainer[lexemContainerLen] = '\0';
					lexemContainerLen++;
					lexem.lexem = new char[lexemContainerLen];
					for (int i = 0; i < lexemContainerLen; i++) {
						lexem.lexem[i] = lexemContainer[i];
					}
					in.lexems.push_back(lexem);
					delete[] lexemContainer;
					lexemContainer = new char[MAX_LEXEM_LENGTH];
					lexemContainerLen = 0;
				}
				break;
			}
			case IN::SINGLE: {
				in.size++;
				col++;
				if (lexemContainerLen != 0) {
					lexemContainer[lexemContainerLen] = '\0';
					lexemContainerLen++;
					lexem.lexem = new char[lexemContainerLen];
					for (int i = 0; i < lexemContainerLen; i++) {
						lexem.lexem[i] = lexemContainer[i];
					}
					in.lexems.push_back(lexem);
					delete[] lexemContainer;
					lexemContainer = new char[MAX_LEXEM_LENGTH];
					lexemContainerLen = 0;
				}
				lexemContainer[0] = str[0];
				lexemContainer[1] = '\0';
				lexemContainerLen = 2;
				lexem.line = in.lines;
				lexem.col = col;
				lexem.lexem = new char[lexemContainerLen];
				for (int i = 0; i < lexemContainerLen; i++) {
					lexem.lexem[i] = lexemContainer[i];
				}
				in.lexems.push_back(lexem);
				delete[] lexemContainer;
				lexemContainer = new char[MAX_LEXEM_LENGTH];
				lexemContainerLen = 0;
				break;
			}
			case IN::LINE: {
				in.size++;
				in.lines++;
				col = 0;
				if (lexemContainerLen != 0) {
					lexemContainer[lexemContainerLen] = '\0';
					lexemContainerLen++;
					lexem.lexem = new char[lexemContainerLen];
					for (int i = 0; i < lexemContainerLen; i++) {
						lexem.lexem[i] = lexemContainer[i];
					}
					in.lexems.push_back(lexem);
					delete[] lexemContainer;
					lexemContainer = new char[MAX_LEXEM_LENGTH];
					lexemContainerLen = 0;
				}
				break;
			}
			case IN::C: {
				in.size++;
				col++;
				if (lexemContainerLen != 0) {
					lexemContainer[lexemContainerLen] = '\0';
					lexemContainerLen++;
					lexem.lexem = new char[lexemContainerLen];
					for (int i = 0; i < lexemContainerLen; i++) {
						lexem.lexem[i] = lexemContainer[i];
					}
					in.lexems.push_back(lexem);
					delete[] lexemContainer;
					lexemContainer = new char[MAX_LEXEM_LENGTH];
					lexemContainerLen = 0;
				}
				int cur = 0;
				wchar_t* text = new wchar_t[TI_STR_MAXSIZE];
				text[0] = '\"';
				wchar_t ch;
				do {
					fin >> ch;
					in.text[in.size] = ch;
					cur++; col++; in.size++;
					if (cur - 1 > TI_STR_MAXSIZE) {
						throw ERROR_THROW_IN(118, in.lines, col);
					}
					text[cur] = ch;
				} while (ch != L'\"');
				text[cur + 1] = L'\0';
				char* stringLexem = new char[TI_STR_MAXSIZE];
				int stringLexemLen = cur + 2;
				wcstombs(stringLexem, text, cur + 2);
				if (stringLexemLen != 0) {
					lexem.lexem = new char[stringLexemLen];
					for (int i = 0; i < stringLexemLen; i++) {
						lexem.lexem[i] = stringLexem[i];
					}
					in.lexems.push_back(lexem);
					delete[] stringLexem;
				}
				break;
			}
			default: {
				ERROR_THROW(1);
				break;
			}
			}
			prev = ch;
		}
		fin.close();
		return in;
	}
}