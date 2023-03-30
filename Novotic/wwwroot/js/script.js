https://www.youtube.com/watch?v=idRdAgNnC5Q&ab_channel=MagtimusPro
// 4343
//Ejecutar funci�n en el evento click
document.getElementById("btn_open").addEventListener("click", open_close_menu);

let demo = document.querySelector('.demo');

//Declaramos variables
var side_menu = document.getElementById("menu_side");
var btn_open = document.getElementById("btn_open");
var body = document.getElementById("body");

let icono_menu = document.querySelector('#icon__menu')
let seccion_principal = document.querySelector('#sectionID')

//Evento para mostrar y ocultar men�
function open_close_menu() {
    body.classList.toggle("body_move");
    side_menu.classList.toggle("menu__side_move");

    icono_menu.classList.toggle("icon__menu_move")
    seccion_principal.classList.toggle("seccion_principal_move")


    let propiedad = window.getComputedStyle(demo);
    let vrPropiedad = propiedad.getPropertyValue('margin-left');
    let controladorPixel = vrPropiedad;

    // console.log(controladorPixel)

    if (controladorPixel === '80px') {
        demo.style.marginLeft = '0px';
        controladorPixel = '0px'
    } else {
        demo.style.marginLeft = '80px';
        controladorPixel = '80px'
    }
    // console.log(controladorPixel)

    // if(controladorPixel === '0px'){
    //     demo.style.marginLeft = '80px'
    //     controladorPixel = '80px'
    // }else{
    //     demo.style.marginLeft = '0px'
    //     controladorPixel = '0px'
    // }

    // console.log(controladorPixel)


}

//Si el ancho de la p�gina es menor a 760px, ocultar� el men� al recargar la p�gina

if (window.innerWidth < 760) {
    body.classList.add("body_move");
    side_menu.classList.add("menu__side_move");

    icono_menu.classList.toggle("icon__menu_move")
    seccion_principal.classList.toggle("seccion_principal_move")
}

//Haciendo el men� responsive(adaptable)

window.addEventListener("resize", function () {

    if (window.innerWidth > 760) {
        body.classList.remove("body_move");
        side_menu.classList.remove("menu__side_move");

    }

    if (window.innerWidth < 760) {
        body.classList.add("body_move");
        side_menu.classList.add("menu__side_move");

    }

});
