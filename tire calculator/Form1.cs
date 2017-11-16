using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tire_calculator.Class;

namespace tire_calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //Заполняем все 6-ть полей ComboBox данными: ширина профиля, высота и посадочный диаметр
            //В последеющем заполнять данные из XML файла.
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
            string[] lstelem = { "Диаметр", "Ширина", "Длина окружности", "Высота профиля", "Оборотов на км", "Изменение клиренса" };
            for (int i = 0; i < lstelem.Length; i++)
            {
                listView1.Items.Add(lstelem[i]);
            }
            string[] lstheaders = { "Показатель", "Старая размерность", "Новая размерность", "Разница" };
            for (int i = 0; i < lstheaders.Length; i++)
            {
                listView1.Columns.Add(lstheaders[i]);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); //авторазмер по ширине текста

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TyreParams tyre1 = new TyreParams(Convert.ToInt32(widthComboBox.SelectedItem), 
                Convert.ToInt32(profileComboBox.SelectedItem), Convert.ToInt32(wheelSizeComboBox.SelectedItem) );
            listView1.Items[0].SubItems.Add(string.Concat(Convert.ToString(tyre1.TyreDiametr()), " мм") );
            listView1.Items[1].SubItems.Add(string.Concat(widthComboBox.SelectedItem, " мм" ));
            listView1.Items[2].SubItems.Add(string.Concat(Convert.ToString(Math.Round(tyre1.CircleLenght() )), " мм") );
            listView1.Items[3].SubItems.Add(string.Concat(Convert.ToString(tyre1.SideWall() )," мм" ) );
            listView1.Items[4].SubItems.Add(Convert.ToString(Math.Round(tyre1.RevsPerKm()) ) );
            //!!!
            if (newWidthComboBox.SelectedIndex != -1 && newProfileComboBox.SelectedIndex != -1 && newWheelSizeComboBox.SelectedIndex != -1)
            {
                TyreParams tyre2 = new TyreParams(Convert.ToInt32(newWidthComboBox.SelectedItem),
                Convert.ToInt32(newProfileComboBox.SelectedItem), Convert.ToInt32(newWheelSizeComboBox.SelectedItem));
                listView1.Items[0].SubItems.Add(string.Concat(Convert.ToString(tyre2.TyreDiametr()), " мм"));
                listView1.Items[1].SubItems.Add(string.Concat(newWidthComboBox.SelectedItem, " мм"));
                listView1.Items[2].SubItems.Add(string.Concat(Convert.ToString(Math.Round(tyre2.CircleLenght())), " мм"));
                listView1.Items[3].SubItems.Add(string.Concat(Convert.ToString(tyre2.SideWall()), " мм"));
                listView1.Items[4].SubItems.Add(Convert.ToString(Math.Round(tyre2.RevsPerKm())));
            }
            
        }

        private void CmbBox_Change(object sender, EventArgs e)
        {
            ComboBox cmbbx = (ComboBox)sender;
            TyreParams tyre1 = new TyreParams(Convert.ToInt32(widthComboBox.SelectedItem),
                Convert.ToInt32(profileComboBox.SelectedItem), Convert.ToInt32(wheelSizeComboBox.SelectedItem));
            listView1.Items[0].SubItems.Add(string.Concat(Convert.ToString(tyre1.TyreDiametr()), " мм"));
            listView1.Items[1].SubItems.Add(string.Concat(widthComboBox.SelectedItem, " мм"));
            listView1.Items[2].SubItems.Add(string.Concat(Convert.ToString(Math.Round(tyre1.CircleLenght())), " мм"));
            listView1.Items[3].SubItems.Add(string.Concat(Convert.ToString(tyre1.SideWall()), " мм"));
            listView1.Items[4].SubItems.Add(Convert.ToString(Math.Round(tyre1.RevsPerKm())));
        }
    }
}
