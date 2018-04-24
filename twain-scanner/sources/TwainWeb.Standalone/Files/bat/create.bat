@echo off
set serv=TWAIN
@echo Пересоздаем сервис %serv%
@echo ============================
@echo.

cd %~dp0
cd..\..
cd bin\Debug

sc stop %serv%
sc delete %serv%
sc create %serv% binPath= "%CD%\TwainWeb.Standalone.exe" DisplayName= "My %serv%" type= own  start= auto
sc start %serv%

@echo.
@pause