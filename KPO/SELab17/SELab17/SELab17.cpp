#include "stdafx.h"
#include <locale>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	Log::LOG log = Log::INITLOG;
	Out::OUT out = Out::INITOUT;
	//try
	//{
	//	Parm::PARM parm = Parm::getparm(argc, argv);
	//	wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << endl << endl;
	//}
	//catch (Error::ERROR e)
	//{
	//	cout << "ID: " << e.id << " Сообщение: " << e.message << " Строка: " << e.inext.line << " Позиция:" << e.inext.col << endl;
	//}
	//cout << "---- тест getin----" << endl;
	//try
	//{
	//	Parm::PARM parm = Parm::getparm(argc, argv);
	//	Out::OUT out = Out::getOut(parm.out);
	//	In::IN in = In::getin(parm.in);
	//	cout << in.text << endl;
	//	cout << "Всего символов: " << in.size << endl;
	//	cout << "Всего строк: " << in.lines << endl;
	//	cout << "Пропущено: " << in.ignore << endl;
	//	Out::WriteOut(out, in.text);
	//	Out::Close(out);
	//}
	//catch (Error::ERROR e)
	//{
	//	cout << "ID: " << e.id << " Сообщение: " << e.message << " Строка: " << e.inext.line << " Позиция:" << e.inext.col << endl;
	//}
	//cout << "-------------------------------------------------------------------------" << endl;

	//try
	//{
	//	Parm::PARM parm = Parm::getparm(argc, argv);
	//	log = Log::getlog(parm.log);
	//	Log::WriteLine(log, (char*)"Тест", (char*)" без ошибок \n", "");
	//	Log::WriteLine(log, (wchar_t*)L"Тест", (wchar_t*)L" без ошибок \n", L"");
	//	Log::WriteLog(log);
	//	Log::WriteParm(log, parm);
	//	In::IN in = In::getin(parm.in);
	//	Log::WriteIn(log, in);
	//	Log::Close(log);
	//}
	//catch (Error::ERROR e)
	//{
	//	Log::WriteError(log, e);
	//};
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);
		log = Log::getlog(parm.log);
		Log::WriteLine(log, (char*)"Тест: ", (char*)"ввод анализируемых строк из входного файла, заданного параметром –in:\n", "");
		Log::WriteLog(log);
		Log::WriteParm(log, parm);
		In::IN in = In::getin(parm.in);
		Log::WriteIn(log, in);
		Log::Close(log);
	}
	catch (Error::ERROR e)
	{
		Log::WriteError(log, e);
		Log::Close(log);
	}
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);
		out = Out::getOut(parm.out);
		In::IN in = In::getin(parm.in);
		Out::WriteOut(out, in.text);
		Out::Close(out);
	}
	catch (Error::ERROR e)
	{
		Out::WriteOutError(out, e);
		Out::Close(out);
	}
	system("pause");
	return 0;
}; 