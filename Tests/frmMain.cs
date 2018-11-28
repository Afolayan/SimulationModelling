using System;
using System.Collections;
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

namespace Tests
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            var log = "";

            //log += DoGfsr();
            richTextBox.Text = log;
        }

        private void test_LCG_mixedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Basic m = new Basic();
            Basic n = new Basic(678524359383);

            string log = "";

            for (int i = 0; i < 64; i++)
            {
                log += "\nrand[" + i.ToString("00") + "] m: " + m.Next().ToString("00");
                log += " n: " + n.NextDouble().ToString("e4");
            }

            richTextBox.Text = log;
        }

      

        private void richTextBox_TextChanged(object sender, EventArgs e) {

        }

        private void generalizedFeedbackShiftRegisterToolStripMenuItem_Click(object sender, EventArgs e) {
            string log = "";

            log += DoGfsr();

            LSFR a = new LSFR(8, "01101000010");
            

            int i = 0;
            for (i = 0; i < 31; i++){
                string xx = a.Registry;
                a.Shift();
                log += " " + xx + "\n";
            }
            
            richTextBox.Text = log;
        }

        private static string DoGfsr(){
            GeneralizedFeedbackShiftRegister register = new GeneralizedFeedbackShiftRegister("11111111", 8, 3, 4, 6);

            string log = "";
            var generateWi = register.GenerateWi(20048);
            var generateUis = register.generateUis(generateWi);
            log += "Binary (Yi)\t==>\tDecimal Value\tUi\n";
            log += "==================================================\n";
            for (var index = 0; index < generateWi.Length; index++){
                var wi = generateWi[index];
                log += wi + "\t==>\t"
                          + GeneralizedFeedbackShiftRegister.GetBinaryIntegerEqui(wi)
                          + "\t"+ generateUis[index]
                    ;
                log += "\n";
            }

            return log;
        }
    }
}