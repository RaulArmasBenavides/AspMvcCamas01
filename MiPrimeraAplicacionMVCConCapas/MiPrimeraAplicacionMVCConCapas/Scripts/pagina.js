window.onload = function () {
    listarPagina();
}

function listarPagina() {
    pintar({
        url: "Pagina/listarPaginas",
        id: "divTabla",
        cabeceras: ["Id Pagina", "Nombre Pagina", "Controlador","Accion"],
        propiedades: ["iidpagina", "mensaje", "controlador","accion"],
        editar: true,
      
    
        urlRecuperar: "Pagina/recuperarPagina",
        parametroRecuperar: "iidpagina",
        propiedadId: "iidpagina",
        nuevo: true,
        callbacknuevo: function () {
            agregarPagina();
        }

    });
}

function agregarPagina(id=0) {
    pintar({
        id: "divTabla"
    }, null, {
        id: "frmPagina",
        callbackOnload: function () {
            if (id > 0) {
                recuperarGenericoEspecifico("Pagina/recuperarPagina/?iidpagina=" + id, "frmPagina")
            }
        },
        type: "fieldset",
        urlGuardar: "Pagina/guardarPagina",
        legend: "Datos de la pagina",
        regresar: true,
        callbackregresar: function () {
            listarPagina()
        },
        callbackGuardarDatos: function () {
            listarPagina()
        },
        formulario: [
            [
                {
                    class: "mb-3 col-md-5",
                    label: "Id Pagina",
                    name: "iidpagina",
                    value: 0,

                    readonly: true
                },
                {
                    class: "mb-3 col-md-7",
                    label: "Mensaje",
                    name: "mensaje",
                    classControl: "o max-50 min-3"
                }

            ],
            [
                {
                    class: "col-md-12",
                    type: "text",
                    label: "Controlador",
                    name: "controlador",

                    classControl: "o max-70 min-4"

                }
            ],
            [
                {
                    class: "col-md-12",
                    type: "text",
                    label: "Accion",
                    name: "accion",

                    classControl: "o max-70 min-4"

                }
            ]

        ]

    });
}

function Editar(id) {
    agregarPagina(id);
    // alert(id);
}