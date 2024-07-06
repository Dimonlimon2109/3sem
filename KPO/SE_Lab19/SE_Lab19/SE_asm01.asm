.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib SE_Asm01a.lib
ExitProcess PROTO : DWORD
getmin PROTO : DWORD, : DWORD
getmax PROTO : DWORD, : DWORD
.STACK 4096
.CONST
.data
myNums dd 3, 2, 3, 4, 5, 6, 7, 8, 9, 10
.CODE

main PROC
	push offset myNums
	push lengthof myNums
	call getmin
	push offset myNums
	push lengthof myNums
	call getmax
	
push -1
call ExitProcess
main ENDP
end main
