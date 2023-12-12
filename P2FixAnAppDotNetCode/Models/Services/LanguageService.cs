using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language.
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language.
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture. 
        /// Default culture : en-GB.
        /// </summary>
        /// <param name="language">Define the Culture (language) to set.</param>
        /// <returns>Return the applied culture (language).</returns>
        /// <remarks>TODO T05 (SMO) ==> implement cultures (languages) support.</remarks>
        public string SetCulture(string language)
        {
            // TODO complete the code. 
            // Default language is "en", french is "fr" and spanish is "es".

            // SMO: Defautl culture.
            string culture = "en-GB";
            switch (language)
            {
                // SMO: English culture support.
                case "Anglais":
                case "English":
                case "Inglès":
                    culture = "en-GB";
                    break;
                // SMO: French culture support.
                case "Français":
                case "French":
                case "Francés":
                    culture = "fr-FR";
                    break;
                // SMO: Spanish culture support.
                case "Espagnol":
                case "Spanish":
                case "Español":
                    culture = "es-ES";
                    break;
            }
            
            return culture;
        }

        /// <summary>
        /// Update the culture cookie.
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
