function btnHelp_onclick() {
    var features = "status=no,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes";
    var common = "_blank"
    var installpath = oDmApp.Options.HelpFolder;
    installpath = installpath.replace(" ", "%20");
    var helpcommand = "mk:@MSITStore:" + installpath + "/DatamineStudio.chm::/Studio_3_General/Concept_Studio%203%20Scripting%20Overview.htm";
    window.open(helpcommand, common, features);
}
function btnSetSample_Ok($scope) {
    try {

        var try100times = 1;
        var old_pointstring = "";
        alert("Указывайте скважины нажатием ПКМ");
        oDmApp.ParseCommand("deselect-all-points"); //отменяет выделение точек
        var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points"); //получаем слой с нужным именем
        if (ol_kol == null)															// если такого слоя нет, то
            var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points (points)");    // получаем слой с нужным именем, который был сохранен в файл (об этом говорит фраза "(points)")

        if (ol_kol != null) { 																								 // если опять нет такого слоя, то

            ol_kol3D = ol_kol.Ew3DObject;   // получаем ссылку на объект слоя
        }
        else {
            alert("Слой 'dh_points' или 'dh_points (points)' не найден")
            return;
        }



        oDmApp.ActiveProject.Data.SetCurrentPointsObject(ol_kol3D); //  устанавливаем нужный слой с точками текущим

        ovPTNS = oDmApp.ActiveProject.Design.GetCurrentPointsObject(false); // еще раз получаем слой с точками установленный текущим
        //ovSTNS = oDmApp.ActiveProject.Design.GetCurrentStringsObject(false); // получаем слой с линиями установленный текущим
        ovPTNS.PointsStyle = 0x2c;											// Устанавливаем символ точки (окружность с точкой внутри)
        ovPTNS.Color = 0xcca533;											// Устанавливаем цвет точки
        ovPTNS.PointsSize = 0xc8;											// Устанавливаем размер точки
        ovPTNS.PointsMode = 0x0;											// Устанавливаем системные настройки точки (без легенды)
        ovPTNS.ColorMode = 0x0;											// Устанавливаем системные настройки цвета (без легенды)

        ovPTNS.FormatLabels.InitLabels(4, 1)							// выделяем количество ячееек
        ovPTNS.FormatLabels.SetAt(1, "S_SAMP")
        ovPTNS.FormatLabels.SetAt(2, "COL_SAMP")
        ovPTNS.FormatLabels.SetAt(3, "BHID")
        ovPTNS.FormatLabels.SetTextPosition(3);							// расположение label относительно точки (3-слева)
        ovPTNS.FormatLabels.SetTextFontHeight(1, 1000);					// размер шрифта
        ovPTNS.FormatLabels.SetTextColor(1, 0xF0FFF0);					// белый цвет надписи
        ovPTNS.FormatLabels.SetTextFontHeight(2, 800);					// размер шрифта
        ovPTNS.FormatLabels.SetTextColor(2, 0x884533);					// белый цвет надписи
        ovPTNS.FormatLabels.SetTextFontHeight(3, 500);					// размер шрифта
        ovPTNS.FormatLabels.SetTextColor(3, 0xcca533);					// белый цвет надписи
        oDmApp.ParseCommand("redraw-display");

        //oDmApp.ParseCommand("add-attributes"); 			// Добавление аттрибута через интерфейс
        //ovPTNS.ObjectData.Schema.AddColumn("KOL", 2, 0);	// Добавление аттрибута KOL программно
        var try100times = 1;
        while (try100times <= 100) {
            oDmApp.ActiveProject.Design.Selection.PickPoint("Pick Point");  		// Комманда ожидает указания ьышью точки на экране
            var pointstring = oDmApp.ActiveProject.Design.Selection.PointString; // получаем координту отмеченной точки

            if (old_pointstring.slice(0, old_pointstring.lastIndexOf(",")) == pointstring.slice(0, pointstring.lastIndexOf(","))
                && old_ViewCentreX == oDmApp.ActiveProject.Design.ViewDef.ViewCentreX
                && old_ViewCentreY == oDmApp.ActiveProject.Design.ViewDef.ViewCentreY
                && old_ViewCentreZ == oDmApp.ActiveProject.Design.ViewDef.ViewCentreZ) break;  // если пользователь нажал ESС то значение старой точки = значению новой точки, значит выходим из скрипта

            if (old_pointstring.slice(0, old_pointstring.lastIndexOf(",")) == pointstring.slice(0, pointstring.lastIndexOf(","))
                && (old_ViewCentreX != oDmApp.ActiveProject.Design.ViewDef.ViewCentreX
                || old_ViewCentreY != oDmApp.ActiveProject.Design.ViewDef.ViewCentreY
                || old_ViewCentreZ != oDmApp.ActiveProject.Design.ViewDef.ViewCentreZ)) {

                old_ViewCentreX = oDmApp.ActiveProject.Design.ViewDef.ViewCentreX;
                old_ViewCentreY = oDmApp.ActiveProject.Design.ViewDef.ViewCentreY;
                old_ViewCentreZ = oDmApp.ActiveProject.Design.ViewDef.ViewCentreZ;
                oDmApp.ParseCommand("redraw-display");
                continue;

            }

            // str = "new-points " + pointstring;
            //oDmApp.ParseCommand(str);					// создаём новую точку
            //oDmApp.ParseCommand("cancel-command");

            //ovSTNS.IsShown = false;						// скрываем слой строк, чтобы назначаемые аттрибуты присвоились точкам, а не строкам (как иногда бывает)

            
            str_S_SAMP = Number($scope.dtm.startSample);

            str_COL_SAMP = Number($scope.dtm.numSample);
            str = "edit-attributes " + pointstring + " @attribute='S_SAMP'," + str_S_SAMP;

            old_pointstring = pointstring;
            old_ViewCentreX = oDmApp.ActiveProject.Design.ViewDef.ViewCentreX;
            old_ViewCentreY = oDmApp.ActiveProject.Design.ViewDef.ViewCentreY;
            old_ViewCentreZ = oDmApp.ActiveProject.Design.ViewDef.ViewCentreZ;

            oDmApp.ParseCommand(str);
            oDmApp.ParseCommand("cancel-command");
            str = "edit-attributes " + pointstring + " @attribute='COL_SAMP'," + str_COL_SAMP;
            old_pointstring = pointstring;
            oDmApp.ParseCommand(str);
            oDmApp.ParseCommand("cancel-command");
            //ovSTNS.IsShown = true;						// показываем слой строк, скрытый ранее
            oDmApp.ParseCommand("redraw-display");		//перерисовываем экран

            try100times++;
            //document.getElementById("S_SAMP").value = Number(S_SAMP) + Number(COL_SAMP);
            $scope.dtm.startSample = Number(str_S_SAMP) + Number(str_COL_SAMP);
        }	//while (try100times <= 100)




        SaveDataToFile();

        var fso_in = new ActiveXObject("Scripting.FileSystemObject"); 

        try {
            if (fso_in.FileExists(str_Prj_Folder + "\\lito_out.dm"))
                fso_in.DeleteFile(str_Prj_Folder + "\\lito_out.dm")
        }
        catch (e) {
            alert("Не могу удалить " + str_Prj_Folder + "\\lito_out.dm" + ". Программа будет остановлена");
            return;
        }


        str_IFile5_Full = oDmApp.ActiveProject.Folder + "\\dh_points.dm"

        if (fso_in.FileExists(str_IFile5_Full)) {

            fso_in.CopyFile(str_IFile5_Full, str_Prj_Folder + "\\lito_out.dm");

        }
        else {
            alert("Не могу переместить. Не найден файл: " + str_IFile5_Full);
            return;
        }

    }
    catch (e) {
        alert("Failed\nReason: " + e.description);
    }
}

function btnShowDh_onclick() {
    try {
        var fso_in = new ActiveXObject("Scripting.FileSystemObject"); // Объект FSO


        if (!(str_IFile1_Full = document.getElementById("iFile1").value)) {
            alert("Выберите входной файл устьев скважин");
            return;
        }

        try {
            if (fso_in.FileExists(oDmApp.ActiveProject.Folder + "\\dh_points.dm"))
                fso_in.DeleteFile(oDmApp.ActiveProject.Folder + "\\dh_points.dm")
        }
        catch (e) {
            alert("Не могу удалить " + oDmApp.ActiveProject.Folder + "\\dh_points.dm" + ". Программа будет остановлена");
            return;
        }
        var pattern_exp = /\.\w{2,3}$/;
        var result = pattern_exp.exec(str_IFile1_Full);
        if (result != null)
            var exp = result[0].substr(1);
        else {
            alert("Неизвестный тип входного файла. Выполнение невозможно");
            return;
        }
        var data = null;
        if (exp == "csv") {
            filehandle = fso_in.OpenTextFile(str_IFile1_Full, 1);
            contents = filehandle.ReadAll();
            filehandle.close();
            var options = new Object();
            options.separator = ";";
            data = $.csv.toObjects(contents, options);
        }
        if (exp == "dm") {
            data = DmFileToObj(str_IFile1_Full);
        }
        oDmApp.ParseCommand("inputd &OUT=dh_points" +
            " 'dh_points'" +
            " 'XCOLLAR'" +
            " 'N'" +
            " 'y'" +
            " '-'" +
            " 'YCOLLAR'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'ZCOLLAR'" +
            " 'n'" +
            " 'y'" +
            " '-'" +
            " 'SYMBOL'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'COLOUR'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'BHID'" +
            " 'A'" +
            " '20'" +
            " 'y'" +
            " '-'" +
            " 'GORIZONT'" +
            " 'A'" +
            " '20'" +
            " 'y'" +
            " '-'" +
            " 'BLOCK'" +
            " 'A'" +
            " '20'" +
            " 'y'" +
            " '-'" +
            " 'HOLE'" +
            " 'A'" +
            " '20'" +
            " 'y'" +
            " '-'" +
            " 'ENDDEPTH'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'LAYER'" +
            " 'A'" +
            " '40'" +
            " 'y'" +
            " '-'" +
            " 'DRILL_TY'" +
            " 'A'" +
            " '20'" +
            " 'y'" +
            " '-'" +
            " 'BRG'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'DIP'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'KOD'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'S_SAMP'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'COL_SAMP'" +
            " 'n'" +
            " 'Y'" +
            " '-'" +
            " 'ERRCOL'" +
            " 'A'" +
            " '80'" +
            " 'y'" +
            " '-'" +
            " 'ERRSUR'" +
            " 'A'" +
            " '80'" +
            " 'y'" +
            " '-'" +
            " 'ERRAS'" +
            " 'A'" +
            " '80'" +
            " 'y'" +
            " '-'" +
            " 'ERRVED'" +
            " 'A'" +
            " '80'" +
            " 'y'" +
            " '-'" +
            " '!'" +
            " 'y'");

        copyRecordsToDmFilesORPoints("dh_points", data);
        oDmApp.ActiveProject.Data.LoadFile(oDmApp.ActiveProject.Folder + "\\dh_points.dm");
        oDmApp.ParseCommand("redraw-display");


    }
    catch (e) {
        alert("Failed\nReason: " + e.description);
        if (oDmApp) oDmApp.Quit(); // release the session to close it down
    }
}

var DmFileToObj = function (filePath) {
    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(filePath, false);
    var data = [];
    var i = 0;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {
        data[i] = new Object();
        data[i].BHID = oDmFile.GetNamedColumn("BHID");
        data[i].XCOLLAR = oDmFile.GetNamedColumn("XCOLLAR");
        data[i].YCOLLAR = oDmFile.GetNamedColumn("YCOLLAR");
        data[i].ZCOLLAR = oDmFile.GetNamedColumn("ZCOLLAR");
        data[i].GORIZONT = oDmFile.GetNamedColumn("GORIZONT");
        data[i].BLOCK = oDmFile.GetNamedColumn("BLOCK");
        data[i].HOLE = oDmFile.GetNamedColumn("HOLE");
        data[i].ENDDEPTH = oDmFile.GetNamedColumn("ENDDEPTH");
        data[i].LAYER = oDmFile.GetNamedColumn("LAYER");
        data[i].DRILL_TY = oDmFile.GetNamedColumn("DRILL_TY");
        data[i].BRG = oDmFile.GetNamedColumn("BRG");
        data[i].DIP = oDmFile.GetNamedColumn("DIP");

    }
    oDmFile.Close();
    return data;
};

var copyRecordsToDmFilesORPoints = function (DhOrPointsDm, DhOrPointsObjects) {
    try {
        var oDmFile = new ActiveXObject("DmFile.DmTableADO");
        oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + DhOrPointsDm + ".dm", false);

        if (DhOrPointsObjects.length == 0) {
            alert("Нет скважин");
            return;
        }

        for (var i = 0 ; i < DhOrPointsObjects.length ; i++) {
            oDmFile.AddRow();
            oDmFile.SetNamedColumn("BHID", DhOrPointsObjects[i].BHID !== null ? DhOrPointsObjects[i].BHID : "");
            oDmFile.SetNamedColumn("XCOLLAR", DhOrPointsObjects[i].XCOLLAR !== null ? Number(DhOrPointsObjects[i].XCOLLAR.toFixed(4)) : 0);
            oDmFile.SetNamedColumn("YCOLLAR", DhOrPointsObjects[i].YCOLLAR !== null ? Number(DhOrPointsObjects[i].YCOLLAR.toFixed(4)) : 0);
            oDmFile.SetNamedColumn("ZCOLLAR", DhOrPointsObjects[i].ZCOLLAR !== null ? Number(DhOrPointsObjects[i].ZCOLLAR.toFixed(4)) : 0);
            oDmFile.SetNamedColumn("GORIZONT", DhOrPointsObjects[i].GORIZONT !== null ? Number(DhOrPointsObjects[i].GORIZONT) : "");
            oDmFile.SetNamedColumn("BLOCK", DhOrPointsObjects[i].BLOCK !== null ? DhOrPointsObjects[i].BLOCK : "");
            oDmFile.SetNamedColumn("HOLE", DhOrPointsObjects[i].HOLE !== null ? DhOrPointsObjects[i].HOLE : "");
            oDmFile.SetNamedColumn("ENDDEPTH", DhOrPointsObjects[i].ENDDEPTH !== null ? Number(DhOrPointsObjects[i].ENDDEPTH) : 0);
            oDmFile.SetNamedColumn("LAYER", DhOrPointsObjects[i].LAYER !== null ? DhOrPointsObjects[i].LAYER : 0);
            oDmFile.SetNamedColumn("DRILL_TY", DhOrPointsObjects[i].DRILL_TY !== null ? DhOrPointsObjects[i].DRILL_TY : 0);
            oDmFile.SetNamedColumn("BRG", DhOrPointsObjects[i].BRG !== null ? Number(DhOrPointsObjects[i].BRG) : 0);
            oDmFile.SetNamedColumn("DIP", DhOrPointsObjects[i].DIP !== null ? Number(DhOrPointsObjects[i].DIP) : 0);
        }


        oDmFile.Close();
    }
    catch (e) {
        alert("Failed\nReason: " + e.description);
        oDmFile.Close();
        if (oDmApp) oDmApp.Quit(); // release the session to close it down
    }
}


var getDhCountInData = function (DhOrPointsDm) {
    var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points"); //получаем слой с нужным именем
    if (ol_kol == null)															// если такого слоя нет, то
        var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points (points)");    // получаем слой с нужным именем, который был сохранен в файл (об этом говорит фраза "(points)")

    if (ol_kol != null) { 																								 // если опять нет такого слоя, то

        ol_kol3D = ol_kol.Ew3DObject;   // получаем ссылку на объект слоя
    }
    else {
        alert("Слой 'dh_points' или 'dh_points (points)' не найден")
        return;
    }
    var ol_kol3D_ObjData = ol_kol3D.ObjectData();

    var cn_X_Coord = ol_kol3D_ObjData.Schema.GetFieldIndex("_X_Coord");
    var cnS_SAMP = ol_kol3D_ObjData.Schema.GetFieldIndex("S_SAMP");
    var cnCOL_SAMP = ol_kol3D_ObjData.Schema.GetFieldIndex("COL_SAMP");
    var count = 0;
    ol_kol3D_ObjData.GetFirstRow()
    for (var i = 1 ; i <= ol_kol3D_ObjData.GetRowCount() ; ol_kol3D_ObjData.GetNextRow(), i++) {
        var cr1 = ol_kol3D_ObjData.GetColumnAsLong(cnS_SAMP);
        var cr2 = ol_kol3D_ObjData.GetColumnAsLong(cnCOL_SAMP);
        var cr3 = ol_kol3D_ObjData.GetColumnAsString(cn_X_Coord);
        if (cr1 != 0 && cr2 != 0 && cr3 != '-') {
            count = count + 1;
        }
    }
    return count;
}

var getSampleCountInData = function (DhOrPointsDm) {
    var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points"); //получаем слой с нужным именем
    if (ol_kol == null)															// если такого слоя нет, то
        var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points (points)");    // получаем слой с нужным именем, который был сохранен в файл (об этом говорит фраза "(points)")

    if (ol_kol != null) { 																								 // если опять нет такого слоя, то

        ol_kol3D = ol_kol.Ew3DObject;   // получаем ссылку на объект слоя
    }
    else {
        alert("Слой 'dh_points' или 'dh_points (points)' не найден")
        return;
    }
    var ol_kol3D_ObjData = ol_kol3D.ObjectData();

    var cn_X_Coord = ol_kol3D_ObjData.Schema.GetFieldIndex("_X_Coord");
    var cnS_SAMP = ol_kol3D_ObjData.Schema.GetFieldIndex("S_SAMP");
    var cnCOL_SAMP = ol_kol3D_ObjData.Schema.GetFieldIndex("COL_SAMP");
    var count = 0;
    ol_kol3D_ObjData.GetFirstRow()
    for (var i = 1 ; i <= ol_kol3D_ObjData.GetRowCount() ; ol_kol3D_ObjData.GetNextRow(), i++) {
        var cr1 = ol_kol3D_ObjData.GetColumnAsLong(cnS_SAMP);
        var cr2 = ol_kol3D_ObjData.GetColumnAsLong(cnCOL_SAMP);
        var cr3 = ol_kol3D_ObjData.GetColumnAsString(cn_X_Coord);
        if (cr1 != 0 && cr2 != 0 && cr3 != '-') {
            count = count + cr2;
        }
    }
    return count;
}

var SaveDataToFile = function () {
    var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points"); //получаем слой с нужным именем
    if (ol_kol == null)															// если такого слоя нет, то
        var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points (points)");    // получаем слой с нужным именем, который был сохранен в файл (об этом говорит фраза "(points)")

    if (ol_kol != null) { 																								 // если опять нет такого слоя, то

        ol_kol3D = ol_kol.Ew3DObject;   // получаем ссылку на объект слоя
    }
    else {
        alert("Слой 'dh_points' или 'dh_points (points)' не найден. Сохранение не возможно")
        return;
    }
    var bEP = oDmApp.ActiveProject.ExtendedPrecision;
    ol_kol3D.SaveAsDatamineFile("dh_points", bEP, true, "");
}

function SetLito($scope) {
    try {
        SaveDataToFile();
        if (!checkDataIsSaved()) {
            return;
        }


        var fso_in = new ActiveXObject("Scripting.FileSystemObject"); // Объект FSO
        try {
            if (fso_in.FileExists(str_Prj_Folder + "\\lito_out.dm"))
                fso_in.DeleteFile(str_Prj_Folder + "\\lito_out.dm")
        }
        catch (e) {
            alert("Не могу удалить " + str_Prj_Folder + "\\lito_out.dm" + ". Программа будет остановлена");
            return;
        }


        var str_Storage_Folder = "\\\\Blg-geo06\\шлюз\\BLAGODATNIY"; // Каталог структурированного хранилища файлов
        var files_names_subfolder = "Litologiya"; // определяет подкаталог хранилища файлов где находятся фиксированные входные файлы
        // список фиксированных входных файлов используемых в работе команд Datamine
        var files_names = new Array("r2kd3tr", "r2kd2tr", "r2kd1tr", "pr1rztr", "minertr", "r2kd3pt", "r2kd2pt", "r2kd1pt", "pr1rzpt", "minerpt", "big_southtr", "big_nordtr", "big_southpt", "big_nordpt", "str");


        var str_IFile_Full;





        //if (!(str_IFile5_Full = document.getElementById("iFile5").value)) {
        //    alert("Выберите входной файл блочной модели");
        //    return;
        //}
        str_IFile5_Full = oDmApp.ActiveProject.Folder + "\\dh_points.dm"


        var str_IFile5_Short_idx_from = str_IFile5_Full.lastIndexOf("\\");


        var str_IFile5_Short_idx_to = str_IFile5_Full.lastIndexOf(".");


        if (str_IFile5_Short_idx_to != -1) {
            var str_IFile5_Short_DM = str_IFile5_Full.slice(str_IFile5_Short_idx_from + 1, str_IFile5_Short_idx_to);
        }
        else {
            var str_IFile5_Short_DM = str_IFile5_Full.slice(str_IFile5_Short_idx_from + 1);
        }
        var str_oFile_Short;

        //if (!(str_oFile_Short_DM = document.getElementById("oFile").value)) {
        //    alert("Выберите выходной файл");
        //    return;
        //}
        str_oFile_Short_DM = "out";
        str_oFile_Short = str_oFile_Short_DM + ".dm";



        var str_oFile_Root = str_Prj_Folder + "\\" + str_oFile_Short;

        //var sel = document.getElementById("OF_Category"); // Получаем наш список
        //var str_OF_Category = sel.options[sel.selectedIndex].text;
        //sel = document.getElementById("OF_Year"); // Получаем наш список
        //var str_OF_Year = sel.options[sel.selectedIndex].text;
        //sel = document.getElementById("OF_Month"); // Получаем наш список
        //var str_OF_Month = sel.options[sel.selectedIndex].text;

        var str_OF_Category = "DRILLHOLES"

        var str_OF_Year = "2015";

        var str_OF_Month = "11";

        var str_oFile_Full = str_Storage_Folder + "\\" + str_OF_Category + "\\" + str_OF_Year + "\\" + str_OF_Month + "." + str_OF_Year + "\\" + str_oFile_Short;
        var fso_in = new ActiveXObject("Scripting.FileSystemObject"); // Объект FSO

        for (i = 0; i < files_names.length; i++) {
            str_I_files_names_Full = str_Prj_Folder + "\\" + files_names_subfolder + "\\" + files_names[i] + ".dm";
            str_I_files_names_Root = str_Prj_Folder + "\\" + files_names[i] + ".dm";
            if (fso_in.FileExists(str_I_files_names_Full))
                fso_in.CopyFile(str_I_files_names_Full, str_I_files_names_Root);
            else {
                alert("Не могу скопировать. Не найден файл: " + str_I_files_names_Full);
                return false;
            }

        }



        oDmApp.ParseCommand("mgsort &IN=" + str_IFile5_Short_DM + " &OUT=1_sort *KEY1=BHID @ORDER=1");
        if (!chkFileInRoot("1_sort", "mgsort")) return;
        oDmApp.ParseCommand("selwf &IN=1_sort &WIRETR=r2kd3tr &WIREPT=r2kd3pt &OUT=kd3 *X=XCOLLAR *Y=YCOLLAR *Z=ZCOLLAR *ATTRIB1=ROCK @SELECT=3 @EXCLUDE=0 @TOLERANC=0.001 @PRINT=0");
        if (!chkFileInRoot("kd3", "selwf")) return;
        oDmApp.ParseCommand("selwf &IN=1_sort &WIRETR=r2kd2tr &WIREPT=r2kd2pt &OUT=kd2 *X=XCOLLAR *Y=YCOLLAR *Z=ZCOLLAR *ATTRIB1=ROCK @SELECT=3 @EXCLUDE=0 @TOLERANC=0.001 @PRINT=0");
        if (!chkFileInRoot("kd2", "selwf")) return;
        oDmApp.ParseCommand("selwf &IN=1_sort &WIRETR=r2kd1tr &WIREPT=r2kd1pt &OUT=kd1 *X=XCOLLAR *Y=YCOLLAR *Z=ZCOLLAR *ATTRIB1=ROCK @SELECT=3 @EXCLUDE=0 @TOLERANC=0.001 @PRINT=0");
        if (!chkFileInRoot("kd1", "selwf")) return;
        oDmApp.ParseCommand("selwf &IN=1_sort &WIRETR=pr1rztr &WIREPT=pr1rzpt &OUT=rz *X=XCOLLAR *Y=YCOLLAR *Z=ZCOLLAR *ATTRIB1=ROCK @SELECT=3 @EXCLUDE=0 @TOLERANC=0.001 @PRINT=0");
        if (!chkFileInRoot("rz", "selwf")) return;
        oDmApp.ParseCommand("selwf &IN=1_sort &WIRETR=minertr &WIREPT=minerpt &OUT=min *X=XCOLLAR *Y=YCOLLAR *Z=ZCOLLAR *ATTRIB1=ROCK @SELECT=3 @EXCLUDE=0 @TOLERANC=0.001 @PRINT=0");
        if (!chkFileInRoot("min", "selwf")) return;
        oDmApp.ParseCommand("selwf &IN=kd1 &WIRETR=minertr &WIREPT=minerpt &OUT=min2 *X=XCOLLAR *Y=YCOLLAR *Z=ZCOLLAR *ATTRIB1=ROCK @SELECT=4 @EXCLUDE=0 @TOLERANC=0.001 @PRINT=0");
        if (!chkFileInRoot("min2", "selwf")) return;
        oDmApp.ParseCommand("join &IN1=min2 &IN2=kd2 &OUT=kd1_kd2 *KEY1=BHID @SUBSETR=0 @SUBSETF=0 @CARTJOIN=0 @PRINT=0");
        if (!chkFileInRoot("kd1_kd2", "join")) return;
        oDmApp.ParseCommand("join &IN1=kd1_kd2 &IN2=kd3 &OUT=kd1_kd2_kd3 *KEY1=BHID @SUBSETR=0 @SUBSETF=0 @CARTJOIN=0 @PRINT=0");
        if (!chkFileInRoot("kd1_kd2_kd3", "join")) return;
        oDmApp.ParseCommand("join &IN1=kd1_kd2_kd3 &IN2=rz &OUT=rok *KEY1=BHID @SUBSETR=0 @SUBSETF=0 @CARTJOIN=0 @PRINT=0");
        if (!chkFileInRoot("rok", "join")) return;
        oDmApp.ParseCommand("join &IN1=rok &IN2=min &OUT=skv_rok *KEY1=BHID @SUBSETR=0 @SUBSETF=0 @CARTJOIN=0 @PRINT=0");
        if (!chkFileInRoot("skv_rok", "join")) return;
        oDmApp.ParseCommand("selwf &IN=skv_rok &WIRETR=big_southtr &WIREPT=big_southpt &OUT=skv_S *X=XCOLLAR *Y=YCOLLAR *Z=ZCOLLAR *ATTRIB1=PIT @SELECT=3 @EXCLUDE=0 @TOLERANC=0.001 @PRINT=0");
        if (!chkFileInRoot("skv_S", "selwf")) return;
        oDmApp.ParseCommand("selwf &IN=skv_rok &WIRETR=big_nordtr &WIREPT=big_nordpt &OUT=skv_N *X=XCOLLAR *Y=YCOLLAR *Z=ZCOLLAR *ATTRIB1=PIT @SELECT=3 @EXCLUDE=0 @TOLERANC=0.001 @PRINT=0");
        if (!chkFileInRoot("skv_N", "selwf")) return;
        oDmApp.ParseCommand("join &IN1=skv_s &IN2=skv_n &OUT=temp1 *KEY1=BHID @SUBSETR=0 @SUBSETF=0 @CARTJOIN=0 @PRINT=0");
        if (!chkFileInRoot("temp1", "join")) return;
        oDmApp.ParseCommand("SELEXY   &IN=temp1 &PERIM=str &OUT=" + str_oFile_Short_DM + " *X=XCOLLAR *Y=YCOLLAR  *ATTRIB1=DOMEN @OUTSIDE=0.0");
        if (!chkFileInRoot(str_oFile_Short_DM, "SELEXY")) return;
        oDmApp.ParseCommand("delete &IN=1_sort @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=kd1 @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=kd2 @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=kd3 @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=rz @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=min @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=kd1_kd2 @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=kd1_kd2_kd3 @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=rok @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=skv_rok @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=skv_S @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=skv_N @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=temp1 @CONFIRM=0");
        oDmApp.ParseCommand("delete &IN=SQL1 @CONFIRM=0");



        //if (fso_in.FileExists(str_oFile_Full))
        //    fso_in.DeleteFile(str_oFile_Full);


        if (fso_in.FileExists(str_IFile5_Full)) {
            //fso_in.CopyFile(str_oFile_Root, str_Prj_Folder + "\\lito_out.dm");
            //debugger;
            fso_in.CopyFile(str_IFile5_Full, str_Prj_Folder + "\\lito_out.dm");
            
           // fso_in.MoveFile(str_oFile_Root, str_oFile_Full);
        }
        else {
            alert("Не могу переместить. Не найден файл: " + str_oFile_Root);
            return;
        }

        $scope.iDhNum=getDhCountInData("dh_points");
        $scope.iSampleNum = getSampleCountInData("dh_points");

       

        //alert("Всё получилось! Смотри файлы " + str_oFile_Short + "  в  папке " + str_Storage_Folder + "\\" + str_OF_Category + "\\" + str_OF_Year + "\\" + str_OF_Month + "." + str_OF_Year);
        // конец. Раздел выполняет манипуляции с файлами и непосредственное выполнение команд

    }
    catch (e) {
        alert("Failed\nReason: " + e.description);
    }
}

var checkDataIsSaved = function () {
    var result = true;
    var DataRecCount = getRowCountInData("dh_points")
    var FileRecCount = getRowCountInFile("dh_points")
    if (DataRecCount != FileRecCount) {
        result = false;
        alert("Количества записей в файле и кэше Studio не равны. Сохраните данные, затем повторите попытку.");
    }
    return result;
}
function chkFileInRoot(strFileName, strProcess) {
    var fso_temp = new ActiveXObject("Scripting.FileSystemObject");
    str_TempFile_Root = str_Prj_Folder + "\\" + strFileName + ".dm"
    if (!fso_temp.FileExists(str_TempFile_Root)) {
        alert("Не создан файл: " + strFileName + " в процессе " + strProcess + ". Дальнейшее выполнение не возможно.");
        return false;
    }
    else return true;

}



var getRowCountInData = function (DhOrPointsDm) {
    var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points"); //получаем слой с нужным именем
    if (ol_kol == null)															// если такого слоя нет, то
        var ol_kol = oDmApp.ActiveProject.Design.Overlays.GetAtName("dh_points (points)");    // получаем слой с нужным именем, который был сохранен в файл (об этом говорит фраза "(points)")

    if (ol_kol != null) { 																								 // если опять нет такого слоя, то

        ol_kol3D = ol_kol.Ew3DObject;   // получаем ссылку на объект слоя
    }
    else {
        alert("Слой 'dh_points' или 'dh_points (points)' не найден")
        return;
    }
    var ol_kol3D_ObjData = ol_kol3D.ObjectData();


    var cn_X_Coord = 1
    var count = 0;
    ol_kol3D_ObjData.GetFirstRow()
    for (var i = 1 ; i <= ol_kol3D_ObjData.GetRowCount() ; ol_kol3D_ObjData.GetNextRow(), i++) {
        var cr1 = ol_kol3D_ObjData.GetColumnAsString(cn_X_Coord);
        if (cr1 != "-") {
            count = count + 1;
        }
    }
    return count;
}

var getRowCountInFile = function (DhOrPointsDm) {
    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + DhOrPointsDm + ".dm", false);
    var count = oDmFile.GetRowCount();
    oDmFile.Close();
    return count;
}
var checkLitoPitDomen = function (LitoOutDm) {
    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + LitoOutDm + ".dm", false);
    var result = true;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {

        var Lito = oDmFile.GetNamedColumn("ROCK").toFixed(0);
        var Pit = oDmFile.GetNamedColumn("PIT");
        var Domen = oDmFile.GetNamedColumn("DOMEN").toFixed(0);
        if (Lito == 0 || Pit == "" || Domen == 0) {
            result = false;
            oDmFile.Close();
            return result;
        }


    }
    oDmFile.Close();
    return result;
}

//var RecordToDb = function ($scope) {
//    var lito_text = $scope.isLitoExist;
//    if (lito_text !== "Да") {
//        alert("Не проставлена литология. Продолжение не возможно.");
//        return;
//    }
//    RecordCollar("lito_out");
//    RecordSurvey("lito_out");
//    RecordAssay("lito_out");
//}

var RecordCollar = function (LitoOutDm) {
    adParamInput_ = 1
    adParamOutput_ = 2
    adDouble_ = 5
    adInteger_ = 3
    adBoolean_ = 11
    adDate_ = 7
    adDBDate_ = 133
    adVarWChar_ = 202
    adCmdText_ = 1
    adCmdStoredProc_ = 4
    var cn = new ActiveXObject("ADODB.Connection");
    var cmd = new ActiveXObject("ADODB.Command");
    var adoConString;
    adoConString = "DRIVER=SQL Server;SERVER=OGK-S-APPMINE01\\MINESQL;Trusted_Connection=Yes;DATABASE=bl_server;Network=DBMSSOCN;Address=OGK-S-APPMINE01\\MINESQL,1433";

    cn.Open(adoConString);
    cmd.ActiveConnection = cn;
    cmd.CommandType = adCmdStoredProc_;
    cmd.NamedParameters = 1;
    cmd.CommandText = "sp_ZbSample_Add_CollarDmp"
    cmd.Parameters.Append(cmd.CreateParameter("@parBhid", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parXCollar", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parYCollar", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parZCollar", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parEnddepth", adVarWChar_, adParamInput_, 50, ""));
    //cmd.Parameters.Append(cmd.CreateParameter("@parDomen", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parError", adVarWChar_, adParamOutput_, 2000, ""));

    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + LitoOutDm + ".dm", false);



    var numDh = 0;
    var err_count = 0;
    var i = 0;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {
        if (oDmFile.GetNamedColumn("S_SAMP") != 0 && oDmFile.GetNamedColumn("COL_SAMP") != 0) {
            numDh = numDh + 1;
            cmd.Parameters.item("@parBhid").Value = oDmFile.GetNamedColumn("BHID");
            cmd.Parameters.item("@parXCollar").Value = oDmFile.GetNamedColumn("XCOLLAR");
            cmd.Parameters.item("@parYCollar").Value = oDmFile.GetNamedColumn("YCOLLAR");
            cmd.Parameters.item("@parZCollar").Value = oDmFile.GetNamedColumn("ZCOLLAR");
            cmd.Parameters.item("@parEnddepth").Value = oDmFile.GetNamedColumn("ENDDEPTH");
         //   cmd.Parameters.item("@parDomen").Value = oDmFile.GetNamedColumn("DOMEN");

            try {
                cmd.Execute();
            }
            catch (e) {
                err_count++;
                if (e.description.indexOf('duplicate') > -1) {
                    var iStr = Number(i) + 1;
                    oDmFile.SetNamedColumn("ERRCOL", 'Запись№ ' + iStr + ' уже есть в БД');
                    alert('CollarOR. Запись№ ' + iStr + ' уже есть в БД');
                }
                else
                    alert("Failed\nReason: " + e.description);

            }
            if (cmd.Parameters.item("@parError").Value != null && cmd.Parameters.item("@parError").Value != undefined) {
                err_count++;
                var iStr = Number(i) + 1;
                oDmFile.SetNamedColumn("ERRCOL", cmd.Parameters.item("@parError").Value);
                alert('CollarOR. Запись№ ' + iStr + '. ' + cmd.Parameters.item("@parError").Value);
            }
        }
    }
    if (err_count > 0) {
        alert('В таблицу CollarOR Добавилось ' + (numDh - err_count) + ' записей из ' + numDh);
    }
    else {
        alert('В таблицу CollarOR все записи добавлены успешно! ' + numDh + " шт.");
    }
    oDmFile.Close();
    cn.Close();

}

var RecordSurvey = function (LitoOutDm) {
    adParamInput_ = 1
    adParamOutput_ = 2
    adDouble_ = 5
    adInteger_ = 3
    adBoolean_ = 11
    adDate_ = 7
    adDBDate_ = 133
    adVarWChar_ = 202
    adCmdText_ = 1
    adCmdStoredProc_ = 4
    var cn = new ActiveXObject("ADODB.Connection");
    var cmd = new ActiveXObject("ADODB.Command");
    var adoConString;
    adoConString = "DRIVER=SQL Server;SERVER=OGK-S-APPMINE01\\MINESQL;Trusted_Connection=Yes;DATABASE=bl_server;Network=DBMSSOCN;Address=OGK-S-APPMINE01\\MINESQL,1433";

    cn.Open(adoConString);
    cmd.ActiveConnection = cn;
    cmd.CommandType = adCmdStoredProc_;
    cmd.NamedParameters = 1;
    cmd.CommandText = " sp_DhSample_Add_SurveyOR "
    cmd.Parameters.Append(cmd.CreateParameter("@parBhid", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parAt", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parBrg", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parDip", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parError", adVarWChar_, adParamOutput_, 2000, ""));

    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + LitoOutDm + ".dm", false);

    var numDh = 0;
    var err_count = 0;
    var i = 0;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {
        if (oDmFile.GetNamedColumn("S_SAMP") != 0 && oDmFile.GetNamedColumn("COL_SAMP") != 0) {
            numDh = numDh + 1;
            cmd.Parameters.item("@parBhid").Value = oDmFile.GetNamedColumn("BHID");
            cmd.Parameters.item("@parAt").Value = 0;
            cmd.Parameters.item("@parBrg").Value = Number(oDmFile.GetNamedColumn("BRG")) + 90;
            cmd.Parameters.item("@parDip").Value = oDmFile.GetNamedColumn("DIP");

            try {
                cmd.Execute();
            }
            catch (e) {
                err_count++;
                if (e.description.indexOf('duplicate') > -1) {
                    var iStr = Number(i) + 1;
                    oDmFile.SetNamedColumn("ERRSUR", 'Запись№ ' + iStr + ' уже есть в БД');
                    alert('SurveysOR. Запись№ ' + iStr + ' уже есть в БД');
                }
                else
                    alert("Failed\nReason: " + e.description);

            }
            if (cmd.Parameters.item("@parError").Value != null && cmd.Parameters.item("@parError").Value != undefined) {
                err_count++;
                var iStr = Number(i) + 1;
                oDmFile.SetNamedColumn("ERRSUR", cmd.Parameters.item("@parError").Value);
                alert('SurveysOR. Запись№ ' + iStr + '. ' + cmd.Parameters.item("@parError").Value);
            }
        }
    }
    if (err_count > 0) {
        alert('В таблицу SurveysOR Добавилось ' + (numDh - err_count) + ' записей из ' + numDh);
    }
    else {
        alert('В таблицу SurveysOR все записи добавлены успешно! ' + numDh + " шт.");
    }
    oDmFile.Close();
    cn.Close();

}

var RecordAssay = function (LitoOutDm) {
    adParamInput_ = 1
    adParamOutput_ = 2
    adDouble_ = 5
    adInteger_ = 3
    adBoolean_ = 11
    adDate_ = 7
    adDBDate_ = 133
    adVarWChar_ = 202
    adCmdText_ = 1
    adCmdStoredProc_ = 4
    var cn = new ActiveXObject("ADODB.Connection");
    var cmd = new ActiveXObject("ADODB.Command");
    var adoConString;
    adoConString = "DRIVER=SQL Server;SERVER=OGK-S-APPMINE01\\MINESQL;Trusted_Connection=Yes;DATABASE=bl_server;Network=DBMSSOCN;Address=OGK-S-APPMINE01\\MINESQL,1433";

    cn.Open(adoConString);
    cmd.ActiveConnection = cn;
    cmd.CommandType = adCmdStoredProc_;
    cmd.NamedParameters = 1;
    cmd.CommandText = " sp_DhSample_Add_AssayOR "
    cmd.Parameters.Append(cmd.CreateParameter("@parBhid", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parSample", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parFrom", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parTo", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parLength", adVarWChar_, adParamInput_, 50, ""));
  //  cmd.Parameters.Append(cmd.CreateParameter("@parRock", adVarWChar_, adParamInput_, 50, ""));
  //  cmd.Parameters.Append(cmd.CreateParameter("@parPit", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parError", adVarWChar_, adParamOutput_, 2000, ""));

    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + LitoOutDm + ".dm", false);

    var err_count = 0;
    var i = 0;
    var numSample = 0;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {
        if (oDmFile.GetNamedColumn("S_SAMP") != 0 && oDmFile.GetNamedColumn("COL_SAMP") != 0) {
            var startSample = Number(oDmFile.GetNamedColumn("S_SAMP").toFixed(0));
            var countSample = Number(oDmFile.GetNamedColumn("COL_SAMP").toFixed(0));
            var enddepth = Number(oDmFile.GetNamedColumn("ENDDEPTH").toFixed(3));
            var length = Number((enddepth / countSample).toFixed(10));

            for (var j = 0, sampleI = startSample; (j + length).toPrecision(5) <= countSample * length; j = j + length, sampleI = sampleI + 1) {
                numSample = numSample + 1;
                cmd.Parameters.item("@parBhid").Value = oDmFile.GetNamedColumn("BHID");
                cmd.Parameters.item("@parSample").Value = sampleI;
                cmd.Parameters.item("@parFrom").Value = j;
                cmd.Parameters.item("@parTo").Value = j + length;
                cmd.Parameters.item("@parLength").Value = length;
           //     cmd.Parameters.item("@parRock").Value = oDmFile.GetNamedColumn("ROCK");
            //    cmd.Parameters.item("@parPit").Value = oDmFile.GetNamedColumn("PIT");
                try {
                    cmd.Execute();
                }
                catch (e) {
                    err_count++;
                    if (e.description.indexOf('duplicate') > -1) {
                        var iStr = Number(i) + 1;
                        oDmFile.SetNamedColumn("ERRAS", 'Запись№ ' + iStr + ' уже есть в БД');
                        alert('AssaysOR. Запись№ ' + iStr + ' уже есть в БД');
                    }
                    else
                        alert("Failed\nReason: " + e.description);

                }
                if (cmd.Parameters.item("@parError").Value != null && cmd.Parameters.item("@parError").Value != undefined) {
                    err_count++;
                    var iStr = Number(i) + 1;
                    oDmFile.SetNamedColumn("ERRAS", cmd.Parameters.item("@parError").Value);
                    alert('AssaysOR. Запись№ ' + iStr + '. ' + cmd.Parameters.item("@parError").Value);
                }
            }
        }
    }
    if (err_count > 0) {
        alert('В таблицу AssaysOR Добавилось ' + (numSample - err_count) + ' записей из ' + numSample);
    }
    else {
        alert('В таблицу AssaysOR все записи добавлены успешно! ' + numSample + " шт.");
    }
    oDmFile.Close();
    cn.Close();

}



var CollarsObj = function (LitoOutDm) {

    var return_obj = [];

    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + LitoOutDm + ".dm", false);



    var numDh = 0;
    var err_count = 0;
    var i = 0;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {
        if (oDmFile.GetNamedColumn("S_SAMP") != 0 && oDmFile.GetNamedColumn("COL_SAMP") != 0) {
            var new_obj = {};
            numDh = numDh + 1;
            new_obj.BHID = oDmFile.GetNamedColumn("BHID");
            new_obj.XCOLLAR = oDmFile.GetNamedColumn("XCOLLAR");
            new_obj.YCOLLAR = oDmFile.GetNamedColumn("YCOLLAR");
            new_obj.ZCOLLAR = oDmFile.GetNamedColumn("ZCOLLAR");
            new_obj.ENDDEPTH = oDmFile.GetNamedColumn("ENDDEPTH");
        //    new_obj.DOMEN = oDmFile.GetNamedColumn("DOMEN");
            new_obj.error = -1;
            new_obj.message = "";
            return_obj.push(new_obj);
        }
    }
    
    oDmFile.Close();
    
    return return_obj;

}

var SurveysObj = function (LitoOutDm) {
    
    var return_obj = [];

    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + LitoOutDm + ".dm", false);

    var numDh = 0;
    var err_count = 0;
    var i = 0;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {
        if (oDmFile.GetNamedColumn("S_SAMP") != 0 && oDmFile.GetNamedColumn("COL_SAMP") != 0) {
            var new_obj = {};
            numDh = numDh + 1;
            new_obj.BHID = oDmFile.GetNamedColumn("BHID");
            new_obj.AT = 0;
            new_obj.BRG = Number(oDmFile.GetNamedColumn("BRG")) + 90;
            new_obj.DIP = oDmFile.GetNamedColumn("DIP");
            new_obj.error = -1;
            new_obj.message = "";
            return_obj.push(new_obj);
        }
    }
   
    oDmFile.Close();
   
    return return_obj;
}

var AssaysObj = function (LitoOutDm) {
    var return_obj = [];

    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(oDmApp.ActiveProject.Folder + "\\" + LitoOutDm + ".dm", false);

    var err_count = 0;
    var i = 0;
    var numSample = 0;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {
        if (oDmFile.GetNamedColumn("S_SAMP") != 0 && oDmFile.GetNamedColumn("COL_SAMP") != 0) {
            var startSample = Number(oDmFile.GetNamedColumn("S_SAMP").toFixed(0));
            var countSample = Number(oDmFile.GetNamedColumn("COL_SAMP").toFixed(0));
            var enddepth = Number(oDmFile.GetNamedColumn("ENDDEPTH").toFixed(3));
            var length = Number((enddepth / countSample).toFixed(20));

            for (var j = 0, sampleI = startSample; (j + length).toPrecision(5) <= countSample * length; j = j + length, sampleI = sampleI + 1) {
                numSample = numSample + 1;
                var new_obj = {};
                new_obj.BHID = oDmFile.GetNamedColumn("BHID");
                new_obj.SAMPLE = sampleI;
                new_obj.FROM = j.toFixed(2);
                new_obj.TO = Number(j + length).toFixed(2);
                new_obj.LENGTH = length.toFixed(2);
                new_obj.error = -1;
                new_obj.message = "";
                return_obj.push(new_obj);
            }
        }
    }
    
    oDmFile.Close();
    return return_obj;

}



var RecordCollarObj = function (collarObj) {

    adParamInput_ = 1
    adParamOutput_ = 2
    adDouble_ = 5
    adInteger_ = 3
    adBoolean_ = 11
    adDate_ = 7
    adDBDate_ = 133
    adVarWChar_ = 202
    adCmdText_ = 1
    adCmdStoredProc_ = 4
    var cn = new ActiveXObject("ADODB.Connection");
    var cmd = new ActiveXObject("ADODB.Command");
    var adoConString;
    adoConString = "DRIVER=SQL Server;SERVER=OGK-S-APPMINE01\\MINESQL;Trusted_Connection=Yes;DATABASE=bl_server;Network=DBMSSOCN;Address=OGK-S-APPMINE01\\MINESQL,1433";

    cn.Open(adoConString);
    cmd.ActiveConnection = cn;
    cmd.CommandType = adCmdStoredProc_;
    cmd.NamedParameters = 1;
    cmd.CommandText = " sp_ZbSample_Add_CollarDmp "
    cmd.Parameters.Append(cmd.CreateParameter("@parBhid", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parXCollar", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parYCollar", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parZCollar", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parEnddepth", adVarWChar_, adParamInput_, 50, ""));
 //   cmd.Parameters.Append(cmd.CreateParameter("@parDomen", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parError", adVarWChar_, adParamOutput_, 2000, ""));

    var err_count = 0;

    cmd.Parameters.item("@parBhid").Value = collarObj.BHID;
    cmd.Parameters.item("@parXCollar").Value = collarObj.XCOLLAR;
    cmd.Parameters.item("@parYCollar").Value = collarObj.YCOLLAR;
    cmd.Parameters.item("@parZCollar").Value = collarObj.ZCOLLAR;
    cmd.Parameters.item("@parEnddepth").Value = collarObj.ENDDEPTH;
 //   cmd.Parameters.item("@parDomen").Value = collarObj.DOMEN;


    try {
        collarObj.error = 0;
        collarObj.message = "";
        cmd.Execute();
    }
    catch (e) {
        err_count++;
        collarObj.error = 100;
        if (e.description.indexOf('duplicate') > -1) {
            collarObj.message = " Такая запись уже есть в БД. "
        }
        else
            collarObj.message = e.description;
            

    }
    if (cmd.Parameters.item("@parError").Value != null && cmd.Parameters.item("@parError").Value != undefined) {
        collarObj.error = 100;
        collarObj.message = cmd.Parameters.item("@parError").Value;
        err_count++;
    }

    cn.Close();

    return err_count;
    
    

}

var RecordSurveysObj = function (surveysObj) {
    adParamInput_ = 1
    adParamOutput_ = 2
    adDouble_ = 5
    adInteger_ = 3
    adBoolean_ = 11
    adDate_ = 7
    adDBDate_ = 133
    adVarWChar_ = 202
    adCmdText_ = 1
    adCmdStoredProc_ = 4
    var cn = new ActiveXObject("ADODB.Connection");
    var cmd = new ActiveXObject("ADODB.Command");
    var adoConString;
    adoConString = "DRIVER=SQL Server;SERVER=OGK-S-APPMINE01\\MINESQL;Trusted_Connection=Yes;DATABASE=bl_server;Network=DBMSSOCN;Address=OGK-S-APPMINE01\\MINESQL,1433";

    cn.Open(adoConString);
    cmd.ActiveConnection = cn;
    cmd.CommandType = adCmdStoredProc_;
    cmd.NamedParameters = 1;
    cmd.CommandText = " sp_ZbSample_Add_SurveyDmp "
    cmd.Parameters.Append(cmd.CreateParameter("@parBhid", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parAt", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parBrg", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parDip", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parError", adVarWChar_, adParamOutput_, 2000, ""));


    var numDh = 0;
    var err_count = 0;
    
    for (var i = 0; i < surveysObj.length; i++) {
       
        cmd.Parameters.item("@parBhid").Value = surveysObj[i].BHID;
        cmd.Parameters.item("@parAt").Value = surveysObj[i].AT;
        cmd.Parameters.item("@parBrg").Value = surveysObj[i].BRG;
        cmd.Parameters.item("@parDip").Value = surveysObj[i].DIP;

            try {
                surveysObj[i].error = 0;
                surveysObj[i].message = "";
                cmd.Execute();
            }
            catch (e) {
                err_count++;
                surveysObj[i].error = 100;
                if (e.description.indexOf('duplicate') > -1) {
                    var iStr = Number(i) + 1;
                    surveysObj[i].message = " Такая запись уже есть в БД. "
                }
                else
                    surveysObj[i].message = e.description;

            }
            if (cmd.Parameters.item("@parError").Value != null && cmd.Parameters.item("@parError").Value != undefined) {
                err_count++;
                surveysObj[i].error = 100;
                var iStr = Number(i) + 1;
               
                surveysObj[i].message = cmd.Parameters.item("@parError").Value;
            }
        
    }
    cn.Close();

    return err_count;

}

var RecordAssaysObj = function (assaysObj, sector) {
 
    adParamInput_ = 1
    adParamOutput_ = 2
    adDouble_ = 5
    adInteger_ = 3
    adBoolean_ = 11
    adDate_ = 7
    adDBDate_ = 133
    adVarWChar_ = 202
    adCmdText_ = 1
    adCmdStoredProc_ = 4
    var cn = new ActiveXObject("ADODB.Connection");
    var cmd = new ActiveXObject("ADODB.Command");
    var adoConString;
    adoConString = "DRIVER=SQL Server;SERVER=OGK-S-APPMINE01\\MINESQL;Trusted_Connection=Yes;DATABASE=bl_server;Network=DBMSSOCN;Address=OGK-S-APPMINE01\\MINESQL,1433";

    cn.Open(adoConString);
    cmd.ActiveConnection = cn;
    cmd.CommandType = adCmdStoredProc_;
    cmd.NamedParameters = 1;
    cmd.CommandText = " sp_ZbSample_Add_AssayDmp "
    cmd.Parameters.Append(cmd.CreateParameter("@parBhid", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parSample", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parFrom", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parTo", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parLength", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parSector", adVarWChar_, adParamInput_, 50, ""));
  //  cmd.Parameters.Append(cmd.CreateParameter("@parRock", adVarWChar_, adParamInput_, 50, ""));
 //   cmd.Parameters.Append(cmd.CreateParameter("@parPit", adVarWChar_, adParamInput_, 50, ""));
    cmd.Parameters.Append(cmd.CreateParameter("@parError", adVarWChar_, adParamOutput_, 2000, ""));

   

    var err_count = 0;

    var numSample = 0;
    for (var i = 0 ; i < assaysObj.length; i++) {
       

                cmd.Parameters.item("@parBhid").Value = assaysObj[i].BHID;
                cmd.Parameters.item("@parSample").Value = assaysObj[i].SAMPLE;
                cmd.Parameters.item("@parFrom").Value = assaysObj[i].FROM;
                cmd.Parameters.item("@parTo").Value = assaysObj[i].TO;
                cmd.Parameters.item("@parLength").Value = assaysObj[i].LENGTH;
                cmd.Parameters.item("@parSector").Value = sector;
            //    cmd.Parameters.item("@parRock").Value = assaysObj[i].ROCK;
            //    cmd.Parameters.item("@parPit").Value = assaysObj[i].PIT;

                

                try {
                    assaysObj[i].error = 0;
                    assaysObj[i].message = "";
                    cmd.Execute();
                }
                catch (e) {
                    err_count++;
                    assaysObj[i].error = 100;
                    if (e.description.indexOf('duplicate') > -1) {
                        var iStr = Number(i) + 1;
                        assaysObj[i].message = " Такая запись уже есть в БД. "
                    }
                    else
                        assaysObj[i].message = e.description;

                }
                if (cmd.Parameters.item("@parError").Value != null && cmd.Parameters.item("@parError").Value != undefined) {
                    assaysObj[i].error = 100;
                    err_count++;
                    var iStr = Number(i) + 1;
                    assaysObj[i].message = cmd.Parameters.item("@parError").Value;
                }
            
        
    }
    cn.Close();

    return err_count;

}