.586P
.model flat, stdcall
option casemap :none
includelib kernel32.lib
includelib SE_Asm01a.lib
includelib SE_Asm01d.lib
includelib libucrt.lib
ExitProcess PROTO : DWORD
GetStdHandle PROTO : DWORD
WriteConsoleA PROTO : DWORD, : DWORD, : DWORD, : DWORD, : DWORD
int_to_char PROTO : DWORD, : SDWORD
.const
MyStr byte "getmin + getmax = ", 0
.data
consolehandle dd 0h
myNums dd 3, 1, 3, 4, 5, 6, 7, 8, 9, 10
mas byte 12 dup(0)
x SDWORD ?
.code
EXTRN getmin : proc
EXTRN getmax : proc
main PROC
	push lengthof myNums
	push offset myNums
	call getmin
	mov ebx, eax
	push lengthof myNums
	push offset myNums
	call getmax
	add eax, ebx
	mov x, eax
	push -11
	call GetStdHandle
	mov consolehandle, eax
	push 0
	push 0
	push sizeof MyStr
	push offset MyStr
	push consolehandle
	call WriteConsoleA
	push x
	push offset mas
	call int_to_char
	push 0
	push 0
	push sizeof mas
	push offset mas
	push consolehandle
	call WriteConsoleA
	
push -1
call ExitProcess
main ENDP
end