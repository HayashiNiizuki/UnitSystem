using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UnitSystem.Unit {
    class UnitSystem {
        static protected List<Unit> FMUnits = new List<Unit>();
        private static readonly UnitSystem _instance = new UnitSystem();
        
        private UnitSystem() {
            LoadFMUnits("fm-unit-system.xml");
        }

        public static UnitSystem Instance {
            get {
                return _instance;
            }
        }

        public void LoadFMUnits(string Xml) {
            XmlDocument doc = new XmlDocument();
            doc.Load(Xml);

            XmlNode root = doc.DocumentElement;
            foreach (XmlNode group in root.ChildNodes) {
                List<int> dimensions = group.Attributes["dimension"].Value.Split(',').Select(s => int.Parse(s)).ToList();
                foreach (XmlNode unit in group.ChildNodes) {
                    double scale = Double.Parse(unit.Attributes["scale"].Value);
                    string name = unit.Attributes["name"].Value;
                    FMUnits.Add(new Unit(name, dimensions, scale));
                }
            }
        }

        public List<Unit> unitsCanConvert(Unit unit) { 
            return FMUnits.FindAll(u => u.CanConvertTo(unit));
        }

        public Unit Unit(string name) { 
            return FMUnits.Find(u => u.name == name);   
        }
    }
}
