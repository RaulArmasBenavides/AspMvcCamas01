window.onload = function () {
    listarPersona();
    listarCombo();
    previewImagen();
}

function previewImagen() {

    var fupFoto = document.getElementById("fupFoto");
    var imgFoto = document.getElementById("imgFoto");
    fupFoto.onchange = function () {
        var file = fupFoto.files[0];
        var reader = new FileReader();
        reader.onloadend = function () {
            document.getElementById("imgFoto").src = reader.result;
        }
        reader.readAsDataURL(file)
    }
}

function listarPersona() {
    pintar({
        popup: true,
        idpopup:"staticBackdrop",
        url: "Persona/listarPersona", id: "divTabla",
        cabeceras: ["Id Persona", "Nombre Completo", "Sexo","Tipo Usuario","Foto"],
        propiedades: ["iidpersona", "nombreCompleto", "nombreSexo",
        "nombreTipoUsuario","fotobase64"],
        editar: true,
        eliminar: true,
        propiedadId: "iidpersona",
        columnaimg: ["fotobase64"]
    })
}

function listarCombo() {
    fetchGet("TipoUsuario/listarTipoUsuario", function (data) {
        llenarCombo(data, "cboTipoUsuario", "nombre", "iidtipousuario","0")
        llenarCombo(data, "cboTipousuarioForm", "nombre", "iidtipousuario")
    })
}

function filtrarPersonaTipousuario() {
    var iidtipousuario = get("cboTipoUsuario");
    pintar({
        url: "Persona/filtrarPersona/?iidtipousuario="+iidtipousuario, id: "divTabla",
        cabeceras: ["Id Persona", "Nombre Completo", "Sexo", "Tipo Usuario"],
        propiedades: ["iidpersona", "nombreCompleto", "nombreSexo",
            "nombreTipoUsuario"],
        editar: true,
        eliminar: true,
        propiedadId: "iidpersona"
    })
   // alert(iidtipousuario);
}


function Editar(id) {
    Limpiar();
    //NUevo
    if (id == 0) {
        document.getElementById("staticBackdropLabel").innerHTML = "Nueva persona";
        document.getElementById("divcontra").style.display = "block";
    }
    //editar
    else {
        document.getElementById("staticBackdropLabel").innerHTML = "Editar persona";
        document.getElementById("divcontra").style.display = "none";
        recuperarGenericoEspecifico("Persona/recuperarPersona/?iidpersona=" + id,
            "frmPersona", [], true);
    }
  
}

function recuperarEspecifico(res) {
    if (res.nombreusuario == "") document.getElementById("divcontra").style.display = "block";
}

/*
function recuperarEspecifico(res) {
    document.getElementById("imgFoto").src = res.fotobase64;
}
*/
/*
function recuperarEspecifico(res) {
    
    var iidsexo = res.iidsexo;
    //Masculino
    if (iidsexo == 1) {
        document.getElementById("rbMas").checked = true;
    }
    //femenino
    else {
           document.getElementById("rbFem").checked = true;
    }
}
*/
function Guardar() {

    var error = ValidarObligatorios("frmPersona")
    if (error != "") {
        Error(error);
        return;
    }
    var error=  validarSoloNumerosEnteros("frmPersona")
    if (error != "") {
        Error(error);
        return;
    }
    var frmPersona = document.getElementById("frmPersona");
    var frm = new FormData(frmPersona);
    Confirmacion(undefined, "Desea guardar los cambios de la persona", function () {
        fetchPostText("Persona/Guardar", frm, function (res) {
            if (res == "1") {
                // listarTipoHabitacion();
                document.getElementById("btnCerrar").click();
                listarPersona();
                Limpiar();
            }
        })
    })
   
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
    LimpiarDatos("frmPersona", ["iidsexo","valor[]"])
    //Correcto("Funciono mi alerta")
}

function Eliminar(id) {
    Confirmacion("Desea eliminar la persona?", "Confirmar eliminaciòn", function (res) {

        fetchGetText("Persona/eliminarPersona/?iidpersona=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Se elimino correctamente");
                listarPersona();
            }
        })
    })
}