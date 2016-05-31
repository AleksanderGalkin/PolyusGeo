

var AutoConnect = function ()
{
    try {
  
          // начало. Раздел определяет текущий год и месяц для установки каталога для резульатов по умолчанию
        var now= new Date();
        var nowYear=now.getFullYear();
        var nowMonth=now.getMonth()+1;

        document.getElementById('y'+nowYear).selected=true;
        document.getElementById('m'+nowMonth).selected=true;

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
            return true;
        }
    } 
    catch(e) {
        alert("Failed\nReason: " + e.description);
        if ( oDmApp) oDmApp.Quit(); // release the session to close it down
    }	
    return false;		
}