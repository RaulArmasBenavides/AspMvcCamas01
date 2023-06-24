window.onload = function () {
    listarTipoUsuario();
}

function listarTipoUsuario() {
    pintar({
        url: "TipoUsuario/listarTipoUsuario",
        id: "divTabla",
        cabeceras: ["Id Tipo Usuario", "Nombre", "Descripcion"],
        propiedades: ["iidtipousuario", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        urlEliminar: "Cama/eliminarCama",
        parametroEliminar: "idcama",
        urlRecuperar: "Cama/recuperarCama",
        parametroRecuperar: "idcamita",
        propiedadId: "iidtipousuario",
        nuevo: true,
        callbacknuevo: function () {
            agregarTipousuario();
        }

    });
}

function agregarTipousuario(id=0) {
    fetchGet("Pagina/listarPaginas", function (res) {
        pintar({
            id: "divTabla"
        }, null, {
                id: "frmTipoUsuario",
                callbackOnload: function () {
                    if (id > 0) {
                        recuperarGenericoEspecifico("TipoUsuario/recuperarTipoUsuario/?iidtipousuario=" + id,"frmTipoUsuario")
                    }
                },
            type: "fieldset",
            urlGuardar: "TipoUsuario/guardarTipoUsuario",
            legend: "Datos del Tipo usuario",
            regresar: true,
            callbackregresar: function () {
                listarTipoUsuario()
                },
                callbackGuardarDatos: function () {
                    listarTipoUsuario()
                },
            formulario: [
                [
                    {
                        class: "mb-3 col-md-5",
                        label: "Id Tipo usuario",
                        name: "iidtipousuario",
                        value: 0,

                        readonly: true
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Nombre Tipo Usuario",
                        name: "nombre",
                        classControl: "o max-50 min-3"
                    }

                ],
                [
                    {
                        class: "col-md-12",
                        type: "textarea",
                        label: "Descripcion Tipo usuario",
                        name: "descripcion",
                        rows: "5",
                        cols: "20",
                        classControl: "o max-70 min-10"

                    }
                ],
                [
                    {
                        class: "col-md-12",
                        type: "list",
                        label: "Seleccione paginas",
                        id: "divPintado",

                        name: "idpaginas",
                        cabeceras: ["Id Pagina", "Mensaje"],
                        propiedades: ["iidpagina", "mensaje"],
                        propiedadId:"iidpagina",
                        data: res
                   

                   }
                ]

            ]

        });

    })
 
}

function Editar(id) {
    agregarTipousuario(id);
   // alert(id);
}