$(document).ready(function () {

var slidercontent = $(".slidercontent");
var prevbtn = $(".prevbtn");
var nextbtn = $(".nextbtn");
var imgbody = $(".imgbody");
var img = $(".imgbody img");
var main = $("main");
var ekrangenisligi = main.outerWidth();
var length = img.length;
var responsize, ratio, aspectratio;
var imgdiv = $(".img");
function sliderfnc() {
    ekrangenisligi = main.outerWidth(true);
    if (ekrangenisligi >= 1920) {
        responsize = Math.ceil((ekrangenisligi * 20) / 100);
    } else if (ekrangenisligi < 1920 && ekrangenisligi > 1600) {
        responsize = Math.ceil((ekrangenisligi * 20) / 100);
    } else if (ekrangenisligi < 1600 && ekrangenisligi > 1200) {
        responsize = Math.ceil((ekrangenisligi * 20) / 100);
    } else if (ekrangenisligi < 1200 && ekrangenisligi > 992) {
        responsize = Math.ceil((ekrangenisligi * 33.33) / 100);
    } else if (ekrangenisligi < 992 && ekrangenisligi > 768) {
        responsize = Math.ceil((ekrangenisligi * 50) / 100);
    } else if (ekrangenisligi < 768 && ekrangenisligi > 576) {
        responsize = Math.ceil((ekrangenisligi * 50) / 100);
    } else {
        responsize = Math.ceil((ekrangenisligi * 100) / 100);
    }

    imgbody.width(length * responsize);
    imgdiv.width(responsize);
    ratio = responsize / imgdiv.height();
    imgdiv.height(Math.ceil(responsize / ratio));

}

sliderfnc();

$(window).resize(function () {
    imgdiv.height("auto");
    sliderfnc();
});

});