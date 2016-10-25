

angular.module('clientApp.services',[]).factory('Client',function($resource){
    return $resource('http://localhost:58723/api/Client/:id',{id:'@_id'},{
        update: {
            method: 'PUT'
        }
    });
}).service('popupService',function($window){
    this.showPopup=function(message){
        return $window.confirm(message);
    }
});