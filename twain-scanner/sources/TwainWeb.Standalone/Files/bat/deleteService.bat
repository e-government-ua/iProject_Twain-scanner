@echo off
set serv=TWAIN
@echo ����塞 �ࢨ�
@echo ====================
@echo.

sc stop %serv%
sc delete %serv%


sc query | findstr /i "%serv%"

IF ERRORLEVEL 1 (GOTO NOTEXIST) ELSE GOTO EXIST
:NOTEXIST
@echo ��ࢨ� %serv% �� �������
GOTO ENDGOTO

:EXIST

::�����஢騪 ����� ����� ������� SC QUERY schedule, � �� �㤥� ࠡ���� �����. 
::�஢����, ����饭� �� �㦡�, ����� �� ������ ��ப� RUNNING ��� STOPPED:
sc query schedule | find "RUNNING"

sc stop %serv%
sc delete %serv%
@echo �ᯥ� :) �ࢨ� %serv% �� 㤠���

:ENDGOTO
@echo.


@pause