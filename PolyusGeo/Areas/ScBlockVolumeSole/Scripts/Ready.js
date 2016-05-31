$(document).ready(function () {

    AutoConnect();

    $(document).on('change', '.customFile', function () {
        //  debugger;
        var fullFilename = $(this).val();
        var pattern_shortFilename = /[\w\d]+\.(\w{2})$/;  // получаем короткое имя файла
        var result = pattern_shortFilename.exec(fullFilename);
        if (result != null)
            var shortFilename = result[0];
        else
            var shortFilename = '(имя не определено)';
        $(this).next().children().eq(1).val(shortFilename);
    });

    $(document).on('change', '#iFile5', function () {

        var fullFilename = $(this).val();
        var pattern_shortFilename = /[\w\d]+\.(\w{2})$/;  // получаем короткое имя файла
        var result = pattern_shortFilename.exec(fullFilename);
        if (result != null) {
            var shortFilename = result[0];
            var pattern_bench = /^\d{3}/;  // получаем горизонт
            result = pattern_bench.exec(shortFilename);
            if (result != null)
                var bench = result[0];
            else {
                var bench = '(имя не определено)';
            }
        }
        else {
            var shortFilename = '(имя не определено)';
        }
        $('#iBench').text(bench);


        if (bench == '(имя не определено)')
            $('#iFile6FileName').val(bench);
        else
            $('#iFile6FileName').val(bench + '_bm_au.dm');
    });

    var now = new Date();
    var nowYear = now.getFullYear();
    var nowMonth = now.getMonth() + 1;
    document.getElementById('y' + nowYear).selected = true;
    document.getElementById('m' + nowMonth).selected = true;

});