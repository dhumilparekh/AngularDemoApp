var app = angular.module('SampleApp',[]);

app.controller('SampleCtrl', ['$scope', function ($scope) {

   var uri = 'api/SamplesAPI';
   //$scope.samples = [{};//[{ "SampleId": 1, "Barcode": "129076", "CreatedAt": "2015-01-02T00:00:00", "FirstName": "Dhumil", "LastName": "Parekh", "Status": "Report Generation" }, { "SampleId": 2, "Barcode": "176033", "CreatedAt": "2015-07-31T00:00:00", "FirstName": "John", "LastName": "Smith", "Status": "In Lab" }];//{};

   $scope.loadSample = function () {
       $.getJSON(uri)
             .done(function (data) {
                 // On success, 'data' contains a list of samples.
                 //console.log(data);
                 $scope.samples = data;
                 $scope.$digest();
             });
   };

   $scope.loadSample();

}]);