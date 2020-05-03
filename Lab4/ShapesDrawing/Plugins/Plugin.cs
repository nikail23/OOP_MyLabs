using MyShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawing
{
    public class Plugin
    {
        public Assembly Assembly { get; }
        public List<Type> TypesList { get; }

        public Plugin(Assembly assembly, List<Type> typesList)
        {
            Assembly = assembly;
            TypesList = typesList;
        }
    }
}
