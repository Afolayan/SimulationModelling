using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.RNG.GFSR{
    public class Gfsr : Random{
        private int q, r, delay;
        private int wordLength;
        private long maxValue;
        private string _seed = "11111";
        private int currentI = 1;
        private long currentValue = 0;
        private StringBuilder logger = new StringBuilder();


        public Gfsr()
            : base(){
            q = 5;
            wordLength = 4;
            maxValue = (long) System.Math.Pow(2, q);
            r = 3;
            delay = 6;
        }

        public Gfsr(string seed)
            : base(Convert.ToInt64(seed)){
            this._seed = seed;
            q = 5;
            wordLength = 4;
            maxValue = (long) System.Math.Pow(2, q);
            r = 3;
            delay = 6;
        }

        public Gfsr(string seed, int q, int r, int l)
            : base(Convert.ToInt64(seed)) {
            this._seed = seed;
            this.q = q;

            this.r = r;
            maxValue = (long) System.Math.Pow(2.0, q);

            this.wordLength = l;
            delay = 6;


            if ((l % 2) != 1){
                ;
            }
        }

        public Gfsr(string seed, int q, int r, int l, int delay)
            : base() {
            //: base(Convert.ToInt64(seed)) {
            //: base(long.Parse(seed)){
            this.q = q;
            this.r = r;
            wordLength = l;
            this.delay = delay;
            this._seed = seed;
            maxValue = (long) System.Math.Pow(2.0, q);
            if (seed.Length != q){
                throw new ArgumentException("Length of seed not equal to the value of q supplied.");
            }

            //d must not be less than q
        }

        private string tempSeed = "";

        public override long Next(){
            Console.WriteLine("index->"+currentI);
            var seedLength = _seed.Length;

            //preempt the next set of bits
            var nextSetOfBits = maxValue;
            tempSeed = _seed;
            for (var i = seedLength + 1; i < nextSetOfBits; i++){
                Console.WriteLine("i->" + i);
                tempSeed += GetNextBit(i, tempSeed);
                Console.WriteLine("tempSeed->"+tempSeed);

            }
           
            var bitString = "";
            var seedCharArray = tempSeed.ToCharArray();
            var seedCharArrayLength = seedCharArray.Length;
            for (var bitIndex = wordLength; bitIndex > 0; bitIndex--){
                var jumper = delay * (wordLength - bitIndex);
                var index = currentI + jumper - 1;
                if (jumper != 0){
                    //this is not the left most bit
                    index = index - 1;
                }
                bitString += seedCharArray[index % seedCharArrayLength];
            }
            currentI++;
            currentValue = GetBinaryIntegerEqui(bitString);

            return currentValue;
        }

        private int GetNextBit(int currentIndex, string seed){
            var rthPosition = currentIndex - r - 1; //array position starts from zero
            var qthPosition = currentIndex - q - 1;
            var seedCharArray = seed.ToCharArray();
            var operand1 = seedCharArray[rthPosition];
            var operand2 = seedCharArray[qthPosition];

            var result = operand1 ^ operand2;
            return result;
        }

      
        public override double Sample() {
            return currentValue / System.Math.Pow(2, wordLength);
        }

        public string getLogs(){
            return logger.ToString();
        }

        public static int GetBinaryIntegerEqui(string binaryString){
            return Convert.ToInt32(binaryString, 2);
        }


        public override void NextBytes(byte[] b){
            throw new NotImplementedException();
        }
    }
}