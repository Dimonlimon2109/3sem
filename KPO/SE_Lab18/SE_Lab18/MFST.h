#pragma once
#include <stack>
#include "GRB.h"
#include "LT.h"
#include "LEX.h"
#include "Log.h"

#define MFST_DIAGN_NUMBER 3


typedef std::stack<short> MFSTSTSTACK;
namespace MFST {
	struct MfstState {
		short lenta_position;
		short nrulechain;
		MFSTSTSTACK st;
		MfstState();
		MfstState(
				  short pposition,
				  MFSTSTSTACK pst,
				  short pnrulechain
		);
	};

	struct Mfst {
		enum RC_STEP {
					  NS_OK,
					  NS_NORULE,
					  NS_NORULECHAIN,
					  NS_ERROR,
					  TS_OK,
					  TS_NOK,
					  LENTA_END,
					  SURPRISE
		};

		struct MfstDiagnosis {
			short lenta_position;
			RC_STEP rc_step;
			short nrule;
			short nrule_chain;
			MfstDiagnosis();
			MfstDiagnosis(
						  short plenta_position,
						  RC_STEP prc_step,
						  short pnrule,
						  short pnrule_chain
			);
		} diagnosis[MFST_DIAGN_NUMBER];

		GRBALPHABET* lenta;
		short lenta_position;
		short nrule;
		short nrulechain;
		short lenta_size;
		Log::LOG log;
		GRB::Greibach grebach;
		LEX::LEX lex;
		MFSTSTSTACK st;
		std::stack<MfstState> storestate;
		Mfst();
		Mfst(
			LEX::LEX plex,
			GRB::Greibach pgrebach,
			Log::LOG &plog
		);
		char* getCSt(char* buf);
		char* getCLenta(char* buf, short pos, short n = 25);
		char* getDiagnosis(short n, char* buf);
		bool savestate();
		bool reststate();
		bool push_chain(GRB::Rule::Chain chain);
		RC_STEP step();
		bool start();
		bool savediagnosis(RC_STEP pprc_step);
	};
}