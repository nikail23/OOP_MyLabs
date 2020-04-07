using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ShapesDrawing
{
	public class PluginScanner : IPluginScanner
	{
		public string[] GetPluginsList(string directoryPath)
		{
			return Directory.GetFiles(directoryPath, "*.dll");
		}

		public List<string> GetPluginTypes(string pluginPath)
		{
			List<string> result = new List<string>();
			try
			{
				Assembly assembly = Assembly.LoadFrom(pluginPath);
				if (assembly != null)
				{
					foreach (var type in assembly.GetTypes())
					{
						var i = type.GetInterface("IPlugin");
						if (i != null)
							result.Add(type.Name);
					}
				}
				return result;
			}
			catch
			{
				return null;
			}
		}
	}
}
