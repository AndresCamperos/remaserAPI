using System;
using System.Security.Cryptography;
using System.Text;

namespace remaserAPI.Services
{
    public class EncryptServices
    {
        /* ##FORMULA BASE ##
             * El password debe tener como mínimo:
             * Una Mayuscula
             * Una Minuscula
             * Un Numero
             * Un Carácter Especial*/
            
        Random rdm = new Random();
        string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string[] caracteres = { "!", "#", "$", "&", "(", ")", "*", "+", "-", ".", "=", "?" };

        private string Number()
        {
            string number = rdm.Next(10).ToString();
            return number;
        }

        private string Lowercase()
        {
            int i = rdm.Next(0, 25);
            string lowercase = letras[i];
            lowercase = lowercase.ToLower();
            return lowercase;
        }
        private string Uppercase()
        {
            int i = rdm.Next(0, 25);
            string uppercase = letras[i];
            return uppercase;
        }
        private string Character()
        {
            int i = rdm.Next(0, 11);
            string character = caracteres[i];
            return character;
        }

        public string CreatePassword(int longitud)
        {
            int i = 0;
            string resultado = string.Empty;
            int random = default;

            //Garantizo las reglas
            resultado += Uppercase();
            i++;
            resultado += Character();
            i++;
            resultado += Lowercase();
            i++;
            resultado += Number();
            i++;
            do
            {
                //El resto es aleatorio
                random = rdm.Next(0, 11);
                if (random <= 3)
                {
                    resultado += Uppercase();
                }
                if (random > 3 && random <= 6)
                {
                    resultado += Lowercase();
                }
                if (random > 6 && random <= 10)
                {
                    resultado += Number();
                }
                i++;


            } while (i != longitud);

            return resultado;
        }

        public string EncrypterPassword(string password)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(password);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }
    }
}
