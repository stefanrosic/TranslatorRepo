using System;
using TranslatorToolApp.Models;

namespace TranslatorToolApp.Services
{
    public class TranslationServiceFactory
    {
        ITranslationService _translation_service;

        public TranslationServiceFactory(ITranslationService _service)
        {
            _translation_service = _service;
        }

        public string ProcessTranslation(Translation translationRequest)
        {
            return _translation_service.translate(translationRequest);
        }
    }
}