function OpenLoading() {
    loading = document.getElementById("loading");
    loading.style.display = "block";
}

function CloeseLoading() {
    setTimeout(function () {
        loading = document.getElementById("loading");
        loading.style.display = "none";
    }, 600);

}


$(document).ready(
      function () {
          var id = 0;
          var controller;
          $(".lkbExcluir").click(
               function () {
                   id = $(this).attr("data-id");
                   var nome = $(this).attr("data-nome");
                   controller = $(this).attr("data-controller");
                   //console.log(id);
                   //console.log(controller);
                   $("#nomeItem").html(nome);
               });
          $("#btnConfirmar").click(
          function () {
              //console.log(id);
              OpenLoading();
              $.ajax(
                  {
                      dataType: "json",
                      contentType: 'application/json',
                      type: "GET",
                      url: "/" + controller + "/Excluir",
                      data: { 'id': id },

                      success: function (dados) {
                          CloeseLoading();
                          location.reload();
                      },
                      error: function (dados) {
                          //alert(dados);
                          location.reload();
                      }
                  });
          })
             
      });

// para que o menu lateral do adm recolha e mostre corretamente 
$(function () {
    $('.navbar-toggle-sidebar').click(function () {
        $('.navbar-nav').toggleClass('slide-in');
        $('.side-body').toggleClass('body-slide-in');
        $('#search').removeClass('in').addClass('collapse').slideUp(200);
    });

    $('#search-trigger').click(function () {
        $('.navbar-nav').removeClass('slide-in');
        $('.side-body').removeClass('body-slide-in');
        $('.search-input').focus();
    });
});


// para mudara a classe active item de posisao de acordo com a navegacao
//usado na parte adm no menu lateral
$(function () {
    var path = window.location.pathname;
    if (path != "/") {
        $(".navbar-nav li").removeClass("active");
        $(".navbar-nav li").each(function () {
            var href = $(this).children().first().attr("href");
            if (path == href) {
                $(this).addClass("active");
            }
        });
    } else {
        $(".navbar-nav li").removeClass("active");
        $(".navbar-nav li").each(function () {
            var href = $(this).children().first().attr("href");
            if (path == href) {
                $(this).addClass("active");
            }
        });
    }
});
$(function () {
    var path = window.location.pathname;
    //console.log('passei')
    if (path != "/") {
        $(".top-menu .nav .navbar-nav li a").removeClass("active scroll");
        $(".top-menu .nav .navbar-nav li a").each(function () {
            var href = $(this).children().first().attr("href");
            if (path == href) {
                $(this).addClass("active scroll");
            }
        });
    } else {
        $(".top-menu .nav .navbar-nav li a").each(function () {
            var href = $(this).children().first().attr("href");
            if (path == href) {
                $(this).addClass("active scroll");
            }
        });
    }
});


//para mostrar e recolher o menu quando estiver em layouts pequenos
$("span.menu").click(function () {
    $(".top-menu").slideToggle("slow", function () {
        // Animation complete.
    });
});

