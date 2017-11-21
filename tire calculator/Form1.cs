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
using System.Xml;
using System.Xml.Linq;

namespace tire_calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            /*Заполняем все 6-ть полей ComboBox данными содержащимися в XML файлах widthDic.XML, profileDic.XML, wheelSizeDic.XML:
             ширина профиля, высота и посадочный диаметр из XML файлов:
            */
            XmlDocument xDocModelDic = new XmlDocument();
            xDocModelDic.Load("D:\\Downloads\\C#\\tyre calculator\\byModelDic.xml");
            XmlElement xRootModel = xDocModelDic.DocumentElement; // получим корневой элемент
            
            XmlDocument xDocWidthDic = new XmlDocument();
            xDocWidthDic.Load("D:\\Downloads\\C#\\tyre calculator\\widthDic.xml");
            XmlElement xRootWidth = xDocWidthDic.DocumentElement;
            foreach (XmlNode xnode in xRootWidth)
            {
                    widthComboBox.Items.Add(xnode.InnerText);
                    newWidthComboBox.Items.Add(xnode.InnerText);
            }

            XmlDocument xDocProfileDic = new XmlDocument();
            xDocProfileDic.Load("D:\\Downloads\\C#\\tyre calculator\\profileDic.xml");
            XmlElement xRootProfile = xDocProfileDic.DocumentElement;
            foreach (XmlNode xnode in xRootProfile)
            {
                    profileComboBox.Items.Add(xnode.InnerText);
                    newProfileComboBox.Items.Add(xnode.InnerText);
            }

            //XmlDocument xWheelSizeDic = new XmlDocument();
            //xWheelSizeDic.Load("D:\\Downloads\\C#\\tyre calculator\\wheelSizeDic.xml");
            //XmlElement xRootWheelSize = xWheelSizeDic.DocumentElement;
            //foreach (XmlNode xnode in xRootWheelSize)
            //{
            //        wheelSizeComboBox.Items.Add(xnode.InnerText);
            //        newWheelSizeComboBox.Items.Add(xnode.InnerText);
            //}
            XDocument xWheelSizeDic = XDocument.Load("D:\\Downloads\\C#\\tyre calculator\\wheelSizeDic.xml");
            foreach (XElement wheelElement in xWheelSizeDic.Element("wheelSizes").Elements("size"))
            {
                wheelSizeComboBox.Items.Add(wheelElement.Value);
                newWheelSizeComboBox.Items.Add(wheelElement.Value);
            }

            textBox1.Text = Application.StartupPath;
                /*

                for (int i = 115; i < 365; i += 10)
                {
                    widthComboBox.Items.Add(i);
                    newWidthComboBox.Items.Add(i);
                }
                for (int i = 25; i < 95; i += 5)
                {
                    profileComboBox.Items.Add(i);
                    newProfileComboBox.Items.Add(i);
                }
                for (int i = 10; i < 24; i++)
                {
                    wheelSizeComboBox.Items.Add(i);
                    newWheelSizeComboBox.Items.Add(i);
                }
                */
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); //авторазмер по ширине текста
        }
        //Отработка события изменения значения ComboBox
        private void CmbBox_Change(object sender, EventArgs e)
        {
            TyreParams tyre1 = new TyreParams(Convert.ToInt32(widthComboBox.SelectedItem),
                Convert.ToInt32(profileComboBox.SelectedItem), Convert.ToInt32(wheelSizeComboBox.SelectedItem));
            if (widthComboBox.SelectedIndex != -1 && profileComboBox.SelectedIndex != -1 && wheelSizeComboBox.SelectedIndex != -1)
            {
                listView1.Items[0].SubItems[1].Text = string.Concat(Convert.ToString(tyre1.TyreDiametr()), " мм");
                listView1.Items[1].SubItems[1].Text = string.Concat(widthComboBox.SelectedItem, " мм");
                listView1.Items[2].SubItems[1].Text = string.Concat(Convert.ToString(Math.Round(tyre1.CircleLenght())), " мм");
                listView1.Items[3].SubItems[1].Text = string.Concat(Convert.ToString(tyre1.SideWall()), " мм");
                listView1.Items[4].SubItems[1].Text = Convert.ToString(Math.Round(tyre1.RevsPerKm()));
            }
            TyreParams tyre2 = new TyreParams(Convert.ToInt32(newWidthComboBox.SelectedItem),
                Convert.ToInt32(newProfileComboBox.SelectedItem), Convert.ToInt32(newWheelSizeComboBox.SelectedItem));
            if (newWidthComboBox.SelectedIndex != -1 && newProfileComboBox.SelectedIndex != -1 && newWheelSizeComboBox.SelectedIndex != -1)
            {
                listView1.Items[0].SubItems[2].Text = string.Concat(Convert.ToString(tyre2.TyreDiametr()), " мм");
                listView1.Items[1].SubItems[2].Text = string.Concat(newWidthComboBox.SelectedItem, " мм");
                listView1.Items[2].SubItems[2].Text = string.Concat(Convert.ToString(Math.Round(tyre2.CircleLenght())), " мм");
                listView1.Items[3].SubItems[2].Text = string.Concat(Convert.ToString(tyre2.SideWall()), " мм");
                listView1.Items[4].SubItems[2].Text = Convert.ToString(Math.Round(tyre2.RevsPerKm()));
            }
            if (widthComboBox.SelectedIndex != -1 && profileComboBox.SelectedIndex != -1 && wheelSizeComboBox.SelectedIndex != -1 && newWidthComboBox.SelectedIndex != -1 && newProfileComboBox.SelectedIndex != -1 && newWheelSizeComboBox.SelectedIndex != -1)
            {
                listView1.Items[0].SubItems[3].Text = Convert.ToString(tyre1.TyreDiametr() - tyre2.TyreDiametr());
                listView1.Items[1].SubItems[3].Text = Convert.ToString(tyre1.TyreWidth - tyre2.TyreWidth);
                listView1.Items[2].SubItems[3].Text = Convert.ToString(Math.Round(tyre1.CircleLenght() - tyre2.CircleLenght()));
                listView1.Items[3].SubItems[3].Text = Convert.ToString(tyre1.SideWall() - tyre2.SideWall());
                listView1.Items[4].SubItems[3].Text = Convert.ToString(Math.Round(tyre1.RevsPerKm() - tyre2.RevsPerKm()));
                listView1.Items[5].SubItems[1].Text = Convert.ToString(tyre2.SideWall() - tyre1.SideWall());
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawArc(new Pen(Brushes.Red), 10, 10, 150, 150, 90, 180);
            //e.Graphics.DrawArc(new Pen(Brushes.Red), 160, 10, 175, 175, 90, 180);

        }
    }
}
