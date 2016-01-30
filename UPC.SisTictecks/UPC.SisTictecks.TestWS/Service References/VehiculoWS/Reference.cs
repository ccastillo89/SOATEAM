﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPC.SisTictecks.TestWS.VehiculoWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VehiculoWS.IVehiculoService")]
    public interface IVehiculoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/CrearVehiculo", ReplyAction="http://tempuri.org/IVehiculoService/CrearVehiculoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/CrearVehiculoRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.VehiculoEN CrearVehiculo(UPC.SisTictecks.EL.VehiculoEN vehiculoCrear);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/CrearVehiculo", ReplyAction="http://tempuri.org/IVehiculoService/CrearVehiculoResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.VehiculoEN> CrearVehiculoAsync(UPC.SisTictecks.EL.VehiculoEN vehiculoCrear);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ObtenerVehiculo", ReplyAction="http://tempuri.org/IVehiculoService/ObtenerVehiculoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ObtenerVehiculoRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.VehiculoEN ObtenerVehiculo(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ObtenerVehiculo", ReplyAction="http://tempuri.org/IVehiculoService/ObtenerVehiculoResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.VehiculoEN> ObtenerVehiculoAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ModificarVehiculo", ReplyAction="http://tempuri.org/IVehiculoService/ModificarVehiculoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ModificarVehiculoRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.VehiculoEN ModificarVehiculo(UPC.SisTictecks.EL.VehiculoEN vehiculoModificar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ModificarVehiculo", ReplyAction="http://tempuri.org/IVehiculoService/ModificarVehiculoResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.VehiculoEN> ModificarVehiculoAsync(UPC.SisTictecks.EL.VehiculoEN vehiculoModificar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/EliminarVehiculo", ReplyAction="http://tempuri.org/IVehiculoService/EliminarVehiculoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/EliminarVehiculoRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        bool EliminarVehiculo(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/EliminarVehiculo", ReplyAction="http://tempuri.org/IVehiculoService/EliminarVehiculoResponse")]
        System.Threading.Tasks.Task<bool> EliminarVehiculoAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarVehiculos", ReplyAction="http://tempuri.org/IVehiculoService/ListarVehiculosResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ListarVehiculosRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        System.Collections.Generic.List<UPC.SisTictecks.EL.VehiculoEN> ListarVehiculos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarVehiculos", ReplyAction="http://tempuri.org/IVehiculoService/ListarVehiculosResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.VehiculoEN>> ListarVehiculosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarMarcas", ReplyAction="http://tempuri.org/IVehiculoService/ListarMarcasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ListarMarcasRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        System.Collections.Generic.List<UPC.SisTictecks.EL.MarcaEN> ListarMarcas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarMarcas", ReplyAction="http://tempuri.org/IVehiculoService/ListarMarcasResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.MarcaEN>> ListarMarcasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ObtenerMarca", ReplyAction="http://tempuri.org/IVehiculoService/ObtenerMarcaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ObtenerMarcaRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.MarcaEN ObtenerMarca(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ObtenerMarca", ReplyAction="http://tempuri.org/IVehiculoService/ObtenerMarcaResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.MarcaEN> ObtenerMarcaAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarModelos", ReplyAction="http://tempuri.org/IVehiculoService/ListarModelosResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ListarModelosRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        System.Collections.Generic.List<UPC.SisTictecks.EL.ModeloEN> ListarModelos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarModelos", ReplyAction="http://tempuri.org/IVehiculoService/ListarModelosResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.ModeloEN>> ListarModelosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarModelosXMarca", ReplyAction="http://tempuri.org/IVehiculoService/ListarModelosXMarcaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ListarModelosXMarcaRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        System.Collections.Generic.List<UPC.SisTictecks.EL.ModeloEN> ListarModelosXMarca(UPC.SisTictecks.EL.MarcaEN marca);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarModelosXMarca", ReplyAction="http://tempuri.org/IVehiculoService/ListarModelosXMarcaResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.ModeloEN>> ListarModelosXMarcaAsync(UPC.SisTictecks.EL.MarcaEN marca);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ObtenerModelo", ReplyAction="http://tempuri.org/IVehiculoService/ObtenerModeloResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ObtenerModeloRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.ModeloEN ObtenerModelo(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ObtenerModelo", ReplyAction="http://tempuri.org/IVehiculoService/ObtenerModeloResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.ModeloEN> ObtenerModeloAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarColores", ReplyAction="http://tempuri.org/IVehiculoService/ListarColoresResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ListarColoresRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        System.Collections.Generic.List<UPC.SisTictecks.EL.ColorEN> ListarColores();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ListarColores", ReplyAction="http://tempuri.org/IVehiculoService/ListarColoresResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.ColorEN>> ListarColoresAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ObtenerColor", ReplyAction="http://tempuri.org/IVehiculoService/ObtenerColorResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IVehiculoService/ObtenerColorRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.ColorEN ObtenerColor(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVehiculoService/ObtenerColor", ReplyAction="http://tempuri.org/IVehiculoService/ObtenerColorResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.ColorEN> ObtenerColorAsync(int codigo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVehiculoServiceChannel : UPC.SisTictecks.TestWS.VehiculoWS.IVehiculoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VehiculoServiceClient : System.ServiceModel.ClientBase<UPC.SisTictecks.TestWS.VehiculoWS.IVehiculoService>, UPC.SisTictecks.TestWS.VehiculoWS.IVehiculoService {
        
        public VehiculoServiceClient() {
        }
        
        public VehiculoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VehiculoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VehiculoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VehiculoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public UPC.SisTictecks.EL.VehiculoEN CrearVehiculo(UPC.SisTictecks.EL.VehiculoEN vehiculoCrear) {
            return base.Channel.CrearVehiculo(vehiculoCrear);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.VehiculoEN> CrearVehiculoAsync(UPC.SisTictecks.EL.VehiculoEN vehiculoCrear) {
            return base.Channel.CrearVehiculoAsync(vehiculoCrear);
        }
        
        public UPC.SisTictecks.EL.VehiculoEN ObtenerVehiculo(int codigo) {
            return base.Channel.ObtenerVehiculo(codigo);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.VehiculoEN> ObtenerVehiculoAsync(int codigo) {
            return base.Channel.ObtenerVehiculoAsync(codigo);
        }
        
        public UPC.SisTictecks.EL.VehiculoEN ModificarVehiculo(UPC.SisTictecks.EL.VehiculoEN vehiculoModificar) {
            return base.Channel.ModificarVehiculo(vehiculoModificar);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.VehiculoEN> ModificarVehiculoAsync(UPC.SisTictecks.EL.VehiculoEN vehiculoModificar) {
            return base.Channel.ModificarVehiculoAsync(vehiculoModificar);
        }
        
        public bool EliminarVehiculo(int codigo) {
            return base.Channel.EliminarVehiculo(codigo);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarVehiculoAsync(int codigo) {
            return base.Channel.EliminarVehiculoAsync(codigo);
        }
        
        public System.Collections.Generic.List<UPC.SisTictecks.EL.VehiculoEN> ListarVehiculos() {
            return base.Channel.ListarVehiculos();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.VehiculoEN>> ListarVehiculosAsync() {
            return base.Channel.ListarVehiculosAsync();
        }
        
        public System.Collections.Generic.List<UPC.SisTictecks.EL.MarcaEN> ListarMarcas() {
            return base.Channel.ListarMarcas();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.MarcaEN>> ListarMarcasAsync() {
            return base.Channel.ListarMarcasAsync();
        }
        
        public UPC.SisTictecks.EL.MarcaEN ObtenerMarca(int codigo) {
            return base.Channel.ObtenerMarca(codigo);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.MarcaEN> ObtenerMarcaAsync(int codigo) {
            return base.Channel.ObtenerMarcaAsync(codigo);
        }
        
        public System.Collections.Generic.List<UPC.SisTictecks.EL.ModeloEN> ListarModelos() {
            return base.Channel.ListarModelos();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.ModeloEN>> ListarModelosAsync() {
            return base.Channel.ListarModelosAsync();
        }
        
        public System.Collections.Generic.List<UPC.SisTictecks.EL.ModeloEN> ListarModelosXMarca(UPC.SisTictecks.EL.MarcaEN marca) {
            return base.Channel.ListarModelosXMarca(marca);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.ModeloEN>> ListarModelosXMarcaAsync(UPC.SisTictecks.EL.MarcaEN marca) {
            return base.Channel.ListarModelosXMarcaAsync(marca);
        }
        
        public UPC.SisTictecks.EL.ModeloEN ObtenerModelo(int codigo) {
            return base.Channel.ObtenerModelo(codigo);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.ModeloEN> ObtenerModeloAsync(int codigo) {
            return base.Channel.ObtenerModeloAsync(codigo);
        }
        
        public System.Collections.Generic.List<UPC.SisTictecks.EL.ColorEN> ListarColores() {
            return base.Channel.ListarColores();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.ColorEN>> ListarColoresAsync() {
            return base.Channel.ListarColoresAsync();
        }
        
        public UPC.SisTictecks.EL.ColorEN ObtenerColor(int codigo) {
            return base.Channel.ObtenerColor(codigo);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.ColorEN> ObtenerColorAsync(int codigo) {
            return base.Channel.ObtenerColorAsync(codigo);
        }
    }
}