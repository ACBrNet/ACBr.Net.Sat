using System;
using System.Runtime.InteropServices;
using ACBr.Net.Core.Exceptions;
using ExtraConstraints;

namespace ACBr.Net.Sat.Utils
{
	internal static class NativeMethods
	{
		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetProcAddress(this IntPtr hModule, string procedureName);

		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(this IntPtr hModule);

		public static T GetMethod<[DelegateConstraint]T>(this IntPtr ptr, string method) where T : class 
		{
			Guard.Against<ArgumentException>(!typeof(T).IsSubclassOf(typeof(Delegate)), $"{typeof(T).Name} is not a delegate type");
			var functionToCall = ptr.GetProcAddress(method);
			var funcaoSat = Marshal.GetDelegateForFunctionPointer(functionToCall,
				typeof(T));

			return funcaoSat as T;
		}
	}
}