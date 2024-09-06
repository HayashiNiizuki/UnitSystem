using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitSystem.Unit {
    class DoubleWithUnit {
        public DoubleWithUnit(double? value, Unit unit) {
            this.value = value;
            this.unit = unit;
        }
        public double? value {  get; set; }
        public Unit unit { get; set; }

        public override string ToString() {
            return string.Format("{0} {1}", value, unit);
        }

        public void ConvertTo(Unit unit) {
            if (this.unit.CanConvertTo(unit)) {
                this.value *= this.unit.ScaleTo(unit);
            }
        }
    }
}
