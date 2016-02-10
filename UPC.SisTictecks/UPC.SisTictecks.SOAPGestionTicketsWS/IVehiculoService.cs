using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.SisTictecks.EL;

namespace UPC.SisTictecks.SOAPGestionTicketsWS
{

    [ServiceContract]
    public interface IVehiculoService
    {

        #region "Vehiculo"

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        VehiculoEN CrearVehiculo(VehiculoEN vehiculoCrear);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        VehiculoEN ObtenerVehiculo(int codigo);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        VehiculoEN ModificarVehiculo(VehiculoEN vehiculoModificar);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        bool EliminarVehiculo(int codigo);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<VehiculoEN> ListarVehiculos();

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<VehiculoEN> ListarVehiculosPorUsuario(string codigoUsuario);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        bool ValidarPlacaExistente(string strPlaca);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        bool ValidarKMMenorAnterior(int kilometros, int idVehiculo);

        #endregion
        
        #region "Marca"

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<MarcaEN> ListarMarcas();

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        MarcaEN ObtenerMarca(int codigo);

        #endregion

        #region "Modelo"


        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<ModeloEN> ListarModelos();

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<ModeloEN> ListarModelosXMarca(MarcaEN marca);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        ModeloEN ObtenerModelo(int codigo);

        #endregion

        #region "Color"

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<ColorEN> ListarColores();

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        ColorEN ObtenerColor(int codigo);

        #endregion

    }
}
