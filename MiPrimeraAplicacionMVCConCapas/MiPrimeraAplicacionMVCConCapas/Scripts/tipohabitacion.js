window.onload = function () {
    listarTipoHabitacion();
}
var objetoConf;
function listarTipoHabitacion() {
    objetoConf = {
        url: "TipoHabitacion/lista", id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id",
        paginar:true
    }
    pintar(objetoConf)

    

}

function Buscar() {
    var nombretipohabitacion = get("txtnombretipohabitacion")
    objetoConf.url =
        "TipoHabitacion/filtrarTipohabitacionPorNombre/?nombrehabitacion=" + nombretipohabitacion;
    pintar(objetoConf)
    //alert(nombretipohabitacion)
}

function Limpiar() {
    /*
    setN("id", "")
    setN("nombre", "")
    setN("descripcion", "")
    */
    /*
    var elementos = document.querySelectorAll("#frmTipoHabitacion [name]")
    for (var i = 0; i < elementos.length; i++) {
        elementos[i].value = "";
    }*/
    LimpiarDatos("frmTipoHabitacion")
    //Correcto("Funciono mi alerta")
}


function GuardarDatos() {
    
    var error = ValidarObligatorios("frmTipoHabitacion")
    if (error != "") {
        Error(error);
        return;
    }
    var error = ValidarLongitudMaxima("frmTipoHabitacion");
    if (error != "") {
        Error(error);
        return;
    }

    var error = ValidarLongitudMinima("frmTipoHabitacion");
    if (error != "") {
        Error(error);
        return;
    }
    /*
    var nombre = getN("nombre")
    var descripcion = getN("descripcion")
    if (nombre == "") {
        Error("Debe ingresar el nombre");
        return;
    }
    if (descripcion == "") {
        Error("Debe ingresar la descripciòn");
        return;
    }
    */
    Confirmacion("Desea guardar datos de tipo habitacion?", "Confirmar Guardar Datos",
        function (res) {
        var frmTipoHabitacion = document.getElementById("frmTipoHabitacion");
        var frm = new FormData(frmTipoHabitacion);
        fetchPostText("TipoHabitacion/guardarDatos", frm, function (res) {
            if (res == "1") {
                listarTipoHabitacion();
                Limpiar();
            }
        })
    })
   
    /*
    fetch("TipoHabitacion/guardarDatos", {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            if (res == "1") {
                listarTipoHabitacion();
            }
        })
        */

}

function Editar(id) {
    /*
    fetchGet("TipoHabitacion/recuperarTipoHabitacion/?id=" + id, function (res) {
        setN("id",res.id)
        setN("nombre",res.nombre)
        setN("descripcion",res.descripcion)
    })
    */
    recuperarGenerico("TipoHabitacion/recuperarTipoHabitacion/?id=" + id,
        "frmTipoHabitacion");

}


function Eliminar(id) {
    Confirmacion("Desea eliminar el tipo habitacion?", "Confirmar eliminaciòn", function (res) {

        fetchGetText("TipoHabitacion/eliminarTipoHabitacion/?id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Se elimino correctamente");
                listarTipoHabitacion();
            }
        })
    })
}
