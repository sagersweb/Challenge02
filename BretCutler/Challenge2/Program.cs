using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2 {
    class Program {
        static void Main(string[] args) {

            if (args == null || args.Count() == 0) {
                CurrencyCount("145.85");
            } else {
                CurrencyCount(args[0]);
            }
        }

        private static void CurrencyCount(string amount) {

            int value = 0;
            double originalValue = 0.0;
            int units = 0;

            List<OutputModel> outputList = new List<OutputModel>();
            List<CurrencyModel> cmList = GetCurrencyModels().OrderBy(c => c.Units).ToList();
            CurrencyModel lastCurrencyModel = null;

            try {

                originalValue = double.Parse(amount);

                value = (int)(originalValue * 100);

                while (value > 0) {

                    foreach (CurrencyModel cm in cmList) {
                        if (cm.Units > value) {
                            break;
                        }
                        lastCurrencyModel = cm;
                    }

                    units = value / lastCurrencyModel.Units;

                    outputList.Add(new OutputModel { Units = units, CurrencyModel = lastCurrencyModel });

                    value = value - (units * lastCurrencyModel.Units);

                }

                foreach (OutputModel om in outputList) {
                    Console.WriteLine(om.Output());
                    System.Diagnostics.Debug.WriteLine(om.Output());
                }

            } catch {
                Console.WriteLine(string.Format("The value entered '{0}' is not a valid number.", amount));
            }            
        }

        private static List<CurrencyModel> GetCurrencyModels() {

            List<CurrencyModel> cmList = new List<CurrencyModel>();

            cmList.Add(new CurrencyModel { RealWorldValue = .01, DescriptionSingle= "Penny", DescriptionMultiple = "Pennies" });
            cmList.Add(new CurrencyModel { RealWorldValue = .05, DescriptionSingle = "Nickel" });
            cmList.Add(new CurrencyModel { RealWorldValue = .10, DescriptionSingle = "Dime" });
            cmList.Add(new CurrencyModel { RealWorldValue = .25, DescriptionSingle = "Quarter" });
            cmList.Add(new CurrencyModel { RealWorldValue = .50, DescriptionSingle = "Fifty Cent Piece" });
            cmList.Add(new CurrencyModel { RealWorldValue = 1.00, DescriptionSingle = "One Dollar Bill" });
            cmList.Add(new CurrencyModel { RealWorldValue = 2.00, DescriptionSingle = "Two Dollar Bill" });
            cmList.Add(new CurrencyModel { RealWorldValue = 5.00, DescriptionSingle = "Five Dollar Bill" });
            cmList.Add(new CurrencyModel { RealWorldValue = 10.00, DescriptionSingle = "Ten Dollar Bill" });
            cmList.Add(new CurrencyModel { RealWorldValue = 20.00, DescriptionSingle = "Twenty Dollar Bill" });
            cmList.Add(new CurrencyModel { RealWorldValue = 50.00, DescriptionSingle = "Fifty Dollar Bill" });
            cmList.Add(new CurrencyModel { RealWorldValue = 100.00, DescriptionSingle = "One Hundred Dollar Bill" });

            return cmList;
        }
    }

    public class CurrencyModel {

        private int _units = 0;
        public int Units {
            get { return _units; }
        }

        private double _realWorldValue = 0;
        public double RealWorldValue {
            get {
                return _realWorldValue;
            }
            set {
                _realWorldValue = value;
                _units = (int)(value * 100.0);
            }
        }

        public string DescriptionSingle { get; set; }

        private string _descriptionMultiple = string.Empty;
        public string DescriptionMultiple {
            get { return (string.IsNullOrEmpty(_descriptionMultiple)) ? string.Format("{0}s", DescriptionSingle) : _descriptionMultiple; }
            set { _descriptionMultiple = value; }
        }
    }

    public class OutputModel {
        
        public int Units { get; set; }

        public CurrencyModel CurrencyModel { get; set; }

        public string Output() {

            return string.Format("{0} - {1}", Units, (Units == 1) ? CurrencyModel.DescriptionSingle : CurrencyModel.DescriptionMultiple);

        }
    }
}
