<template>
	<div class="root">
		<button class="btn btn-primary" @click="modalAbierto = true">
			+
		</button>
		<Teleport to="body">
			<div v-if="modalAbierto">
				<div class="modal-bg">
					<div class="modal">
						<div class="card mt-4">
							<h1 class="display-5 text-left">Alta de vehiculo</h1>
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
									<button @click="cancelar" class="btn btn-danger mr-1">
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
					</div>
				</div>
			</div>
		</Teleport>
	</div>
</template>

<script>
	import VehiculosController from '../../api/VehiculosController'
	export default {
		props: {
			loadedVehiculo: {},
		},
		data() {
			return {
				modalAbierto: false,
				datosVehiculo: {
					tipoVehiculo: '',
					cantidadRuedas: 0,
					marca: '',
					modelo: 0,
					patente: '',
					chasis: 0,
					kmRecorridos: 0,
					kmMantenimiento: '',
				},
			}
		},

		methods: {
			agregarVehiculo() {
				VehiculosController.agregarVehiculo(this.datosVehiculo)
					.then(() => {
						this.limpiarCampos()
						this.modalAbierto = false
						this.$emit('recargargrilla')
					})
					.catch((error) => {
						console.error(error)
					})
			},
			verificarCamposVacios() {
				if (
					this.datosVehiculo.tipoVehiculo == '' ||
					this.datosVehiculo.cantidadRuedas == 0 ||
					this.datosVehiculo.marca == 0 ||
					this.datosVehiculo.modelo == 0 ||
					this.datosVehiculo.patente == '' ||
					this.datosVehiculo.chasis == 0 ||
					this.datosVehiculo.kmRecorridos == 0 ||
					this.datosVehiculo.kmMantenimiento == ''
				)
					return true
			},
			limpiarCampos() {
				console.log(this.datosVehiculo)
				this.datosVehiculo.tipoVehiculo = ''
				this.datosVehiculo.cantidadRuedas = 0
				this.datosVehiculo.marca = 0
				this.datosVehiculo.modelo = 0
				this.datosVehiculo.patente = ''
				this.datosVehiculo.chasis = 0
				this.datosVehiculo.kmRecorridos = 0
				this.datosVehiculo.kmMantenimiento = ''
			},
			cancelar() {
				this.modalAbierto = false
			},
		},
		mounted() {
			this.verificarCamposVacios()
		},
	}
</script>

<style>
	.root {
		position: relative;
	}
	.modal {
		position: fixed;
		top: 0;
		left: 0;
		width: 100vw;
		height: 100vh;
		background-color: rgba(0, 0, 0, 0.5);
		display: flex;
		justify-content: center;
		align-items: center;
	}

	.modal > div {
		background-color: #fff;
		padding: 50px;
		border-radius: 10px;
	}
</style>
