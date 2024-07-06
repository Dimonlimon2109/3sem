#pragma once
#define LEXEMA_FIXSIZE 1
#define LT_MAXSIZE 4096
#define LT_TI_NULLIDX 0xffffffff
#define LEX_INTEGER 't'
#define LEX_STRING 't'
#define LEX_ID 'i'
#define LEX_LITERAL 'l'
#define LEX_FUNCTION 'f'
#define LEX_DECLARE 'd'
#define LEX_RETURN 'r'
#define LEX_PRINT 'p'
#define LEX_MAIN 'm'
#define LEX_SEMICOLON ';'
#define LEX_COMMA ','
#define LEX_LEFTBRACE '{'
#define	LEX_RIGHTBRACE '}'
#define LEX_LEFTHESIS '('
#define LEX_RIGHTHESIS ')'
#define LEX_PLUS 'v'
#define LEX_MINUS 'v'
#define LEX_START 'v'
#define LEXT_DIRSLASH 'v'

namespace LT {
	struct Entry {
		char lexema;
		int sn;
		int cn;
		int idxTI;
		char data;

		Entry(
			char lexema,
			int sn,
			int cn,
			int idxTI
			) {
			this->lexema = lexema;
			this->sn = sn;
			this->cn = cn;
			this->idxTI = idxTI;
		};

		Entry() = default;
	};

	struct LexTable {
		int maxsize;	
		int size;
		Entry* table;
	};
	LexTable Create(int size);
	void Add(
			  LexTable& lextable,
			  Entry entry
			);
	Entry GetEntry(
				   LexTable& lextable,
				   int n
				  );
	void Delete(LexTable& lextable);
}