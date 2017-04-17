using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fis.Fwk.Core.Extension
{
    /// <summary>
    ///  Cette classe contient des fonctions d'extension pour les objets de type string
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convertit la chaîne spécifiée en une initiale en majuscule (excepté pour les
        /// mots qui sont entièrement en majuscules, lesquels sont considérés comme des acronymes.).
        /// </summary>
        /// <param name="str">Chaîne à convertir en initiales majuscules</param>
        /// <returns>Chaîne spécifiée convertie en initiales majuscules</returns>
        public static string ToTitleCase(this String str)
        {
            if (str != null)
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
            return null;
        }

        /// <summary>
        /// Remplace les multiples espaces par un unique espace et fait un trim 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimAndReduce(this string str)
        {
            return ConvertWhitespacesToSingleSpaces(str).Trim();
        }

        /// <summary>
        /// Replace toutes les multiples espaces par un unique espace
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            if (value != null)
                return Regex.Replace(value, @"\s+", " ");
            return null;
        }

        /// <summary>
        /// Converts a string into a "SecureString"
        /// </summary>
        /// <param name="str">Input String</param>
        /// <returns></returns>
        public static System.Security.SecureString ToSecureString(this String str)
        {
            System.Security.SecureString secureString = new System.Security.SecureString();
            foreach (Char c in str)
                secureString.AppendChar(c);

            return secureString;
        }

    }
}
