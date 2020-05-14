using System;
using System.Web.Http;
using System.Web.Http.Cors;
using TranslatorToolApp.Models;
using TranslatorToolApp.Services;

namespace TranslatorToolApp.Controllers
{
    public class TranslationController : ApiController
    {

        TranslationServiceFactory translationServiceFactory;

        public TranslationController()
        {
            translationServiceFactory = new TranslationServiceFactory(new TranslationService());
        }

        [Route("api/translate")]
        [HttpPost]
        public String Index(Translation translation)
        {
            return translationServiceFactory.ProcessTranslation(translation);
        }

        [Route("api/get")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public String Get()
        {
            return "Evo meeee";
        }
    }
}
