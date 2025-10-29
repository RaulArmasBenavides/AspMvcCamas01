

function Login() {
	var nombreusuario = getN("nombreusuario")
	var contra = getN("contra");
	console.log("Test");
	fetchGet("Login/uspLogin/?usuario=" + nombreusuario + "&contra=" + contra, function (data) {
		console.log(data);
		if (data.iidusuario == 0) Error("Usuario o contra incorrecto")
		else {
			Correcto("Bienvenido");
			//http://localhost:50383/Cama/Index
			document.location.href = setUrl("Cama/Index");
		}
		document.location.href = setUrl("Cama/Index");
			
	})
}