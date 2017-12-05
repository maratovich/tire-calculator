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
            //xDocWidthDic = XDocument.Load("widthDic.xml");
            //var orderedWidth = from widths in xDocWidthDic.Root.Elements("width")
            //                   select widths;
            //foreach (XElement widthElemen in orderedWidth)
            //{
            //    widthComboBox.Items.Add(widthElemen.Value);
            //    newWidthComboBox.Items.Add(widthElemen.Value);
            //}

            //xDocProfileDic = XDocument.Load("profileDic.xml");
            //var orderedProfile = from profiles in xDocProfileDic.Root.Elements("profile")
            //                     select profiles;
            //foreach (XElement profileElement in orderedProfile)
            //{
            //    profileComboBox.Items.Add(profileElement.Value);
            //    newProfileComboBox.Items.Add(profileElement.Value);
            //}

            //xWheelSizeDic = XDocument.Load("wheelSizeDic.xml");
            //var orderedWheelSize = from wheelSizes in xWheelSizeDic.Root.Elements("size")
            //                       select wheelSizes;
            //foreach (XElement wheelElement in orderedWheelSize)
            //{
            //    wheelSizeComboBox.Items.Add(wheelElement.Value);
            //    newWheelSizeComboBox.Items.Add(wheelElement.Value);
            //}

            //xDocModelDic = XDocument.Load("byModelDic.xml");
            //IEnumerable<XElement> brand = from brands in xDocModelDic.Root.Elements("brand")
            //                              select brands;

            //foreach (XElement modelElement in brand)
            //{
            //    brandComboBox.Items.Add(modelElement.Attribute("name").Value);
            //}
            UpDateComboBoxes();
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

        Graphics g;

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
                pictureBox1.Refresh();
                //pictureBox1.Image = null;
                //pictureBox1.Invalidate();
                if (tyre1.TyreDiametr() < tyre2.TyreDiametr() && tyre1.TyreDiametr() != tyre2.TyreDiametr())
                {
                    listView1.Items[0].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[0].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.TyreDiametr() - tyre1.TyreDiametr()));
                    listView1.Items[5].SubItems[1].ForeColor = Color.Green;
                    listView1.Items[5].SubItems[1].Text = string.Concat(Convert.ToString(Math.Round((tyre2.TyreDiametr() - tyre1.TyreDiametr()) / 2, 2)), " мм");
                    percentChange = Math.Round(((tyre2.TyreDiametr() * 100) / tyre1.TyreDiametr()) - 100, 1);
                    titleLabelSpeed.Text = Convert.ToString(string.Concat("Изменение показаний спидометра:\n", percentChange, " %"));
                }
                if (tyre1.TyreDiametr() > tyre2.TyreDiametr() && tyre1.TyreDiametr() != tyre2.TyreDiametr())
                {
                    listView1.Items[0].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[0].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.TyreDiametr() - tyre1.TyreDiametr()));
                    listView1.Items[5].SubItems[1].ForeColor = Color.Red;
                    listView1.Items[5].SubItems[1].Text = string.Concat(Convert.ToString(Math.Round((tyre2.TyreDiametr() - tyre1.TyreDiametr()) / 2, 2)), " мм");
                    percentChange = Math.Round(((tyre2.TyreDiametr() * 100) / tyre1.TyreDiametr()) - 100, 1);
                    titleLabelSpeed.Text = Convert.ToString(string.Concat("Изменение показаний спидометра:\n", percentChange, " %"));
                }
                if (tyre1.TyreDiametr() == tyre2.TyreDiametr())
                {
                    listView1.Items[0].SubItems[3].ForeColor = Color.Gray;
                    listView1.Items[0].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.TyreDiametr() - tyre1.TyreDiametr()));
                    listView1.Items[5].SubItems[1].ForeColor = Color.Gray;
                    listView1.Items[5].SubItems[1].Text = Convert.ToString(Math.Round((tyre2.TyreDiametr() - tyre1.TyreDiametr()) / 2, 2));
                    percentChange = Math.Round(((tyre2.TyreDiametr() * 100) / tyre1.TyreDiametr()) - 100, 1);
                    titleLabelSpeed.Text = Convert.ToString(string.Concat("Изменение показаний спидометра:\n", percentChange, " %"));
                }

                if (tyre1.TyreWidth < tyre2.TyreWidth && tyre1.TyreWidth != tyre2.TyreWidth)
                {
                    listView1.Items[1].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[1].SubItems[3].Text = Convert.ToString(tyre2.TyreWidth - tyre1.TyreWidth);
                }
                if (tyre1.TyreWidth > tyre2.TyreWidth && tyre1.TyreWidth != tyre2.TyreWidth)
                {
                    listView1.Items[1].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[1].SubItems[3].Text = Convert.ToString(tyre2.TyreWidth - tyre1.TyreWidth);
                }

                if (tyre1.TyreWidth == tyre2.TyreWidth)
                {
                    listView1.Items[1].SubItems[3].ForeColor = Color.Gray;
                    listView1.Items[1].SubItems[3].Text = Convert.ToString(tyre2.TyreWidth - tyre1.TyreWidth);
                }

                if (tyre1.CircleLenght() < tyre2.CircleLenght() && tyre1.CircleLenght() != tyre2.CircleLenght())
                {
                    listView1.Items[2].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[2].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.CircleLenght() - tyre1.CircleLenght()));
                }

                if (tyre1.CircleLenght() > tyre2.CircleLenght() && tyre1.CircleLenght() != tyre2.CircleLenght())
                {
                    listView1.Items[2].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[2].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.CircleLenght() - tyre1.CircleLenght()));
                }
                if (tyre1.CircleLenght() == tyre2.CircleLenght())
                {
                    listView1.Items[2].SubItems[3].ForeColor = Color.Gray;
                    listView1.Items[2].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.CircleLenght() - tyre1.CircleLenght()));
                }

                if (tyre1.SideWall() < tyre2.SideWall() && tyre1.SideWall() != tyre2.SideWall())
                {
                    listView1.Items[3].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[3].SubItems[3].Text = Convert.ToString(tyre2.SideWall() - tyre1.SideWall());
                }
                if (tyre1.SideWall() > tyre2.SideWall() && tyre1.SideWall() != tyre2.SideWall())
                {
                    listView1.Items[3].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[3].SubItems[3].Text = Convert.ToString(tyre2.SideWall() - tyre1.SideWall());
                }
                if (tyre1.SideWall() == tyre2.SideWall())
                {
                    listView1.Items[3].SubItems[3].ForeColor = Color.Gray;
                    listView1.Items[3].SubItems[3].Text = Convert.ToString(tyre2.SideWall() - tyre1.SideWall());
                }

                if (tyre1.RevsPerKm() < tyre2.RevsPerKm() && tyre1.RevsPerKm() != tyre2.RevsPerKm())
                {
                    listView1.Items[4].SubItems[3].ForeColor = Color.Green;
                    listView1.Items[4].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.RevsPerKm() - tyre1.RevsPerKm()));
                }
                if (tyre1.RevsPerKm() > tyre2.RevsPerKm() && tyre1.RevsPerKm() != tyre2.RevsPerKm())
                {
                    listView1.Items[4].SubItems[3].ForeColor = Color.Red;
                    listView1.Items[4].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.RevsPerKm() - tyre1.RevsPerKm()));
                }
                if (tyre1.RevsPerKm() == tyre2.RevsPerKm())
                {
                    listView1.Items[4].SubItems[3].ForeColor = Color.Gray;
                    listView1.Items[4].SubItems[3].Text = Convert.ToString(Math.Round(tyre2.RevsPerKm() - tyre1.RevsPerKm()));
                }

                /// <summary>
                /// Заполнение шкалы визуального "спидометра" значениями отклонений
                /// </summary>

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
                int offset = 6;
                int halfX = pictureBox1.Size.Width / 2, halfY = pictureBox1.Size.Height / 2;
                double scale;
                int radiusOfTyre, radiusOfWheel;
                int radiusOfTyre2, radiusOfWheel2;
                g = pictureBox1.CreateGraphics();
                if (tyre1.TyreDiametr() >= 500 || tyre2.TyreDiametr() >= 500)
                {
                    scale = 2.7;
                    radiusOfTyre = (int)((tyre1.TyreDiametr() / 2) / scale);
                    radiusOfWheel = (int)(((tyre1.WheelSize * 25.4) / 2) / scale);
                    radiusOfTyre2 = (int)((tyre2.TyreDiametr() / 2) / scale);
                    radiusOfWheel2 = (int)(((tyre2.WheelSize * 25.4) / 2) / scale);
                    g.DrawArc(new Pen(Brushes.Red), (halfX - offset) - radiusOfTyre, (halfY) - radiusOfTyre, (Int32)(tyre1.TyreDiametr() / scale), (Int32)(tyre1.TyreDiametr() / scale), 90, 180);
                    g.DrawArc(new Pen(Brushes.Red), (halfX - offset) - radiusOfWheel, (halfY) - radiusOfWheel, (Int32)((tyre1.WheelSize * 25.4) / scale), (Int32)((tyre1.WheelSize * 25.4) / scale), 90, 180);
                    g.DrawArc(new Pen(Brushes.Black), (halfX + offset) - radiusOfTyre2, (halfY) - radiusOfTyre2, (Int32)(tyre2.TyreDiametr() / scale), (Int32)(tyre2.TyreDiametr() / scale), 270, 180);
                    g.DrawArc(new Pen(Brushes.Black), (halfX + offset) - radiusOfWheel2, (halfY) - radiusOfWheel2, (Int32)((tyre2.WheelSize * 25.4) / scale), (Int32)((tyre2.WheelSize * 25.4) / scale), 270, 180);
                }
                else
                {
                    scale = 2;
                    radiusOfTyre = (int)((tyre1.TyreDiametr() / 2) / scale);
                    radiusOfWheel = (int)(((tyre1.WheelSize * 25.4) / 2) / scale);
                    radiusOfTyre2 = (int)((tyre2.TyreDiametr() / 2) / scale);
                    radiusOfWheel2 = (int)(((tyre2.WheelSize * 25.4) / 2) / scale);
                    g.DrawArc(new Pen(Brushes.Red), (halfX - offset) - radiusOfTyre, (halfY) - radiusOfTyre, (Int32)(tyre1.TyreDiametr() / scale), (Int32)(tyre1.TyreDiametr() / scale), 90, 180);
                    g.DrawArc(new Pen(Brushes.Red), (halfX - offset) - radiusOfWheel, (halfY) - radiusOfWheel, (Int32)((tyre1.WheelSize * 25.4) / scale), (Int32)((tyre1.WheelSize * 25.4) / scale), 90, 180);
                    g.DrawArc(new Pen(Brushes.Black), (halfX + offset) - radiusOfTyre2, (halfY) - radiusOfTyre2, (Int32)(tyre2.TyreDiametr() / scale), (Int32)(tyre2.TyreDiametr() / scale), 270, 180);
                    g.DrawArc(new Pen(Brushes.Black), (halfX + offset) - radiusOfWheel2, (halfY) - radiusOfWheel2, (Int32)((tyre2.WheelSize * 25.4) / scale), (Int32)((tyre2.WheelSize * 25.4) / scale), 270, 180);
                }
            }
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
            //foreach (XElement elem in infobrand)
            //{
            //    //listView2.Items[0].SubItems[0].Text = elem.Attribute("name").Value;
            //    //listView2.Items[0].SubItems.Add(elem.Attribute("name").Value);
            //    listView2.Items.Add(elem.Attribute("name").Value);
            //    //textBox1.AppendText(elem.Element("model").Attribute("nick").Value + " ");
            //    //textBox1.AppendText(elem.Element("model").Element("prod_year").Attribute("year").Value + " ");
            //    //textBox1.AppendText(elem.Element("model").Element("prod_year").Element("engine").Value + " ");
            //    //foreach (var elem2 in elem.Element("model").Element("prod_year")) textBox1.AppendText(elem.Element("model").Element("prod_year").Element("tyre_sizes").Value + " ");
            //}
            //foreach (XElement elem in infomodel)
            //{
            //    //listView2.Items[0].SubItems[1].Text = elem.Attribute("nick").Value;
            //    listView2.Items[0].SubItems.Add(elem.Attribute("nick").Value);
            //    //listView2.ite
            //    //listView2.Items.Add(elem.Attribute("nick").Value);
            //}
            //foreach (XElement elem in infoyear)
            //{
            //    //listView2.Items[0].SubItems[2].Text = elem.Attribute("year").Value;
            //    //listView2.Items[0].SubItems[3].Text = elem.Element("engine").Value;
            //    listView2.Items[0].SubItems.Add(elem.Attribute("year").Value);
            //    listView2.Items[0].SubItems.Add(elem.Attribute("year").Value);
            //    //listView2.Items.Add(elem.Attribute("year").Value);
            //    //listView2.Items.Add(elem.Element("engine").Value);
            //    //listView2.Items.Add(elem.Element("tyre_sizes").Value);
            //    //listView2.Items[0].SubItems[4].Text = elem.Element("tyre_sizes").Value;
            //    foreach (XElement elem2 in elem.Elements("tyre_sizes"))
            //    {
            //        //listView2.Items.Add(elem2.Value);
            //        listView2.Items[0].SubItems.Add(elem2.Value);
            //    }
            //}
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            brandComboBox.SelectedIndex = -1;
            brandComboBox.Items.Clear();
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

        private void exitStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //brandComboBox.SelectedIndex = -1;
            brandComboBox.Items.Clear();
            //modelComboBox.SelectedIndex = -1;
            modelComboBox.Items.Clear();
            //yearComboBox.SelectedIndex = -1;
            yearComboBox.Items.Clear();
            //engineComboBox.SelectedIndex = -1;
            engineComboBox.Items.Clear();
            widthComboBox.Items.Clear();
            profileComboBox.Items.Clear();
            wheelSizeComboBox.Items.Clear();
            newWidthComboBox.Items.Clear();
            newProfileComboBox.Items.Clear();
            newWheelSizeComboBox.Items.Clear();
            UpDateComboBoxes();
        }

        private void UpDateComboBoxes()
        {
            xDocWidthDic = XDocument.Load("widthDic.xml");
            var orderedWidth = from widths in xDocWidthDic.Root.Elements("width")
                               select widths;
            foreach (XElement widthElemen in orderedWidth)
            {
                widthComboBox.Items.Add(widthElemen.Value);
                newWidthComboBox.Items.Add(widthElemen.Value);
            }

            xDocProfileDic = XDocument.Load("profileDic.xml");
            var orderedProfile = from profiles in xDocProfileDic.Root.Elements("profile")
                                 select profiles;
            foreach (XElement profileElement in orderedProfile)
            {
                profileComboBox.Items.Add(profileElement.Value);
                newProfileComboBox.Items.Add(profileElement.Value);
            }

            xWheelSizeDic = XDocument.Load("wheelSizeDic.xml");
            var orderedWheelSize = from wheelSizes in xWheelSizeDic.Root.Elements("size")
                                   select wheelSizes;
            foreach (XElement wheelElement in orderedWheelSize)
            {
                wheelSizeComboBox.Items.Add(wheelElement.Value);
                newWheelSizeComboBox.Items.Add(wheelElement.Value);
            }

            xDocModelDic = XDocument.Load("byModelDic.xml");
            IEnumerable<XElement> brand = from brands in xDocModelDic.Root.Elements("brand")
                                          select brands;

            foreach (XElement modelElement in brand)
            {
                brandComboBox.Items.Add(modelElement.Attribute("name").Value);
            }
        }
    }
}
