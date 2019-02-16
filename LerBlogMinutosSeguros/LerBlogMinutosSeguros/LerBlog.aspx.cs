using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Xml;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;

namespace LerBlogMinutoSeguros
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //DEVIDO A PROBLEMAS DE PROXY E AUTENTICAÇÃO BAIXEI O XML ATUALIZADO DO BLOG
            // ARQUIVO FEED.XML DENTRO DA PASTA XML

            if (!IsPostBack)
            {
                string texto = LeDadosBlog();
                lblTexto.Text = FormaDados(texto, Convert.ToInt32(txt_QtdCarac.Text));

            }


        }


        // REALIZA A LEITURA DO BLOG
        private string LeDadosBlog()
        {
            string path = HttpContext.Current.Server.MapPath("~/XML/feed.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode node = doc.GetElementsByTagName("content:encoded").Item(0);

            XmlNodeList elemList = doc.GetElementsByTagName("content:encoded");
            string texto = "";
            lblTextoPorTopico.Text = "";
            for (int i = 0; i <= 9; i++)
            {
                string TagPorTopic = "";
                Regex tagRemove = new Regex(@"<[^>]*(>|$)"); // Removendo a formatação HTML
                TagPorTopic += tagRemove.Replace(elemList[i].FirstChild.Value, string.Empty);
                texto += TagPorTopic;
                lblTextoPorTopico.Text += "Tópico " + (i + 1).ToString() + "<br>" + FormaDados(TagPorTopic, Convert.ToInt32(txt_QtdCarac.Text)) + "<br>";
            }

            return texto;

        }


        // RETIRA AS TAGS HTML / CONTA A QUANTIDADE DE PALAVRAS MAIS USADA E ORDENA
        private string FormaDados(string texto, int QtdCaracter)
        {

            Dictionary<string, int> dictionary = new Dictionary<string, int>();


            texto = texto.Replace(",", "");
            texto = texto.Replace(".", "");
            string[] arr = texto.Split(' ');

            foreach (string palavra in arr)
            {
                if (palavra.Length >= QtdCaracter) // por padrão na tela deixe 4 caracteres
                {
                    if (dictionary.ContainsKey(palavra))
                        dictionary[palavra] = dictionary[palavra] + 1;
                    else
                        dictionary[palavra] = 1;
                }
            }

            DataTable dt_Dados = new DataTable("MinutoSeguros");
            dt_Dados.Columns.Add("Palavra", typeof(string));
            dt_Dados.Columns.Add("Qtde", typeof(int));

            foreach (KeyValuePair<string, int> palavra in dictionary)
            {

                dt_Dados.Rows.Add(palavra.Key, Convert.ToInt32(palavra.Value));
            }

             dt_Dados.DefaultView.Sort = "Qtde desc";
             dt_Dados = dt_Dados.DefaultView.ToTable();

             texto = "";
             for (int i = 0; i <= 9; i++)
             {
                 texto += (i+1).ToString() + ") "+ "Palavra: " + "<span style='color:red'>" + dt_Dados.Rows[i]["Palavra"].ToString().ToUpper() + "</span>" + " Qtde: " +  "<span style='color:blue'> " + dt_Dados.Rows[i]["Qtde"].ToString()  + "</span>" + "</br>";

             }


            return texto;

        }


        protected void btnPesquisa_Click(object sender, EventArgs e)
        {

            string texto = LeDadosBlog();
            lblTexto.Text = FormaDados(texto, Convert.ToInt32(txt_QtdCarac.Text));


        }





    }
}
