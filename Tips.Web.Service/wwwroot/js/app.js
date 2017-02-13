var myApp = angular.module('myApp', ['restangular', 'ngRoute']);

myApp.config(function($routeProvider, RestangularProvider) {
    RestangularProvider.setBaseUrl('http://localhost:5000/api/');

    $routeProvider
        .when('/', {
            controller: 'ShowTipController',
            templateUrl: 'showTip.html'
        })
        .otherwise({
            redirectTo: '/'
        });
});

// Controller for show a tip
myApp.controller('ShowTipController', ['$scope', 'Restangular', function($scope, Restangular) {
    $scope.tips = Restangular.all("tips").getList().then(function(tips){
        $scope.tipToShow = tips[Math.floor(Math.random() * tips.length)];
    })
}]);
