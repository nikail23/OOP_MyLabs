using MyShapes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public class PluginsManager : IPluginsManager
    {
        public IList<Plugin> HierarchyPlugins { get; }
        public IList<Plugin> SerializerPlugins { get; }
        public IPluginScanner PluginScanner { get; }
        public Plugin CurrentPlugin { get; private set; }

        public PluginsManager(IList<Plugin> hierarchyPlugins, IList<Plugin> functionalPlugins, IPluginScanner pluginScanner)
        {
            HierarchyPlugins = hierarchyPlugins;
            SerializerPlugins = functionalPlugins;
            PluginScanner = pluginScanner;
        }

        public Type[] GetAllHierarchyPluginsTypes()
        {
            var types = new List<Type>();
            foreach (var plugin in HierarchyPlugins)
                foreach (var type in plugin.TypesList)
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

        public bool TryAddSerializerPlugin(string pluginPath, CheckedListBox checkedFunctionalListBox)
        {
            var errorString = "";
            var assembly = PluginScanner.GetAssembly(pluginPath, ref errorString);
            if (assembly != null)
            {
                var pluginTypes = PluginScanner.GetSortedTypesList<IShapeListSerializer>(assembly);
                if (pluginTypes.Count != 0)
                {
                    CurrentPlugin = new Plugin(assembly, pluginTypes);
                    SerializerPlugins.Add(CurrentPlugin);
                    AddPluginTypesNameToListBox(CurrentPlugin.TypesList, checkedFunctionalListBox);
                    return true;
                }
                else
                {
                    MessageBox.Show("Функциональных классов не было найдено!", "Ошибка!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show(errorString, "Ошибка!");
                return false;
            }
        }

        public bool TryAddHierarchyPlugin(string pluginPath, ListBox hierarchyListBox)
        {
            var errorString = "";
            var assembly = PluginScanner.GetAssembly(pluginPath, ref errorString);
            if (assembly != null)
            {
                var pluginTypes = PluginScanner.GetSortedTypesList<Shape>(assembly);
                if (pluginTypes.Count != 0)
                {
                    CurrentPlugin = new Plugin(assembly, pluginTypes);
                    HierarchyPlugins.Add(CurrentPlugin);
                    AddPluginTypesNameToListBox(CurrentPlugin.TypesList, hierarchyListBox);
                    return true;
                }
                else
                {
                    MessageBox.Show("Классов, расширяющих имеющуюся иерархию фигур, не было найдено!", "Ошибка!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show(errorString, "Ошибка!");
                return false;
            }
        }
    }
}
