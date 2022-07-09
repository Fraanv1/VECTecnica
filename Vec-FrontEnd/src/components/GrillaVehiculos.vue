<template>
	<div>
		<h1 class="display-4 text-center">CRUD Vehiculos</h1>
		<hr />
		<div class="row">
			<div class="col-lg-8 offset-lg-2">
				<div class="pt-2 " style="text-align:center">
					<NuevoVehiculo @recargargrilla="recargargrilla"></NuevoVehiculo>
				</div>
				<div class="card mt-4">
					<div class="card-body">
						<h5 v-if="listVehiculos.length == 0">No hay vehiculos para ver</h5>
						<table class="table table-bordered">
							<thead class="thead-dark">
								<tr>
									<th scope="col">Tipo de vehículo</th>
									<th scope="col">Patente</th>
									<th scope="col">Cantidad de ruedas</th>
									<th scope="col">Marca</th>
									<th scope="col">Modelo</th>
									<th scope="col">N° de Chasis</th>
									<th scope="col">KM's recorridos</th>
									<th scope="col">KM's mantenmiento</th>
									<th style="text-align:center" scope="col">Acciones</th>
								</tr>
							</thead>
							<tbody>
								<tr v-for="(vehiculo, index) of listVehiculos" :key="index">
									<th scope="row">{{ vehiculo.tipoVehiculo }}</th>
									<td>{{ vehiculo.patente }}</td>
									<td>{{ vehiculo.cantidadRuedas }}</td>
									<td>{{ vehiculo.marca }}</td>
									<td>{{ vehiculo.modelo }}</td>
									<td>{{ vehiculo.chasis }}</td>
									<td>{{ vehiculo.kmRecorridos }}</td>
									<td>{{ vehiculo.kmMantenimiento }}</td>

									<td style="text-align:center">
										<div class="form-row">
											<button
												class="btn btn-danger mr-1"
												@click="eliminarVehiculo(vehiculo.vehiculoId)"
											>
												🗑️
											</button>
											<ModificarVehiculo
												@recargargrilla="recargargrilla"
												:loadedVehiculo="vehiculo"
											></ModificarVehiculo>
										</div>
									</td>
								</tr>
							</tbody>
						</table>
						<br />
						<div class="text-center">
							<div v-if="loading" class="spinner-border text-success" role="status">
								<span class="sr-only">Loading...</span>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import NuevoVehiculo from './Modals/NuevoVehiculo.vue'
	import ModificarVehiculo from './Modals/ModificacionVehiculo.vue'
	import VehiculosController from '../api/VehiculosController.js'
	export default {
		components: { NuevoVehiculo, ModificarVehiculo },
		name: 'Tarea',
		data() {
			return {
				showModal: false,
				listVehiculos: [],
				loading: false,
				vehiculoCargado: '',
			}
		},
		methods: {
			recargargrilla: function() {
				this.obtenerTodosLosVehiculos()
			},
			obtenerTodosLosVehiculos() {
				this.loading = true
				VehiculosController.obtenerTodosLosVehiculos()
					.then((response) => {
						this.listVehiculos = response.data
						this.loading = false
					})
					.catch((error) => {
						console.log(error)
					})
			},
			eliminarVehiculo(vehiculoId) {
				VehiculosController.eliminarVehiculo(vehiculoId).then(() => {
					this.obtenerTodosLosVehiculos()
				})
			},
			asignarVehiculo(vehiculoId) {
				this.vehiculoCargado = vehiculoId
			},
		},
		mounted() {
			this.obtenerTodosLosVehiculos()
		},
	}
</script>

<style scoped>
	.cursor {
		cursor: pointer;
	}
</style>
