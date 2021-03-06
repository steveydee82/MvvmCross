﻿// IMvxSimpleFileStoreService.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

#region using

using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace Cirrious.MvvmCross.Plugins.File
{
    public interface IMvxSimpleFileStoreService
    {
        bool TryReadTextFile(string path, out string contents);
        bool TryReadBinaryFile(string path, out Byte[] contents);
        bool TryReadBinaryFile(string path, Func<Stream, bool> readMethod);
        void WriteFile(string path, string contents);
        void WriteFile(string path, IEnumerable<Byte> contents);
        void WriteFile(string path, Action<Stream> writeMethod);
        bool TryMove(string from, string to, bool deleteExistingTo);
        bool Exists(string path);
        string PathCombine(string items0, string items1);

        void EnsureFolderExists(string folderPath);
        IEnumerable<string> GetFilesIn(string folderPath);
        void DeleteFile(string path);
    }
}