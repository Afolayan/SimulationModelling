using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Math.RNG.GFSR;
using Math.RNG.LCG;

namespace Tests{
    public partial class frmMain : Form{
        public frmMain(){
            InitializeComponent();

            //"111100011011101010000100101100111110001"
        }

        private void test_LCG_randomToolStripMenuItem_Click(object sender, EventArgs e){
            Math.RNG.LCG.Random m = new Math.RNG.LCG.Random();
            Math.RNG.LCG.Random n = new Math.RNG.LCG.Random(678524359383);

            string log = "";

            for (int i = 0; i < 64; i++){
                log += "\nrand[" + i.ToString("00") + "] m: " + m.Next(16, 22).ToString("00");
                //log += " n: " + n.NextDouble().ToString("e4");
            }

            richTextBox.Text = log;
        }

        private void test_LCG_uRandomToolStripMenuItem_Click(object sender, EventArgs e){
            URandom ux = new Math.RNG.LCG.URandom();
            ux.SetParameters(Math.RNG.Enums.Distribution.Uniform_Cont, 0.0, 100.00, null, null, null, null, null, null,
                null, null, null, null, null, null);

            // using a prime modulus multiplicative LCG (see pg 401) as ubasic rng
            long m = (long) System.Math.Pow(2.0, 31.0);
            m -= 1;
            long a = 630360016;
            URandom uy = new Math.RNG.LCG.URandom(new Math.RNG.LCG.Random(678524359383, a, m, 0));
            uy.SetParameters(Math.RNG.Enums.Distribution.Uniform_Cont, 0.0, 100.00, null, null, null, null, null, null,
                null, null, null, null, null, null);

            string log = "";

            for (int i = 0; i < 64; i++){
                log += "\nrand[" + i.ToString("00") + "] m: " + ((double) ux.Next()).ToString("e8");
                log += " n: " + ((double) uy.Next()).ToString("e8");
            }

            richTextBox.Text = log;
        }

        private void generalizedShiftFeedbackRegisterToolStripMenuItem_Click(object sender, EventArgs e){
            string logOutPut = "";
            //Gfsr1 gfsr = new Gfsr1("11111", 5, 3, 4, 6);
            //Gfsr1 gfsr = new Gfsr1("11111111", 8, 5, 7, 7);
            var gfsr = new Gfsr1("11110100001001000000", 20, 9, 8, 8);
            int[] distribution = new int[100];
            int i = 0;
            //while (i < 100000){
            while (i < 1000000){
                var intValue = gfsr.Next();
                Console.WriteLine("Value->" +intValue);
                var currentDouble = gfsr.NextDouble() * 100;
                var possibleIndex = (int) System.Math.Ceiling(currentDouble);
                logOutPut += currentDouble + " == " + possibleIndex + "\n";
                //Console.WriteLine(@"{0} == {1}->", currentDouble, possibleIndex);
                distribution[possibleIndex]++;
                i++;

            }

            var distributionLogger = new StringBuilder("");
            var sum = 0.0;
            for (var index = 0; index < distribution.Length; index++){
                var distributionString = index + ", " + distribution[index];
                distributionLogger.Append(distributionString);
                distributionLogger.Append("\n");

                var dist = distribution[index];
                if (dist > 0){
                    sum += dist;
                }
                
                Console.WriteLine(@"{0}==={1}", index, dist);
            }

            File.WriteAllText("distribution.csv", distributionLogger.ToString());
            //Console.WriteLine(@"sum==={0}", sum);
            
            richTextBox.Text = logOutPut;
        }
    }
}