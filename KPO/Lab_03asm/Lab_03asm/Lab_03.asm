.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO :DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA
	myBytes BYTE 10h, 20h, 30h, 40h					; 1 ����
	myWords WORD 8Ah, 3Bh, 44h, 5Fh, 99h			; 2 �����
	myDoubles DWORD 1, 2, 3, 4, 5, 6				; 4 �����
	myPointer DWORD myDoubles						; 4 �����

	massive DWORD 1, 2, 3, 4, 5, 6, 7				; ������ �� 7 �����, ��� ������� �)
	sum DWORD 0							; ����� ��������� �������, ��� ������� �)
	
	STR1 DB "zxc", 0			
	STR2 DB "���� ������� �������", 0 
	STR3 DB "�������� �������� �� �������", 0 

.CODE

main PROC
start: 
    mov EDI, 4
	mov AX, [myWords + EDI]
	mov BX, myWords[0]

	;��������� ����� ��������� �������. ��������� ��������� � �������� EAX.
	mov ESI, OFFSET massive
	mov ECX, lengthof massive						; ������ �������
	mov EBX, 1
CYCLE:
	mov EAX, [ESI]									; EAX = massive[ESI], ESI = massive[0]
	add sum, EAX							; sumOfElements = sumOfElements + EAX, ��������� ��, ��� � EAX
	add ESI, type massive							; +4 �����
	cmp EAX, 0										; ���� ���������
	jz ZERO
	loop CYCLE										; --ECX, if (ECX != 0) goto CYCLE
	jmp ALLOK

ZERO:
	mov EBX, 0	
	jz ZD1

ALLOK:
	mov eax, sum	
	jnz ZD2


ZD1:
	INVOKE MessageBoxA, 0, OFFSET Str2, OFFSET Str1, 0

ZD2:
	INVOKE MessageBoxA, 0, OFFSET Str3, OFFSET Str1, 0

	
push -1
call ExitProcess

main ENDP

end main