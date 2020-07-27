using System;
using System.Collections.Generic;

namespace CopyrightCheckerLogic {
    class Program {
        static void Main(string[] args) {
            if (args[0] == null) {
                Console.WriteLine("Please supply a folder to analyze.");
                return;
            }

            md5 assets = new md5();
            Directories dir = new Directories(args[0]);
            List<string> detectedFiles = new List<string>();

            foreach (var x in dir.md5Files) {
                for (int i = 0; i < assets.publicMd5.Count; i++) {
                    if (x.Value == assets.publicMd5[i]) {
                        detectedFiles.Add(x.Key);
                    }
                }
            }

            if (detectedFiles.Count > 0) {
                
                Console.WriteLine("Illegal assets detected! The following are the files that were detected: ");
                for (int i = 0; i < detectedFiles.Count; i++) {
                    Console.WriteLine(detectedFiles[i]);
                }
            } else {
                Console.WriteLine("No illegal assets detected.");
            }
        }
    }
}