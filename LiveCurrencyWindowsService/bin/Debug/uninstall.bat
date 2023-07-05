prompt #meterpreter# 

cls

echo 'uninstalling .......'

cd C:\Windows\Microsoft.NET\Framework\v4.0.30319

set srvPath=C:\Users\rusey\source\repos\LiveCurrencyWindowsService\LiveCurrencyWindowsService\bin\Debug

installutil -u %srvPath%\LiveCurrencyWindowsService.exe

pause

