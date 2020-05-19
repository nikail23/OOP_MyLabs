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
        IList<Plugin> HierarchyPlugins { get; }
        IList<Plugin> SerializerPlugins { get; }
        IPluginScanner PluginScanner { get; }
        Plugin CurrentPlugin { get; }

        Type[] GetAllHierarchyPluginsTypes();
        bool TryAddHierarchyPlugin(string pluginPath, ListBox hierarchyListBox);
        bool TryAddSerializerPlugin(string pluginPath, CheckedListBox checkedFunctionalListBox);
    }
}
