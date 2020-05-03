using System;
using System.Collections.Generic;
using System.Reflection;

namespace ShapesDrawing
{
    public interface IPluginScanner
    {
        List<Type> GetSortedTypesList<BaseType>(Assembly assembly);
        Assembly GetAssembly(string pluginPath, ref string errorString);
    }
}
