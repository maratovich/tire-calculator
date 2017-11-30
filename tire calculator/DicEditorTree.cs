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

            //openFileBtn = new Button() { Text = "open", Width = 50, Height = 20 };
            //openFileBtn.Click += openFileBtn_Click;
            //Controls.Add(openFileBtn);

            //treeView = new TreeView()
            //{
            //    Location = new Point(0, openFileBtn.Bottom + 5),
            //    Width = this.Width,
            //    Height = this.Height - openFileBtn.Bottom + 5
            //};
            //Controls.Add(treeView);
        }

        void openFileBtn_Click(object sender, EventArgs e)
        {
            string fileName;

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Data files |*.xml|All iles|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName;

                XDocument doc = XDocument.Load(fileName);

                TreeNode root = new TreeNode(doc.Root.Name.ToString());
                treeView1.Nodes.Add(root);

                ReadNode(doc.Root, root);
            }
        }

        void ReadNode(XElement xElement, TreeNode treeNode)
        {
            foreach (XElement element in xElement.Elements())
            {
                TreeNode node = new TreeNode(element.Value.ToString());
                treeNode.Nodes.Add(node);

                if (element.HasAttributes)
                {
                    TreeNode attributesNode = new TreeNode("Attributes");
                    ReadAttributes(element, attributesNode);
                    node.Nodes.Add(attributesNode);
                }

                ReadNode(element, node);
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
    }
}
