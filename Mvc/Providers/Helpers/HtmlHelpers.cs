using System.Web.Mvc;

namespace Mvc.Helpers
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
        /*ecrire methode qui met en majusucule la 1ere lettre de chaque mot
         * pour afficher le nom produits, categories en mieux .... et y faire appel chaque fois qu'on affiche genre @p.ProductName.ToUpperFirst
         */
        //public static string ToUpperFirst(this HtmlHelper helper, string input)
        //{
        //    if(
        //}
    }
}