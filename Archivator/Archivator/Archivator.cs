﻿using ShapesDrawing;
using System;
using System.IO;
using System.IO.Compression;

namespace Archivator
{
    public class Archivator
    { 
        public Archivator() { }

        public Stream Open(string openPath)
        {
            var sourceStream = new FileStream(openPath, FileMode.OpenOrCreate);
            var compressionStream = new GZipStream(sourceStream, CompressionMode.Decompress);
            return compressionStream;
        }

        public void Save(byte[] data, string savePath)
        {
            using (var targetStream = new FileStream(savePath, FileMode.Create))
            using (var compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
            {
                compressionStream.Write(data, 0, data.Length);
            }
        }
    }
}
