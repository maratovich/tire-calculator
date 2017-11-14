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
            string[] lstheaders = { "Диаметр", "Ширина", "Длина окружности", "Высота профиля", "Оборотов на км", "Изменение клиренса" };
            for (int i = 0; i < lstheaders.Length; i++)
            {
                listView1.Items.Add(lstheaders[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TyreParams tyre1 = new TyreParams(Convert.ToInt32(widthComboBox.SelectedItem), 
                Convert.ToInt32(profileComboBox.SelectedItem), Convert.ToInt32(wheelSizeComboBox.SelectedItem));
            listView1.Items[0].SubItems.Add(Convert.ToString(tyre1.TyreDiametr() ) );
            listView1.Items[1].SubItems.Add(string.Concat(widthComboBox.SelectedItem, " мм" ));
            listView1.Items[2].SubItems.Add(Convert.ToString(tyre1.CircleLenght() ) );
            listView1.Items[3].SubItems.Add(Convert.ToString(tyre1.SideWall() ) );
            listView1.Items[4].SubItems.Add(Convert.ToString(tyre1.RevsPerKm() ) );
            
        }
    }
}
