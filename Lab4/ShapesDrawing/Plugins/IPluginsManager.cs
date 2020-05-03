using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public interface IPluginsManager
    {
        IList<Plugin> Plugins { get; }
        IPluginScanner PluginScanner { get; }
        Plugin CurrentPlugin { get; }

        Type[] GetAllPluginsTypes();
        void AddPlugin(string pluginPath, ListBox listBox);
    }
}
