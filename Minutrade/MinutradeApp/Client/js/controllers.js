
angular.module('clientApp.controllers',[]).controller('ClientListController',function($scope,$state,popupService,$window,Client){

    $scope.clients= Client.query();
    $scope.deleteClient=function(client){
        if(popupService.showPopup('Tem certeza que deseja remover?')){
            Client.delete({id: client.Cpf});   
            setTimeout(function(){ $scope.clients= Client.query();}, 2500);
                        
        }
    }

}).controller('ClientViewController',function($scope,$stateParams,Client){

    $scope.client=Client.get({id:$stateParams.id});

}).controller('ClientCreateController',function($scope,$state,$stateParams,Client){

    $scope.client=new Client();

    $scope.addClient=function(){
        $scope.client.$save(function(){
            $state.go('client');
        });
    }

}).controller('ClientEditController',function($scope,$state,$stateParams,Client){

    $scope.updateClient=function(){
        $scope.client.$update(function(){
            $state.go('client');
        });
    };

    $scope.loadClient=function(){
        $scope.client=Client.get({id:$stateParams.id});
    };

    $scope.loadClient();
});