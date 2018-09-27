var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    $scope.InsertData = function () {
        var action = document.getElementById("btnSave").getAttribute("value");
        if (action == "Save") {
            $scope.Student = {};
            $scope.Student.StudentID = $scope.StudentID;
            $scope.Student.Name = $scope.Name;
            $scope.Student.Address = $scope.Address;
            $http({
                method: "post",
                url: "http://localhost:15508/Student/InsertStudent",
                datatype: "json",
                data: JSON.stringify($scope.Student)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.StudentID = "";
                $scope.Name = "";
                $scope.Address = "";
            })
        } else {
            $scope.Student = {};
            $scope.Student.StudentID = $scope.StudentID;
            $scope.Student.Name = $scope.Name;
            $scope.Student.Address = $scope.Address;
            $scope.Student.id = document.getElementById("id").value;
            $http({
                method: "post",
                url: "http://localhost:15508/Student/UpdateStudent",
                datatype: "json",
                data: JSON.stringify($scope.Student)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.StudentID = "";
                $scope.Name = "";
                $scope.Address = "";
                document.getElementById("btnSave").setAttribute("value", "Save");
            })
        }
    }

    //GetDataStudent
    $scope.GetAllData = function () {
        
        $http({
            method: "get",
            url: "http://localhost:15508/Student/GetStudent"
        }).then(function (response) {
            $scope.students = response.data;
        }, function () {
            alert("Data Not Found");
        })

    };

    $scope.GetById = function (student) {
        $http({
            method: "get",
            url: "http://localhost:15508/Student/GetById",
            datatype: "json",
            data: JSON.stringify(student)
        }).then(function () {
            document.getElementById("id").value = student.id;
            $scope.StudentID = student.StudentID;
            $scope.Name = student.Name;
            $scope.Address = student.Address;
        })
    };

    $scope.DeleteStudent = function (id) {
        //var coba = document.getElementById("id_student").value;
        $http({
            method: "post",
            url: "http://localhost:15508/Student/DeleteStudent/"+id,
            datatype: "json",
            data: JSON.stringify(id)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })

    };

});