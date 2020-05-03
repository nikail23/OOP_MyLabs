using MyShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public class PluginsManager : IPluginsManager
    {
        public IList<Plugin> Plugins { get; }
        public IPluginScanner PluginScanner { get; }
        public Plugin CurrentPlugin { get; private set; }

        public PluginsManager(IList<Plugin> plugins, IPluginScanner pluginScanner)
        {
            Plugins = plugins;
            PluginScanner = pluginScanner;
        }

        public Type[] GetAllPluginsTypes()
        {
            List<Type> types = new List<Type>();
            foreach (Plugin plugin in Plugins)
                foreach (Type type in plugin.TypesList)
                {
                    types.Add(type);
                }
            return types.ToArray();
        }
        private void AddPluginTypesNameToListBox(List<Type> pluginTypes, ListBox listBox)
        {
            foreach (var type in pluginTypes)
            {
                listBox.Items.Add(type.Name);
            }
        }
        public void AddPlugin(string pluginPath, ListBox listBox)
        {
            var errorString = "";
            var assembly = PluginScanner.GetAssembly(pluginPath, ref errorString);
            if (assembly != null)
            {
                var pluginTypes = PluginScanner.GetSortedTypesList<Shape>(assembly);
                if (pluginTypes.Count != 0)
                {
                    CurrentPlugin = new Plugin(assembly, pluginTypes);
                    Plugins.Add(CurrentPlugin);
                    AddPluginTypesNameToListBox(CurrentPlugin.TypesList, listBox);
                }
            }
            else
            {
                MessageBox.Show(errorString, "Ошибка!");
            }
        }
    }
}
