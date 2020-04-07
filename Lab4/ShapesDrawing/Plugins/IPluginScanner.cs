﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawing
{
    public interface IPluginScanner
    {
        string[] GetPluginsList(string directoryPath);
        List<string> GetPluginTypes(string pluginPath);
    }
}