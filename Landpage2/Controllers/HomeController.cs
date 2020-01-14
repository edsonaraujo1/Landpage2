using System;
using System.Net;
using System.Web.Mvc;
using System.Globalization;
using System.Net.Sockets;
using Landpage2.DataAccess;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Landpage2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

             return View();
        }

        [HttpPost]
        public ActionResult Index(string value)
        {
            // Obtem o IP Real do Usuario
            string Informa = "";
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress addr in localIPs)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    Informa = addr.ToString();
                }
            }

            // Obtem a Data de Hoje
            string data_hj      = DateTime.Now.ToString("d");
            string dat_zo1      = DateTime.Now.ToString("d");
            // Obtem a Hora Atual
            string hora_hj      = DateTime.Now.ToString("HH:mm:ss");
            string ip_maquina   = Request.UserHostName.ToString();
            string ip_real      = Informa;

            // Obtem o Paiz de Origem
            string culture      = CultureInfo.CurrentCulture.EnglishName;
            string country      = culture.Substring(culture.IndexOf('(') + 1, culture.LastIndexOf(')') - culture.IndexOf('(') - 1);

            // Obtem o Nome do Usuario
            string host         = Dns.GetHostName();

            string nome         = Request.Form["nome"];
            string compralog    = Request.Form["compralog"];
            string comprasport  = Request.Form["comprasport"];
            string time         = Request.Form["time"];
            string outtime      = Request.Form["outtime"];
            string dingast      = Request.Form["dingast"];
            string formpag      = Request.Form["formpag"];
            string dt_dataniv   = Request.Form["dt_dataniv"];

            // Calcula a Idade pela Data de Aniversario
            int idade_sub = int.Parse(dt_dataniv.Substring(6, 4));
            int ano_hj = int.Parse(data_hj.Substring(6, 4));
            int idade_pes = ano_hj - idade_sub;

            string idade        = Request.Form["idade"];
            string pais         = Request.Form["pais"];
            string bairro       = Request.Form["bairro"];
            string cidade       = Request.Form["cidade"];
            string estado       = Request.Form["estado"];
            string telefone     = Request.Form["telefone"];
            string sex          = Request.Form["sex"];
            string termcond     = Request.Form["termcond"];
            string a_log        = DateTime.Now.ToString("d") + " - " + hora_hj + " em: " + ip_real;

            double latitude;
            double longitude;
            string estado_go = ", " + estado;
            string cidade_go = ", " + cidade;
            string bairro_go = ", " + bairro;
            string endereco = country + estado_go + cidade_go + bairro_go;

            // Obtem a Localização a partir do Endereço
            ObterLocalizacao(out latitude, out longitude, endereco);

            var strlatitude = latitude.ToString();
            var strlongitude = longitude.ToString();

            // Conversão de Data para Us americano
            string sub1_dt1 = data_hj;
            string data_hj_sub = sub1_dt1.Substring(6, 4) + "-" + sub1_dt1.Substring(3, 2) + "-" + sub1_dt1.Substring(0, 2);

            string sub1_dt2 = dt_dataniv;
            string dt_dataniv_sub = sub1_dt2.Substring(6, 4) + "-" + sub1_dt2.Substring(3, 2) + "-" + sub1_dt2.Substring(0, 2);

            string sub1_dt3 = dat_zo1;
            string dat_zo1_sub = sub1_dt3.Substring(6, 4) + "-" + sub1_dt3.Substring(3, 2) + "-" + sub1_dt3.Substring(0, 2);

            // Abre uma Conexão com o Banco 
            using (var contexto = new Contexto())
            {
                // Insere Informação na Tabela nw_LandPage2
                string strQueryUpdat1 = "INSERT INTO nw_LandPage2 (  dt_data   ," +
                                                                    "data_hj   ," +
                                                                    "dt_dataniv," +
                                                                    "hora_hj   ," +
                                                                    "ip_maquina," +
                                                                    "ip_real   ," +
                                                                    "latitude  ," +
                                                                    "longitude ," +
                                                                    "culture   ," +
                                                                    "country   ," +
                                                                    "host      ," +
                                                                    "nome      ," +
                                                                    "bairro    ," +
                                                                    "cidade    ," +
                                                                    "estado    ," +
                                                                    "idade     ," +
                                                                    "pais      ," +
                                                                    "sex      ," +
                                                                    "compralog ," +
                                                                    "comprasport  ," +
                                                                    "time      ," +
                                                                    "outtime      ," +
                                                                    "dingast      ," +
                                                                    "formpag      ," +
                                                                    "termcond      ," +
                                                                    "a_log)     " +
                                                      "VALUES ('" + dat_zo1_sub     + "'," + 
                                                              "'" + data_hj_sub     + "'," +
                                                              "'" + dt_dataniv_sub  + "'," +
                                                              "'" + hora_hj         + "'," +
                                                              "'" + ip_maquina      + "'," +
                                                              "'" + ip_real         + "'," +
                                                              "'" + strlatitude     + "'," +  
                                                              "'" + strlongitude    + "'," +
                                                              "'" + culture         + "'," +
                                                              "'" + country         + "'," +
                                                              "'" + host            + "'," +
                                                              "'" + nome            + "'," +
                                                              "'" + bairro          + "'," +
                                                              "'" + cidade          + "'," +
                                                              "'" + estado          + "'," +
                                                              "'" + idade_pes + "'," +
                                                              "'" + pais + "'," +
                                                              "'" + sex + "'," +
                                                              "'" + compralog + "'," +
                                                              "'" + comprasport + "'," +
                                                              "'" + time + "'," +
                                                              "'" + outtime + "'," +
                                                              "'" + dingast + "'," +
                                                              "'" + formpag + "'," +
                                                              "'" + termcond + "'," +
                                                              "'" + a_log + "')";
                contexto.ExecutaComando(strQueryUpdat1);
                contexto.Close();
            }
            // Direciona para a Pagina ThanYou
            return RedirectToAction("/ThanYou");
        }

        public ActionResult ThanYou()
        {
            ViewBag.Message = "Your application description page.";

            return View();
            
        }

        public ActionResult Resultado()
        {

            // Abre uma Conexão com o Banco 
            using (var contexto = new Contexto())
            {
                string Querygenero = "SELECT count(sex) as gener FROM nw_LandPage2 where sex = 'MASCULINO'";

                string val = "";
                SqlDataReader dados_lang_z = contexto.ExecutaComandoComRetorno(Querygenero);
                if (dados_lang_z.Read())
                {
                    val = dados_lang_z["gener"].ToString();
                }

                Session["genero"] = val.ToString(); 
                contexto.Close();
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Função ObterLocalização pelo Endereço
        public void ObterLocalizacao(out double latitude, out double longitude, string endereco)
        {
            latitude = 0;
            longitude = 0;

            string url = "https://www.google.com.br/maps/place/";
            url += endereco;
            //url += "&output=csv";

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Timeout = 50000;//5 segundos
            WebResponse resp = wr.GetResponse();
            Stream stream = resp.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                string content = reader.ReadToEnd();//coloca todo o HTML na variável content
                if (content != null && content != "")
                {
                    var coordenadas1 = content.Substring(content.IndexOf("=[[["), +1000);//separa o html em um array
                    string coordenadas2 = coordenadas1.Substring(0, coordenadas1.IndexOf("]"));
                    var coordenadas3 = coordenadas2.Substring(0, coordenadas2.IndexOf(","));
                    //var coordenadas4 = coordenadas3.Substring(0, coordenadas3.IndexOf(","));

                    string[] coordenadas = coordenadas2.Split(',');//separa o html em um array
                    if (coordenadas.Length >= 3)//verifica se existem 4 elementos no array
                    {
                        if (!double.TryParse(coordenadas[1].Replace(".", ","), out latitude))
                            latitude = 0;//se não for um número coloca a latitude 0
                        if (!double.TryParse(coordenadas[2].Replace(".", ","), out longitude))
                            longitude = 0;//se não for um número coloca a longitude 0
                    }
                }
            }

        }

        // Função Json que Busca o Estado apartir do Pais
        public JsonResult Pais(string var_data1, string var_data2)
        {
            var contexto = new Contexto();
            string strQuerySelect = string.Format("  SELECT t1.nome AS pais, t2.nome AS estado FROM  nw_pais t1" +
                                                  "  INNER JOIN nw_estado t2" +
                                                  "  ON t1.id = t2.pais where t1.nome = '"+ var_data1 + "'");

            List<object> Salaslis = new List<object>();
            Salaslis.Clear();
            SqlDataReader dados1a = contexto.ExecutaComandoComRetorno(strQuerySelect);
            while (dados1a.Read())
            {
                Salaslis.Add(new
                {
                    estado = dados1a["estado"].ToString(),
                });
            }

            return Json(Salaslis, JsonRequestBehavior.AllowGet);
        }

        // Função Json que Busca a Cidade apartir do Estado
        public JsonResult Estado(string var_data1)
        {
            var contexto = new Contexto();
            string strQuerySelect1 = string.Format(" SELECT t1.nome AS pais, t2.nome AS cidade FROM  nw_Estado t1" +
                                                  "  INNER JOIN nw_Municipio t2" +
                                                  "  ON t1.codigouf = substring(CONVERT(varchar, t2.codigo), 1, 2) where t1.nome = '"+ var_data1 + "'");  

            List <object> Salaslis1 = new List<object>();
            Salaslis1.Clear();
            SqlDataReader dados1b = contexto.ExecutaComandoComRetorno(strQuerySelect1);
            while (dados1b.Read())
            {
                Salaslis1.Add(new
                {
                    nome = dados1b["cidade"].ToString(),
                });
            }

            return Json(Salaslis1, JsonRequestBehavior.AllowGet);
        }

        // Função Json que Busca o Bairro apartir do Cidade
        public JsonResult Bairro(string var_data1)
        {
            var contexto = new Contexto();
            string strQuerySelect1 = string.Format(" SELECT t1.nome AS cidade, t2.nome AS bairro FROM  nw_Municipio t1" +
                                                  "  INNER JOIN nw_Bairro t2" +
                                                  "  ON t1.codigo = substring(CONVERT(varchar, t2.codigo), 1, 7) where t1.nome = '" + var_data1 + "'");

            List<object> Salaslis1 = new List<object>();
            Salaslis1.Clear();
            SqlDataReader dados1b = contexto.ExecutaComandoComRetorno(strQuerySelect1);
            while (dados1b.Read())
            {
                Salaslis1.Add(new
                {
                    nome = dados1b["bairro"].ToString(),
                });
            }

            return Json(Salaslis1, JsonRequestBehavior.AllowGet);
        }

    }
}