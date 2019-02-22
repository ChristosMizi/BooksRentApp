$(function () {
    $('[data-admin-menu]').hover(function () {

        $('[data-admin-menu]').toggleClass('open');
    })

});
//1) we have to add this to our BundleConfig 
//2) change the reference to _Layout.cshtml from Scripts.Render("~/bundles/bootstrap") to