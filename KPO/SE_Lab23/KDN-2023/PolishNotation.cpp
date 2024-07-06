#include <iostream>
#include <stack>
#include <vector>
#include "LT.h"
#include "IT.h"
#include "LEX.h"
#include "Error.h"

namespace PolishNotation {

	template <typename T>
	struct container : T
	{
		using T::T;
		using T::c;
	};

	int get_priority(char a)
	{
		switch (a)
		{
		case '(':
			return 0;
		case ')':
			return 0;
		case ',':
			return 1;
		case '-':
			return 2;
		case '+':
			return 2;
		case '*':
			return 3;
		case '/':
			return 3;
		default: {
			return 0;
		}
		}
	}

	bool ContainsElement(std::stack<char> stack, int size, char elem) {
		for (int i = 0; i < size; i++)
			if (stack.top() == elem)
				return true;
			else
				stack.pop();
		return false;
	}

	std::string toString(int n) {
		char buf[5];
		sprintf_s(buf, "%d", n);
		return buf;
	}

	void FixLT(LT::LexTable& lextable, const std::string& str, int length, int pos, std::vector<int>& ids) {
		std::cout << str << std::endl;
		for (int i = 0, q = 0; i < str.size(); i++) {
			lextable.table[pos + i].lexema = str[i];
			if (lextable.table[pos + i].lexema == LEX_ID || lextable.table[pos + i].lexema == LEX_LITERAL) {
				lextable.table[pos + i].idxTI = ids[q];
				q++;
			}
			else
				lextable.table[pos + i].idxTI = LT_TI_NULLIDX;
		}
		int temp = str.size() + pos;
		for (int i = 0; i < length - str.size(); i++) {
			lextable.table[temp + i].idxTI = LT_TI_NULLIDX;
			lextable.table[temp + i].lexema = '#';
			lextable.table[temp + i].sn = -1;
		}
	}

	bool PolishNotation(int pos, LT::LexTable& lextable, IT::IdTable& idtable) {
		container<std::stack<char>> stack;
		std::string PolishString;
		std::vector<int> ids;
		int operators_count = 0, operands_count = 0, iterator = 0, right_counter = 0, left_counter = 0, params_counter = 0;

		for (int i = pos; i < lextable.size; i++, iterator++) {
			char lexem = lextable.table[i].lexema;
			char data = lextable.table[i].data;
			size_t stack_size = stack.size();
			if (lextable.table[i].idxTI != -1) {
				if (idtable.table[lextable.table[i].idxTI].idtype == IT::IDTYPE::F) {
					stack.push('@');
					operands_count--;
				}
			}
			switch (lexem) {
			case LEX_PLUS:
			{
				if (!stack.empty() && stack.top() != LEX_LEFTHESIS) {
					while (!stack.empty() && get_priority(data) <= get_priority(stack.top())) {
						PolishString += stack.top();
						stack.pop();
					}
				}
				stack.push(data);
				operators_count++;
				break;
			}
			case LEX_COMMA:
			{
				while (!stack.empty()) {
					if (stack.top() == LEX_LEFTHESIS)
						break;
					PolishString += stack.top();
					stack.pop();
				}
				operands_count--; 
				break;
			}
			case LEX_LEFTHESIS:
			{
				left_counter++;
				stack.push(lexem);
				break;
			}
			case LEX_RIGHTHESIS:
			{
				right_counter++;
				if (!ContainsElement(stack, stack_size, LEX_LEFTHESIS))
					return false;
				while (stack.top() != LEX_LEFTHESIS) {
					PolishString += stack.top();
					stack.pop();
				}
				stack.pop();
				if (!stack.empty() && stack.top() == '@') {
					PolishString += stack.top() + toString(params_counter - 1);
					params_counter = 0;
					stack.pop();
				}
				break;
			}
			case LEX_SEMICOLON:
			{
				if (operators_count != 0 && operands_count != 0)
					if ((!stack.empty() && (stack.top() == LEX_RIGHTHESIS || stack.top() == LEX_LEFTHESIS))
						|| right_counter != left_counter || operands_count - operators_count != 1)
						return false;
				while (!stack.empty()) {
					PolishString += stack.top();
					stack.pop();
				}
				FixLT(lextable, PolishString, iterator, pos, ids);
				return true;
				break;
			}
			case LEX_ID: {
				if (std::find(stack.c.begin(), stack.c.begin(), '@') != stack.c.end())
					params_counter++;
				PolishString += lexem;
				if (lextable.table[i].idxTI != LT_TI_NULLIDX)
					ids.push_back(lextable.table[i].idxTI);
				operands_count++;
				break;
			}
			case LEX_LITERAL: {
				if (std::find(stack.c.begin(), stack.c.begin(), '@') != stack.c.end())
					params_counter++;
				PolishString += lexem;
				if (lextable.table[i].idxTI != LT_TI_NULLIDX)
					ids.push_back(lextable.table[i].idxTI);
				operands_count++;
				break;
			}
			}
		}
		return true;
	}

	void CreatePolishTable(LEX::LEX& t) {
		for (int i = 0; i < t.lextable.size; i++)
			if (t.lextable.table[i].lexema == LEX_PLUS)
				if (!PolishNotation(i + 1, t.lextable, t.idtable))
					throw ERROR_THROW(129);
		for (int i = 0; i < t.lextable.size; i++)
			if (t.lextable.table[i].lexema == '+' || t.lextable.table[i].lexema == '-' || t.lextable.table[i].lexema == '*' ||
				t.lextable.table[i].lexema == '/' || t.lextable.table[i].lexema == '\\' || t.lextable.table[i].lexema == ':' ||
				t.lextable.table[i].lexema == '%')
			{
				t.lextable.table[i].data = t.lextable.table[i].lexema;
				t.lextable.table[i].lexema = LEX_PLUS;
			}
	}
}