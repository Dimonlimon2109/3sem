#include "IT.h"
#include "LT.h"
#include "LEX.h"
#include "Error.h"

namespace SA {

	void operands(LEX::LEX lex) {
		for (int i = 0; i < lex.lextable.size; i++) {
			if (lex.lextable.table[i].lexema == LEX_PLUS)
			{
				if (lex.lextable.table[i].data == '=') {
					int cur = -1;
					IT::IDDATATYPE datatype = (IT::IDDATATYPE)0;
					while (lex.lextable.table[i + cur].lexema != LEX_SEMICOLON) {
						if (lex.lextable.table[i + cur].lexema == LEX_ID || lex.lextable.table[i + cur].lexema == LEX_LITERAL)
						{
							if (datatype == (IT::IDDATATYPE)0) {
								datatype = lex.idtable.table[lex.lextable.table[i + cur].idxTI].iddatatype;
							}
							else {
								if (datatype != lex.idtable.table[lex.lextable.table[i + cur].idxTI].iddatatype) {
									throw ERROR_THROW_IN(703, lex.lextable.table[i + cur].sn, lex.lextable.table[i + cur].cn)
								}
							}
							if (lex.idtable.table[lex.lextable.table[i + cur].idxTI].idtype == IT::F) {
								while (lex.lextable.table[i + cur].lexema != LEX_RIGHTHESIS) {
									cur++;
								}
							}
						}
						if (datatype == IT::STR && lex.lextable.table[i + cur].lexema == LEX_PLUS && cur != 0 && lex.lextable.table[i + cur].data != '+') {
							throw ERROR_THROW_IN(704, lex.lextable.table[i + cur].sn, lex.lextable.table[i + cur].cn)
						}
						if (datatype == IT::CHR && lex.lextable.table[i + cur].lexema == LEX_PLUS && cur != 0 && lex.lextable.table[i + cur].data != '+' && lex.lextable.table[i + cur].data != '-') {
							throw ERROR_THROW_IN(704, lex.lextable.table[i + cur].sn, lex.lextable.table[i + cur].cn)
						}
						cur++;
					}
					i += cur - 1;
				}
			}
		}
	}

	void functions(LEX::LEX lex) {
		for (int i = 0; i < lex.lextable.size; i++) {
			if (lex.lextable.table[i].lexema == LEX_ID && lex.idtable.table[lex.lextable.table[i].idxTI].idtype == IT::F && lex.lextable.table[i - 3].lexema == LEX_DECLARE)
			{
				int cur = 1;
				IT::IDDATATYPE returnType = lex.idtable.table[lex.lextable.table[i].idxTI].iddatatype;
				while (lex.lextable.table[i + cur].lexema != LEX_RETURN) {
					cur++;
				}
				if ((lex.lextable.table[i + cur + 1].lexema == LEX_ID || lex.lextable.table[i + cur + 1].lexema == LEX_LITERAL)
					&& lex.idtable.table[lex.lextable.table[i + cur + 1].idxTI].idtype != IT::F
					&& lex.idtable.table[lex.lextable.table[i + cur + 1].idxTI].iddatatype != returnType)
					throw ERROR_THROW_IN(700, lex.lextable.table[i + cur].sn, lex.lextable.table[i + cur].cn)
			}
		}
		for (int i = 0; i < lex.lextable.size; i++) {
			if (lex.lextable.table[i].lexema == LEX_PRINT && lex.idtable.table[lex.lextable.table[i + 1].idxTI].idtype == IT::F) {
				throw ERROR_THROW_IN(700, lex.lextable.table[i + 1].sn, lex.lextable.table[i + 1].cn)
			}
			
			if (lex.lextable.table[i].lexema == LEX_ID && lex.idtable.table[lex.lextable.table[i].idxTI].idtype == IT::F && lex.lextable.table[i - 3].lexema == LEX_DECLARE) {
				IT::IDDATATYPE* ids = new IT::IDDATATYPE[16];
				int idsSize = 0;
				int funcPos = lex.idtable.table[lex.lextable.table[i].idxTI].idxfirstLE;
				while (lex.lextable.table[funcPos + 1].lexema != LEX_RIGHTHESIS)
				{
					if (lex.lextable.table[funcPos + 1].lexema == LEX_ID || lex.lextable.table[funcPos + 1].lexema == LEX_LITERAL) {
						ids[idsSize] = lex.idtable.table[lex.lextable.table[funcPos + 1].idxTI].iddatatype;
						idsSize++;
					}
					funcPos++;
					if (idsSize == 16) {
						throw ERROR_THROW_IN(705, lex.lextable.table[i].sn, lex.lextable.table[i].cn);
					}
				}
			}
			if (lex.lextable.table[i].lexema == LEX_ID && lex.idtable.table[lex.lextable.table[i].idxTI].idtype == IT::F && lex.lextable.table[i - 3].lexema != LEX_DECLARE)
			{
				IT::IDDATATYPE* ids = new IT::IDDATATYPE[16];
				int idsSize = 0;
				int funcPos = lex.idtable.table[lex.lextable.table[i].idxTI].idxfirstLE;
				if (lex.lextable.table[i + 1].lexema != LEX_LEFTHESIS) {
					throw ERROR_THROW_IN(706, lex.lextable.table[i].sn, lex.lextable.table[i].cn)
				}
				while (lex.lextable.table[funcPos + 1].lexema != LEX_RIGHTHESIS)
				{
					if (lex.lextable.table[funcPos + 1].lexema == LEX_ID || lex.lextable.table[funcPos + 1].lexema == LEX_LITERAL) {
						ids[idsSize] = lex.idtable.table[lex.lextable.table[funcPos + 1].idxTI].iddatatype;
						idsSize++;
					}
					funcPos++;
					if (idsSize == 16) {
						throw ERROR_THROW_IN(705, lex.lextable.table[i].sn, lex.lextable.table[i].cn);
					}
				}
				int cur = 1;
 				int paramCount = 0;
				while (lex.lextable.table[i + cur].lexema != LEX_RIGHTHESIS) {
					if (lex.lextable.table[i + cur].lexema == LEX_ID || lex.lextable.table[i + cur].lexema == LEX_LITERAL) {
						if (lex.idtable.table[lex.lextable.table[i + cur].idxTI].iddatatype != ids[paramCount]) {
							throw ERROR_THROW_IN(702, lex.lextable.table[i + cur].sn, lex.lextable.table[i + cur].cn)
						}
						paramCount++;
					}
					cur++;
				}
				if (paramCount != idsSize) {
					throw ERROR_THROW_IN(701, lex.lextable.table[i + cur].sn, lex.lextable.table[i + cur].cn)
				}
				i += cur;
				delete[] ids;
			}
		}
	}

	bool startSA(LEX::LEX lex) {
		functions(lex);
		operands(lex);
		return true;
	};

}
