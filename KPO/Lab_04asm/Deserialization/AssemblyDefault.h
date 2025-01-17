#pragma once

#define ASM_HEAD \
<< ".586P" << endl \
<< ".MODEL FLAT, STDCALL" << endl \
<< "includelib kernel32.lib" << endl << endl\
<< "ExitProcess PROTO : DWORD" << endl\
<< "MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD" << endl << endl\
<< ".STACK 4096" << endl << endl\
<< ".CONST" << endl << endl \
<< ".DATA" << endl << endl \
<< "MB_OK\tEQU 0" << endl\
<< "HW\t\tDD ?" << endl

#define ASM_FOOTER \
<< ".CODE" << endl << endl \
<< "main PROC" << endl << endl \
<< "START: " << endl\
<< "\tINVOKE MessageBoxA, HW, OFFSET var3, OFFSET var4, MB_OK" << endl\
<< "\tpush -1" << endl \
<< "\tcall ExitProcess" << endl \
<< "main ENDP" << endl\
<< "end main" << endl	
