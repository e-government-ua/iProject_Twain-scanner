@echo off
set serv=TWAIN@Web
@echo ���ᮧ���� �ࢨ� TWAIN@Web
@echo ============================
@echo.

@set @x=0; /*
@cscript /e:jscript "%~f0"
@exit */

oShell = new ActiveXObject("WScript.Shell");
myDir = oShell.CurrentDirectory;
uShortcut = oShell.CreateShortcut(oShell.SpecialFolders("Desktop") + "\\%serv%.lnk");
uShortcut.TargetPath = myDir + "\\TwainWeb.Standalone.exe";
uShortcut.Arguments = "run";
uShortcut.WorkingDirectory = myDir;
//uShortcut.HotKey = "CTRL+ALT+SHIFT+C";
// uShortcut.Description = "";
// uShortcut.IconLocation = "";
// uShortcut.WindowStyle = 1;       // �⨫� ����: 1-���筮�; 3-�������⮥; 7-�����⮥
uShortcut.Save();
 