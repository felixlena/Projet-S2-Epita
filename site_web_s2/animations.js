/*var compteur = document.getElementById("essai");

function decrease ()    {
    var count = Number(compteur.textContent);
    if  (count >1) {
        compteur.textContent = count -1;
    }   else    {
        clearInterval(tetsinterval);
        var recup = document.getElementById("titre");
        recup.textContent = "BOUM";
        setTimeout(function () {
            recup.textContent = "Je sais plus quoi faire ;(";
        }, 2000);
    }
}

var tetsinterval = setInterval(decrease,1000);





var bloc = document.getElementById("testMove2");
var cadre = document.getElementById("testMove");
var vitesse = 7;
var blocLarge = parseFloat(getComputedStyle(bloc).width);
var anime = null;

function move ()    {
    var myBlock = parseFloat(getComputedStyle(bloc).left); //recupere l'element left 
    var cadreLarge = parseFloat(getComputedStyle(cadre).width);


    if (myBlock + blocLarge <= cadreLarge)   {
        bloc.style.left = (myBlock + vitesse) + "px"; // on assigne a l'element left une nouvelle position egale a vitesse + sa position initiale

        anime = requestAnimationFrame(move); // On demande au pc de refaire l'animation si c'est possible
    }   else    {
        cancelAnimationFrame(anime);
    }

}

anime = requestAnimationFrame(move); // on lance l'animation*/


/* RESPONSIVE_BUTTON_INDEX*/
var nav = document.querySelector('.nav');

var btn = document.querySelector('.button');

btn.onclick = function(){
    nav.classList.toggle('nav_open');
}

/* RESPONSIVE_BUTTON_INDEX*/