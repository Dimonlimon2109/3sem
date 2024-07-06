#pragma once
#include "In.h"
#include "Parm.h"
#include "Error.h"

namespace Out {
	void WriteOut(In::IN in, Parm::PARM parms);
	void WriteError(Error::ERROR err, Parm::PARM parms);
}