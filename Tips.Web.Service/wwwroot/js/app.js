var myApp = angular.module('myApp', ['restangular', 'ngRoute']);

myApp.config(function($routeProvider, RestangularProvider) {
    RestangularProvider.setBaseUrl('http://localhost:5000/api/');

    $routeProvider
        .when('/', {
            controller: 'ShowTipController',
            templateUrl: 'showTip.html'
        })
        .when('/admin/add', {
            controller: 'AddTipController',
            templateUrl: 'addTip.html'
        })
        .otherwise({
            redirectTo: '/'
        });
});

// Controller for show a tip
myApp.controller('ShowTipController', ['$scope', 'Restangular', function($scope, Restangular) {
    $scope.tips = Restangular.all("tips").getList()
        .then(function(tips){
            $scope.tipToShow = tips[Math.floor(Math.random() * tips.length)];
        },
        function(err){
            $scope.tipToShow = {text:"maybe there is a problem with the tips api :-)"};
        });
}]);

// Controller for add a tip
myApp.controller('AddTipController', ['$scope', 'Restangular', function($scope, Restangular) {
    $scope.tipText='';
    $scope.addTip = function(){
        console.log("I'd like to add the tip " + $scope.tipText);
        Restangular.all('tips').post({text:$scope.tipText}).then(function (tip) {
            // Reload main view when done
            $location.path('/');
        });
    }
}]);
