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
    public class AprobacionCitasRestTest
    {
        [TestMethod]
        public void DarAltasTest()
        {
            string postdata = "";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:28603/AprobacionCitaService.svc/AltasCita");
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

                Assert.AreEqual("4", citaEnAlta.Codigo);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("No es posible el alta. La fecha de cita es posterior a la fecha actual.", message);
            }
        }

        [TestMethod]
        public void ObtenerCitaTest()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:28603/AprobacionCitaService.svc/AltasCita/1");
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
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:28603/AprobacionCitaService.svc/AltasCita");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string citasJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<CitaEN> listaCitasAltas = js2.Deserialize<List<CitaEN>>(citasJson2);

            int cantidad = listaCitasAltas.Count;
            Assert.AreEqual(1, cantidad);
        }

    }
}
