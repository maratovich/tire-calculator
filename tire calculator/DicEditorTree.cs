using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TyreCalculator
{
    public partial class DicEditorTree : Form
    {
        //TreeView treeView;
        //Button openFileBtn;

        public DicEditorTree()
        {
            InitializeComponent();
        }

        XDocument doc;
        void openFileBtn_Click(object sender, EventArgs e)
        {
            string fileName;

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Data files |*.xml|All iles|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName;

                doc = XDocument.Load(fileName);
                foreach (XElement brand in doc.Root.Elements())
                {
                    TreeNode brandNode = new TreeNode(brand.Attribute("name").Value.ToString());
                    treeView1.Nodes.Add(brandNode);
                    foreach (XElement model in brand.Elements("model"))
                    {
                        TreeNode modelNode = new TreeNode(model.Attribute("nick").Value.ToString());
                        brandNode.Nodes.Add(modelNode);
                        foreach (XElement prod_year in model.Elements("prod_year"))
                        {
                            TreeNode YearNode = new TreeNode(prod_year.Attribute("year").Value.ToString());
                            modelNode.Nodes.Add(YearNode);
                            foreach (XElement prodYearElements in prod_year.Elements())
                            {
                                string value = prodYearElements.Value.ToString();
                                if (prodYearElements.Name.ToString().Equals("engine"))
                                {
                                    value += " двигатель";
                                }
                                TreeNode YearElemsNode = new TreeNode(value);
                                YearNode.Nodes.Add(YearElemsNode);
                            }
                        }
                    }
                }
                /*
                TreeNode root = new TreeNode(doc.Root.Name.ToString());
                treeView1.Nodes.Add(root);

                ReadNode(doc.Root, root);
                */
            }
        }

        void ReadNode(XElement xElement, TreeNode treeNode)
        {
            foreach (XElement element in xElement.Elements())
            {
                TreeNode node = new TreeNode(element.Attribute("name").Value.ToString());
                treeNode.Nodes.Add(node);

                if (element.HasAttributes)
                {
                    TreeNode attributesNode = new TreeNode("Attributes");
                    ReadAttributes(element, attributesNode);
                    node.Nodes.Add(attributesNode);
                }

                //ReadNode(element, node);
            }
        }

        void ReadAttributes(XElement element, TreeNode treeNode)
        {
            foreach (XAttribute attribute in element.Attributes())
            {
                TreeNode node = new TreeNode(attribute.ToString());
                treeNode.Nodes.Add(node);
            }
        }

        private void brandComboBoxEd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var brands = from xbrand in doc.Root.Elements("brand")
            //             where xbrand.Attribute("name").Value == treeView1.SelectedNode
            //             select xbrand;
        }
    }
}
