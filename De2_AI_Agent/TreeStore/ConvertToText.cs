using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using De2_AI_Agent.Models;

namespace De2_AI_Agent.TreeStore
{
    public class ConvertToText
    {


        string path = @"C:\Users\gabez\Desktop\AI Project\De2_AI_Agent\De2_AI_Agent\TreeStore\MyTree.txt";
        public void SaveTree(TreeNode treeNodes)
        {
            try
            {

                if (File.Exists(path))
                {
                    using (Stream stream = File.Open(path, FileMode.Create))
                    {
                        var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        binaryformatter.Serialize(stream, treeNodes);
                    }

                }
                else
                {

                    using (Stream stream = File.Open(path, FileMode.Create))
                    {
                        var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        binaryformatter.Serialize(stream, treeNodes);
                    }
                }
                

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public TreeNode RetrieveTree()
        {
            if (new FileInfo(path).Length != 0)
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {

                    var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return (TreeNode)binaryformatter.Deserialize(stream);

                }
            }
            else
            {
                return null;
            }
            
        }
    }
}