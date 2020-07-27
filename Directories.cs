using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace CopyrightCheckerLogic {
    public class Directories {
        public Dictionary<string, string> md5Files { get; }

        public Directories(string directory) {
            md5Files = getDirectories(directory);
        }
        
        public static Dictionary<string, string> getDirectories(string directory) {
            Dictionary<string, string> md5Files = new Dictionary<string, string>();
            
            foreach (var file in Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories)) {
                using (var stream = File.OpenRead(file)) {
                    var hash = MD5.Create().ComputeHash(stream);
                    md5Files.Add(file, BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant());
                }
            }

            return md5Files;
        }
    }
}