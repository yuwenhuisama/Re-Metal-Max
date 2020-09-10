using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace ReMetalMax.Core
{
    class JsonHelper : IHelper
    {
        public static readonly JsonHelper Instance = new JsonHelper();

        public Dictionary<string, ISource> Parse(string path) {
            if (Directory.Exists(path)) {
                return ParseDirectory(path);
            }
            else if (File.Exists(path)) {
                return ParseFile(path);
            }

            return null;
        }
        public Dictionary<string, ISource> ParseDirectory(string path) {
            Debug.Log("[JsonHelper]Start parse path: " + path);
            Dictionary<string, ISource> dict = new Dictionary<string, ISource>();
            if (!Directory.Exists(path)) {
                Debug.LogError("path: " + path + "do not exists!!");
                return null;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
            foreach (FileSystemInfo entry in fileSystemInfos) {
                if (entry is DirectoryInfo) {
                    var tmpDict = ParseDirectory(entry.FullName);
                    dict = dict.Concat(tmpDict).ToDictionary(obj => obj.Key, obj => obj.Value); // 如果具有重复的键，但是值不相同时会报错。
                } else if (entry is FileInfo && entry.Extension == ".json") {
                    var tmpDict = ParseFile(entry.FullName);
                    dict = dict.Concat(tmpDict).ToDictionary(obj => obj.Key, obj => obj.Value);
                }
            }

            return dict;
        }

        public Dictionary<string, ISource> ParseFile(string path) {
            Dictionary<string, ISource> dict = new Dictionary<string, ISource>();
            if (!File.Exists(path)) {
                Debug.LogError("path: " + path + "do not exists!!");
                return null;
            }

            string content = File.ReadAllText(path);
            var sourceList = JsonConvert.DeserializeObject<IEnumerable<ISource>>(content);
            dict = sourceList.ToDictionary(obj => obj.Name, obj => obj);

            return dict;
        }
    }
}
