using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitSystem.Unit {
    public class Unit {
        /*
         * openfoam like dimensions
         * dimensions [ n, n, n, n, n, n, n ] n
         * 
         * No.      Property            SI unit     
         * -----------------------------------------
         * 1        Mass                kilogram (kg)
         * 2        Length              metre (m)
         * 3        Time                second (s)
         * 4        Temperature         Kelvin (K)
         * 5        Quantity            mole (mol)
         * 6        Current             ampere (A)
         * 7        Luminous intensity  candela(cd)
         */
        protected int[] _dimensions;
        protected double scale;
        public string name { get; set; }
        public int[] dimensions { get => _dimensions; }

        public Unit(string name, IEnumerable<int> dimens, double s = 1) {
            this.name = name;
            this._dimensions = dimens.ToArray();
            scale = s;
        }

        public override string ToString() {
            return this.name;
        }

        public bool CanConvertTo(Unit unit) {
            return Enumerable.SequenceEqual(dimensions, unit.dimensions);
        }

        public double ScaleTo(Unit unit) {
            if (unit.CanConvertTo(this))
                return this.scale / unit.scale;
            else
                throw new InvalidOperationException("Cannot convert between incompatible units.");
        }

        public double ScaleFrom(Unit unit) {
            return unit.ScaleTo(this);
        }
    }
}
