cscript %WINDIR%\System32\Printing_Admin_Scripts\en-US\Prnport.vbs -a -r IP_192.168.1.200 -h 192.168.1.200 -o raw -n 9100
rundll32 printui.dll,PrintUIEntry /ia /m "HP Universal Printing PCL 6" /f "C:\PrinterInf\hpcu118c.inf"
rundll32 printui.dll,PrintUIEntry /if /b “HP PRINTER1” /f "C:\PrinterInf\hpcu118c.inf" /r "IP_192.168.1.200” /m "HP Universal Printing PCL 6"