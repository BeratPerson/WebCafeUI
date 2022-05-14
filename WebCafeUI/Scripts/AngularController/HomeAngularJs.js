var app = angular.module("HomeApp", []);

app.controller("HomeController", function ($scope, $http) {

    $scope.GetTable = function() {

        $.ajax({
            url: '/Category/GetList',
            type: "POST",
            success: function (data, textStatus, jqXHR) {
                $scope.list = data;
                console.log(data);

            },
            error: function (jqXHR, textStatus, errorThrown) {
                toastr.error("Category", "Couldn't added category ")

            }
        });
    }
});