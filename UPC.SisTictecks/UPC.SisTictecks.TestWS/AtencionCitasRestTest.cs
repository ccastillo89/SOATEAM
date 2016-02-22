using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using UPC.SisTictecks.EL;

namespace UPC.SisTictecks.TestWS
{
    [TestClass]
    public class AtencionCitasRestTest
    {
        [TestMethod]
        public void DarAltasTest()
        {
            string postdata = "{\"Codigo\":1,\"Estado\":1,\"Fecha\":\"16\\/02\\/2016\",\"HoraFin\":\"\\/Date(1455674400000-0500)\\/\",\"HoraInicio\":\"\\/Date(1455627600000-0500)\\/\",\"NroCita\":\"R2016021203251702\",\"Observacion\":\"2312321\",\"RangoHora\":0,\"Servicio\":{\"Codigo\":6,\"Descripcion\":\"BAJAR GASES\",\"Estado\":true,\"TiempoEstimado\":13,\"Valor\":297.00},\"Taller\":{\"Codigo\":1,\"Taller\":\"TALLER NRO 1\"},\"Usuario\":{\"Apellidos\":\"Juarez\",\"Codigo\":4,\"Correo\":\"ivan.juarez@gmail.com\",\"Dni\":\"44582563\",\"Estado\":false,\"Nombres\":\"Ivan\",\"Pass\":\"1234\",\"Perfil\":{\"Codigo\":2,\"Descripcion\":\"CLIENTE\",\"Estado\":true},\"Telefono\":\"987452361\",\"Usuario\":\"IVAN\",\"login\":null},\"Vehiculo\":{\"Anio\":2016,\"Codigo\":1,\"Color\":{\"Codigo\":16,\"Color\":\"Amarillo de zinc\"},\"Descripcion\":\"dasdsad\",\"Kilometros\":15000,\"Marca\":{\"Codigo\":7,\"Marca\":\"HONDA\"},\"Modelo\":{\"Codigo\":19,\"Marca\":{\"Codigo\":7,\"Marca\":\"HONDA\"},\"Modelo\":\"Honda Civic\"},\"Placa\":\"abc-111\",\"Usuario\":{\"Apellidos\":\"Castillo\",\"Codigo\":1,\"Correo\":\"carlos@gmail.com\",\"Dni\":\"45792116\",\"Estado\":true,\"Nombres\":\"Carlos\",\"Pass\":\"123\",\"Perfil\":{\"Codigo\":1,\"Descripcion\":\"ADMINISTRADOR\",\"Estado\":true},\"Telefono\":\"91440830\",\"Usuario\":\"CCASTILLO\",\"login\":null}}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:28603/AtencionCitaService.svc/Citas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string citaAltaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                CitaEN citaEnAlta = js.Deserialize<CitaEN>(citaAltaJson);

                Assert.AreEqual(1, citaEnAlta.Codigo);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("No es posible el alta. La fecha de cita es posterior a la fecha actual. Se debe dar alta el mismo dia de la cita.", message);
            }
        }

        [TestMethod]
        public void ObtenerCitaTest()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:28603/AtencionCitaService.svc/Citas/1");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string citasJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            CitaEN citasAltas = js2.Deserialize<CitaEN>(citasJson2);

            Assert.AreNotEqual(null, citasAltas);
        }

        [TestMethod]
        public void ListarCitaPendienteAltaTest()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:28603/AtencionCitaService.svc/Citas");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string citasJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<CitaEN> listaCitasAltas = js2.Deserialize<List<CitaEN>>(citasJson2);

            int cantidad = listaCitasAltas.Count;
            Assert.AreEqual(1, cantidad);
        }

        [TestMethod]
        public void DarBajasTest()
        {
            string postdata = "{\"Codigo\":2,\"NroCita\":null,\"Fecha\":null,\"HoraInicio\":\"\\/Date(-62135578800000)\\/\",\"RangoHora\":0,\"HoraFin\":\"\\/Date(-62135578800000)\\/\",\"Observacion\":null,\"Estado\":0,\"Usuario\":null,\"Vehiculo\":null,\"Servicio\":null,\"Taller\":null}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:28603/AtencionCitaService.svc/Citas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string citaAltaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                CitaEN citaEnBaja = js.Deserialize<CitaEN>(citaAltaJson);

                Assert.AreEqual(2, citaEnBaja.Codigo);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
            }
        }

    }
}
