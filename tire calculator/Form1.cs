using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tyre_calculator.Model;
using System.Xml.Linq;

namespace TyreCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            /*Заполняем все 6-ть полей ComboBox данными содержащимися в XML файлах widthDic.XML, profileDic.XML, wheelSizeDic.XML:
             ширина профиля, высота и посадочный диаметр из XML файлов:
            */
            xDocWidthDic = XDocument.Load("D:\\Repos\\tire-calculator\\widthDic.xml");
            var orderedWidth = from widths in xDocWidthDic.Root.Elements("width")
                         select widths;
            foreach (XElement widthElemen in orderedWidth)
            {
                widthComboBox.Items.Add(widthElemen.Value);
                newWidthComboBox.Items.Add(widthElemen.Value);
            }

            xDocProfileDic = XDocument.Load("D:\\Repos\\tire-calculator\\profileDic.xml");
            var orderedProfile = from profiles in xDocProfileDic.Root.Elements("profile")
                               select profiles;
            foreach (XElement profileElement in orderedProfile)
            {
                profileComboBox.Items.Add(profileElement.Value);
                newProfileComboBox.Items.Add(profileElement.Value);
            }

            xWheelSizeDic = XDocument.Load("D:\\Repos\\tire-calculator\\wheelSizeDic.xml");
            var orderedWheelSize = from wheelSizes in xWheelSizeDic.Root.Elements("size")
                                   select wheelSizes;
            foreach (XElement wheelElement in orderedWheelSize)
            {
                wheelSizeComboBox.Items.Add(wheelElement.Value);
                newWheelSizeComboBox.Items.Add(wheelElement.Value);
            }

            xDocModelDic = XDocument.Load("D:\\Repos\\tire-calculator\\byModelDic.xml");
            IEnumerable<XElement> brand = from brands in xDocModelDic.Root.Elements("brand")
                                   select brands;

            // Разобрать класс XNodeDocumentOrderComparer сортировка по бренду
            foreach (XElement modelElement in brand)
            {
                //XAttribute nameAttribute = modelElement.Attribute("name");
                brandComboBox.Items.Add(modelElement.Attribute("name").Value);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); //авторазмер по ширине текста
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.Items[0].UseItemStyleForSubItems = false;
            listView1.Items[1].UseItemStyleForSubItems = false;
            listView1.Items[3].UseItemStyleForSubItems = false;
            listView1.Items[4].UseItemStyleForSubItems = false;
            listView1.Items[5].UseItemStyleForSubItems = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].UseItemStyleForSubItems = false;
            }
            //labelSpeed10.Tag = 10;
            //labelSpeed20.Tag = 20;
            //labelSpeed30.Tag = 30;
            //labelSpeed40.Tag = 40;
            //labelSpeed50.Tag = 50;
            //labelSpeed60.Tag = 60;
            //labelSpeed70.Tag = 70;
            //labelSpeed80.Tag = 80;
            //labelSpeed90.Tag = 90;
            //labelSpeed100.Tag = 100;
            //labelSpeed110.Tag = 110;
            //labelSpeed120.Tag = 120;
            //labelSpeed130.Tag = 130;
            //labelSpeed140.Tag = 140;
            //labelSpeed150.Tag = 150;
            //labelSpeed160.Tag = 160;
            //labelSpeed170.Tag = 170;
            //labelSpeed180.Tag = 180;
        }

        /// <summary>
        /// Список моделям
        /// </summary>
        XDocument xDocModelDic;

        /// <summary>
        /// Список ширины
        /// </summary>
        XDocument xDocWidthDic;

        /// <summary>
        /// Список высоты профиля
        /// </summary>
        XDocument xDocProfileDic;

        /// <summary> 
        /// Список посадочных размерностей
        /// </summary>
        XDocument xWheelSizeDic;

        TyreParams tyre1;

        TyreParams tyre2;

        Double percentChange;

        Speed Speedo;

        //Отработка события изменения значений ComboBox
        private void CmbBox_Change(object sender, EventArgs e)
        {
            tyre1 = new TyreParams(Convert.ToInt32(widthComboBox.SelectedItem),
                Convert.ToInt32(profileComboBox.SelectedItem), Convert.ToInt32(wheelSizeComboBox.SelectedItem));
            if (widthComboBox.SelectedIndex != -1 && profileComboBox.SelectedIndex != -1 && wheelSizeComboBox.SelectedIndex != -1)
            {
                listView1.Items[0].SubItems[1].Text = string.Concat(Convert.ToString(tyre1.TyreDiametr()), " мм");
                listView1.Items[1].SubItems[1].Text = string.Concat(widthComboBox.SelectedItem, " мм");
                listView1.Items[2].SubItems[1].Text = string.Concat(Convert.ToString(Math.Round(tyre1.CircleLenght())), " мм");
                listView1.Items[3].SubItems[1].Text = string.Concat(Convert.ToString(tyre1.SideWall()), " мм");
                listView1.Items[4].SubItems[1].Text = Convert.ToString(Math.Round(tyre1.RevsPerKm()));
            }
            tyre2 = new TyreParams(Convert.ToInt32(newWidthComboBox.SelectedItem),
                Convert.ToInt32(newProfileComboBox.SelectedItem), Convert.ToInt32(newWheelSizeComboBox.SelectedItem));
            if (newWidthComboBox.SelectedIndex != -1 && newProfileComboBox.SelectedIndex != -1 && newWheelSizeComboBox.SelectedIndex != -1)
            {
                listView1.Items[0].SubItems[2].Text = string.Concat(Convert.ToString(tyre2.TyreDiametr()), " мм");
                listView1.Items[1].SubItems[2].Text = string.Concat(newWidthComboBox.SelectedItem, " мм");
                listView1.Items[2].SubItems[2].Text = string.Concat(Convert.ToString(Math.Round(tyre2.CircleLenght())), " мм");
                listView1.Items[3].SubItems[2].Text = string.Concat(Convert.ToString(tyre2.SideWall()), " мм");
                listView1.Items[4].SubItems[2].Text = Convert.ToString(Math.Round(tyre2.RevsPerKm()));
            }
            percentChange = new Double();
            if (widthComboBox.SelectedIndex != -1 && profileComboBox.SelectedIndex != -1 && wheelSizeComboBox.SelectedIndex != -1 && newWidthComboBox.SelectedIndex != -1 && newProfileComboBox.SelectedIndex != -1 && newWheelSizeComboBox.SelectedIndex != -1)
            {
                if (tyre1.TyreDiametr() < tyre2.TyreDiametr())
                {
                    listView1.Items[0].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[0].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.TyreDiametr() - tyre1.TyreDiametr()));
                    listView1.Items[5].SubItems[1].ForeColor = Color.Green;
                    listView1.Items[5].SubItems[1].Text = Convert.ToString(Math.Round((tyre2.TyreDiametr() - tyre1.TyreDiametr())/ 2, 2));
                    percentChange = Math.Round(((tyre2.TyreDiametr() * 100) / tyre1.TyreDiametr()) - 100, 1);
                    titleLabelSpeed.Text = Convert.ToString(string.Concat("Изменение показаний спидометра:\n", percentChange, " %"));
                }
                else
                {
                    listView1.Items[0].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[0].SubItems[3].Text = Convert.ToString(Math.Round(tyre1.TyreDiametr() - tyre2.TyreDiametr()));
                    listView1.Items[5].SubItems[1].ForeColor = Color.Red;
                    listView1.Items[5].SubItems[1].Text = Convert.ToString(Math.Round((tyre1.TyreDiametr() - tyre2.TyreDiametr()) / 2, 2));
                    percentChange = Math.Round(((tyre2.TyreDiametr() * 100) / tyre1.TyreDiametr()) - 100, 1);
                    titleLabelSpeed.Text = Convert.ToString(string.Concat("Изменение показаний спидометра:\n", percentChange, " %"));
                }
                //listView1.Items[0].SubItems[3].Text = Convert.ToString(tyre1.TyreDiametr() - tyre2.TyreDiametr());
                if (tyre1.TyreWidth < tyre2.TyreWidth)
                {
                    listView1.Items[1].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[1].SubItems[3].Text = Convert.ToString(tyre2.TyreWidth - tyre1.TyreWidth);
                }
                else
                {
                    listView1.Items[1].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[1].SubItems[3].Text = Convert.ToString(tyre1.TyreWidth - tyre2.TyreWidth);
                }
                //listView1.Items[1].SubItems[3].Text = Convert.ToString(tyre1.TyreWidth - tyre2.TyreWidth);
                if (tyre1.CircleLenght() < tyre2.CircleLenght())
                {
                    listView1.Items[2].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[2].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.CircleLenght() - tyre1.CircleLenght()));
                }
                else
                {
                    listView1.Items[2].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[2].SubItems[3].Text = Convert.ToString(Math.Round(tyre1.CircleLenght() - tyre2.CircleLenght()));
                }
                //listView1.Items[2].SubItems[3].Text = Convert.ToString(Math.Round(tyre1.CircleLenght() - tyre2.CircleLenght()));
                if (tyre1.SideWall() < tyre2.SideWall())
                {
                    listView1.Items[3].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[3].SubItems[3].Text = Convert.ToString(tyre2.SideWall() - tyre1.SideWall());
                    //listView1.Items[5].SubItems[1].ForeColor = Color.Green;
                }
                else
                {
                    listView1.Items[3].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[3].SubItems[3].Text = Convert.ToString(tyre1.SideWall() - tyre2.SideWall());
                    //listView1.Items[5].SubItems[1].ForeColor = Color.Red;
                }
                //listView1.Items[3].SubItems[3].Text = Convert.ToString(tyre1.SideWall() - tyre2.SideWall());
                if (tyre1.RevsPerKm() < tyre2.RevsPerKm())
                {
                    listView1.Items[4].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[4].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.RevsPerKm() - tyre1.RevsPerKm()));
                }
                else
                {
                    listView1.Items[4].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[4].SubItems[3].Text = Convert.ToString(Math.Round(tyre1.RevsPerKm() - tyre2.RevsPerKm()));
                }
                //listView1.Items[4].SubItems[3].Text = Convert.ToString(Math.Round(tyre1.RevsPerKm() - tyre2.RevsPerKm()));

                /// <summary>
                /// Заполнение шкалы визуального "спидометра" значениями отклонений
                /// </summary>
                //labelSpeed10.Text = Convert.ToString(10 * ((percentChange + 100) / 100));
                //labelSpeed20.Text = Convert.ToString(20 * ((percentChange + 100) / 100));
                //labelSpeed30.Text = Convert.ToString(30 * ((percentChange + 100) / 100));
                //labelSpeed40.Text = Convert.ToString(40 * ((percentChange + 100) / 100));
                //labelSpeed50.Text = Convert.ToString(50 * ((percentChange + 100) / 100));
                //labelSpeed60.Text = Convert.ToString(60 * ((percentChange + 100) / 100));
                //labelSpeed70.Text = Convert.ToString(70 * ((percentChange + 100) / 100));
                //labelSpeed80.Text = Convert.ToString(80 * ((percentChange + 100) / 100));
                //labelSpeed90.Text = Convert.ToString(90 * ((percentChange + 100) / 100));
                //labelSpeed100.Text = Convert.ToString(100 * ((percentChange + 100) / 100));
                //labelSpeed110.Text = Convert.ToString(110 * ((percentChange + 100) / 100));
                //labelSpeed120.Text = Convert.ToString(120 * ((percentChange + 100) / 100));
                //labelSpeed130.Text = Convert.ToString(130 * ((percentChange + 100) / 100));
                //labelSpeed140.Text = Convert.ToString(140 * ((percentChange + 100) / 100));
                //labelSpeed150.Text = Convert.ToString(150 * ((percentChange + 100) / 100));
                //labelSpeed160.Text = Convert.ToString(160 * ((percentChange + 100) / 100));
                //labelSpeed170.Text = Convert.ToString(170 * ((percentChange + 100) / 100));
                //labelSpeed180.Text = Convert.ToString(180 * ((percentChange + 100) / 100));
                //Изменение показаний спидометра перенесено в отдельный класс!
                Speedo = new Speed(percentChange);
                string[] strDigs = Speedo.ScaleSpeedo(18, 10);
                labelSpeed10.Text = strDigs[0];
                labelSpeed20.Text = strDigs[1];
                labelSpeed30.Text = strDigs[2];
                labelSpeed40.Text = strDigs[3];
                labelSpeed50.Text = strDigs[4];
                labelSpeed60.Text = strDigs[5];
                labelSpeed70.Text = strDigs[6];
                labelSpeed80.Text = strDigs[7];
                labelSpeed90.Text = strDigs[8];
                labelSpeed100.Text = strDigs[9];
                labelSpeed110.Text = strDigs[10];
                labelSpeed120.Text = strDigs[11];
                labelSpeed130.Text = strDigs[12];
                labelSpeed140.Text = strDigs[13];
                labelSpeed150.Text = strDigs[14];
                labelSpeed160.Text = strDigs[15];
                labelSpeed170.Text = strDigs[16];
                labelSpeed180.Text = strDigs[17];
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawArc(new Pen(Brushes.Red), 10, 10, 150, 150, 90, 180);
            //e.Graphics.DrawArc(new Pen(Brushes.Red), 160, 10, 175, 175, 90, 180);
        }

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var brands = from xbrand in xDocModelDic.Root.Elements("brand")
                         where xbrand.Attribute("name").Value == brandComboBox.Text
                         select xbrand;
            modelComboBox.SelectedIndex = -1;
            modelComboBox.Items.Clear();
            yearComboBox.SelectedIndex = -1;
            yearComboBox.Items.Clear();
            engineComboBox.SelectedIndex = -1;
            engineComboBox.Items.Clear();
            foreach (XElement brand in brands)
            {
                foreach (XElement model in brand.Elements("model"))
                    modelComboBox.Items.Add(model.Attribute("nick").Value);
            }
        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var models = from xmodel in xDocModelDic.Root.Elements("brand").Elements("model")
                         where xmodel.Attribute("nick").Value == modelComboBox.Text
                         select xmodel;
            yearComboBox.SelectedIndex = -1;
            yearComboBox.Items.Clear();
            engineComboBox.SelectedIndex = -1;
            engineComboBox.Items.Clear();
            foreach (XElement model in models)
            {
                yearComboBox.Items.Add(model.Element("prod_year").Attribute("year").Value);
            }
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var years = from xYear in xDocModelDic.Root.Elements("brand").Elements("model").Elements("prod_year")
                        where xYear.Attribute("year").Value == yearComboBox.Text
                        select xYear;
            engineComboBox.SelectedIndex = -1;
            engineComboBox.Items.Clear();
            foreach (XElement engine in years)
            {
                engineComboBox.Items.Add(engine.Element("engine").Value);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var infobrand = from brand in xDocModelDic.Root.Elements("brand")
                                //from model in brand.Elements("model")
                                //from year in model.Elements("prod_year")
                            where brand.Attribute("name").Value == brandComboBox.Text
                            //where model.Attribute("nick").Value == modelComboBox.Text
                            //where year.Attribute("year").Value == yearComboBox.Text
                            select brand;

            var infomodel = from model in xDocModelDic.Root.Elements("brand").Elements("model")
                            where model.Attribute("nick").Value == modelComboBox.Text
                            select model;

            var infoyear = from year in xDocModelDic.Root.Elements("brand").Elements("model").Elements("prod_year")
                           where year.Attribute("year").Value == yearComboBox.Text
                           select year;

            List<string> values = new List<string>();

            foreach (XElement elem in infobrand)
            {
                values.Add(elem.Attribute("name").Value);
            }
            foreach (XElement elem in infomodel)
            {
                values.Add(elem.Attribute("nick").Value);
            }
            foreach (XElement elem in infoyear)
            {
                values.Add(elem.Attribute("year").Value);
                values.Add(elem.Element("engine").Value);
                foreach (XElement elem2 in elem.Elements("tyre_sizes"))
                {
                    values.Add(elem2.Value);
                }
            }
            listView2.Items.Add(new ListViewItem(values.ToArray()));
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            brandComboBox.SelectedIndex = -1;
            modelComboBox.SelectedIndex = -1;
            modelComboBox.Items.Clear();
            yearComboBox.SelectedIndex = -1;
            yearComboBox.Items.Clear();
            engineComboBox.SelectedIndex = -1;
            engineComboBox.Items.Clear();
            listView2.Items.Clear();
        }

        private void engineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brandComboBox.SelectedIndex != -1 && modelComboBox.SelectedIndex != -1 && yearComboBox.SelectedIndex != -1 && engineComboBox.SelectedIndex != -1)
            {
                addButton.Enabled = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        private void dictionarySetStripMenuItem_Click(object sender, EventArgs e)
        {
            DicEditorTree dicEditorTree = new DicEditorTree();
            dicEditorTree.Show();
        }
    }
}
