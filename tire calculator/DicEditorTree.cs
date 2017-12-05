using System;
using System.IO;
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
        XDocument xDocModelDic = XDocument.Load("byModelDic.xml");
        XDocument xDocWidthDic = XDocument.Load("widthDic.xml");
        XDocument xDocProfileDic = XDocument.Load("profileDic.xml");
        XDocument xWheelSizeDic = XDocument.Load("wheelSizeDic.xml");
        bool brandFlag;
        bool modelFlag;
        bool yearFlag;
        bool engineFlag;

        public DicEditorTree()
        {
            InitializeComponent();
            CreatTreeView();

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
                listBoxProfiles.Items.Add(profileElement.Value);
            }

            var orderedWheelSize = from wheelSizes in xWheelSizeDic.Root.Elements("size")
                                   select wheelSizes;
            foreach (XElement wheelElement in orderedWheelSize)
            {
                listBoxWheelSize.Items.Add(wheelElement.Value);
            }
        }

        //Обработчики событий на вкладке "Ширина профиля"
        private void buttonEditWidth_Click(object sender, EventArgs e)
        {
            string editingWidth = textBoxWidth.Text;
            XElement width = xDocWidthDic.Root;
            foreach (XElement widthElemen in width.Elements("width").ToList())
            {
                if (widthElemen.Value == listBoxWidths.SelectedItem.ToString()) widthElemen.Value = editingWidth;

            }
            listBoxWidths.Items[listBoxWidths.SelectedIndex] = textBoxWidth.Text;
            xDocWidthDic.Save("widthDic.xml");
            textBoxWidth.Clear();
        }

        private void buttonDelWidth_Click(object sender, EventArgs e)
        {
            XElement width = xDocWidthDic.Root;
            foreach (XElement widthElemen in width.Elements("width").ToList())
            {
                if (widthElemen.Value == listBoxWidths.SelectedItem.ToString()) widthElemen.Remove();

            }
            listBoxWidths.Items.Remove(listBoxWidths.SelectedItem);
            xDocWidthDic.Save("widthDic.xml");
        }

        private void buttonAddWidth_Click(object sender, EventArgs e)
        {
            XElement width = xDocWidthDic.Root;
            string newWidth = textBoxWidth.Text;
            width.Add(new XElement("width", newWidth));
            listBoxWidths.Items.Add(newWidth);
            xDocWidthDic.Save("widthDic.xml");
            textBoxWidth.Clear();
            textBoxWidth.Enabled = false;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void listBoxWidths_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxWidth.Enabled = true;
            buttonDelWidth.Enabled = true;
        }
        //Обработчики событий на вкладке "Высота профиля"
        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            string editingProfile = textBoxProfile.Text;
            XElement profile = xDocProfileDic.Root;
            foreach (XElement profileElemen in profile.Elements("profile").ToList())
            {
                if (profileElemen.Value == listBoxProfiles.SelectedItem.ToString()) profileElemen.Value = editingProfile;

            }
            listBoxProfiles.Items[listBoxProfiles.SelectedIndex] = textBoxWidth.Text;
            xDocProfileDic.Save("profileDic.xml");
            textBoxProfile.Clear();
        }

        private void buttonDelProfile_Click(object sender, EventArgs e)
        {
            XElement profile = xDocProfileDic.Root;
            foreach (XElement profileElemen in profile.Elements("profile").ToList())
            {
                if (profileElemen.Value == listBoxProfiles.SelectedItem.ToString()) profileElemen.Remove();

            }
            listBoxProfiles.Items.Remove(listBoxProfiles.SelectedItem);
            xDocProfileDic.Save("profileDic.xml");
        }

        private void buttonAddProfile_Click(object sender, EventArgs e)
        {
            XElement profile = xDocProfileDic.Root;
            string newProfile = textBoxProfile.Text;
            profile.Add(new XElement("profile", newProfile));
            listBoxProfiles.Items.Add(newProfile);
            xDocProfileDic.Save("profileDic.xml");
            textBoxProfile.Clear();
            textBoxProfile.Enabled = false;
        }

        private void listBoxProfiles_SelectedValueChanged(object sender, EventArgs e)
        {
            buttonDelProfile.Enabled = true;
            textBoxProfile.Enabled = true;
        }
        //Обработчики событий на вкладке "Посадочные размеры"
        private void buttonEditWheelSize_Click(object sender, EventArgs e)
        {
            string editingWheelSize = textBoxWheelSize.Text;
            XElement wheelSize = xWheelSizeDic.Root;
            foreach (XElement profileElemen in wheelSize.Elements("size").ToList())
            {
                if (profileElemen.Value == listBoxWheelSize.SelectedItem.ToString()) profileElemen.Value = editingWheelSize;

            }
            listBoxWheelSize.Items[listBoxWheelSize.SelectedIndex] = textBoxWidth.Text;
            xWheelSizeDic.Save("wheelSizeDic.xml");
            textBoxWheelSize.Clear();
            textBoxWheelSize.Enabled = false;
        }

        private void buttonDelWheelSize_Click(object sender, EventArgs e)
        {
            XElement wheelSize = xWheelSizeDic.Root;
            foreach (XElement profileElemen in wheelSize.Elements("size").ToList())
            {
                if (profileElemen.Value == listBoxWheelSize.SelectedItem.ToString()) profileElemen.Remove();

            }
            listBoxWheelSize.Items.Remove(listBoxWheelSize.SelectedItem);
            xWheelSizeDic.Save("wheelSizeDic.xml");
        }

        private void buttonAddWheelSize_Click(object sender, EventArgs e)
        {
            XElement wheelSize = xWheelSizeDic.Root;
            string newWheelSize = textBoxWheelSize.Text;
            wheelSize.Add(new XElement("size", newWheelSize));
            listBoxWheelSize.Items.Add(newWheelSize);
            xWheelSizeDic.Save("wheelSizeDic.xml");
            textBoxWheelSize.Clear();
            textBoxWheelSize.Enabled = false;
        }

        private void listBoxWheelSize_SelectedValueChanged(object sender, EventArgs e)
        {
            buttonDelWheelSize.Enabled = true;
            textBoxWheelSize.Enabled = true;
        }

        //Обработчки событий вкладка "Автомобили"
        private void brandComboBoxEd_TextChanged(object sender, EventArgs e)
        {
            brandFlag = false;
            foreach (string item in brandComboBoxEd.Items)
            {

                if (item.Equals(brandComboBoxEd.Text))
                {
                    modelComboBoxEd.Items.Clear();
                    var brands = from xbrand in xDocModelDic.Root.Elements("brand")
                                 where xbrand.Attribute("name").Value == brandComboBoxEd.Text
                                 select xbrand;
                    foreach (XElement model in brands.Elements("model"))
                    {
                        modelComboBoxEd.Items.Add(model.Attribute("nick").Value);
                    }
                    modelComboBoxEd.Enabled = true;

                    brandFlag = true;
                }
            }
            buttonAddTreeGroup.Enabled = true;
            buttonDelTreeGroup.Enabled = true;
        }

        private void modelComboBoxEd_TextChanged(object sender, EventArgs e)
        {
            modelFlag = false;
            foreach (string item in modelComboBoxEd.Items)
            {
                if (item.Equals(modelComboBoxEd.Text))
                {
                    yearComboBoxEd.Items.Clear();
                    var models = from xmodel in xDocModelDic.Root.Elements("brand").Elements("model")
                                 where xmodel.Attribute("nick").Value == modelComboBoxEd.Text
                                 select xmodel;
                    foreach (XElement model in models)
                    {
                        yearComboBoxEd.Items.Add(model.Element("prod_year").Attribute("year").Value);
                    }
                    yearComboBoxEd.Enabled = true;
                    modelFlag = true;
                }
            }
        }

        private void yearComboBoxEd_TextChanged(object sender, EventArgs e)
        {
            yearFlag = false;
            foreach (string item in yearComboBoxEd.Items)
            {
                if (item.Equals(yearComboBoxEd.Text))
                {
                    engineComboBoxEd.Items.Clear();
                    var years = from xYear in xDocModelDic.Root.Elements("brand").Elements("model")
                            .Elements("prod_year")
                                where xYear.Attribute("year").Value == yearComboBoxEd.Text
                                select xYear;
                    foreach (XElement engine in years)
                    {
                        engineComboBoxEd.Items.Add(engine.Element("engine").Value);
                    }
                    engineComboBoxEd.Enabled = true;
                    yearFlag = true;
                }
            }
        }

        private void engineComboBoxEd_TextChanged(object sender, EventArgs e)
        {
            engineFlag = false;
            foreach (string item in engineComboBoxEd.Items)
            {

                if (item.Equals(engineComboBoxEd.Text))
                {
                    tyreSizesTextBoxEd.Clear();
                    var years = from xYear in xDocModelDic.Root.Elements("brand").Elements("model")
                            .Elements("prod_year")
                                where xYear.Attribute("year").Value == yearComboBoxEd.Text
                                select xYear;
                    foreach (XElement tyreSizes in years.Elements("tyre_sizes"))
                    {
                        tyreSizesTextBoxEd.Text += tyreSizes.Value + Environment.NewLine;
                    }
                    tyreSizesTextBoxEd.Enabled = true;
                    engineFlag = true;
                }

            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            treeView1.Tag = treeView1.SelectedNode.Text;
            treeView1.LabelEdit = true;
            if (!treeView1.SelectedNode.IsEditing)
            {
                treeView1.SelectedNode.BeginEdit();
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                e.Node.EndEdit(false);
                IEnumerable<XElement> brands = xDocModelDic.Root.Elements("brand");
                //treeView1.Tag - старое значение
                //e.Node.Text - новое значение //уровень элемента (0-4)
                switch (e.Node.Tag)
                {
                    case 0:
                        foreach (XElement brand in brands)
                        {
                            if (brand.Attribute("name").Value.Equals(treeView1.Tag))
                            {
                                brand.Attribute("name").Value = e.Label;
                            }
                        };
                        break;
                    case 1:
                        IEnumerable<XElement> models = xDocModelDic.Root.Elements("brand").Elements("model");
                        //IEnumerable<XElement> models = from xmodel in elements
                        //                               where xmodel.Attribute("nick").Equals(treeView1.Tag)
                        //                               select xmodel;
                        foreach (XElement model in models)
                        {
                            if (model.Attribute("nick").Value.Equals(treeView1.Tag) && model.Parent.Attribute("name").Value.Equals(treeView1.SelectedNode.Parent.Text))
                            {
                                model.Attribute("nick").Value = e.Label;
                            }
                        };
                        break;
                    case 2:
                        IEnumerable<XElement> years = xDocModelDic.Root.Elements("brand").Elements("model").Elements("prod_year");
                        //IEnumerable<XElement> years = from xyear in elements
                        //                              where xyear.Attribute("year").Equals(treeView1.Tag)
                        //                              select xyear;
                        foreach (XElement year in years)
                        {
                            if (year.Attribute("year").Value.Equals(treeView1.Tag) && year.Parent.Attribute("nick").Value.Equals(treeView1.SelectedNode.Parent.Text))
                            {
                                year.Attribute("year").Value = e.Label;
                            }
                        };
                        break;
                    case 3:
                        IEnumerable<XElement> engines = xDocModelDic.Root.Elements("brand").Elements("model").Elements("prod_year");
                        //IEnumerable<XElement> engines = from xengine in elements
                        //                                where xengine.Attribute("year").Equals(treeView1.Tag)
                        //                                select xengine;
                        foreach (XElement engine in engines)
                        {
                            if (engine.Element("engine").Value.Equals(treeView1.Tag.ToString().Replace(" двигатель", "")) && engine.Attribute("year").Value.Equals(treeView1.SelectedNode.Parent.Text))
                            {
                                engine.Element("engine").Value = e.Label;
                            }
                        };
                        break;
                    case 4:
                        IEnumerable<XElement> tyres = xDocModelDic.Root.Elements("brand").Elements("model").Elements("prod_year");
                        //IEnumerable<XElement> tyres1 = from xtyre in tyres
                        //                               where xtyre.Element("tyre_sizes").Value.Equals(treeView1.Tag)
                        //                              select xtyre;
                        foreach (XElement tyre in tyres)
                        {
                            foreach (XElement elem in tyre.Elements("tyre_sizes"))
                                if (elem.Value.Equals(treeView1.Tag) && tyre.Attribute("year").Value.Equals(treeView1.SelectedNode.Parent.Text))
                                {
                                    elem.Value = e.Label;
                                }
                        };
                        break;
                }
                xDocModelDic.Save("byModelDic.xml");
            }
        }

        private void buttonAddTreeGroup_Click(object sender, EventArgs e)
        {
            XElement xDoc = xDocModelDic.Root;
            if (brandFlag == false)
            {
                DialogResult result = MessageBox.Show("Элемета БРЕНД в списке нет, завести новый элемент справочника?", "Добавление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var lines = new List<string>();
                    lines.AddRange(tyreSizesTextBoxEd.Lines);
                    XElement newBrand = new XElement(new XElement("brand", new XAttribute("name", brandComboBoxEd.Text),
                        new XElement("model", new XAttribute("nick", modelComboBoxEd.Text),
                        new XElement("prod_year", new XAttribute("year", yearComboBoxEd.Text),
                        new XElement("engine", engineComboBoxEd.Text), new XElement("tyre_sizes", lines)))));
                    xDoc.Add(newBrand);
                }
            }
            if (brandFlag == true && modelFlag == false)
            {
                DialogResult result = MessageBox.Show("МОДЕЛИ в списке нет, завести новый элемент бренда " + brandComboBoxEd.Text + "?", "Добавление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var lines = new List<string>();
                    lines.AddRange(tyreSizesTextBoxEd.Lines);
                    IEnumerable<XElement> models = xDocModelDic.Root.Elements("brand");
                    foreach (XElement model in models)
                    {
                        if (model.Attribute("name").Value.Equals(brandComboBoxEd.Text))
                        {
                            XElement newModel = new XElement(new XElement("model", new XAttribute("nick", modelComboBoxEd.Text),
                            new XElement("prod_year", new XAttribute("year", yearComboBoxEd.Text),
                            new XElement("engine", engineComboBoxEd.Text), new XElement("tyre_sizes", lines))));
                            model.Add(newModel);
                        }
                    }
                }
            }
            if (brandFlag == true && modelFlag == true && yearFlag == false)
            {
                DialogResult result = MessageBox.Show("ГОДА ВЫПУСКА модели " + modelComboBoxEd.Text + " в списке нет, завести новый элемент?", "Добавление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var lines = new List<string>();
                    lines.AddRange(tyreSizesTextBoxEd.Lines);
                    IEnumerable<XElement> yaers = xDocModelDic.Root.Elements("brand").Elements("model");
                    foreach (XElement year in yaers)
                    {
                        if (year.Parent.Attribute("name").Value.Equals(brandComboBoxEd.Text) && year.Attribute("nick").Value.Equals(modelComboBoxEd.Text))
                        {
                            XElement newYear = new XElement(new XElement("prod_year", new XAttribute("year", yearComboBoxEd.Text),
                            new XElement("engine", engineComboBoxEd.Text), new XElement("tyre_sizes", lines)));
                            year.Add(newYear);
                        }
                    }
                }
            }
            if (brandFlag == true && modelFlag == true && yearFlag == true && engineFlag == false)
            {
                DialogResult result = MessageBox.Show("ДВИГАТЕЛЯ модели " + modelComboBoxEd.Text + " года выпуска " + yearComboBoxEd.Text + " в списке нет, завести новый элемент?", "Добавление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var lines = new List<string>();
                    lines.AddRange(tyreSizesTextBoxEd.Lines);
                    IEnumerable<XElement> engines = xDocModelDic.Root.Elements("brand").Elements("model");
                    foreach (XElement engine in engines)
                    {
                        if (engine.Parent.Attribute("name").Value.Equals(brandComboBoxEd.Text) && engine.Attribute("nick").Value.Equals(modelComboBoxEd.Text)
                            && engine.Element("prod_year").Attribute("year").Value.Equals(yearComboBoxEd.Text))
                        {
                            XElement newEngine = new XElement(new XElement("prod_year", new XAttribute("year", yearComboBoxEd.Text),
                            new XElement("engine", engineComboBoxEd.Text), new XElement("tyre_sizes", lines)));
                            engine.Add(newEngine);
                        }
                    }
                }
            }
            if (brandFlag == true && modelFlag == true && yearFlag == true && engineFlag == true)
            {
                DialogResult result = MessageBox.Show("Добавить к элементу справочника " + brandComboBoxEd.Text + " " + modelComboBoxEd.Text + " " + yearComboBoxEd.Text + " " + engineComboBoxEd.Text + " " + "новые размерности шин",  "Добавление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var lines = new List<string>();
                    lines.AddRange(tyreSizesTextBoxEd.Lines);
                    //tyreSizesTextBoxEd.Clear();
                    IEnumerable<XElement> tyres = xDocModelDic.Root.Elements("brand").Elements("model");
                    int i = 1;
                    foreach (XElement elem in tyres)
                    {
                        if (elem.Parent.Attribute("name").Value.Equals(brandComboBoxEd.Text) && elem.Attribute("nick").Value.Equals(modelComboBoxEd.Text)
                            && elem.Element("prod_year").Attribute("year").Value.Equals(yearComboBoxEd.Text) 
                            && elem.Element("prod_year").Element("engine").Value.Equals(engineComboBoxEd.Text))
                        {
                            if (i <= lines.Count)
                            {
                                XElement newTyre = new XElement(new XElement("prod_year", new XAttribute("year", yearComboBoxEd.Text),
                                new XElement("engine", engineComboBoxEd.Text), new XElement("tyre_sizes", lines[i])));
                                elem.Add(newTyre);
                                i++;
                            }

                        }
                    }
                }
            }
            xDoc.Save("byModelDic.xml");
            tyreSizesTextBoxEd.Clear();
            CreatTreeView();
            //brandComboBoxEd.SelectedIndex = -1;
            //modelComboBoxEd.SelectedIndex = -1;
            //modelComboBoxEd.Items.Clear();
            //yearComboBoxEd.SelectedIndex = -1;
            //yearComboBoxEd.Items.Clear();
            //engineComboBoxEd.SelectedIndex = -1;
            //engineComboBoxEd.Items.Clear();
        }

        private void buttonDelTreeGroup_Click(object sender, EventArgs e)
        {
            XElement xDoc = xDocModelDic.Root;
            if (brandComboBoxEd.SelectedIndex != -1 && modelComboBoxEd.SelectedIndex != -1 && yearComboBoxEd.SelectedIndex != -1 && engineComboBoxEd.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("УДАЛИТЬ выбранный элемент и все его дочернии элементы?", "Добавление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    IEnumerable<XElement> Elements = xDocModelDic.Root.Elements("brand").ToList();
                    foreach (XElement elemToDel in Elements)
                    {
                        if (elemToDel.Attribute("name").Value.Equals(brandComboBoxEd.Text)
                            && elemToDel.Element("model").Attribute("nick").Value.Equals(modelComboBoxEd.Text)
                            && elemToDel.Element("model").Element("prod_year").Attribute("year").Value.Equals(yearComboBoxEd.Text)
                            && elemToDel.Element("model").Element("prod_year").Element("engine").Value.Equals(engineComboBoxEd.Text))
                        {
                           elemToDel.Remove();
                        }
                    }
                }
            }
            xDoc.Save("byModelDic.xml");
            CreatTreeView();
        }

        //Метод заполнения Древо TreeView
        private void CreatTreeView()
        {
            treeView1.Nodes.Clear();
            brandComboBoxEd.Items.Clear();
            brandComboBoxEd.Text = "";
            brandComboBoxEd.SelectedIndex = -1;
            modelComboBoxEd.Items.Clear();
            modelComboBoxEd.Text = "";
            modelComboBoxEd.SelectedIndex = -1;
            yearComboBoxEd.Items.Clear();
            yearComboBoxEd.Text = "";
            yearComboBoxEd.SelectedIndex = -1;
            engineComboBoxEd.Items.Clear();
            engineComboBoxEd.Text = "";
            engineComboBoxEd.SelectedIndex = -1;

            foreach (XElement brand in xDocModelDic.Root.Elements())
            {
                TreeNode brandNode = new TreeNode(brand.Attribute("name").Value);
                brandNode.Tag = 0;
                treeView1.Nodes.Add(brandNode);
                brandComboBoxEd.Items.Add(brand.Attribute("name").Value);
                foreach (XElement model in brand.Elements("model"))
                {
                    TreeNode modelNode = new TreeNode(model.Attribute("nick").Value);
                    modelNode.Tag = 1;
                    brandNode.Nodes.Add(modelNode);
                    foreach (XElement prod_year in model.Elements("prod_year"))
                    {
                        TreeNode yearNode = new TreeNode(prod_year.Attribute("year").Value);
                        yearNode.Tag = 2;
                        modelNode.Nodes.Add(yearNode);
                        foreach (XElement prodYearElements in prod_year.Elements())
                        {
                            TreeNode yearElemsNode;
                            if (prodYearElements.Name.ToString().Equals("engine"))
                            {
                                yearElemsNode = new TreeNode(prodYearElements.Value + " двигатель");
                                yearElemsNode.Tag = 3;
                            }
                            else
                            {
                                yearElemsNode = new TreeNode(prodYearElements.Value);
                                yearElemsNode.Tag = 4;
                            }
                            yearNode.Nodes.Add(yearElemsNode);
                        }
                    }
                }
            }
        }

        //Метод заполнения вкладок "Широина профиля", "Высота профиля", "Посадочные размеры"
        private void FillListBoxes()
        {
            listBoxWidths.Items.Clear();
            listBoxProfiles.Items.Clear();
            listBoxWheelSize.Items.Clear();
            brandComboBoxEd.Items.Clear();
            modelComboBoxEd.Items.Clear();
            yearComboBoxEd.Items.Clear();
            engineComboBoxEd.Items.Clear();

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
                listBoxProfiles.Items.Add(profileElement.Value);
            }

            var orderedWheelSize = from wheelSizes in xWheelSizeDic.Root.Elements("size")
                                   select wheelSizes;
            foreach (XElement wheelElement in orderedWheelSize)
            {
                listBoxWheelSize.Items.Add(wheelElement.Value);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
             IEnumerable<XElement> brands = xDocModelDic.Root.Elements("brand");
            switch (treeView1.SelectedNode.Tag)
            {
                case 0:
                    foreach (XElement brand in brands)
                    {
                        if (brand.Attribute("name").Value.Equals(treeView1.Tag))
                        {
                            treeView1.SelectedNode.Remove();
                            brand.Remove();
                        }
                    };
                    break;
                case 1:
                    IEnumerable<XElement> models = xDocModelDic.Root.Elements("brand").Elements("model");
                    foreach (XElement model in models)
                    {
                        if (model.Attribute("nick").Value.Equals(treeView1.Tag) && model.Parent.Attribute("name").Value.Equals(treeView1.SelectedNode.Parent.Text))
                        {
                            treeView1.SelectedNode.Remove();
                            model.Remove();
                        }
                    };
                    break;
                case 2:
                    IEnumerable<XElement> years = xDocModelDic.Root.Elements("brand").Elements("model").Elements("prod_year");
                    //IEnumerable<XElement> years = from xyear in elements
                    //                              where xyear.Attribute("year").Equals(treeView1.Tag)
                    //                              select xyear;
                    foreach (XElement year in years)
                    {
                        if (year.Attribute("year").Value.Equals(treeView1.Tag) && year.Parent.Attribute("nick").Value.Equals(treeView1.SelectedNode.Parent.Text))
                        {
                            treeView1.SelectedNode.Remove();
                            year.Remove();
                        }
                    };
                    break;
                case 3:
                    IEnumerable<XElement> engines = xDocModelDic.Root.Elements("brand").Elements("model").Elements("prod_year");
                    //IEnumerable<XElement> engines = from xengine in elements
                    //                                where xengine.Attribute("year").Equals(treeView1.Tag)
                    //                                select xengine;
                    foreach (XElement engine in engines)
                    {
                        if (engine.Element("engine").Value.Equals(treeView1.Tag.ToString().Replace(" двигатель", "")) && engine.Attribute("year").Value.Equals(treeView1.SelectedNode.Parent.Text))
                        {
                            treeView1.SelectedNode.Remove();
                            engine.Remove();
                        }
                    };
                    break;
                case 4:
                    IEnumerable<XElement> tyres = xDocModelDic.Root.Elements("brand").Elements("model").Elements("prod_year");
                    //IEnumerable<XElement> tyres1 = from xtyre in tyres
                    //                               where xtyre.Element("tyre_sizes").Value.Equals(treeView1.Tag)
                    //                              select xtyre;
                    foreach (XElement tyre in tyres)
                    {
                        foreach (XElement elem in tyre.Elements("tyre_sizes"))
                            if (elem.Value.Equals(treeView1.Tag) && tyre.Attribute("year").Value.Equals(treeView1.SelectedNode.Parent.Text))
                            {
                                treeView1.SelectedNode.Remove();
                                elem.Remove();
                            }
                    };
                    break;
            }
            xDocModelDic.Save("byModelDic.xml");
            CreatTreeView();
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            if (textBoxWidth.Text.Length != 0)
            {
                buttonAddWidth.Enabled = true;
                buttonEditWidth.Enabled = true;
            }
            else
            {
                buttonAddWidth.Enabled = false;
                buttonEditWidth.Enabled = false;
            }
        }

        private void textBoxProfile_TextChanged(object sender, EventArgs e)
        {
            if (textBoxProfile.Text.Length != 0)
            {
                buttonAddProfile.Enabled = true;
                buttonEditProfile.Enabled = true;
            }
            else
            {
                buttonAddProfile.Enabled = false;
                buttonEditProfile.Enabled = false;
            }
        }

        private void textBoxWheelSize_TextChanged(object sender, EventArgs e)
        {
            if (textBoxWheelSize.Text.Length != 0)
            {
                buttonAddWheelSize.Enabled = true;
                buttonEditWheelSize.Enabled = true;
            }
            else
            {
                buttonAddWheelSize.Enabled = false;
                buttonEditWheelSize.Enabled = false;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
                this.contextMenuStrip1.Show(treeView1, e.Location);
                treeView1.Tag = treeView1.SelectedNode.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brandComboBoxEd.SelectedIndex = -1;
            modelComboBoxEd.SelectedIndex = -1;
            modelComboBoxEd.Items.Clear();
            yearComboBoxEd.SelectedIndex = -1;
            yearComboBoxEd.Items.Clear();
            engineComboBoxEd.SelectedIndex = -1;
            engineComboBoxEd.Items.Clear();
        }
    }
}
