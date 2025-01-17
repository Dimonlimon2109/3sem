#pragma once

#define PATH_IN L"-in:"
#define PATH_OUT L"-out:"
#define PATH_LOG L"-log:"
#define PARM_MAX_SIZE 300
#define PARM_OUT_DEFAULT_EXT L".out"
#define PARM_LOG_DEFAULT_EXT L".log"

namespace Parm {
	struct PARM {
		wchar_t in[PARM_MAX_SIZE];
		wchar_t out[PARM_MAX_SIZE];
		wchar_t log[PARM_MAX_SIZE];
		bool writeRules;
	};
	PARM getparm(int argc, wchar_t* argv[]);
}

