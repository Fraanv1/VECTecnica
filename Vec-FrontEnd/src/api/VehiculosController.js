import axios from 'axios'

export default {
	obtenerTodosLosVehiculos() {
		return axios({
			method: 'GET',
			url: `https://localhost:44368/api/v1/vehiculo`,
		})
	},
	agregarVehiculo(vehiculo) {
		return axios({
			method: 'POST',
			url: `https://localhost:44368/api/v1/vehiculo`,
			data: { vehiculo: vehiculo },
		})
	},
	modificarVehiculo(vehiculo) {
		return axios({
			method: 'PUT',
			url: `https://localhost:44368/api/v1/vehiculo`,
			data: { vehiculo: vehiculo },
		})
	},
	eliminarVehiculo(vehiculoId) {
		return axios({
			method: 'DELETE',
			url: `https://localhost:44368/api/v1/vehiculo?vehiculoId=${vehiculoId}`,
		})
	},
}
