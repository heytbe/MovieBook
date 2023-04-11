$(document).ready(function(){
    var menu = $(".menu");
    var main = $("main");
    var tiklamasayisi = 0;
    $("body").on("click",".menubutonu",function(){
        if(tiklamasayisi == 0){
        menu.css("width","80px");
        main.css("width","calc(100% - 80px)");
        tiklamasayisi++;
        }else{
            menu.css("width","250");
            main.css("width","calc(100% - 250px");
            tiklamasayisi--;
        }
     });

     $(".div6bolum .heytbe").hover(
        function() {
        $(this).children(".divsetting").css("display","block");
        }, function() {
        $(this).children(".divsetting").css("display","none");
        }
      );


    $(document).on("click", ".fragmanbtn", function () {
        $(".popupfragman").css("display", "block");
    });

    $(document).on("click", ".popupfragman span", function () {
        $(".popupfragman").css("display", "none");
    });

});


