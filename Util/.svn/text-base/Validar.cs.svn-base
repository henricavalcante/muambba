using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class Validar
    {
        private static string[] strCPF = {
		"11111111111",
		"22222222222",
		"33333333333",
		"44444444444",
		"55555555555",
		"66666666666",
		"77777777777",
		"88888888888",
		"99999999999"
	    };
        private static string[] strCNPJ = {
		"11111111111111",
		"22222222222222",
		"33333333333333",
		"44444444444444",
		"55555555555555",
		"66666666666666",
		"77777777777777",
		"88888888888888",
		"99999999999999"
	    };


        public const string REGULAR_EXPRESSION_EMAIL = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        public const string REGULAR_EXPRESSION_NOME = "^[a-zA-Z0-9-]*$";
        public const string REGULAR_EXPRESSION_CEP = "^[0-9]{5}\\-[0-9]{3}$";
        //Public Const REGULAR_EXPRESSION_DATA As String = "(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}"


        public const string REGULAR_EXPRESSION_DATA = "(((0[1-9]|[12][0-9]|3[01])([/])(0[13578]|10|12)([/])(\\d{4}))|(([0][1-9]|[12][0-9]|30)([/])(0[469]|11)([/])(\\d{4}))|((0[1-9]|1[0-9]|2[0-8])([/])(02)([/])(\\d{4}))|((29)(\\.|-|\\/)(02)([/])([02468][048]00))|((29)([/])(02)([/])([13579][26]00))|((29)([/])(02)([/])([0-9][0-9][0][48]))|((29)([/])(02)([/])([0-9][0-9][2468][048]))|((29)([/])(02)([/])([0-9][0-9][13579][26])))";
        
        public static object ChecarNulo(object vTexto, bool Numerico = false)
        {
            object functionReturnValue = null;


            if (((vTexto == null) || object.ReferenceEquals(vTexto, DBNull.Value)))
            {
                if (Numerico)
                {
                    functionReturnValue = 0;
                }
                else
                {
                    functionReturnValue = "";
                }


            }
            else
            {
                functionReturnValue = vTexto;

            }
            return functionReturnValue;

        }

        public static void Condicao(bool blnCondicao, string strMensagem)
        {

            if (!blnCondicao)
            {
                throw new ApplicationException(strMensagem);

            }

        }

        public static void StringVazia(string strString, string strMensagem)
        {

            Condicao(strString.Trim() != String.Empty, strMensagem);

        }

        public static void Nulo(object objObjeto, string strMensagem)
        {
            Condicao(objObjeto != null, strMensagem);
        }

        public static bool EMail(string strEMail)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(strEMail, REGULAR_EXPRESSION_EMAIL);

        }

        public static void NomeDeUsuario(string strNome, string strMensagem)
        {
            Condicao(System.Text.RegularExpressions.Regex.IsMatch(strNome, REGULAR_EXPRESSION_NOME), strMensagem);

        }

        public static bool CEP(string strCEP)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(strCEP, REGULAR_EXPRESSION_CEP);

        }

        public static bool Data(string strData)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(strData, REGULAR_EXPRESSION_DATA);

        }

        public static bool CPF(string cpf)
        {

            
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            foreach (var item in strCPF)
            {
                if (item == cpf)
                {
                    return false;
                }
            }
            
            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for(int i=0; i<9; i++)

            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if ( resto < 2 )

            resto = 0;

            else

            resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for(int i=0; i<10; i++)

            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)

            resto = 0;

            else

            resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
            

        }

        public static bool CNPJ(string cnpj)
	    {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;

            int resto;

            string digito;

            string tempCnpj;

            cnpj = cnpj.Trim();

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                return false;

            }

            foreach (var item in strCNPJ)
            {
                if (item == cnpj)
                {
                    return false;
                }
            }


            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
	    }

    }
}
