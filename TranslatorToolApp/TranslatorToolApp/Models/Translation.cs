using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TranslatorToolApp.Models
{
	[Serializable]
	public class Translation
    {

		[Required]
		private long translationID;

		public long TranslationID
		{
			get { return translationID; }
			set { translationID = value; }
		}

		private DateTime timestamp;

		public DateTime Timestamp
		{
			get { return timestamp; }
			set { timestamp = value; }
		}


		[Required]
		private String word;

		public String Word
		{
			get { return word; }
			set { word = value; }
		}

		[Required]
		[StringLength(2)]
		[RegularExpression(@"^[A-Z]{2}")]
		private String translateFrom;

		public String TranslateFrom
		{
			get { return translateFrom; }
			set { translateFrom = value; }
		}


		[Required]
		[StringLength(2)]
		[RegularExpression(@"^[A-Z]{2}")]
		private String translateTo;

		public String TranslateTo
		{
			get { return translateTo; }
			set { translateTo = value; }
		}
	}
}