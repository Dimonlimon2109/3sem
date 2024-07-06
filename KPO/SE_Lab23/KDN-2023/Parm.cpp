#include "Parm.h"
#include "Error.h"
#include <cwchar>
#include <iostream>

namespace Parm {
	PARM getparm(int argc, wchar_t* argv[]) {
		bool isIn = 0, isOut = 0, isLog = 0, writeRules = 0;
		PARM parms;
		parms.writeRules = 0;
		for (int i = 1; i < argc; i++) {
			if (wcslen(argv[i]) > PARM_MAX_SIZE) {
				throw ERROR_THROW(104);
			}
			if (wcsstr(argv[i], PATH_IN)) {
				isIn = 1;
				wcscpy_s(parms.in, argv[i] + 4);
			}
			if (wcsstr(argv[i], PATH_OUT)) {
				isOut = 1;
				wcscpy_s(parms.out, argv[i] + 5);
			}
			if (wcsstr(argv[i], PATH_LOG)) {
				isLog = 1;
				wcscpy_s(parms.log, argv[i] + 5);
			}
			if (wcsstr(argv[i], L"writeRules")) {
				writeRules = 1;
			}
		};
		if (!isIn) {
			throw ERROR_THROW(100);
		}
		if (!isOut) {
			wcscpy_s(parms.out, parms.in);
			parms.out[wcslen(parms.out) - 4] = '\0';
			wcscat_s(parms.out, PARM_OUT_DEFAULT_EXT);
		}
		if (!isLog) {
			wcscpy_s(parms.log, parms.in);
			parms.log[wcslen(parms.log) - 4] = '\0';
			wcscat_s(parms.log, PARM_LOG_DEFAULT_EXT);
		}
		if (writeRules) {
			parms.writeRules = true;
		}
  		return parms;
	}
}