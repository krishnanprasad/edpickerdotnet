/**
 * Created by DELL on 9/1/2016.
 */


jQuery(document).ready(function($){

    var opallisting_ppt_type_select_val =  $("#opallisting_ppt_type").val();

    $(".specific-fields").hide();

    $(".specific-field-"+opallisting_ppt_type_select_val).show();

    $("#opallisting_ppt_type").on("change", function (e) {
        e.preventDefault();

        var selectVal = $(this).val();

        $(".specific-fields").hide();

        $(".specific-field-"+selectVal).show();

    });

});


