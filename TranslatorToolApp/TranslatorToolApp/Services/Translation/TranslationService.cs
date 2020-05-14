using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using TranslatorToolApp.Data.XML;
using TranslatorToolApp.Models;

namespace TranslatorToolApp.Services
{
    public class TranslationService: ITranslationService
    {

        private static string TRANSLATION_API = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";

        public String translate(Translation translationRequest)
        {

            String URL = String.Format(
                TRANSLATION_API,
                translationRequest.TranslateFrom, translationRequest.TranslateTo,
                Uri.EscapeUriString(translationRequest.Word));

            String result = GetHttpClient().GetStringAsync(URL).Result;

            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
            var translationObjects = jsonData[0];

            StringBuilder stringBuilder = new StringBuilder();

            foreach (object obj in translationObjects)
            {
                IEnumerable translationObject = obj as IEnumerable;
                IEnumerator translationString = translationObject.GetEnumerator();

                translationString.MoveNext();

                stringBuilder.Append(
                    string.Format(" {0}", Convert.ToString(translationString.Current)));
            }

            String translation = stringBuilder.ToString();
            if (translation.Length > 1) { translation = translation.Substring(1); };

            TranslationXML.ProcessStoring(translationRequest);

            return translation;
        }

        private HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            return httpClient;
        }

        public TranslationService() { }
    }
}