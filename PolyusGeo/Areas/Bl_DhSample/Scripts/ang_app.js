

    var Samples = angular.module("Samples", ["ui.bootstrap"]);
 
    Samples.controller("DataPanel", function ($scope, $uibModal) {
    
        $scope.btnSetSamples = function () {
            var dtm = { startSample: 0 , numSample:0 };
            var modalInstance = $uibModal.open({
                templateUrl: ModalTplUrl,
                controller: 'ModalInstanceCtrl',
                resolve: {
                    dtm: function () {
                        return dtm;
                    }
                }
            });

            modalInstance.result.then(function () {
                startSample = dtm.startSample;
                numSample = dtm.numSample;

                $scope.iDhNum = getDhCountInData("dh_points");
                $scope.iSampleNum = getSampleCountInData("dh_points");
                $scope.isLitoExist = "Нет";

            });

        }

        $scope.btnSetLito = function () {
            SetLito($scope);
        }

        $scope.btnRecordToDb = function()
        {
            RecordToDb($scope);
        }

        $scope.input_file_change = function (element) {

            var fullFilename = element.value;
            var pattern_shortFilename = /[\w\d\s]+\.(\w{2})$/;  // получаем короткое имя файла
            var result = pattern_shortFilename.exec(fullFilename);
            if (result != null)
                var shortFilename = result[0];
            else
                var shortFilename = '(имя не определено)';
            angular.element(element).next().children().eq(1).val(shortFilename)
            btnShowDh_onclick();
            $scope.iDhNum = getDhCountInData("dh_points");
            $scope.iSampleNum = getSampleCountInData("dh_points");
            $scope.isLitoExist = "Нет";
            $scope.$apply();

        }


    });
    
    Samples.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance,  dtm) {
        $scope.dtm = dtm;
        $scope.ok = function () {

            btnSetSample_Ok($scope);

        };

        $scope.cancel = function () {
            $uibModalInstance.close();
            //$uibModalInstance.dismiss('cancel');
        };
    });

    var test = function ($scope)
  {
        alert($scope.dtm.startSample);
  }