.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA

MB_OK	EQU 0
HW		DD ?
var1 db 1h
var2 db 0h
var3 DB "abcdef", 0
var4 DB "ghzxc", 0
.CODE

main PROC

START: 
	INVOKE MessageBoxA, HW, OFFSET var3, OFFSET var4, MB_OK
	push -1
	call ExitProcess
main ENDP
end main
