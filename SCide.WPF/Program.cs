using System;
using System.IO;
using System.Reflection;

namespace SCide.WPF
{
	internal static class Program
	{
		public static string Title
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (!String.IsNullOrEmpty(titleAttribute.Title))
						return titleAttribute.Title;
				}

				// If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}
	}
}
