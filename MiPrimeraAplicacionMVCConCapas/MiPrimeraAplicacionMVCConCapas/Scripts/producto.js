window.onload = function () {
    listarProductos();
   // llenarComboMarca();
}

function llenarComboMarca() {
    fetchGet("Marca/listarMarca", function (data) {
        llenarCombo(data, "cboMarca", "nombreMarca", "iidMarca")

    })
}

function listarProductos() {
    pintar({
        popup: true,
        editar: true,
        eliminar: true,
       
        idpopup: "staticBackdrop1",
        sizepopup:"modal-lg",
        url: "Producto/listarProductoMarca", id: "divTabla",
        cabeceras: ["Id Producto", "Nombre", "Nombre Marca", "Precio",
            "Stock", "Denominacion"],
        name:"listaProducto",
        propiedades: ["iidproducto", "nombreproducto","nombremarca",
            "precioventa", "stock", "denominacion"],
        //Modficarlo
        urlEliminar: "Cama/eliminarCama",
        parametroEliminar: "idcama",
        urlRecuperar: "Producto/recuperarProducto",
        //recuperarexcepcion: ["iidproducto"],
        iscallbackeditar: true,
        callbackeditar: function (res) {
            //COsas adicionales
            document.getElementById("lblTituloForm").innerHTML = "Producto";
        },
        parametroRecuperar: "iidproducto",
        propiedadId: "iidproducto"
    }, {
            busqueda: true,
        //filtro
            url: "Producto/filtrarProductoPorCategoria",
            nombreparametro: "iidcategoria",
            type: "combobox",
            name: "listaCategoria",
            displaymember: "nombre",
            valuemember:"iidcategoria",
        button: true,
            id: "cboCategoriaBusqueda"

    }, {
             type: "popup",
             titulo: "Producto",
             tituloconfirmacionguardar:"Desea guardar el producto?",
             id: "frmProducto",
           // limpiarexcepcion: ["iidproducto"],
             urlGuardar: "Producto/guardarProducto",
             formulario: [
                [
                    {
                        class: "mb-3 col-md-5",
                        label: "Id Producto",
                        name: "iidproducto",
                        value: 0,
                        readonly: true
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Nombre producto",
                        name: "nombreproducto",
                        classControl: "o max-100 min-3"
                    }

                ],
                [
                    {
                        class: "col-md-5",
                        type: "combobox",
                        label: "Marca",
                        datasource: "listaMarca",
                        name: "iidmarca",
                        id: "cboMarca",
                        propiedadMostrar: "nombreMarca",
                        propiedadId: "iidMarca",
                        classControl: "o"

                    },
                    {
                        class: "col-md-7",
                        type: "combobox",
                        label: "Categoria",
                        datasource: "listaCategoria",
                        name: "iidcategoria",
                        id: "cboCategoria",
                        propiedadMostrar: "nombre",
                        propiedadId: "iidcategoria",
                        classControl: "o"

                    }
                ],
                [
                    {
                        class: "col-md-12",
                        type: "textarea",
                        label: "Descripcion Producto",
                        name: "descripcion",
                        rows: "3",
                        cols: "20",
                        classControl: "o"

                    }
                ],
                [
                    {
                        type:"number",
                        class: "mb-3 col-md-4",
                        label: "Precio compra producto",
                        name: "preciocontra",
                        classControl: "o sndc"
                    },
                    {
                        type: "number",
                        class: "mb-3 col-md-4",
                        label: "Precio venta producto",
                        name: "precioventa",
                        classControl: "o sndc"
                    },
                    {
                        type: "number",
                        class: "mb-3 col-md-4",
                        label: "Stock",
                        name: "stock",
                        classControl: "o snc"
                    }
                  
                ]
            ]
           

    }
    )
}
/*
function Buscar() {
    var nombreproducto = get("txtnombreproducto");
    pintar({
        url: "Producto/filtrarProductoPorNombre/?nombreproducto=" + nombreproducto,
        id: "divTabla",
        cabeceras: ["Id Producto", "Nombre", "Nombre Marca", "Precio",
            "Stock", "Denominacion"],
        propiedades: ["iidproducto", "nombreproducto", "nombremarca",
            "precioventa", "stock", "denominacion"]
    })
}*/

function BuscarProductoMarca() {
    var iidmarca = get("cboMarca")
    pintar({
        url: "Producto/filtrarProductoPorMarca/?iidmarca=" + iidmarca,
        id: "divTabla",
        cabeceras: ["Id Producto", "Nombre", "Nombre Marca", "Precio",
            "Stock", "Denominacion"],
        propiedades: ["iidproducto", "nombreproducto", "nombremarca",
            "precioventa", "stock", "denominacion"]
    })
}