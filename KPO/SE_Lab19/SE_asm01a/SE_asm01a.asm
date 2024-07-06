.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib libucrt.lib
ExitProcess PROTO : DWORD
.STACK 4096
.CONST
.data
myNums dd 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
.CODE

getmin PROC arr:DWORD, len:DWORD
	mov esi, len
	mov eax, [esi]
	mov ecx, arr
	L1:
		cmp eax, [esi]
		jle L2
		mov eax, [esi]
	L2:
		add esi, 4
		loop L1
		ret 8;

getmin ENDP

getmax PROC arr:DWORD, len:DWORD
	mov esi, len
	mov eax, [esi]
	mov ecx, arr
	L1:
		cmp eax, [esi]
		jae L2
		mov eax, [esi]
	L2:
		add esi, 4
		loop L1
		ret 8;

getmax ENDP

int_to_char PROC pstr : dword, intfield : sdword
	mov edi, pstr ; �������� �� pstr � edi
	mov esi, 0 ; ���������� �������� � ���������� 
	mov eax, intfield ; ����� -> � eax
	cdq ; ���� ����� ���������������� � eax �� edx
	mov ebx, 10 ; ��������� ������� ��������� (10) -> ebx
	idiv ebx ; eax = eax/ebx, ������� � edx (������� ����� �� ������)
	test eax, 80000000h ; ��������� �������� ���
	jz plus ; ���� ������������� ����� - �� plus
	neg eax ; ����� ������ ���� eax
	neg edx ; edx = -edx
	mov cl, '-' ; ������ ������ ���������� '-'
	mov[edi], cl ; ������ ������ ���������� '-'
	inc edi ; ++edi
	plus : ; ���� ���������� �� �������� 10
	push dx ; ������� -> ����
	inc esi ; ++esi
	test eax, eax ; eax == ?
	jz fin ; ���� ��, �� �� fin
	cdq ; ���� ���������������� � eax �� edx 
	idiv ebx ; eax = eax/ebx, ������� � edx
	jmp plus ; ����������� ������� �� plus
	fin : ; � ecx ���-�� �� 0-��� �������� = ���-�� �������� ����������
	mov ecx, esi
	write : ; ���� ������ ����������
	pop bx ; ������� �� ����� -> bx
	add bl, '0' ; ������������ ������ � bl
	mov[edi], bl ; bl -> � ���������
	inc edi ; edi++
	loop write ; ���� (--ecx)>0 ������� �� write
	ret
int_to_char ENDP


end 
