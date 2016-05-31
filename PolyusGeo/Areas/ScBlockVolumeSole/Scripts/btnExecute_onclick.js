var btnExecute_onclick = function () {
    try {

        if (!(str_IFile5_Full = document.getElementById("iFile5").value)) {
            alert("Выберите входной файл стрингов");
            return;
        }

        pit = GetPit(str_IFile5_Full);
        switch (pit) {
            case "BL":
                str_Storage_Folder = "\\\\Blg-geo06\\шлюз\\BLAGODATNIY";
                files_names = new Array("proto2x2x800", "proto2x2x0_1", "bench_lev")
                break;
            case "OL":
                str_Storage_Folder = "X:\\Geology\\OLIMPIADA";
                files_names = new Array("proto_3x3x800", "proto_3x3x0_5", "OL_bench_lev");
                break;
        }



        var str_iBench;
        var str_iBench1;
        var str_iBench2;
        var str_iHBench;

        if (!(str_iBench = document.getElementById("iBench").innerHTML)) {
            alert("Введите № горизонта");
            return;
        }
        var int_iBench1 = 605;
        var int_iBench2 = -105;
        var int_iHBench = 10;
       //  начало. Раздел определяет каталоги проекта и хранилища файлов	
        var objDmApp, objScript;
        objScript = new ActiveXObject("DatamineStudio.ScriptHelper");
        objScript.initialize(window);
        objDmApp = objScript.getApplication();

        objScript = new ActiveXObject("DatamineStudio.ScriptHelper");
        str_Prj_Folder = objDmApp.ActiveProject.Folder




        // конец. Раздел определяет каталоги проекта и хранилища файлов	

        // начало. Раздел определяет входные и выходные файлы для команд Datamine
        var str_IFile_Full;
        var str_oFile1_Short;
        var str_oFile2_Short;

        var fso_in = new ActiveXObject("Scripting.FileSystemObject"); // Объект FSO


        if (!(str_IFile2_Full = document.getElementById("iFile2").value.replace("pt.dm", "tr.dm"))) {
            alert("Выберите входной файл  периода №1");
            return;
        }
        str_IFile_Full = str_IFile2_Full.replace("tr.dm", "pt.dm")
        if (!fso_in.FileExists(str_IFile_Full))
            alert("Не найден файл: " + str_IFile_Full);

        if (!(str_IFile3_Full = document.getElementById("iFile3").value)) {
            alert("Выберите входной файл бровок периода 1");
            return;
        }
        if (!(str_IFile4_Full = document.getElementById("iFile4").value)) {
            alert("Выберите входной файл бровок периода 2");
            return;
        }

        if (!(str_IFile6_Full = document.getElementById("iFile6").value)) {
            if (!(str_IFile6_Short = document.getElementById("iFile6FileName").value)) {
                alert("Определите входной файл блочной модели");
                return;
            }
            else {
                if (getPathForIFile6() == '(имя не определено)') {
                    alert(getPathForIFile6());
                    alert("Не определен путь к файлу блочной модели");
                    return;
                }
                else
                    str_IFile6_Full = getPathForIFile6() + str_IFile6_Short;
            }
        }
        if (!(str_oFile1_Short_DM = document.getElementById("oFile1").value)) {
            alert("Выберите выходной файл");
            return;
        }
        if (!(str_oFile2_Short_DM = document.getElementById("oFile2").value)) {
            alert("Выберите выходной файл");
            return;
        }


        str_oFile1_Short = str_oFile1_Short_DM + ".csv";
        str_oFile2_Short = str_oFile2_Short_DM + ".dm";



        var str_IFile_Short_idx_from = str_IFile_Full.lastIndexOf("\\");
        var str_IFile2_Short_idx_from = str_IFile2_Full.lastIndexOf("\\");
        var str_IFile3_Short_idx_from = str_IFile3_Full.lastIndexOf("\\");
        var str_IFile4_Short_idx_from = str_IFile4_Full.lastIndexOf("\\");
        var str_IFile5_Short_idx_from = str_IFile5_Full.lastIndexOf("\\");
        var str_IFile6_Short_idx_from = str_IFile6_Full.lastIndexOf("\\");

        var str_IFile_Short_idx_to = str_IFile_Full.lastIndexOf(".");
        var str_IFile2_Short_idx_to = str_IFile2_Full.lastIndexOf(".");
        var str_IFile3_Short_idx_to = str_IFile3_Full.lastIndexOf(".");
        var str_IFile4_Short_idx_to = str_IFile4_Full.lastIndexOf(".");
        var str_IFile5_Short_idx_to = str_IFile5_Full.lastIndexOf(".");
        var str_IFile6_Short_idx_to = str_IFile6_Full.lastIndexOf(".");

        if (str_IFile_Short_idx_to != -1) {
            var str_IFile_Short_DM = str_IFile_Full.slice(str_IFile_Short_idx_from + 1, str_IFile_Short_idx_to);
        }
        else {
            var str_IFile_Short_DM = str_IFile_Full.slice(str_IFile_Short_idx_from + 1);
        }
        if (str_IFile2_Short_idx_to != -1) {
            var str_IFile2_Short_DM = str_IFile2_Full.slice(str_IFile2_Short_idx_from + 1, str_IFile2_Short_idx_to);
        }
        else {
            var str_IFile2_Short_DM = str_IFile2_Full.slice(str_IFile2_Short_idx_from + 1);
        }
        if (str_IFile3_Short_idx_to != -1) {
            var str_IFile3_Short_DM = str_IFile3_Full.slice(str_IFile3_Short_idx_from + 1, str_IFile3_Short_idx_to);
        }
        else {
            var str_IFile3_Short_DM = str_IFile3_Full.slice(str_IFile3_Short_idx_from + 1);
        }
        if (str_IFile4_Short_idx_to != -1) {
            var str_IFile4_Short_DM = str_IFile4_Full.slice(str_IFile4_Short_idx_from + 1, str_IFile4_Short_idx_to);
        }
        else {
            var str_IFile4_Short_DM = str_IFile4_Full.slice(str_IFile4_Short_idx_from + 1);
        }
        if (str_IFile5_Short_idx_to != -1) {
            var str_IFile5_Short_DM = str_IFile5_Full.slice(str_IFile5_Short_idx_from + 1, str_IFile5_Short_idx_to);
        }
        else {
            var str_IFile5_Short_DM = str_IFile5_Full.slice(str_IFile5_Short_idx_from + 1);
        }
        if (str_IFile6_Short_idx_to != -1) {
            var str_IFile6_Short_DM = str_IFile6_Full.slice(str_IFile6_Short_idx_from + 1, str_IFile6_Short_idx_to);
        }
        else {
            var str_IFile6_Short_DM = str_IFile6_Full.slice(str_IFile6_Short_idx_from + 1);
        }


        var operation_date = getDateFromFileName(str_IFile4_Short_DM);
        //var ObjData = getObjDataFromFile("SKM14");
        //sendObjData(ObjData, operation_date);

        //return;

        var str_oFile1_Root = str_Prj_Folder + "\\" + str_oFile1_Short;
        var str_oFile2_Root = str_Prj_Folder + "\\" + str_oFile2_Short;



        var sel = document.getElementById("OF_Category"); // Получаем наш список
        var str_OF_Category = sel.options[sel.selectedIndex].text;
        sel = document.getElementById("OF_Year"); // Получаем наш список
        var str_OF_Year = sel.options[sel.selectedIndex].text;
        sel = document.getElementById("OF_Month"); // Получаем наш список
        var str_OF_Month = sel.options[sel.selectedIndex].text;

        var str_oFile1_Full = str_Storage_Folder + "\\" + str_OF_Category + "\\" + str_OF_Year + "\\" + str_OF_Month + "." + str_OF_Year + "\\" + str_oFile1_Short;
        var str_oFile2_Full = str_Storage_Folder + "\\" + str_OF_Category + "\\" + str_OF_Year + "\\" + str_OF_Month + "." + str_OF_Year + "\\" + str_oFile2_Short;




        // конец. Раздел определяет входные и выходные файлы для команд Datamine

        // начало. Раздел выполняет манипуляции с файлами и непосредственное выполнение команд
        var fso_in = new ActiveXObject("Scripting.FileSystemObject"); // Объект FSO


        for (i = 0; i < files_names.length; i++) {
            str_I_files_names_Full = str_Storage_Folder + "\\" + files_names_subfolder + "\\" + files_names[i] + ".dm";
            //  не копируем а добавляем в проект str_I_files_names_Root=str_Prj_Folder+"\\"+ files_names[i]+".dm" ;

            if (fso_in.FileExists(str_I_files_names_Full)) {

                // не копируем а добавляем в проект fso_in.CopyFile(str_I_files_names_Full, str_I_files_names_Root,true);
                oDmApp.ActiveProject.AddFile(str_I_files_names_Full);

            }
            else {
                alert("Не могу скопировать. Файл: " + str_I_files_names_Full);
                return false;
            }
        }


        if (fso_in.FileExists(str_IFile_Full))
            oDmApp.ActiveProject.AddFile(str_IFile_Full);
        else alert("Не могу присоединить файл к проекту. Не найден файл: " + str_IFile_Full);
        if (fso_in.FileExists(str_IFile2_Full))
            oDmApp.ActiveProject.AddFile(str_IFile2_Full);
        else alert("Не могу присоединить файл к проекту. Не найден файл: " + str_IFile2_Full);
        if (fso_in.FileExists(str_IFile3_Full))
            oDmApp.ActiveProject.AddFile(str_IFile3_Full);
        else alert("Не могу присоединить файл к проекту. Не найден файл: " + str_IFile3_Full);
        if (fso_in.FileExists(str_IFile4_Full))
            oDmApp.ActiveProject.AddFile(str_IFile4_Full);
        else alert("Не могу присоединить файл к проекту. Не найден файл: " + str_IFile4_Full);
        if (fso_in.FileExists(str_IFile5_Full))
            oDmApp.ActiveProject.AddFile(str_IFile5_Full);
        else alert("Не могу присоединить файл к проекту. Не найден файл: " + str_IFile5_Full);
        if (fso_in.FileExists(str_IFile6_Full))
            oDmApp.ActiveProject.AddFile(str_IFile6_Full);
        else alert("Не могу присоединить файл к проекту. Не найден файл: " + str_IFile6_Full);

        deleteTemporaryFiles();

        oDmApp.ParseCommand("SORTX  &IN=" + str_IFile3_Short_DM + "  &OUT=skm1  *KEY1=PVALUE  @BINS=5.0  @ORDER=1.0");
        if (!chkFileInRoot("skm1", "SORTX")) return;

        switch (pit) {
            case "BL":
                oDmApp.ParseCommand("SPLIT &IN=skm1 &FNAMES=bench_lev *KEY=LAYER @NDP=0 @MAXFILES=100");
                break;
            case "OL":
                oDmApp.ParseCommand("SPLIT &IN=skm1 &FNAMES=OL_bench_lev *KEY=LAYER @NDP=0 @MAXFILES=100");
                break;
        }
        oDmApp.ParseCommand("RENAME &IN=p0000" + str_iBench + " &OUT=skm2");

        if (!chkFileInRoot("skm2", "RENAME")) return;
        oDmApp.ParseCommand("SORTX  &IN=" + str_IFile4_Short_DM + "  &OUT=skm3  *KEY1=PVALUE  @BINS=5.0  @ORDER=1.0");
        if (!chkFileInRoot("skm3", "SORTX")) return;
        oDmApp.ParseCommand("SPLIT &IN=skm3 &FNAMES=bench_lev *KEY=LAYER @NDP=0 @MAXFILES=100");
        switch (pit) {
            case "BL":
                oDmApp.ParseCommand("SPLIT &IN=skm3 &FNAMES=bench_lev *KEY=LAYER @NDP=0 @MAXFILES=100");
                break;
            case "OL":
                oDmApp.ParseCommand("SPLIT &IN=skm3 &FNAMES=OL_bench_lev *KEY=LAYER @NDP=0 @MAXFILES=100");
                break;
        }
        oDmApp.ParseCommand("RENAME &IN=p0000" + str_iBench + " &OUT=skm4");

        if (!chkFileInRoot("skm4", "RENAME")) return;
        var str_extra = "EXTRA    &IN=skm4  &OUT=skm5  @APPROX=0.0 @PRINT=0 ";
        for (i = int_iBench1 + int_iHBench; i >= int_iBench2; i = i - int_iHBench) {
            str_extra = str_extra +
            " 'IF(ZP>= " + (i - int_iHBench) + " AND ZP< " + i + " )'" +
            " 'LEVEL_10= " + (i - int_iHBench) + "'" +
            " 'END'";
        }
        str_extra = str_extra + " 'GO'";
        oDmApp.ParseCommand(str_extra);
        if (!chkFileInRoot("skm5", "extra")) return;
        oDmApp.ParseCommand("EXTRA &IN=skm5 &OUT=skm6 @APPROX=0 @PRINT=0" +
        " 'BENCH=LEVEL_10'" +
        " 'BENCH=LEVEL_10+5'" +
        " 'erase(LEVEL_10)'" +
        " 'erase(LAYER)'" +
        " 'GO'");
        if (!chkFileInRoot("skm6", "EXTRA")) return;

        var str_copy = "copy &IN=skm6 &OUT=skm7 ";

        if (str_iBench)
            str_copy = str_copy + " {BENCH=" + str_iBench + "}";
        oDmApp.ParseCommand(str_copy);
        if (!chkFileInRoot("skm2", "RENAME")) return;
        var str_extra = "EXTRA    &IN=skm2  &OUT=skm15  @APPROX=0.0 @PRINT=0 ";
        for (i = int_iBench1 + int_iHBench; i >= int_iBench2; i = i - int_iHBench) {
            str_extra = str_extra +
            " 'IF(ZP>= " + (i - int_iHBench) + " AND ZP< " + i + " )'" +
            " 'LEVEL_10= " + (i - int_iHBench) + "'" +
            " 'END'";
        }
        str_extra = str_extra + " 'GO'";
        oDmApp.ParseCommand(str_extra);
        if (!chkFileInRoot("skm15", "extra")) return;
        oDmApp.ParseCommand("EXTRA &IN=skm15 &OUT=skm16 @APPROX=0 @PRINT=0" +
        " 'BENCH=LEVEL_10'" +
        " 'BENCH=LEVEL_10+5'" +
        " 'erase(LEVEL_10)'" +
        " 'erase(LAYER)'" +
        " 'GO'");
        if (!chkFileInRoot("skm16", "EXTRA")) return;

        var str_copy = "copy &IN=skm16 &OUT=skm17 ";

        if (str_iBench)
            str_copy = str_copy + " {BENCH=" + str_iBench + "}";
        oDmApp.ParseCommand(str_copy);
        if (!chkFileInRoot("skm17", "COPY")) return;
        eraseSegmentLess3Points(str_Prj_Folder + "\\SKM17.dm");
        oDmApp.ParseCommand("SELEXY   &IN=" + str_IFile6_Short_DM + "  &PERIM=SKM17  &OUT=SKM8  *X=XC  *Y=YC  @OUTSIDE=1.0");
        if (!chkFileInRoot("SKM8", "SELEXY")) return;
        eraseSegmentLess3Points(str_Prj_Folder + "\\SKM7.dm");
        oDmApp.ParseCommand("SELEXY   &IN=SKM8  &PERIM=SKM7  &OUT=SKM9  *X=XC  *Y=YC  @OUTSIDE=0.0");
        if (!chkFileInRoot("SKM9", "SELEXY")) return;
        switch (pit) {
            case "BL":
                oDmApp.ParseCommand("SLIMOD   &PROTO=proto2x2x0_1  &IN=SKM9  &OUT=SKM10");
                break;
            case "OL":
                oDmApp.ParseCommand("SLIMOD   &PROTO=proto_3x3x0_5  &IN=SKM9  &OUT=SKM10");
                break;
        }
        if (!chkFileInRoot("SKM10", "SLIMOD")) return;
        oDmApp.ParseCommand("SELTRI &IN=SKM10 &WIRETR=" + str_IFile2_Short_DM + " &WIREPT=" + str_IFile_Short_DM + " &OUT=SKM11 *X=XC *Y=YC *Z=ZC @SELECT=2 @TOLERANC=0.001");
        if (!chkFileInRoot("SKM11", "SELTRI")) return;
        oDmApp.ParseCommand("SORTX  &IN=SKM11  &OUT=SKM12  *KEY1=IJK @BINS=5.0  @ORDER=1.0");
        if (!chkFileInRoot("SKM12", "SORTX")) return;
        switch (pit) {
            case "BL":
                oDmApp.ParseCommand("SLIMOD   &PROTO=proto2x2x800  &IN=SKM12  &OUT=SKM13");
                break;
            case "OL":
                oDmApp.ParseCommand("SLIMOD   &PROTO=proto_3x3x800  &IN=SKM12  &OUT=SKM13");
                break;
        }
        if (!chkFileInRoot("SKM13", "SLIMOD")) return;
        eraseSegmentLess3Points(str_IFile5_Full);
        oDmApp.ParseCommand("SELEXY   &IN=SKM13  &PERIM=" + str_IFile5_Short_DM + "  &OUT=SKM18  *X=XC  *Y=YC  *ATTRIB1=BLOCKID *ATTRIB2=MATERIAL *ATTRIB3=BLKNAM @OUTSIDE=0.0");
        if (!chkFileInRoot("SKM18", "SELEXY")) return;
        switch (pit) {
            case "BL":
                oDmApp.ParseCommand("EXTRA &IN=SKM18 &OUT=" + str_oFile2_Short_DM + " @APPROX=0 @PRINT=0" +
                        " 'if(GC_AU==absent())'" +
                        " 'GC_AU=0'" +
                        " 'end'" +
                        " 'if(GC_AS==absent())'" +
                        " 'GC_AS=0'" +
                        " 'end'" +
                        " 'if(GC_C==absent())'" +
                        " 'GC_C=0'" +
                        " 'end'" +
                        " 'if(GC_S==absent())'" +
                        " 'GC_S=0'" +
                        " 'end'" +
                        " 'if(GC_FE==absent())'" +
                        " 'GC_FE=0'" +
                        " 'end'" +
                        " 'GO'");
                if (!chkFileInRoot(str_oFile2_Short_DM, "SELEXY")) return;
                oDmApp.ParseCommand("TONGRAD  &IN=" + str_oFile2_Short_DM + "  &OUT=SKM14 &CSVOUT=" + str_oFile1_Short_DM + " *KEY1=BLOCKID *KEY2=BLKNAM *KEY3=MATERIAL  *DENSITY=DENSITY *F1=GC_AU *F2=GC_AS  *F3=GC_C  *F4=GC_S  *F5=GC_FE *F6=ORETYPE @FACTOR=1");
                break;
            case "OL":
                oDmApp.ParseCommand("EXTRA &IN=SKM18 &OUT=" + str_oFile2_Short_DM + " @APPROX=0 @PRINT=0" +
                        " 'if(GC_AU==absent())'" +
                        " 'GC_AU=0'" +
                        " 'end'" +
                        " 'if(GC_AS==absent())'" +
                        " 'GC_AS=0'" +
                        " 'end'" +
                        " 'if(GC_C==absent())'" +
                        " 'GC_C=0'" +
                        " 'end'" +
                        " 'if(GC_S==absent())'" +
                        " 'GC_S=0'" +
                        " 'end'" +
                        " 'if(GC_FE==absent())'" +
                        " 'GC_FE=0'" +
                        " 'end'" +
                        " 'if(GC_SB==absent())'" +
                        " 'GC_SB=0'" +
                        " 'end'" +
                        " 'if(GC_CA==absent())'" +
                        " 'GC_CA=0'" +
                        " 'end'" +
                        " 'if(GC_AG==absent())'" +
                        " 'GC_AG=0'" +
                        " 'end'" +
                        " 'GO'");
                if (!chkFileInRoot(str_oFile2_Short_DM, "SELEXY")) return;
                oDmApp.ParseCommand("TONGRAD  &IN=" + str_oFile2_Short_DM + "  &OUT=SKM14 &CSVOUT=" + str_oFile1_Short_DM + " *KEY1=BLOCKID *KEY2=BLKNAM *KEY3=MATERIAL  *DENSITY=DENSITY *F1=GC_AU *F2=GC_AS *F3=GC_C *F4=GC_S  *F5=GC_FE *F6=GC_SB *F7=GC_CA *F8=GC_AG @FACTOR=1");
                break;
        }
        if (!chkFileInRoot("SKM14", "TONGRAD")) return;

        var OVstr_oFile2_Short_DM = oDmApp.ActiveProject.Data.LoadFromProject("" + str_oFile2_Short_DM + "");
        oDmApp.ExecuteCommand("redraw-display");
        oDmApp.ExecuteCommand("update-vr-objects");
        var OVstr_IFile2_Short_DM = oDmApp.ActiveProject.Data.LoadFromProject("" + str_IFile2_Short_DM + "");
        oDmApp.ExecuteCommand("redraw-display");
        var OVstr_IFile5_Short_DM = oDmApp.ActiveProject.Data.LoadFromProject("" + str_IFile5_Short_DM + "");
        oDmApp.ExecuteCommand("redraw-display");
        var ObjData = getObjDataFromFile("SKM14");
        

        deleteTemporaryFiles();

        if (fso_in.FileExists(str_oFile1_Full))
            fso_in.DeleteFile(str_oFile1_Full);
        if (fso_in.FileExists(str_oFile2_Full))
            fso_in.DeleteFile(str_oFile2_Full);

        sendObjData(ObjData, operation_date);


        //if (fso_in.FileExists(str_oFile1_Root))
        //    fso_in.MoveFile(str_oFile1_Root, str_oFile1_Full);
        //else alert("Не могу переместить. Не найден файл: " + str_oFile1_Root);






       // alert("Всё получилось! Смотри файлы " + str_oFile1_Short + " в  папке " + str_Storage_Folder + "\\" + str_OF_Category + "\\" + str_OF_Year + "\\" + str_OF_Month + "." + str_OF_Year);

        // конец. Раздел выполняет манипуляции с файлами и непосредственное выполнение команд



    }
    catch (e) {
        alert("Failed\nReason: " + e.description);
    }
}