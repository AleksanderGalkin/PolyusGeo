

var AutoConnect = function ()
{
    try {
  
          // начало. Раздел определяет текущий год и месяц для установки каталога для резульатов по умолчанию

        oScript = new ActiveXObject("DatamineStudio.ScriptHelper");
        oScript.initialize(window);
        oDmApp = oScript.getApplication();
        if (oDmApp == null || oDmApp.ActiveProject == null)    //Attempt to Use the Active Datamine Session
        {
            alert("There are no active Studio3 projects open.\n Please open a Studio 3 project before continuing.");
            window.close();                                                     // Closes the script window
            return false;
        }
        else
        {
            str_Prj_Folder = oDmApp.ActiveProject.Folder;
            return true;
        }
    } 
    catch(e) {
        alert("Failed\nReason: " + e.description);
        if ( oDmApp) oDmApp.Quit(); // release the session to close it down
    }	
    return false;		
}