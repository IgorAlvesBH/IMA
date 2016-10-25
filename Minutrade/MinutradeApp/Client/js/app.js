

angular.module('clientApp',['ui.router','ngResource', 'ngMask','clientApp.controllers','clientApp.services']);

angular.module('clientApp').config(function($stateProvider,$httpProvider){
    $stateProvider.state('client',{
        url:'/clients',
        templateUrl:'partials/client.html',
        controller:'ClientListController'
    }).state('viewClient',{
       url:'/clients/:id/view',
       templateUrl:'partials/client-view.html',
       controller:'ClientViewController'
    }).state('newClient',{
        url:'/clients/new',
        templateUrl:'partials/client-add.html',
        controller:'ClientCreateController'
    }).state('editClient',{
        url:'/clients/:id/edit',
        templateUrl:'partials/client-edit.html',
        controller:'ClientEditController'
    });
}).run(function($state){
   $state.go('client');
});