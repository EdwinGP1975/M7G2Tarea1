@echo ON
if [%1]==[] goto todo
cucumber.bat %* --retry 2 -f pretty -f junit -out %CD%\ut
goto :eof
:todo
cucumber.bat .\features\Cargar_fixtures\* .\features\Productos\* .\features\Cliente\* .\features\_Ventas\* --retry 2 -f pretty -f junit -out %CD%\ut