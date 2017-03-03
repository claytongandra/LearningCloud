using System;
using System.Web.Mvc;

namespace LearningCloud.MVC.HTMLHelpers
{
    public static class ItensPaginacao
    {
        public static MvcHtmlString LegendaPaginacao(this HtmlHelper helper, string identificadorRegistro, char generoRegistro, string pluralizacao, int pageNumber, int pageSize, int totalItemCount)
        {
            string retornoLegendaPaginacao = "";
            string resultadoLegenda = "";
            string identificadorRegistroPlural = "";

            if (identificadorRegistro == "" || identificadorRegistro == null)
            {
                identificadorRegistro = "Registro";
                pluralizacao = null;
                generoRegistro = 'M';
            }

            identificadorRegistroPlural = identificadorRegistro;

            if (pluralizacao == "" || pluralizacao == null)
            {
                pluralizacao = "s";
            }
            else if (pluralizacao == "ões")
            {
                identificadorRegistroPlural = identificadorRegistro.Replace("ão", "");
            }

            if (generoRegistro != 'F')
            {
                generoRegistro = 'M';
            }

            if (generoRegistro == 'F')
            {
                resultadoLegenda = "Localizada";
            }
            else
            {
                resultadoLegenda = "Localizado";
            }

            if (totalItemCount <= 1)
            {
                retornoLegendaPaginacao = totalItemCount + " " + identificadorRegistro + " " + resultadoLegenda;
            }
            else
            {
                if (totalItemCount <= pageSize)
                {
                    retornoLegendaPaginacao = totalItemCount + " " + identificadorRegistroPlural + pluralizacao + " " + resultadoLegenda + "s";
                }
                else
                {
                    if ((pageNumber * pageSize) > totalItemCount)
                    {
                        retornoLegendaPaginacao = totalItemCount + " " + identificadorRegistroPlural + pluralizacao + " " + resultadoLegenda + "s. Exibindo de " + ((pageNumber * pageSize) - (pageSize - 1)) + " a " + totalItemCount;
                    }
                    else
                    {
                        retornoLegendaPaginacao = totalItemCount + " " + identificadorRegistroPlural + pluralizacao + " " + resultadoLegenda + "s. Exibindo de " + ((pageNumber * pageSize) - (pageSize - 1)) + " a " + (pageNumber * pageSize);
                    }
                }
            }

            return MvcHtmlString.Create(string.Format("<span>{0}</span>", retornoLegendaPaginacao));
        }
    }
}