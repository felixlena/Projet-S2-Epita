

var gallerie = document.querySelector(".gal1")

var but = document.querySelector(".galButton")
var but2 = document.querySelector(".galButton2")

var i = 0;

but2.onclick= function()   { 
    i = i-=1;
    if (i<0)
    {
        i=8;
    }
    if (i ===0)  {
        gallerie.classList = ("gal1");
    }
    if (i ===1)  {
        gallerie.classList = ("gal2");
    }
    if (i ===2)  {
        gallerie.classList = ("gal3");
    }
    if (i==3)   {
        gallerie.classList = ("gal4");
    }
    if (i==4)   {
        gallerie.classList = ("gal4");
    }
    if (i==5)   {
        gallerie.classList = ("gal4");
    }    
    if (i==6)   {
        gallerie.classList = ("gal4");
    }    
    if (i==7)   {
        gallerie.classList = ("gal4");
    }
    if (i==8)   {
        gallerie.classList = ("gal4");
        i=8
    }
}
but.onclick= function()   { 
    i = i+1;
    if (i>8)
    {
        i=0;
    }
    if (i ===0)  {
        gallerie.classList = ("gal1");
    }
    if (i ===1)  {
        gallerie.classList = ("gal2");
    }
    if (i ===2)  {
        gallerie.classList = ("gal3");
    }
    if (i==3)   {
        gallerie.classList = ("gal4");
    }
    if (i==4)   {
        gallerie.classList = ("gal4");
    }
    if (i==5)   {
        gallerie.classList = ("gal4");
    }    
    if (i==6)   {
        gallerie.classList = ("gal4");
    }    
    if (i==7)   {
        gallerie.classList = ("gal4");
    }
    if (i==8)   {
        gallerie.classList = ("gal4");
        i=8
    }
}

var ele1 = document.querySelector(".element1");
var ele2 = document.querySelector(".element2");
var ele3 = document.querySelector(".element3");
var ele4 = document.querySelector(".element4");
var ele5 = document.querySelector(".element5");
var ele6 = document.querySelector(".element6");
var ele7 = document.querySelector(".element7");
var ele8 = document.querySelector(".element8");
var ele9 = document.querySelector(".element9");


ele1.onclick = function()   {
    i=0;
    gallerie.classList = ("gal1");
}


ele2.onclick = function()   {
    i=1
    gallerie.classList = ("gal2");
}

ele3.onclick = function()   {
    i=2;
    gallerie.classList = ("gal3");
}


ele4.onclick = function()   {
    i=3;
    gallerie.classList = ("gal4");
}


ele5.onclick = function()   {
    i=4;
    gallerie.classList = ("gal4");
}

ele6.onclick = function()   {
    i=5;
    gallerie.classList = ("gal4");
}

ele7.onclick = function()   {
    i=6;
    gallerie.classList = ("gal4");
}


ele8.onclick = function()   {
    i=7;
    gallerie.classList = ("gal4");
}

ele9.onclick = function()   {
    i=8;
    gallerie.classList = ("gal4");
}
