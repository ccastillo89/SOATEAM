var mensajevalidacionseleccionar = "Debe seleccionar por lo menos un registro.";

String.prototype.format = function () {
   var args = arguments;
   return this.replace(/\{(\d+)\}/g, function (m, n) { return args[n]; });
};

function createCookie(name, value, days) {
   if (days) {
      var date = new Date();
      date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
      var expires = "; expires=" + date.toGMTString();
   }
   else var expires = "";
   document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
   var nameEQ = name + "=";
   var ca = document.cookie.split(';');
   for (var i = 0; i < ca.length; i++) {
      var c = ca[i];
      while (c.charAt(0) == ' ') c = c.substring(1, c.length);
      if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
   }
   return null;
}

function eraseCookie(name) {
   createCookie(name, "", -1);
}

function seleccionarDeseleccionarTodos(idTodos, idCheck) {
   $('#' + idTodos).on('click', function () {
      var checked = $('#' + idTodos).is(':checked');
      $('input[name="' + idCheck + '"]:checkbox').each(function () {
         if (!this.disabled)
            this.checked = checked;
      });
   });
   $("[name='" + idCheck + "']").on('click', function () {
      var checks = $("[name='" + idCheck + "']");
      var checkados = checks.filter(":checked");
      $("#" + idTodos)[0].checked = (checks.length == checkados.length);
   });
}

function validachecks(tablagrilla) {
   var check = $('table[id="' + tablagrilla + '"] :checkbox:gt(0)');
   var lanza = true;


   //verifica  que este seleccionado por lo menos uno
   for (var i = 0; i < check.length; i++) {
      if (check[i].checked) {
         lanza = false;
         break;
      }
   }

   if (lanza) {
      bootbox.alert(mensajevalidacionseleccionar);
      return false;
   }

   return true;
}

function ObtenerIds(IdCheck) {
   var o = new Array();
   $("[name='chkSeleccion']").filter(":checked").each(function () {
      o.push($(this).next().val());
   });
   return o;
}

var dialogocargando;

$.ajaxSetup({
   beforeSend: function () {
      dialogocargando = bootbox.dialog({ message: 'Cargando...' });
   },
   complete: function () {
      dialogocargando.modal('hide');
   },
   success: function () {
      dialogocargando.modal('hide');
   }
});

function selectorUsuarios(Control, Persistencia) {
   var agrega = function (per) {
      for (p in per) {
         Control.tokenInput("add", {
            id: per[p].id,
            nombre: per[p].nombre,
            readonly: per[p].readonly
         });
      }
      Control.tokenInput("hideHint");
      var algo = 1;
   };
   return {
      persistePostBack: function () {
         var per;
         if (Persistencia.val() != "[]" && Persistencia.val() != "") {
            per = $.parseJSON(Persistencia.val());
            agrega(per);
         }
      },
      persistencia: function (item) {
         Persistencia.val(JSON.stringify(Control.tokenInput("get")));
         Control.tokenInput("hideHint");
      },
      inicializa: function (items) {
         var obj = $.parseJSON(items);
         agrega(obj);
      },
      limpiar: function () {
         Control.tokenInput("clear");
         Control.tokenInput("hideHint");
      },
      width: function (w) {
         Control.parent().find("ul").width(w);
      },
      disabled: function (b) {
         if (Persistencia.val() != "[]" && Persistencia.val() != "") {
            var per = $.parseJSON(Persistencia.val());
            for (p in per) {
               per[p].readonly = b;
            }
            Control.tokenInput("clear");
            agrega(per);
         }
         Control.parent().find("input[type=text]").prop("disabled", b);
      },
      HideHint: function () {
         Control.tokenInput("hideHint");
      },
      Get: function () {
         return Control.tokenInput("get");
      },
      Add: function (item) {
         agrega(item);
      }
   };
};

function FormatFechaYHora(fecha) {
   var fechasola = fecha.substr(0, 10);
   return fechasola.substr(8, 2) + "/" + fechasola.substr(5, 2) + "/"
       + fechasola.substr(0, 4) + " " + fecha.substr(fecha.indexOf("T") + 1, 5);
}

function FormatFecha(fecha) {
   var fechasola = fecha.substr(0, 10);
   return fechasola.substr(8, 2) + "/" + fechasola.substr(5, 2) + "/"
       + fechasola.substr(0, 4);
}

//el formato de fecha debe ser dd/MM/yyyy
function CompararFecha(fecha1, comparacion, fecha2) {
   var b = true;
   if (fecha1 != "" && fecha2 != "") {
      b = false;
      iFechaBase = fecha1.split("/")[2] * 10000 + fecha1.split("/")[1] * 1000 + fecha1.split("/")[0] * 1;
      iFechaFin = fecha2.split("/")[2] * 10000 + fecha2.split("/")[1] * 1000 + fecha2.split("/")[0] * 1;

      switch (comparacion) {
         case "menor": b = (iFechaBase < iFechaFin); break;
         case "mayor": b = (iFechaBase > iFechaFin); break;
         case "mayor=": b = (iFechaBase >= iFechaFin); break;
         case "menor=": b = (iFechaBase <= iFechaFin); break;
      }
   }

   return b;
}
function UltimoDiaMes(mes, anio) {
   mes = mes * 1;
   anio = anio * 1;
   var dia = 0;
   switch (mes) {
      case 1: case 3: case 5: case 7: case 8: case 10: case 12:
         dia = 31;
         break;
      case 4: case 6: case 9: case 11:
         dia = 30;
         break;
      case 2:
         dia = (anio % 4 == 0) ? 29 : 28;
         break;
   }

   return dia;
}

function FormatFechaControlador(fecha) {
   return fecha.substr(3, 2) + "/" + fecha.substr(0, 2) + "/" + fecha.substr(6, 4);
}

function ObtenerIdsGrilla(nombregrilla, nombrecheck, nombrehidid, bactivo) {
   var lista = new Array();

   //recorremos grilla para obtener parametros
   var count = 0;
   $('#' + nombregrilla + " tr").each(function () {
      var $row = $(this);
      var checkeado = false;
      var id = 0;
      $row.find("input").each(function () {
         if ($(this).attr("name") == nombrecheck) {
            checkeado = $(this).is(":checked");
         }
         if ($(this).attr("id") == nombrehidid) {
            id = $(this).val();
         }
      });
      if (checkeado == true) {
         var objeto = new Object();
         objeto.Id = id;
         objeto.Activo = bactivo;
         lista[count] = objeto;
         count++;
      }
   });

   return JSON.stringify(lista);
}

//Mostrar sumario
function MostrarError(summary, strError) {
   var panelError = "#" + summary;
   if (strError == "") {
      $(panelError).css("display", "none");
      $(panelError).html("");
      return true;
   } else {
      $(panelError).css("display", "block");
      $(panelError).html('<ul>' + strError + '</ul>');
      return false;
   }
}

//Funcion generica para exportar e imprimir de las bandejas
function ExportarImprimir(filtro, entidad, exportar) {
   $("#filtroexportarimprimir").val(filtro);
   var tipo = (exportar == true) ? 1 : 0; window.open("../../Reportes/BandejaImpresion.aspx?tipo=" + tipo + "&entidad=" + entidad);
}

function DevuelveRutaIndicador(indicador) {
   var rutabase = $("#urlpath").val() + "/Content/Images/";
   var retorno = "";
   switch (indicador) {
      case 4:
         retorno = rutabase + "circle_verde.png";
         break;
      case 5:
         retorno = rutabase + "circle_blanco.png";
         break;
      case 3:
         retorno = rutabase + "circle_naranja.png";
         break;
      case 1:
         retorno = rutabase + "circle_negro.png";
         break;
      case 2:
         retorno = rutabase + "circle_rojo.png";
         break;
   }
   return retorno;
}
