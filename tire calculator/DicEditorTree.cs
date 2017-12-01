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
using tyre_calculator.Model;


namespace TyreCalculator
{
    public partial class DicEditorTree : Form
    {
        XDocument xDocModelDic = XDocument.Load("D:\\Downloads\\C#\\tyre calculator\\byModelDic.xml");
        XDocument xDocWidthDic = XDocument.Load("D:\\Downloads\\C#\\tyre calculator\\widthDic.xml");
        XDocument xDocProfileDic = XDocument.Load("D:\\Downloads\\C#\\tyre calculator\\profileDic.xml");
        XDocument xWheelSizeDic = XDocument.Load("D:\\Downloads\\C#\\tyre calculator\\wheelSizeDic.xml");

        public DicEditorTree()
        {
            InitializeComponent();
            foreach (XElement brand in xDocModelDic.Root.Elements())
            {
                TreeNode brandNode = new TreeNode(brand.Attribute("name").Value.ToString());
                treeView1.Nodes.Add(brandNode);
                brandComboBoxEd.Items.Add(brand.Attribute("name").Value);
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
                
                //label5.Text = fike
            }

            var orderedWidth = from widths in xDocWidthDic.Root.Elements("width")
                               select widths;
            foreach (XElement widthElemen in orderedWidth)
            {
                listBoxWidths.Items.Add(widthElemen.Value);
            }

            var orderedProfile = from profiles in xDocProfileDic.Root.Elements("profile")
                                 select profiles;
            foreach (XElement profileElement in orderedProfile)
            {
                listBox2.Items.Add(profileElement.Value);
            }

            var orderedWheelSize = from wheelSizes in xWheelSizeDic.Root.Elements("size")
                                   select wheelSizes;
            foreach (XElement wheelElement in orderedWheelSize)
            {
                listBox3.Items.Add(wheelElement.Value);
            }
        }

        private void brandComboBoxEd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var brands = from xbrand in doc.Root.Elements("brand")
            //             where xbrand.Attribute("name").Value == treeView1.SelectedNode
            //             select xbrand;
        }

        private void buttonEditWidth_Click(object sender, EventArgs e)
        {
            string editingWidth = textBox1.Text;
            XElement width = xDocWidthDic.Root;
            foreach (XElement widthElemen in width.Elements("width").ToList())
            {
               if (widthElemen.Value == listBoxWidths.SelectedItem.ToString()) widthElemen.Value = editingWidth;

            }
            xDocWidthDic.Save("D:\\Downloads\\C#\\tyre calculator\\TESTwidthDic.xml");
            textBox1.Clear();
            textBox1.Enabled = false;

        }

        private void buttonDelWidth_Click(object sender, EventArgs e)
        {
            XElement width = xDocWidthDic.Root;
            foreach (XElement widthElemen in width.Elements("width").ToList())
            {
                if (widthElemen.Value == listBoxWidths.SelectedItem.ToString()) widthElemen.Remove();

            }
            xDocWidthDic.Save("D:\\Downloads\\C#\\tyre calculator\\TESTwidthDic.xml");
        }

        private void buttonAddWidth_Click(object sender, EventArgs e)
        {
            XElement width = xDocWidthDic.Root;
            string newWidth = textBox1.Text;
            width.Add(new XElement("width", newWidth));
            xDocWidthDic.Save("D:\\Downloads\\C#\\tyre calculator\\TESTwidthDic.xml");
            textBox1.Clear();
            textBox1.Enabled = false;

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void listBoxWidths_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            buttonAddWidth.Enabled = true;
            buttonEditWidth.Enabled = true;
            buttonDelWidth.Enabled = true;
        }
    }
}
