window.onload = function () {
    listarHabitacion();
    // llenarComboMarca();
}


function listarHabitacion() {
    pintar({
        popup: true,
        editar: true,
        eliminar: true,

        idpopup: "staticBackdrop1",
        sizepopup: "modal-lg",
        url: "Habitacion/listarHabitacionList", id: "divTabla",
        cabeceras: ["Id Habitacion", "Nombre", "Precio Noche", "Numero Personas",
            "Wifi", "Vista Mar","Piscina"],
        name: "listaHabitacion",
        propiedades: ["iidhabitacion", "nombre", "precionoche",
            "numeropersonas", "textotienewifi",  "textotienevistaalmar","textotienepiscina"],
        //Modficarlo
        urlEliminar: "Cama/eliminarCama",
        parametroEliminar: "iidhabitacion",
        urlRecuperar: "Habitacion/recuperarHabitacion",
        //recuperarexcepcion: ["iidproducto"],
        iscallbackeditar: true,
        callbackeditar: function (res) {
            //COsas adicionales
           // document.getElementById("lblTituloForm").innerHTML = "Producto";
        },
        parametroRecuperar: "idhabitacion",
        propiedadId: "iidhabitacion"
    },null, {
        type: "popup",
        titulo: "Habitacion",
        tituloconfirmacionguardar: "Desea guardar la habitacion?",
        id: "frmHabitacion",
        // limpiarexcepcion: ["iidproducto"],
            urlGuardar: "Habitacion/guardarHabitacion",
        formulario: [
            [
                {
                    class: "mb-3 col-md-5",
                    label: "Id Habitacion",
                    name: "iidhabitacion",
                    value: 0,
                    readonly: true
                },
                {
                    class: "mb-3 col-md-7",
                    label: "Nombre Habitacion",
                    name: "nombre",
                    classControl: "o max-100 min-3"
                }

            ],
            [
                {
                    class: "col-md-6",
                    type: "combobox",
                    label: "Tipo Habitacion",
                    datasource: "listaTipoHabitacion",
                    name: "iidtipohabitacion",
                    id: "cboTipoHabitacion",
                    propiedadMostrar: "nombre",
                    propiedadId: "id",
                    classControl: "o"

                },
                {
                    class: "col-md-6",
                    type: "combobox",
                    label: "Cama",
                    datasource: "listaCama",
                    name: "iidcama",
                    id: "cboCama",
                    propiedadMostrar: "nombre",
                    propiedadId: "idcama",
                    classControl: "o"

                }
            ],
            [
                {
                    class: "col-md-6",
                    type: "combobox",
                    label: "Hotel",
                    datasource: "listaHotel",
                    name: "iidhotel",
                    id: "cboHotel",
                    propiedadMostrar: "nombre",
                    propiedadId: "iidhotel",
                    classControl: "o"

                },
                {
                    type: "text",
                    class: "mb-3 col-md-6",
                    label: "Descripcion",
                    name: "descripcion",
                    classControl: "o"
                }
            ],
            [
                
                {
                    type: "number",
                    class: "mb-3 col-md-6",
                    label: "Numero personas",
                    name: "numeropersonas",
                    classControl: "o snc"
                },
                {
                    type: "number",
                    class: "mb-3 col-md-6",
                    label: "Precio Noche",
                    name: "precionoche",
                    classControl: "o sndc"
                }

            ], [

                {
                    class: "col-md-4",
                    label: "Seleccione si tiene vista al mar",
                    type: "radio",
                    labels: ["Si", "No"],
                    values: ["1","0"],
                    ids: ["rbVistaMarSi", "rbVistaMarNo"],
                    name: "tienevistaalmar",
                    classControl: "o-1"
                    //checked:"rbBuen"
                },
                {
                    class: "col-md-4",
                    label: "Seleccione si tiene wifi",
                    type: "radio",
                    labels: ["Si", "No"],
                    values: ["1", "0"],
                    ids: ["rbWiFiSi", "rbWifiNo"],
                    name: "tienewifi",
                    classControl: "o-1"
                    //checked:"rbBuen"
                },
                {
                    class: "col-md-4",
                    label: "Seleccione si tiene piscina",
                    type: "radio",
                    labels: ["Si", "No"],
                    values: ["1", "0"],
                    ids: ["rbPiscinaSi", "rbPiscinaNo"],
                    name: "tienepiscina",
                    classControl: "o-1"
                    //checked:"rbBuen"
                }
             
            ]
        ]


    }
    )
}