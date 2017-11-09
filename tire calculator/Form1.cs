using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
