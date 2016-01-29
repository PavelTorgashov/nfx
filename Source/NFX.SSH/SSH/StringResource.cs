/*
 Copyright (c) 2005 Poderosa Project, All Rights Reserved.
 This file is a part of the Granados SSH Client Library that is subject to
 the license included in the distributed package.
 You may not use this file except in compliance with the license.

 $Id: ConnectionParameter.cs,v 1.5 2011/10/27 23:21:56 kzmi Exp $
*/

using System;
using System.Globalization;
using System.Resources;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NFX.SSH.Util {

    /// <summary>
    /// StringResource の概要の説明です。
    /// </summary>
    internal class StringResources {
        private string _resourceName;
        private ResourceManager _resMan;
        Assembly asm;

        public StringResources(string name, Assembly asm)
        {
            _resourceName = name;
            this.asm = asm;
        }

        public string GetString(string id) 
        {
            return GlobalResources.GetString(id, asm);
        }
    }

    /// <summary>
    /// Returns resource from entry assembly
    /// </summary>
    public static class GlobalResources
    {
        public static string GetString(string sourceName)
        {
            return GetResources().Select(res => res.GetString(sourceName)).FirstOrDefault(result => result != null);
        }

        public static Stream GetStream(string sourceName)
        {
            return GetResources().Select(res => res.GetStream(sourceName)).FirstOrDefault(result => result != null);
        }

        public static object GetObject(string sourceName)
        {
            return GetResources().Select(res => res.GetObject(sourceName)).FirstOrDefault(result => result != null);
        }

        static IEnumerable<System.Resources.ResourceManager> GetResources()
        {
            var ass = Assembly.GetEntryAssembly();
            foreach (var resourceName in ass.GetManifestResourceNames())
                yield return new System.Resources.ResourceManager(resourceName.Split(new string[] { ".resource" }, StringSplitOptions.None)[0], ass);
        }

        public static string GetString(string sourceName, Assembly ass)
        {
            return GetResources(ass).Select(res => res.GetString(sourceName)).FirstOrDefault(result => result != null);
        }

        public static Stream GetStream(string sourceName, Assembly ass)
        {
            return GetResources().Select(res => res.GetStream(sourceName)).FirstOrDefault(result => result != null);
        }

        public static object GetObject(string sourceName, Assembly ass)
        {
            return GetResources().Select(res => res.GetObject(sourceName)).FirstOrDefault(result => result != null);
        }

        static IEnumerable<System.Resources.ResourceManager> GetResources(Assembly ass)
        {
            foreach (var resourceName in ass.GetManifestResourceNames())
                yield return new System.Resources.ResourceManager(resourceName.Split(new string[] { ".resource" }, StringSplitOptions.None)[0], ass);
        }
    }
}