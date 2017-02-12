var myApp = angular.module('tipsApp', []);

angular.module('tipsApp').controller('tipsController', ['$scope', function($scope) {
    $scope.password = '';
    $scope.strength = 'not evaluated';
    $scope.grade = function () {
        var size = $scope.password.length;
        if (size > 8) {
            $scope.strength = 'strong';
        } else if (size > 3) {
            $scope.strength = 'medium';
        } else {
            $scope.strength = 'weak';
        }
    };

    $scope.test = function(){
        console.log('qui');
    }

    $scope.$watch('password.length', function (newValue, oldValue) {
        $scope.grade();
    });
}]);
