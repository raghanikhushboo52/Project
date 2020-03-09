$(document).ready(function () {
    $("#Delete").click(function () {
        debugger;
        alert($("#cid").val());
        AJAXCall("Customer", $("#cid").val())
    })
    $("#DeleteCity").click(function () {
        debugger;
        alert($("#cityid").val());
        AJAXCall1("Cities", $("#cityid").val())
    })

    function AJAXCall(controller, id) {
        debugger;
        $.ajax({
            type: "POST",
            url: "/" + controller + "/ConfirmDelete/" + id,
            dataType: "json",
            success: function (data) {
                alert("Data Deleted succesfully!!!!");
                window.location.assign("/Customer/Index");
            }
        });
    }

    function AJAXCall1(controller, id) {
  
        $.ajax({
            type: "POST",
            url: "/" + controller + "/ConfirmDelete/" + id,
            dataType: "json",
            success: function (data) {
                alert("Data Deleted succesfully!!!!");
                window.location.assign("/Cities/Index");
            }
        });
    }

   
});