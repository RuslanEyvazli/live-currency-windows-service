prompt #meterpreter# 

cls

echo 'installing .......'

cd C:\Windows\Microsoft.NET\Framework\v4.0.30319

set srvPath=C:\Users\rusey\source\repos\LiveCurrencyWindowsService\LiveCurrencyWindowsService\bin\Debug

installutil %srvPath%\LiveCurrencyWindowsService.exe

pause

