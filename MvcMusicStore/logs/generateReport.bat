SET logFile=2020-04-19.log
.\LogParser.exe -i "TEXTLINE" file:totalReportScript.sql?file=%logFile% -o "CSV" -filemode 1 -headers OFF
.\LogParser.exe -i "TEXTLINE" file:errorsReportScript.sql?file=%logFile% -o "CSV" -filemode 0 -headers ON