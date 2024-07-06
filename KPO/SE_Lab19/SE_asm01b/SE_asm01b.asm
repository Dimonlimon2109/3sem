.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib SE_Asm01a.lib
ExitProcess PROTO : DWORD
GetStdHandle PROTO : DWORD
WriteConsoleA PROTO : DWORD, : DWORD, : DWORD, : DWORD, : DWORD
int_to_char PROTO : DWORD, : SDWORD
getmin PROTO : DWORD, : DWORD
getmax PROTO : DWORD, : DWORD
.STACK 4096
.CONST
MyStr byte "getmin + getmax = ", 0
.data
consolehandle dd 0h
myNums dd 3, 1, 3, 4, 5, 6, 7, 8, 9, 10
mas byte 12 dup(0)
x SDWORD ?

.code
main PROC
	mov ebx, 0
	push offset myNums
	push lengthof myNums
	call getmin
	add ebx, eax
	push offset myNums
	push lengthof myNums
	call getmax
	add ebx, eax
	push -11
	call GetStdHandle
	mov consolehandle, eax
	push 0
	push 0
	push sizeof MyStr
	push offset MyStr
	push consolehandle
	call WriteConsoleA
	mov x, ebx
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
end main
