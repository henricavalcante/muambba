using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class Data
    {
        public static string DataPorExtenso(DateTime Data)
        {
            string data = null;

            switch (Data.Month)
            {
                case 1:
                    data = string.Format("{0:dd} de Janeiro de {0:yyyy}", Data);

                    break;
                case 2:
                    data = string.Format("{0:dd} de Fevereiro de {0:yyyy}", Data);

                    break;
                case 3:
                    data = string.Format("{0:dd} de Março de {0:yyyy}", Data);

                    break;
                case 4:
                    data = string.Format("{0:dd} de Abril de {0:yyyy}", Data);

                    break;
                case 5:
                    data = string.Format("{0:dd} de Maio de {0:yyyy}", Data);

                    break;
                case 6:
                    data = string.Format("{0:dd} de Junho de {0:yyyy}", Data);

                    break;
                case 7:
                    data = string.Format("{0:dd} de Julho de {0:yyyy}", Data);

                    break;
                case 8:
                    data = string.Format("{0:dd} de Agosto de {0:yyyy}", Data);

                    break;
                case 9:
                    data = string.Format("{0:dd} de Setembro de {0:yyyy}", Data);

                    break;
                case 10:
                    data = string.Format("{0:dd} de Outubro de {0:yyyy}", Data);

                    break;
                case 11:
                    data = string.Format("{0:dd} de Novembro de {0:yyyy}", Data);

                    break;
                case 12:
                    data = string.Format("{0:dd} de Dezembro de {0:yyyy}", Data);

                    break;
            }

            return data;

        }


        public static string MesPorExtenso(DateTime Data)
        {

            return MesPorExtenso(Data.Month);

        }

        public static string MesPorExtenso(int Data)
        {

            string Mes = null;

            switch (Data)
            {
                case 1:
                    Mes = "Janeiro";

                    break;
                case 2:
                    Mes = "Fevereiro";

                    break;
                case 3:
                    Mes = "Março";

                    break;
                case 4:
                    Mes = "Abril";

                    break;
                case 5:
                    Mes = "Maio";

                    break;
                case 6:
                    Mes = "Junho";

                    break;
                case 7:
                    Mes = "Julho";

                    break;
                case 8:
                    Mes = "Agosto";

                    break;
                case 9:
                    Mes = "Setembro";

                    break;
                case 10:
                    Mes = "Outubro";

                    break;
                case 11:
                    Mes = "Novembro";

                    break;
                case 12:
                    Mes = "Dezembro";

                    break;
            }

            return Mes;


        }


        public static string Saudacao(DateTime Data)
        {
            if (Data.Hour > 5 && Data.Hour < 12)
            {
                return "Bom Dia";
            }
            else if (Data.Hour >= 12 && Data.Hour < 18)
            {
                return "Boa Tarde";
            }
            else
            {
                return "Boa Noite";
            }
        }

    }
}
