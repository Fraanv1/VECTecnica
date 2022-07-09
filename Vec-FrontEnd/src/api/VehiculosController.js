import axios from 'axios'

export default {
	obtenerTodosLosVehiculos() {
		return axios({
			method: 'GET',
			url: `https://localhost:44368/api/v1/vehiculo`,
		})
	},
	obtenerVehiculo(vehiculoId) {
		return axios({
			method: 'GET',
			url: `https://localhost:44368/api/v1/vehiculo/getvehiculo?=vehiculoId=${vehiculoId}`,
		})
	},
	agregarVehiculo(vehiculo) {
		return axios.post(`https://localhost:44368/api/v1/vehiculo`, vehiculo)
	},
	modificarVehiculo(vehiculo) {
		return axios(`https://localhost:44368/api/v1/vehiculo`, vehiculo)
	},
	eliminarVehiculo(vehiculoId) {
		return axios.delete(
			`https://localhost:44368/api/v1/vehiculo?vehiculoId=${vehiculoId}`
		)
	},
}
