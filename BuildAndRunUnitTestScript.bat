@echo off

"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe" .\PractumTest.sln /p:Configuration=Debug

"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\MSTest.exe" /testcontainer:.\UnitTestPractum\bin\debug\UnitTestPractum.dll

pause
