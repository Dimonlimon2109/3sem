#include "stdafx.h"
namespace Out {

	OUT getOut(wchar_t outFile[])
	{
		OUT out = INITOUT;

		out.stream = new std::ofstream(outFile);

		if (!out.stream)
			throw ERROR_THROW(112);

		return out;
	};

	void WriteOut(OUT out, unsigned char* outText) {

		if ((*out.stream).is_open()) {
			(*out.stream) << outText;
		}
	}

	void WriteOutError(OUT out, Error::ERROR error) {
		if (error.id != 100)
		{
			(*out.stream) << "Ошибка " << error.id << ": " << error.message << " "
				<< "строка " << error.inext.line << ", позиция: " << error.inext.col << std::endl;
		}
	}

	void Close(OUT out)
	{
		out.stream->close();
	}
}