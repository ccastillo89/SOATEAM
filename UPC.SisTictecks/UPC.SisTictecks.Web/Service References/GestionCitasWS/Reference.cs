﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPC.SisTictecks.Web.GestionCitasWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GestionCitasWS.IGestionCitasService")]
    public interface IGestionCitasService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/CrearCita", ReplyAction="http://tempuri.org/IGestionCitasService/CrearCitaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IGestionCitasService/CrearCitaRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.CitaEN CrearCita(UPC.SisTictecks.EL.CitaEN citaCrear);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/CrearCita", ReplyAction="http://tempuri.org/IGestionCitasService/CrearCitaResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.CitaEN> CrearCitaAsync(UPC.SisTictecks.EL.CitaEN citaCrear);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ObtenerCita", ReplyAction="http://tempuri.org/IGestionCitasService/ObtenerCitaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IGestionCitasService/ObtenerCitaRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.CitaEN ObtenerCita(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ObtenerCita", ReplyAction="http://tempuri.org/IGestionCitasService/ObtenerCitaResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.CitaEN> ObtenerCitaAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ModificarCita", ReplyAction="http://tempuri.org/IGestionCitasService/ModificarCitaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IGestionCitasService/ModificarCitaRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        UPC.SisTictecks.EL.CitaEN ModificarCita(UPC.SisTictecks.EL.CitaEN citaModificar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ModificarCita", ReplyAction="http://tempuri.org/IGestionCitasService/ModificarCitaResponse")]
        System.Threading.Tasks.Task<UPC.SisTictecks.EL.CitaEN> ModificarCitaAsync(UPC.SisTictecks.EL.CitaEN citaModificar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/EliminarCita", ReplyAction="http://tempuri.org/IGestionCitasService/EliminarCitaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IGestionCitasService/EliminarCitaRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        bool EliminarCita(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/EliminarCita", ReplyAction="http://tempuri.org/IGestionCitasService/EliminarCitaResponse")]
        System.Threading.Tasks.Task<bool> EliminarCitaAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ListarCitas", ReplyAction="http://tempuri.org/IGestionCitasService/ListarCitasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IGestionCitasService/ListarCitasRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN> ListarCitas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ListarCitas", ReplyAction="http://tempuri.org/IGestionCitasService/ListarCitasResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN>> ListarCitasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ValidarFechaHoraCitaXTaller", ReplyAction="http://tempuri.org/IGestionCitasService/ValidarFechaHoraCitaXTallerResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IGestionCitasService/ValidarFechaHoraCitaXTallerRepetidoExcept" +
            "ionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        bool ValidarFechaHoraCitaXTaller(string fecha, System.DateTime horaIni, System.DateTime horaFin, int idTaller, int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ValidarFechaHoraCitaXTaller", ReplyAction="http://tempuri.org/IGestionCitasService/ValidarFechaHoraCitaXTallerResponse")]
        System.Threading.Tasks.Task<bool> ValidarFechaHoraCitaXTallerAsync(string fecha, System.DateTime horaIni, System.DateTime horaFin, int idTaller, int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ListarCitasPendientesDeAtencion", ReplyAction="http://tempuri.org/IGestionCitasService/ListarCitasPendientesDeAtencionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IGestionCitasService/ListarCitasPendientesDeAtencionRepetidoEx" +
            "ceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN> ListarCitasPendientesDeAtencion(string codigoUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ListarCitasPendientesDeAtencion", ReplyAction="http://tempuri.org/IGestionCitasService/ListarCitasPendientesDeAtencionResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN>> ListarCitasPendientesDeAtencionAsync(string codigoUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ListarHistorialDeCitas", ReplyAction="http://tempuri.org/IGestionCitasService/ListarHistorialDeCitasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UPC.SisTictecks.EL.RepetidoException), Action="http://tempuri.org/IGestionCitasService/ListarHistorialDeCitasRepetidoExceptionFa" +
            "ult", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/UPC.SisTictecks.EL")]
        System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN> ListarHistorialDeCitas(string codigoUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestionCitasService/ListarHistorialDeCitas", ReplyAction="http://tempuri.org/IGestionCitasService/ListarHistorialDeCitasResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN>> ListarHistorialDeCitasAsync(string codigoUsuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGestionCitasServiceChannel : UPC.SisTictecks.Web.GestionCitasWS.IGestionCitasService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GestionCitasServiceClient : System.ServiceModel.ClientBase<UPC.SisTictecks.Web.GestionCitasWS.IGestionCitasService>, UPC.SisTictecks.Web.GestionCitasWS.IGestionCitasService {
        
        public GestionCitasServiceClient() {
        }
        
        public GestionCitasServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GestionCitasServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionCitasServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionCitasServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public UPC.SisTictecks.EL.CitaEN CrearCita(UPC.SisTictecks.EL.CitaEN citaCrear) {
            return base.Channel.CrearCita(citaCrear);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.CitaEN> CrearCitaAsync(UPC.SisTictecks.EL.CitaEN citaCrear) {
            return base.Channel.CrearCitaAsync(citaCrear);
        }
        
        public UPC.SisTictecks.EL.CitaEN ObtenerCita(int codigo) {
            return base.Channel.ObtenerCita(codigo);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.CitaEN> ObtenerCitaAsync(int codigo) {
            return base.Channel.ObtenerCitaAsync(codigo);
        }
        
        public UPC.SisTictecks.EL.CitaEN ModificarCita(UPC.SisTictecks.EL.CitaEN citaModificar) {
            return base.Channel.ModificarCita(citaModificar);
        }
        
        public System.Threading.Tasks.Task<UPC.SisTictecks.EL.CitaEN> ModificarCitaAsync(UPC.SisTictecks.EL.CitaEN citaModificar) {
            return base.Channel.ModificarCitaAsync(citaModificar);
        }
        
        public bool EliminarCita(int codigo) {
            return base.Channel.EliminarCita(codigo);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarCitaAsync(int codigo) {
            return base.Channel.EliminarCitaAsync(codigo);
        }
        
        public System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN> ListarCitas() {
            return base.Channel.ListarCitas();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN>> ListarCitasAsync() {
            return base.Channel.ListarCitasAsync();
        }
        
        public bool ValidarFechaHoraCitaXTaller(string fecha, System.DateTime horaIni, System.DateTime horaFin, int idTaller, int idUsuario) {
            return base.Channel.ValidarFechaHoraCitaXTaller(fecha, horaIni, horaFin, idTaller, idUsuario);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarFechaHoraCitaXTallerAsync(string fecha, System.DateTime horaIni, System.DateTime horaFin, int idTaller, int idUsuario) {
            return base.Channel.ValidarFechaHoraCitaXTallerAsync(fecha, horaIni, horaFin, idTaller, idUsuario);
        }
        
        public System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN> ListarCitasPendientesDeAtencion(string codigoUsuario) {
            return base.Channel.ListarCitasPendientesDeAtencion(codigoUsuario);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN>> ListarCitasPendientesDeAtencionAsync(string codigoUsuario) {
            return base.Channel.ListarCitasPendientesDeAtencionAsync(codigoUsuario);
        }
        
        public System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN> ListarHistorialDeCitas(string codigoUsuario) {
            return base.Channel.ListarHistorialDeCitas(codigoUsuario);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<UPC.SisTictecks.EL.CitaEN>> ListarHistorialDeCitasAsync(string codigoUsuario) {
            return base.Channel.ListarHistorialDeCitasAsync(codigoUsuario);
        }
    }
}
