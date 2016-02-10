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
        #region "Vehiculo"

        private VehiculoDAO vehiculoDAO = null;

        private VehiculoDAO VehiculoDAO
        {
            get
            {
                if (vehiculoDAO == null)
                    vehiculoDAO = new VehiculoDAO();

                return vehiculoDAO;
            }
        }

        public VehiculoEN CrearVehiculo(VehiculoEN vehiculoCrear)
        {
            bool bPlacaExistente = false;
            bPlacaExistente = VehiculoDAO.ValidarPlacaExistente(vehiculoCrear.Placa);

            if (bPlacaExistente)
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 1,
                    Mensaje = "La placa ya ha sido registrada"
                },
                new FaultReason("Validación de negocio"));
            }

            return VehiculoDAO.Crear(vehiculoCrear);
        }

        public VehiculoEN ObtenerVehiculo(int codigo)
        {
            return VehiculoDAO.Obtener(codigo);
        }

        public VehiculoEN ModificarVehiculo(VehiculoEN vehiculoModificar)
        {
            VehiculoEN vehiculoExistente = VehiculoDAO.Obtener(vehiculoModificar.Codigo);
            bool bPlacaExistente = false;

            if (vehiculoExistente.Placa != vehiculoModificar.Placa)
            {
                bPlacaExistente = VehiculoDAO.ValidarPlacaExistente(vehiculoModificar.Placa);
                if (bPlacaExistente)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 1,
                        Mensaje = "La placa ya ha sido registrada"
                    },
                    new FaultReason("Validación de negocio"));
                }
            }

            return VehiculoDAO.Modificar(vehiculoModificar);
        }

        public bool EliminarVehiculo(int codigo)
        {
            VehiculoEN vehiculoExistente = VehiculoDAO.Obtener(codigo);
            bool ejecuto = false;
            if (vehiculoExistente != null)
            {
                VehiculoDAO.Eliminar(vehiculoExistente);
                ejecuto = true;
            }
            else
                ejecuto = false;

            return ejecuto;
            
        }

        public List<VehiculoEN> ListarVehiculos()
        {
            return VehiculoDAO.ListarTodos().ToList();
        }

        public List<VehiculoEN> ListarVehiculosPorUsuario(string codigoUsuario)
        {
            return VehiculoDAO.ListarVehiculosPorUsuario(codigoUsuario).ToList();
        }

        public bool ValidarPlacaExistente(string strPlaca)
        {
            return VehiculoDAO.ValidarPlacaExistente(strPlaca);
        }

        public bool ValidarKMMenorAnterior(int kilometros, int idVehiculo)
        {
            return VehiculoDAO.ValidarKMMenorAnterior(kilometros, idVehiculo);
        }

        #endregion

        #region "Marcas"

        private MarcaDAO marcaDAO = null;

        private MarcaDAO MarcaDAO
        {
            get
            {
                if (marcaDAO == null)
                    marcaDAO = new MarcaDAO();

                return marcaDAO;
            }
        }

        public List<MarcaEN> ListarMarcas()
        {
            return MarcaDAO.ListarTodos().ToList();
        }

        public MarcaEN ObtenerMarca(int codigo)
        {
            return MarcaDAO.Obtener(codigo);
        }

        #endregion

        #region "Modelos"

        private ModeloDAO modeloDAO = null;

        private ModeloDAO ModeloDAO
        {
            get
            {
                if (modeloDAO == null)
                    modeloDAO = new ModeloDAO();

                return modeloDAO;
            }
        }

        public List<ModeloEN> ListarModelos()
        {
            return ModeloDAO.ListarTodos().ToList();
        }

        public List<ModeloEN> ListarModelosXMarca(MarcaEN marca)
        {
            return ModeloDAO.ListarModelosXMarca(marca).ToList();
        }

        public ModeloEN ObtenerModelo(int codigo)
        {
            return ModeloDAO.Obtener(codigo);
        }

        #endregion

        #region "Colores"

        private ColorDAO colorDAO = null;

        private ColorDAO ColorDAO
        {
            get
            {
                if (colorDAO == null)
                    colorDAO = new ColorDAO();

                return colorDAO;
            }
        }

        public List<ColorEN> ListarColores()
        {
            return ColorDAO.ListarTodos().ToList();
        }

        public ColorEN ObtenerColor(int codigo)
        {
            return ColorDAO.Obtener(codigo);
        }

        #endregion

    }
}
