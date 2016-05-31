function btnHelp_onclick() {
    var features = "status=no,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes";
    var common = "_blank"
    var installpath = oDmApp.Options.HelpFolder;
    installpath = installpath.replace(" ", "%20");
    var helpcommand = "mk:@MSITStore:" + installpath + "/DatamineStudio.chm::/Studio_3_General/Concept_Studio%203%20Scripting%20Overview.htm";
    window.open(helpcommand, common, features);
}
function chkFileInRoot(strFileName, strProcess) {
    var fso_temp = new ActiveXObject("Scripting.FileSystemObject");
    str_TempFile_Root = str_Prj_Folder + "\\" + strFileName + ".dm"
    if (!fso_temp.FileExists(str_TempFile_Root)) {
        alert("Не создан файл: " + strFileName + " в процессе " + strProcess + ". Дальнейшее выполнение не возможно.");
        return false;
    }
    else return true;

};

var STtable = function (filePath, xAxis, yAxis, zAxis, xElPos, yElPos, zElPos) {

    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(filePath, false);
    this.points = [];
    var i = 0;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; oDmFile.MoveNext(), i++) {

        this.points[i] = Object();
        this.points[i].x = oDmFile.GetNamedColumn("XP").toFixed(2) > 0 ? oDmFile.GetNamedColumn("XP").toFixed(2) : 0;
        this.points[i].y = oDmFile.GetNamedColumn("YP").toFixed(2) > 0 ? oDmFile.GetNamedColumn("YP").toFixed(2) : 0;
        this.points[i].z = oDmFile.GetNamedColumn("ZP").toFixed(2) > 0 ? oDmFile.GetNamedColumn("ZP").toFixed(2) : 0;

    }
    oDmFile.Close();
};

var GetPit = function (filename) {
    var stFile = new STtable(filename);
    var xmin = 999999;
    var xmax = 0;
    var ymin = 999999;
    var ymax = 0;

    var xminBL = 102400;
    var xmaxBL = 105000;
    var yminBL = 81160;
    var ymaxBL = 83500;

    var isIn_xminBL = false;
    var isIn_xmaxBL = false;
    var isIn_yminBL = false;
    var isIn_ymaxBL = false;

    var xminOL = 101000;
    var xmaxOL = 103000;
    var yminOL = 60300;
    var ymaxOL = 61500;

    var isIn_xminOL = false;
    var isIn_xmaxOL = false;
    var isIn_yminOL = false;
    var isIn_ymaxOL = false;

    for (var i = 0; i < stFile.points.length; i++) {
        if (stFile.points[i].x < xmin)
            xmin = stFile.points[i].x;
        if (stFile.points[i].x > xmax)
            xmax = stFile.points[i].x;
        if (stFile.points[i].y < ymin)
            ymin = stFile.points[i].y;
        if (stFile.points[i].y > ymax)
            ymax = stFile.points[i].y;
    }

    if (xmin > xminBL && xmin < xmaxBL) isIn_xminBL = true;
    if (xmax > xminBL && xmax < xmaxBL) isIn_xmaxBL = true;
    if (ymin > yminBL && ymin < ymaxBL) isIn_yminBL = true;
    if (ymax > yminBL && ymax < ymaxBL) isIn_ymaxBL = true;

    if (xmin > xminOL && xmin < xmaxOL) isIn_xminOL = true;
    if (xmax > xminOL && xmax < xmaxOL) isIn_xmaxOL = true;
    if (ymin > yminOL && ymin < ymaxOL) isIn_yminOL = true;
    if (ymax > yminOL && ymax < ymaxOL) isIn_ymaxOL = true;

    var pit;

    if (isIn_xminBL && isIn_xmaxBL && isIn_yminBL && isIn_ymaxBL)
        pit = "BL";
    else if (isIn_xminOL && isIn_xmaxOL && isIn_yminOL && isIn_ymaxOL)
        pit = "OL";
    else {
        countBL = isIn_xminBL ? 1 : 0 + isIn_xmaxBL ? 1 : 0 + isIn_yminBL ? 1 : 0 + isIn_ymaxBL ? 1 : 0;
        countOL = isIn_xminOL ? 1 : 0 + isIn_xmaxOL ? 1 : 0 + isIn_yminOL ? 1 : 0 + isIn_ymaxOL ? 1 : 0;
        if (countBL > countOL) {
            pit = "BL";
            alert("Карьер Благодатный больше подходит под указанные координаты, но одна или несколько точек контура выходят за определенные границы карьера. Необходимо проанализировать и исправить это.")
        }
        else {
            pit = "OL";
            alert("Карьер Восточный больше подходит под указанные координаты, но одна или несколько точек контура выходят за определенные границы карьера. Необходимо проанализировать и исправить это.")
        }
    }
    return pit;
};

var deleteTemporaryFiles = function () {
    oDmApp.ParseCommand("DELETE   &IN=SKM1  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM2  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM3  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM4  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM5  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM6  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM7  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM8  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM9  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM10  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM11  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM12  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM13  @CONFIRM=0.0");
//    oDmApp.ParseCommand("DELETE   &IN=SKM14  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM15  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM16  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM17  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=SKM18  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000180  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000190  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000200  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000210  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000220  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000230  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000240  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000250  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000260  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000270  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000280  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000290  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000300  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000310  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000320  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000330  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000340  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000350  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000360  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000370  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000380  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000390  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000400  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000410  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000420  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000430  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000440  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000450  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000460  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000470  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000480  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000490  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000500  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000510  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000520  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000530  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000540  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000550  @CONFIRM=0.0");
    oDmApp.ParseCommand("DELETE   &IN=p0000560  @CONFIRM=0.0");
}

var eraseSegmentLess3Points = function (filePath) {

    var oDmFile = new ActiveXObject("DmFile.DmTableADO");

    oDmFile.Open(filePath, false);
    var i = 1;
    oDmFile.MoveFirst()
    var countOfTheSamePvalue;
    countOfTheSamePvalue = 1;
    var currentPvalue = oDmFile.GetNamedColumn("PVALUE").toFixed(0);
    oDmFile.MoveNext()
    i = i + 1;
    var arPvalueToDel = [];

    for (; !oDmFile.EOF; oDmFile.MoveNext(), i++) {

        if (currentPvalue == oDmFile.GetNamedColumn("PVALUE").toFixed(0)) {
            countOfTheSamePvalue = countOfTheSamePvalue + 1;
        }
        else {
            if (countOfTheSamePvalue < 3) {
                arPvalueToDel.push(currentPvalue);
            }
            currentPvalue = oDmFile.GetNamedColumn("PVALUE").toFixed(0);
            countOfTheSamePvalue = 1;
        }

    }
    // проверка последних строк в файле, потому что проверка в цикле не сработает в случае если сегмент прервется концом файла
    if (countOfTheSamePvalue < 3) {
        arPvalueToDel.push(currentPvalue);
    }
    i = 1;
    for (oDmFile.MoveFirst() ; !oDmFile.EOF; i++) {

        if (arPvalueToDel.indexOf(oDmFile.GetNamedColumn("PVALUE").toFixed(0)) != -1) {
            oDmFile.DeleteRow(oDmFile.GetCurrentRow());
        }
        else {
            oDmFile.MoveNext();
        }
    }
    oDmFile.Close();
};

var getPathForIFile6 = function () {
    var fullFilenameIFile5 = $('#iFile5').val();
    var pattern_path = /^(([a-zA-Z]:)|(\\{2}[\w\s\-\!а-я]+))(\\([\w\s\-\!а-я]+))+\\/i;  // получаем путь файла  /^(([a-zA-Z]:)|(\{2}w+)$)(\\([\w\s]+))+\\/i
    var result = pattern_path.exec(fullFilenameIFile5);
    if (result != null) {
        var path = result[0];
    }
    else
        var path = '(имя не определено)';
    return path;
}


var getObjDataFromFile = function (filename) {
    full_filename = str_Prj_Folder + "\\" +filename + ".dm"
    var oDmFile = new ActiveXObject("DmFile.DmTableADO");
    oDmFile.Open(full_filename, false);
    var result = [];
    var i = 0;
    for (oDmFile.MoveFirst(); !oDmFile.EOF; oDmFile.MoveNext(), i++) {
        result[i] = Object();
        result[i].BLKNAM = rtrim(oDmFile.GetNamedColumn("BLKNAM"));
        result[i].MATERIAL = rtrim(oDmFile.GetNamedColumn("MATERIAL"));
        result[i].VOLUME = oDmFile.GetNamedColumn("VOLUME").toFixed(2);
        result[i].TONNES = oDmFile.GetNamedColumn("TONNES").toFixed(2);
        result[i].DENSITY = oDmFile.GetNamedColumn("DENSITY").toFixed(2);
        result[i].GC_AU = oDmFile.GetNamedColumn("GC_AU").toFixed(2);
        result[i].GC_AS = oDmFile.GetNamedColumn("GC_AS").toFixed(2);
        result[i].GC_C = oDmFile.GetNamedColumn("GC_C").toFixed(2);
        result[i].GC_S = oDmFile.GetNamedColumn("GC_S").toFixed(2);
        result[i].GC_FE = oDmFile.GetNamedColumn("GC_FE").toFixed(2);
        result[i].ORETYPE = oDmFile.GetNamedColumn("ORETYPE").toFixed(0);


    }
    oDmFile.Close();
    return result;
};

function trim(s) {
    return rtrim(ltrim(s));
}

function ltrim(s) {
    return s.replace(/^\s+/, '');
}

function rtrim(s) {
    return s.replace(/\s+$/, '');
}

var getDateFromFileName = function (filename)
{

    var Year = filename.match(/\d{4}(?=st)/)[0];
    var Month = filename.match(/\d{2}(?=_\d{4})/)[0];
    var Day = filename.match(/^\d{2}(?=_)/)[0];
    return Year + "/" + Month + "/" + Day;
}