using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.SisTictecks.EL;
using UPC.SisTictecks.DAL;

namespace UPC.SisTictecks.SOAPGestionTicketsWS
{

    public class VehiculoService : IVehiculoService
    {

        public VehiculoEN CrearVehiculo(VehiculoEN vehiculoCrear)
        {
            throw new NotImplementedException();
        }

        public VehiculoEN ObtenerVehiculo(int codigo)
        {
            throw new NotImplementedException();
        }

        public VehiculoEN ModificarVehiculo(VehiculoEN vehiculoModificar)
        {
            throw new NotImplementedException();
        }

        public bool EliminarVehiculo(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<VehiculoEN> ListarVehiculos()
        {
            throw new NotImplementedException();
        }

        public List<MarcaEN> ListarMarcas()
        {
            throw new NotImplementedException();
        }

        public MarcaEN ObtenerMarca(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<ModeloEN> ListarModelos()
        {
            throw new NotImplementedException();
        }

        public ModeloEN ObtenerModelo(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<ColorEN> ListarColores()
        {
            throw new NotImplementedException();
        }

        public ColorEN ObtenerColor(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}
