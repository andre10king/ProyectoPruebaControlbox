
var testApp = angular.module("articuloModule", []);

testApp.controller("articuloController", function ($scope, $http) {
    $http.get('/api/Pais').then(function (response) {
        $scope.articulos2 = response.data;
    });




    $scope.countries = [
        {
            name: 'Colombia',
            cities: ['Bogotá', 'Medellín', 'Cali']
        },
        {
            name: 'Perú',
            cities: ['Lima', 'Arequipa', 'Cusco']
        },
        {
            name: 'México',
            cities: ['Ciudad de México', 'Guadalajara', 'Monterrey']
        }
    ];

    $scope.getCities = function (country) {

        if (country.name == 'Colombia') {
            return country.cities;
        }

        else
        {
            console.log('no hay');

        }


        
    };






   




  
    //$scope.categories = [
    //    { name: 'Categoría 1', id: 1 },
    //    { name: 'Categoría 2', id: 2 },
    //    { name: 'Categoría 3', id: 3 }
    //];

    //$scope.products = [
    //    { name: 'Producto 1', categoryId: 1 },
    //    { name: 'Producto 2', categoryId: 1 },
    //    { name: 'Producto 3', categoryId: 2 },
    //    { name: 'Producto 4', categoryId: 3 },
    //    { name: 'Producto 5', categoryId: 3 }
    //];

    //$scope.filterProducts = function () {
    //    $scope.filteredProducts = $scope.products.filter(function (product) {
    //        return product.categoryId === $scope.selectedCategory.id;
    //    });
    //};





    $scope.delete = function (id) {

        $http.delete('/api/Pais/' + id)
            .success(function (data) {
                console.log(data);

            })
            .error(function (data) {
                console.log('Error: ' + data);
            });
    };


    $scope.deleteItem = function (a) {
        var index = $scope.articulos2.indexOf(a);
        $scope.articulos2.splice(index, 1);
    };






    $scope.submitForm = function () {
        if ($scope.myForm.$valid) {
          

            var data = {
                /*id: $scope.Id,*/

                Nombre: $scope.nombre
               
            };
            $http.post('/api/Pais', data).then(function (response) {

                console.log(response.data);
                $scope.articulos2.push(response.data);



             



            });




            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: 'guardado con exito',
                showConfirmButton: false,
                timer: 2000

            })
            
        }
        else {

            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Porfavor llenar todos los campos!',
                footer: '<a href="">Why do I have this issue?</a>'
            })

        }
    };












});