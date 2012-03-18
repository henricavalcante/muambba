using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Util
{
    public class Criptografia
    {

        #region "Enum"

        public enum HashMethod
        {

            MD5,
            SHA1,
            SHA384

        }

        #endregion

        #region "Atributos"

        public const string CHAVE = "{A74B1C77-D61B-46D9-B94F-261D8779CF89}";

        public const string CHAVE_RETORNO = "{5802A904-AF81-4F46-92B6-35F0CF9DE517}";
        #endregion

        #region "Métodos Públicos"

        public static string GerarHash(string source, HashMethod algorithm)
        {

            HashAlgorithm hashAlgorithm = null;

            switch (algorithm)
            {

                case HashMethod.MD5:

                    hashAlgorithm = new MD5CryptoServiceProvider();

                    break;
                case HashMethod.SHA1:

                    hashAlgorithm = new SHA1CryptoServiceProvider();

                    break;
                case HashMethod.SHA384:

                    hashAlgorithm = new SHA384Managed();

                    break;
                default:


                    return string.Empty;
            }

            byte[] byteValue = Encoding.UTF8.GetBytes(source);
            byte[] hashValue = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(hashValue);

        }

        #endregion

    }
}
