window.onload = function () {
    listarHotel();
}

function listarHotel() {
    pintar({
        popup: true,
        url: "Hotel/listarHotel",
        id: "divTabla",
        cabeceras: ["Id Hotel", "Nombre Hotel", "Direccion","Foto Hotel"],
        propiedades: ["iidhotel", "nombre", "direccion","fotobase64"],
        editar: true,
        sizepopup: "modal-lg",
        eliminar: true,
        urlEliminar: "Cama/eliminarCama",
        parametroEliminar: "idcama",
        urlRecuperar: "Hotel/recuperarHotel",
        parametroRecuperar: "iidhotel",
        propiedadId: "iidhotel",
        columnaimg: ["fotobase64"]

    },
       null
        , {
            type: "popup",
            id: "frmHotel",
            titulo: "Hotel",
            urlGuardar: "Hotel/guardarHotel",
            legend: "Datos de la Cama",
            formulario: [
                [
                    {
                        class: "mb-3 col-md-5",
                        label: "Id Hotel",
                        name: "iidhotel",
                        value: 0,

                        readonly: true
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Nombre Hotel",
                        name: "nombre",
                        classControl: "o max-50 min-3"
                    }

                ],
                [
                    {
                        class: "col-md-5",
                        type: "textarea",
                        label: "Descripcion Hotel",
                        name: "descripcion",
                        rows: "5",
                        cols: "20",
                        classControl: "o max-70 min-10"

                    },
                    {
                        class: "col-md-7",
                        type: "textarea",
                        label: "Direccion Hotel",
                        name: "direccion",
                        rows: "5",
                        cols: "20",
                        classControl: "o max-70 min-10"

                    }
                ],
                [
                    {
                        label: "Foto Hotel",
                        type: "file",
                        name: "fotodata",
                        preview: true,
                        imgwidth: 200,
                        imgheight: 200,
                        imgclass:"o",
                        namefoto:"fotobase64"
                    }
                  
                ]
            ]

        })
}