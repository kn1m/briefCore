﻿namespace briefCore.Tesseract.Interop
{
	using System;

	/// <summary>
	/// Provides information about the hosting process.
	/// </summary>
	static class HostProcessInfo
	{
		public static readonly bool Is64Bit;
		
		static HostProcessInfo() {
			Is64Bit = IntPtr.Size == 8;
		}
	}
}
