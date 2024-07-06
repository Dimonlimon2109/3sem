#pragma once
#define PARM_IN L"-in:" // ключ для файла исходного кода
#define PARM_OUT L"-out:" // ключ для файла объектного кода
#define PARM_LOG L"-log:" // ключ для файла журнала
#define PARM_MAX_SIZE 300 // максимальная длина строки параметра 
#define PARM_OUT_DEFAULT_EXT L".out" // расширение файла объектного кода по умолчанию
#define PARM_LOG_DEFAULT_EXT L".log" // расширение файла протокола по умолчанию

namespace Parm // обработка входных параметров
{
	struct PARM // входные параметры
	{
		wchar_t in[PARM_MAX_SIZE]; // -in: имя исходного файла
		wchar_t out[PARM_MAX_SIZE]; // -out: имя объектного файла
		wchar_t log[PARM_MAX_SIZE]; // -log: имя протокола
	};

	// int _tmain(int argc, _TCHAR* argv[])
	PARM getparm(int argc, wchar_t* argv[]); // сформировать struct PARM на основе функции  main
};