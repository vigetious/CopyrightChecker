using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace CopyrightCheckerLogic {
    public class md5 {
        public List<string> publicMd5 { get; }
        public md5() {
            publicMd5 = getMd5();
        }
        
        private List<string> getMd5() {
            using var client = new WebClient();

            var content = client.DownloadString("https://raw.githubusercontent.com/vigetious/CopyrightMd5File/master/md5");

            List<string> listOfMd5 = new List<string>();
            
            using (StringReader reader = new StringReader(content)) {
                while (reader.Peek() >= 0) {
                    listOfMd5.Add(reader.ReadLine());
                }
            }
            
            return listOfMd5;
        }
    }
}