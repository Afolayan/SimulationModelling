using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            //Console.WriteLine("seed-> " + Int64.Parse("111111111111111001111111111111"));
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
            //Gfsr gfsr = new Gfsr("11111", 5, 3, 4, 6);
            var gfsr = new Gfsr("11111111111111111111111111111110", 32, 3, 31, 10);
            int[] distribution = new int[100];
            int i = 0;
            while (i < 100){
                Console.WriteLine("Value->" + gfsr.Next());
                var currentDouble = gfsr.NextDouble() * 100;
                int possibleIndex = (int) System.Math.Ceiling(currentDouble);
                logOutPut += currentDouble + " == " + possibleIndex + "\n";
                Console.WriteLine(@"{0} == {1}->", currentDouble, possibleIndex);
                distribution[possibleIndex]++;
                i++;
            }

            var distributionLogger = new StringBuilder("");
            var sum = 0.0;
            for (var index = 0; index < distribution.Length; index++){
                var distributionString = (index - 1) + ", " + distribution[index];
                distributionLogger.Append(distributionString);
                distributionLogger.Append("\n");

                var dist = distribution[index];
                if (dist > 0){
                    sum += dist;
                }
                
                Console.WriteLine(@"{0}==={1}", index, dist);
            }

            Console.WriteLine(@"sum==={0}", sum);
            logOutPut += gfsr.getLogs();
            richTextBox.Text = logOutPut;
        }
    }
}