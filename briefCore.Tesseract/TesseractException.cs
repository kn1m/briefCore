﻿namespace briefCore.Tesseract
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Desctiption of TesseractException.
	/// </summary>
	[Serializable]
	public class TesseractException : Exception, ISerializable
	{
		public TesseractException()
		{
		}

	 	public TesseractException(string message) : base(message)
		{
		}

		public TesseractException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected TesseractException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
