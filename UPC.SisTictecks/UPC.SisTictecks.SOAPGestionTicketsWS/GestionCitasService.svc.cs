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

    public class GestionCitasService : IGestionCitasService
    {
        private CitaDAO citaDAO = null;

        private CitaDAO CitaDAO
        {
            get
            {
                if (citaDAO == null)
                    citaDAO = new CitaDAO();

                return citaDAO;
            }
        }

        public CitaEN CrearCita(CitaEN citaCrear)
        {
            return CitaDAO.Crear(citaCrear);
        }

        public CitaEN ObtenerCita(int codigo)
        {
            return CitaDAO.Obtener(codigo);
        }

        public CitaEN ModificarCita(CitaEN citaModificar)
        {
            CitaEN citaExistente = CitaDAO.Obtener(citaModificar.Codigo);

            return CitaDAO.Modificar(citaModificar);
        }

        public bool EliminarCita(int codigo)
        {
            CitaEN citaExistente = CitaDAO.Obtener(codigo);
            bool ejecuto = false;
            if (citaExistente != null)
            {
                CitaDAO.Eliminar(citaExistente);
                ejecuto = true;
            }
            else
                ejecuto = false;

            return ejecuto;
        }

        public List<CitaEN> ListarCitas()
        {
			//return CitaDAO.ListarTodos().ToList();

            List<CitaEN> lista = new List<CitaEN>();
            lista.Add(new CitaEN { Codigo = 1, NroCita = "11111", Fecha = "01/02/2016", HoraInicio = DateTime.Today, HoraFin = DateTime.Today, Observacion = "MMMMMMM", Estado=true});
            lista.Add(new CitaEN { Codigo = 2, NroCita = "2222", Fecha = "01/03/2016", HoraInicio = DateTime.Today, HoraFin = DateTime.Today, Observacion = "PPPPPP", Estado = true });
            lista.Add(new CitaEN { Codigo = 3, NroCita = "3333", Fecha = "01/04/2016", HoraInicio = DateTime.Today, HoraFin = DateTime.Today, Observacion = "AAAAA", Estado = true });
            
            return lista;
        }
    }
}
