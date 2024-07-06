.586P														; ������� ������ (��������� Pentium)
.MODEL FLAT, STDCALL										; ������ ������, ���������� � �������
includelib kernel32.lib										; ������������: ����������� � kernel32

ExitProcess PROTO : DWORD									; �������� ������� ��� ���������� �������� Windows
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD		; �������� API-������� MessageBoxA

.STACK 4096													; ��������� �����

.CONST														; ������� ��������

.DATA														; ������� ������
MB_OK	EQU	0											; EQU ���������� ���������
STR1	DB	"SE_Asm02",	0									; ������, ������ ������� ������ + ������� ���
STR2	DB	"��������� �������� = ", 0						; ������, ������ ������� ������ + ������� ���
HW		DD	?												; ������� ����� ������ 4 �����, ������������������

NUM01	DD	3
NUM02	DD	2

.CODE														; ������� ����

main PROC													; ����� ����� main
START	:													; �����
	   
	   mov eax, 0h

	   add eax, NUM01
	   add eax, NUM02
	   add eax, 30h
	   

	   mov [STR2 + 21], al

	   INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK

	push - 1												; ��� �������� �������� Windows(�������� ExitProcess)
	call ExitProcess										; ��� ����������� ����� ������� Windows
main ENDP													; ����� ���������
			
end main													; ����� ������ main