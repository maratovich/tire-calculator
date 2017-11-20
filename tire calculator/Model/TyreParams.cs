using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tyre_calculator.Model
{
    class TyreParams
    {
        int _tyreWidth;           // Ширина профиля шины
        int _tyreProfile;         // Выстора профиля шины
        int _wheelSize;           // Посадочный диаметр шины (диаметр диска)
        const double inch = 25.4; //Кол-во мм в одном дюйме
        
        internal int TyreWidth
        {
            get { return _tyreWidth; }
        }

        internal int TyreProfile
        {
            get { return _tyreProfile; }
        }

        internal int WheelSize
        {
            get { return _wheelSize; }
        }

        internal TyreParams (int tyreWidth, int tyreProfile, int wheelSize)
        {
            this._tyreWidth = tyreWidth;
            this._tyreProfile = tyreProfile;
            this._wheelSize = wheelSize;
        }
        // Вывод инофрмации о текущей размерности колеса
        internal string GetInfo()
        {
            return String.Concat(_tyreWidth, "/", _tyreProfile, " ", _wheelSize);
        }
        // Метод расчета высоты профиля шины 
        internal double SideWall()
        {
            return (_tyreWidth * _tyreProfile) / 100;
        }
        // Метод расчета внешнего диаметра колеса
        internal double TyreDiametr()
        {
            return SideWall() * 2 + (_wheelSize * inch);
        }
        // Метод расчета длинны окружности колеса
        internal double CircleLenght()
        {
            return 2 * Math.PI * (TyreDiametr() / 2);
        }
        // Метод расчета количество оборот колеса на 1 километр
        internal double RevsPerKm()
        {
            return 1000000 / CircleLenght();
        }
    }

    class ComboBoxFilling
    {
        string _xmlPath;
        static XmlDocument _xDoc = new XmlDocument();
        XmlElement xRoot = _xDoc.DocumentElement;

        internal ComboBoxFilling(string xmlPath)
        {
            this._xmlPath = xmlPath;
        }

        internal string[] Elementi()
        {
           return ;
        }
    }
}
