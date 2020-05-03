using MyShapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ShapesDrawing
{
	public class PluginScanner : IPluginScanner
	{
	     private bool CheckPluginSignature(Assembly pluginAssembly)
		 {
		     var currentAssemblyName = Assembly.GetExecutingAssembly().GetName();
			 var pluginAssemblyName = pluginAssembly.GetName();
			 if (currentAssemblyName.GetPublicKeyToken().SequenceEqual(pluginAssemblyName.GetPublicKeyToken()))
			 {
				 return true;
			 }
			 return false;
		 }

		public Assembly GetAssembly(string pluginPath, ref string stringError)
		{
			try
			{
				var assembly = Assembly.LoadFile(pluginPath);
				if (CheckPluginSignature(assembly))
				{
					return assembly;
				}
				stringError = "Цифровая подпись плагина - неверна!";
				return null;
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
