var myApp = angular.module('myApp', ['restangular', 'ngRoute']);

myApp.config(function($routeProvider, RestangularProvider) {
    RestangularProvider.setBaseUrl('http://localhost:5000/api/');

    $routeProvider
        .when('/', {
            controller: 'ShowTipController',
            templateUrl: 'showTip.html'
        })
        .when('/admin/', {
            controller: 'ListTipController',
            templateUrl: 'listTip.html'
        })
        .when('/admin/add', {
            controller: 'AddTipController',
            templateUrl: 'detailTip.html'
        })
        .when('/admin/edit/:tipId', {
            controller: 'EditTipController',
            templateUrl: 'detailTip.html',
            resolve: {
                tip: function (Restangular, $route) {
                    // return a Restangular promise, the route will 
                    // load only when the promise resolves
                    return Restangular.one('tips', $route.current.params.tipId).get();
                }
            }
        })
        .otherwise({
            redirectTo: '/'
        });
});

// Controller for showing a tip
myApp.controller('ShowTipController', ['$scope', 'Restangular', function($scope, Restangular) {
    Restangular.all("tips").getList()
        .then(function(tips){
            $scope.tipToShow = tips[Math.floor(Math.random() * tips.length)];
        },
        function(err){
            $scope.tipToShow = {text:"maybe there is a problem with the tips api :-)"};
        });
}]);

// Controller for listing tips and deleting a tip (admin)
myApp.controller('ListTipController', ['$scope', 'Restangular', '$location', function($scope, Restangular, $location) {
    Restangular.all("tips").getList()
        .then(function(tips){
            $scope.tips = tips;
        },
        function(err){
            console.log("maybe there is a problem with the tips api :-)");
        });
    
    $scope.deleteTip = function (tip) {
        tip.remove().then(function () {
            // Reload list when done
            $location.path('/admin');
        });
    };
}]);

// Controller for editing a tip (admin)
myApp.controller('EditTipController', ['$scope', 'Restangular', 'tip', '$location', function($scope, Restangular, tip, $location) {
    var original = tip;
    $scope.tip = Restangular.copy(original);
    $scope.save = function () {
        $scope.tip.put().then(function () {
            // Reload list when done
            $location.path('/admin');
        });
    };
}]);

// Controller for adding a tip (admin)
myApp.controller('AddTipController', ['$scope', 'Restangular', '$location', function($scope, Restangular, $location) {
    $scope.save = function () {
        Restangular.all('tips').post($scope.tip).then(function (project) {
        $location.path('/admin');
    });
  };
}]);
