$(document).ready(function(){
    var userID = $.session.get('userID');
    if(userID>0)
        alert(userID);
})