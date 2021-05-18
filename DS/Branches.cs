using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace DS
{
    public class Branches
    {

        public static List<BankBranch> getAllBrancehs()
        {

            List<BankBranch> list = new List<BankBranch>();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"snifim_dnld_he.xml");
            XmlNode rootNode = doc.DocumentElement;
            //DisplayNodes(rootNode);

            XmlNodeList children = rootNode.ChildNodes;
            foreach (XmlNode child in children)
            {
              BankBranch b =  GetBranchByXmlNode(child);
              if (b != null)
              {
                  list.Add(b);
              }
            }

            return list;
        }


        private static BankBranch GetBranchByXmlNode(XmlNode node)
        {
            if (node.Name != "BRANCH") return null;
            BankBranch branch = new BankBranch();


            XmlNodeList children = node.ChildNodes;
          
            foreach (XmlNode child in children)
            {
                switch (child.Name)
                {
                    case "Bank_Code":
                        branch.BankNumber = int.Parse( child.InnerText);
                        break;
                    case "Bank_Name":
                        branch.BankName = child.InnerText;
                        break;
                    case "Branch_Code":
                        branch.BranchNumber = int.Parse(child.InnerText);
                        break;
                    case "Branch_Name":
                        branch.BranchName = child.InnerText;
                        break;
                    case "Branch_Address":
                        branch.BranchAddress = child.InnerText;
                        break;
                    case "City":
                        branch.BranchCity = child.InnerText;
                        break;


                }
               
            }

            if (branch.BranchNumber> 0) 
                return branch;

            return null;

           
        }

        //private static void DisplayNodes(XmlNode node)
        //{
        //    //Print the node type, node name and node value of the node
        //    if (node.NodeType == XmlNodeType.Text)
        //    {
        //        Console.WriteLine("Type = [" + node.NodeType + "] Value = " + node.Value);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Type = [" + node.NodeType + "] Name = " + node.Name);
        //    }

        //    //Print attributes of the node
        //    if (node.Attributes != null)
        //    {
        //        XmlAttributeCollection attrs = node.Attributes;
        //        foreach (XmlAttribute attr in attrs)
        //        {
        //            Console.WriteLine("Attribute Name = " + attr.Name + "; Attribute Value = " + attr.Value);
        //        }
        //    }

        //    //Print individual children of the node, gets only direct children of the node
        //    //XmlNodeList children = node.ChildNodes;
        //    //foreach (XmlNode child in children)
        //    //{
        //    //    DisplayNodes(child);
        //    //}
        //}
    }
}
