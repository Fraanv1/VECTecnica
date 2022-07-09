<template>
	<form v-if="showModal">
		<div class="card mt-4">
			<div class="card-body">
				<div class="form-row">
					<div class="form-group col-md-6">
						<label for="inputPassword4">Tipo de vehiculo</label>
						<select v-model="datosVehiculo.tipoVehiculo" class="form-control">
							<option value="" selected disabled>Elija un vehiculo</option>
							<option value="Auto">Auto</option>
							<option value="Camioneta">Camioneta</option>
							<option value="Moto">Moto</option>
							<option value="Cuatriciclo">Cuatriciclo</option>
							<option value="Barco">Barco</option>
						</select>
					</div>
					<div class="form-group col-md-6">
						<label for="inputPassword4">Cantidad de ruedas</label>
						<input
							v-model="datosVehiculo.cantidadRuedas"
							type="number"
							class="form-control"
							placeholder="Cantidad de ruedas"
						/>
					</div>
				</div>
				<div class="form-row">
					<div class="form-group col-md-6">
						<label>Marca</label>
						<input
							v-model="datosVehiculo.marca"
							class="form-control"
							placeholder="Marca"
						/>
					</div>
					<div class="form-group col-md-6">
						<label>Patente</label>
						<input
							v-model="datosVehiculo.patente"
							class="form-control"
							placeholder="Patente"
						/>
					</div>
				</div>
				<div class="form-row">
					<div class="col-3">
						<label>N° de Chasis</label>
						<input
							v-model="datosVehiculo.chasis"
							type="number"
							class="form-control mb-2"
							id="inlineFormInput"
							placeholder="N° de Chasis"
						/>
					</div>
					<div class="col-3">
						<label>KM Recorridos</label>
						<input
							v-model="datosVehiculo.kmRecorridos"
							type="number"
							class="form-control mb-2"
							id="inlineFormInput"
							placeholder="KM Recorridos"
						/>
					</div>
					<div class="col-3">
						<label>KM Para mantenimiento</label>
						<input
							v-model="datosVehiculo.kmMantenimiento"
							type="number"
							class="form-control mb-2"
							id="inlineFormInput"
							placeholder="KM Para mantenimiento"
						/>
					</div>
					<div class="col-3">
						<label>Modelo</label>
						<input
							v-model="datosVehiculo.modelo"
							type="number"
							class="form-control mb-2"
							id="inlineFormInput"
							placeholder="KM Para mantenimiento"
						/>
					</div>
				</div>
				<div class="pt-2 " style="text-align:right">
					<button class="btn btn-danger mr-1">
						Cancelar
					</button>
					<button
						v-if="!verificarCamposVacios()"
						@click="agregarVehiculo"
						type="submit"
						class="btn btn-success"
					>
						Agregar
					</button>
				</div>
			</div>
		</div>
	</form>
</template>

<script>
	import VehiculosController from '../../api/VehiculosController'
	export default {
		data() {
			return {
				datosVehiculo: {
					tipoVehiculo: '',
					cantidadRuedas: 0,
					marca: '',
					modelo: 0,
					patente: '',
					chasis: 0,
					kmRecorridos: 0,
					kmMantenimiento: 'string',
				},
			}
		},
		props: {
			showModal: {
				type: Boolean,
			},
		},
		methods: {
			agregarVehiculo() {
				VehiculosController.agregarVehiculo(this.datosVehiculo)
					.then((response) => {
						console.log(response.data)
					})
					.catch((error) => {
						console.error(error)
					})
			},
			verificarCamposVacios() {
				if (this.datosVehiculo.tipoVehiculo == '') return true
			},
			modificarVehiculo() {},
			cerrarModal() {
				this.$emit('close', false)
			},
		},
		created() {
			this.verificarCamposVacios()
		},
	}
</script>
