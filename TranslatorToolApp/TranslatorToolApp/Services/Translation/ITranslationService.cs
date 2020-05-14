using System;
using TranslatorToolApp.Models;

namespace TranslatorToolApp.Services
{
    public interface ITranslationService
    {
        String translate(Translation translationRequest);
    }
}
