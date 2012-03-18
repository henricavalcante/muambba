using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public static class Excecao
    {
        public static string Trata(Exception ex)
        {
            return (ex.InnerException == null) ? ex.Message : ex.InnerException.Message;
        }
            
    }
}
