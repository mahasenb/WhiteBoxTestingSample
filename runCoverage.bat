REM IIS Express Executable
SET IISExecutable=%PROGRAMFILES%\IIS Express\iisexpress.exe

@ECHO OFF
REM Get OpenCover Executable
for /R "%userprofile%\.nuget\packages" %%a in (*) do if /I "%%~nxa"=="OpenCover.Console.exe" SET OpenCoverExe=%%~dpnxa

REM Get Report Generator
for /R "%userprofile%\.nuget\packages" %%a in (*) do if /I "%%~nxa"=="ReportGenerator.exe" SET ReportGeneratorExe=%%~dpnxa

@ECHO ON

REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"

SET targetAppConfig=%~dp0.vs\config\applicationhost.config
SET targetDir=%~dp0TargetApplication\bin\Debug\netcoreapp2.1

set LAUNCHER_ARGS=-p "C:\Program Files\dotnet\dotnet.exe" -a "exec ""C:\Users\mahas\Repositories\Personal\SeleniumMeetup\WhiteBoxTesting\TargetApplication\bin\Debug\netcoreapp2.1\TargetApplication.dll"""
set LAUNCHER_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\Extensions\Microsoft\Web Tools\ProjectSystem\VSIISExeLauncher.exe

call :RunIISWithOpenCover
exit /b %errorlevel%

:RunIISWithOpenCover
"%OpenCoverExe%" ^
 -register:user ^
 -filter:"+[TargetApplication*]* +[TargetLibrary*]* -[TargetApplication.Tests*]*" ^
 -targetdir:"%targetDir%" ^
 -output:"%~dp0GeneratedReports\CoverageReport.xml" ^
 -target:"%IISExecutable%" ^
 -targetargs:"/config:%targetAppConfig% /site:TargetApplication" ^
 -oldstyle

"%ReportGeneratorExe%" ^
 -reports:"%~dp0GeneratedReports\CoverageReport.xml" ^
 -targetdir:"%~dp0GeneratedReports\Output"

start "report" "%~dp0GeneratedReports\Output\index.htm"