using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Socket
{
    class IOBlacklist
    {
        private string filename;

        public IOBlacklist(string filename)
        {
            this.filename = filename;
        }
        //
        // Summary
        //     Read a blacklist websites from file
        public List<string> ReadBlackList()
        {
            List<string> list = new List<string>();
            using (FileStream fs = new FileStream(this.filename, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sReader = new StreamReader(fs))
                {
                    string line;

                    while ((line = sReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }
            return list;
        }
        //
        // Summary
        //     Write an item to blacklist
        public void WriteItem(string item)
        {
            using (StreamWriter sWriter = File.AppendText(this.filename))
            {
                sWriter.WriteLine(item);
            }
        }
        //
        // Summary
        //     Write a blacklist to output file
        //     We don't use WriteItem method because that will append text, not rewrite
        public void WriteBlackList(List<string> list)
        {
            using (StreamWriter sWriter = new StreamWriter(this.filename))
            {
                foreach (string line in list)
                {
                    sWriter.WriteLine(line);
                }
            }
        }
    }
}
