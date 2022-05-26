jQuery(document).ready(function ($) {

    $(".hrInp, .minInp").focus(function () {
        console.log($(this).val());
    });
    //$(document).on(' change blur', ' .minInp, .hrInp', function () {
    //    let v = ($(this).val() == "") ? 0 : $(this).val();
    //    $(this).val(v);
    //});
    $(document).on('focus', ' .minInp, .hrInp', function () {
        
        $(this).val('');
    });
    $(document).on('blur', ' .minInp, .hrInp', function () {
        //let v = ($(this).val() == "") ? 0 : $(this).val() ;
        //$(this).val(v);
    });
    var focusedElement;
    //$(document).on('focus keyup blur', ' .minInp', function () {
    //    if ($(this).val() > 60) {
    //        $(this).val(0);
    //    }
    //    else { }
    //    if (focusedElement == this) return;
    //    focusedElement = this;

    //    setTimeout(function () { focusedElement.select(); }, 100);

    //});


});