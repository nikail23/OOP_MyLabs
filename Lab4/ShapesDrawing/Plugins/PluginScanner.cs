using MyShapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ShapesDrawing
{
	public class PluginScanner : IPluginScanner
	{
		public Assembly GetAssembly(string pluginPath, ref string stringError)
		{
			try
			{
				var assembly = Assembly.LoadFile(pluginPath);
				return assembly;
			}
			catch (FileNotFoundException)
			{
				stringError = "Не удалось загрузить сборку, указанный путь - неверный!";
				return null;
			}
			catch (FileLoadException)
			{
				stringError = "Сборка не подписана!";
				return null;
			}
		}

		public List<Type> GetSortedTypesList<BaseType>(Assembly assembly)
		{
			var typesList = new List<Type>();
			foreach (var type in assembly.GetExportedTypes())
			{
				if ((type.IsClass) && (typeof(BaseType).IsAssignableFrom(type)))
				{
					typesList.Add(type);
				}
			}
			return typesList;
		}
	}
}
