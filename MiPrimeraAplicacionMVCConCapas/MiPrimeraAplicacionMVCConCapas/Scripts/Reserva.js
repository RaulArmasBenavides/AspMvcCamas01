window.onload = function () {
	listarHoteles();
}

function listarHoteles() {
	var contenido = "";
	var hotel;
	var obj;
	fetchGet("Hotel/listarHotel", function (rpta) {
		contenido += "<h2>Hoteles o Sedes disponibles</h2>";
		contenido+="<div class='row'>"
		for (var i = 0; i < rpta.length; i++) {
			obj = rpta[i];
			hotel = `
                  <div class='col-md-4'>
                   <div class="card" style="width: 18rem;">
                      <img src="${obj.fotobase64}" class="card-img-top" alt="...">
                       <div class="card-body">
                         <h5 class="card-title">${obj.nombre}</h5>
                           <a onclick='VerHabitacionHotel(${obj.iidhotel},"${obj.nombre}")' class="btn btn-primary">Ver Habitaciones</a>
                    </div>
                    </div>
                 </div>
             `;

			contenido += hotel
		}
		contenido += "</div>"
		document.getElementById("divHoteles").innerHTML = contenido;	
		
	})

	
}

function VerHabitacionHotel(id,nombre) {
	var contenido = "";
	fetchGet("Habitacion/recuperarHabitacionPorIdHotel/?iidhotel=" + id, function (rpta) {
		contenido += "<h2 class='text-center'>" + nombre+"</h2>"
		contenido += "<button class='btn btn-dark mb-4' onclick='VolverHotel()'>Volver Pantalla Hotel</button>"
		var obj;
		contenido += "<div class='row'>"
		for (var i = 0; i < rpta.length; i++) {
			obj = rpta[i];
			contenido += `
                    <div class='col-md-3'>
                     <div style="width:240px;height:auto;background-color:green" 
                  class="card d-flex justify-content-center align-items-center p-2 m-2">
                             <label style="font-size:18px;font-weight:bold" class='text-white'> Nº ${obj.nombre} </label>
								<div class='mt-2 mb-2' style='width:100%;height:2px;background-color:white'></div>
                              <label style="font-size:18px;font-weight:bold" class='text-white'> Precio :
                                  ${obj.precionoche} </label>
                              <label style="font-size:18px;font-weight:bold" class='text-white'> Capacidad :
                                   ${obj.numeropersonas} personas </label>
                             <label style="font-size:18px;font-weight:bold" class='text-white'> Tiene Piscina? :
                                 ${obj.textotienepiscina} </label>
                             <label style="font-size:18px;font-weight:bold" class='text-white'> Tiene Wifi? :
                                 ${obj.textotienewifi} </label>
                             <label style="font-size:18px;font-weight:bold" class='text-white'> Tiene Vista al Mar? :
                                 ${obj.textotienevistaalmar} </label>

                             <button class='btn btn-info mt-2' onclick='Reservar(${JSON.stringify(obj)},${id},"${nombre}")'>Reservar</button>
                             
                     </div>
                     
                    </div>
                 `;
		}
		contenido+="</div>"
		document.getElementById("divHoteles").innerHTML = contenido;	


	})
	//alert(id);
}

function Reservar(objHabitacion,idhotel,nombrehotel) {
	console.log(objHabitacion);
	var contenido = "";
	contenido += "<h2 class='text-center'> Nº " + objHabitacion.nombre + "</h2>"
	contenido += `<button class='btn btn-dark mb-4' onclick='VerHabitacionHotel(${idhotel},"${nombrehotel}")'>Volver Habitacion</button> `
	contenido += "<button class='btn btn-dark mb-4' onclick='VolverHotel()'>Volver Pantalla Hotel</button>"
	contenido +=`
 <form id="frmReserva" method="post">
<fieldset class="container mb-4">
    <legend>Datos de Reserva</legend>
   
        <div class="row">
           
            <div class="mb-3 col-md-4" >
                <label>Nombre Hotel</label>
                <input type="text" class="form-control o max-40 min-4" value="${nombrehotel}"
                        readonly />
            </div>

            <div class="mb-3 col-md-4" >
                <label>Nombre Habitaciòn</label>
                <input type="text" class="form-control o max-40 min-4" value="${ objHabitacion.nombre}"
                       readonly />
            </div>

         <div class="mb-3 col-md-4" >
                <label>Precio por Noche</label>
                <input type="text" class="form-control o max-40 min-4"
                    name="preciohabitacion"
                id="txtprecionoche" value="${ objHabitacion.precionoche}"
                        readonly />
            </div>

        </div>

 <div class="row">
            <div class="mb-3 col-md-3" >
                <label>Tiene Wifi?</label>
                <input type="text" class="form-control o max-40 min-4" value="${objHabitacion.textotienewifi}"
                      readonly />
            </div>
            <div class="mb-3 col-md-3" >
                <label>Tiene Piscina?</label>
                <input type="text" class="form-control o max-40 min-4" value="${objHabitacion.textotienepiscina}"
                       readonly />
            </div>
            <div class="mb-3 col-md-3" >
                <label>Tiene vista al mar?</label>
                <input type="text" class="form-control o max-40 min-4" value="${objHabitacion.textotienevistaalmar}"
                      readonly />
            </div>
            <div class="mb-3 col-md-3" >
                <label>Numero Personas</label>
                <input type="text" class="form-control o max-40 min-4" value="${objHabitacion.numeropersonas}"
                      readonly />
            </div>
   
       </div> 
 <div class="row" style="display:none">
          <div class="mb-3 col-md-3" >
                <label>Id Hotel</label>
                <input type="text" name="iidhotel" class="form-control o max-40 min-4" value="${idhotel}"
                      readonly />
            </div>
            <div class="mb-3 col-md-3" >
                <label>Id Habitacion</label>
                <input type="text" name="iidhabitacion" class="form-control o max-40 min-4"
                     value="${objHabitacion.iidhabitacion}"
                      readonly />
            </div>
 </div> 
</fieldset>
        <fieldset class="container mb-4">
           <legend>Fechas Reserva</legend>
            <div class="row">
   <div class="mb-3 col-md-3" >
                        <label>Fecha Inicio</label>
                        <input type="date" name="fechainicio" class="form-control" id="txtfechainicio"
                               />
                    </div>
             <div class="mb-3 col-md-3" >
                        <label>Fecha Fin</label>
                        <input type="date" name="fechafin" class="form-control"  id="txtfechafin"
                               />
                    </div>
                    <div class="mb-3 col-md-3 d-flex align-items-center ">
                          <button type="button" class='btn btn-primary mt-4' onclick='Calcular()'>Calcular Costo</button>
                    </div>
           </div>
                <div class="row">
                         <div class="mb-3 col-md-3" >
                         <label>Numero Dias</label>
                             <input type="text" name="cantidadnoches" class="form-control" id="txtnumerodias"
                                    readonly />
                            </div>
                          <div class="mb-3 col-md-3" >
                         <label>Total</label>
                             <input type="text" name="total" class="form-control"   id="txtnumerototal"
                                    readonly />
                            </div>
                </div>      
        </fieldset>

    </form>
    <button class="btn btn-primary" onclick="GuardarDatos()">Aceptar</button>
    <button class="btn btn-danger" onclick="Limpiar()">Limpiar</button>



      `
	document.getElementById("divHoteles").innerHTML = contenido;	

}

function GuardarDatos() {
    Confirmacion("Desea guardar la reserva?", "Confirmar Guardar Datos",
        function (res) {
            var frmReserva = document.getElementById("frmReserva");
            var frm = new FormData(frmReserva);
            fetchPostText("Reserva/guardarReserva", frm, function (res) {
                if (res == "1") {
                    Correcto("Se reservo correctamente")
                    listarHoteles();
                    //Limpiar();
                }
            })
        })
}

function Calcular() {
    var numerodias = diasRangoFecha(get("txtfechainicio"), get("txtfechafin")) * 1
    set("txtnumerodias", numerodias)
    var total = get("txtprecionoche") * 1 * numerodias
    set("txtnumerototal", total)
}

function VolverHotel() {
	listarHoteles();
}