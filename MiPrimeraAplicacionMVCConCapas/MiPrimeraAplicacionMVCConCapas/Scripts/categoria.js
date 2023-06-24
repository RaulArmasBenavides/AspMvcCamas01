window.onload = function () {
    listarCategoria();
}

function listarCategoria() {
    pintar({
        popup: true,
        url: "Categoria/listarCategoria",
        id: "divTabla",
        cabeceras: ["Id Categoria", "Nombre", "Descripcion"],
        propiedades: ["iidcategoria", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        sizepopup: "modal-lg",
        urlEliminar: "Categoria/eliminarCategoria",
        parametroEliminar: "iidcategoria",
        urlRecuperar: "Categoria/recuperarCategoria",
        parametroRecuperar: "iidcategoria",
        propiedadId: "iidcategoria"
    }, null, {
             id: "frmCategoria",
            type: "popup",
            titulo: "Categoria",
            tituloconfirmacionguardar: "Desea guardar la categoria?",
            urlGuardar: "Categoria/guardarCategoria",
      
        formulario: [
            [
                {
                    class: "mb-3 col-md-5",
                    label: "Id Categoria",
                    name: "iidcategoria",
                    value: 0,

                    readonly: true
                },
                {
                    class: "mb-3 col-md-7",
                    label: "Nombre Categoria",
                    name: "nombre",
                    classControl: "o max-100 min-2"
                }

            ],
            [
                {
                    class: "col-md-12",
                    type: "textarea",
                    label: "Descripcion Categoria",
                    name: "descripcion",
                    rows: "5",
                    cols: "20",
                    classControl: "o max-100 min-10"

                }
            ]
        ]

    })
}