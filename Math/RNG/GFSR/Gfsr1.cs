using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.RNG.GFSR{
    public class Gfsr1 : Random{
        private int q, r, delay;
        private int wordLength;
        private long maxValue;
        private string _seed = "11111";
        private int currentI = 1;
        private long currentValue = 0;
        private StringBuilder logger = new StringBuilder();
        private List<MyClass> seedChar = new List<MyClass>();


        public Gfsr1()
            : base(){
            q = 5;
            wordLength = 4;
            maxValue = (long) System.Math.Pow(2, q);
            r = 3;
            delay = 6;
            var charArray = _seed.ToCharArray();
            for (var i = 0; i < _seed.Length; i++) {
                MyClass item = new MyClass(i, charArray[i]);
                seedChar.Add(item);
            }
        }

        public Gfsr1(string seed)
            : base(Convert.ToInt64(seed)){
            this._seed = seed;
            q = 5;
            wordLength = 4;
            maxValue = (long) System.Math.Pow(2, q);
            r = 3;
            delay = 6;
            var charArray = seed.ToCharArray();
            for (var i = 0; i < seed.Length; i++) {
                MyClass item = new MyClass(i, charArray[i]);
                seedChar.Add(item);
            }
        }

        public Gfsr1(string seed, int q, int r, int l)
            : base(Convert.ToInt64(seed)){
            this._seed = seed;
            this.q = q;

            this.r = r;
            maxValue = (long) System.Math.Pow(2.0, q);

            this.wordLength = l;
            delay = 6;
            var charArray = seed.ToCharArray();
            for (var i = 0; i < seed.Length; i++) {
                MyClass item = new MyClass(i, charArray[i]);
                seedChar.Add(item);
            }

            if ((l % 2) != 1){
                ;
            }
        }

        public Gfsr1(string seed, int q, int r, int l, int delay)
            : base(){
            this.q = q;
            this.r = r;
            wordLength = l;
            this.delay = delay;
            this._seed = seed;
            var charArray = seed.ToCharArray();
            for (var i = 0; i < seed.Length; i++){
                MyClass item = new MyClass(i, charArray[i]);
                seedChar.Add(item);
            }

            maxValue = (long) System.Math.Pow(2.0, q);
            if (seed.Length != q){
                Console.WriteLine(q+"===Seed Length="+seed.Length);
                throw new ArgumentException("Length of seed not equal to the value of q supplied.");
            }

            //d must not be less than q
        }

      

        public override long Next(){
            var lengthToKeep = 1+q + (delay * wordLength);
            Console.WriteLine("index->" + currentI);
            var seedLength = seedChar.Count;

            //preempt the next set of bits
            var nextSetOfBits = currentI + (delay * (wordLength - 1));

            //generate new bits if we do not have the nextSetOfBits in our list
            var lastItemIndex = seedChar[seedLength-1].Index;
            var possibleNextItemCount = nextSetOfBits - lastItemIndex;
            if (possibleNextItemCount > 0){ //if the length required for the Wi is greater than the current length of strings
                for (var i = lastItemIndex+1; i < nextSetOfBits; i++){
                    //Console.WriteLine("i->" + i);
                    //var nIndex = seedLength + i;
                    MyClass newItem = new MyClass(i, Convert.ToChar(GetNextBit(i)));
                    seedChar.Add(newItem);
                }
            }
            //seedChar.ForEach(Console.WriteLine);
          
            var bitString = "";
            //var seedCharArray = tempSeed.ToCharArray();
            //var seedCharArrayLength = seedCharArray.Length;
            
            for (var bitIndex = wordLength; bitIndex > 0; bitIndex--){
                var jumper = delay * (wordLength - bitIndex);
                var index = currentI + jumper - 1;
                if (jumper != 0){
                    //this is not the left most bit
                    index = index - 1;
                }

                var value = 0;
                foreach (var charItem in seedChar){
                    if (charItem.Index != index) continue;
                    value = charItem.Value;
                    break;
                }
               
                bitString += value != '1'? 0+"": 1+"";
            }

            currentI++;
            currentValue = GetBinaryIntegerEqui(bitString);

            //cut the seed list to remain only the value we need
            var indexBehind = seedLength - lengthToKeep;
            if (indexBehind <= 0) return currentValue;

            //discard the remainder behind;
            seedChar.RemoveRange(0, indexBehind);

            return currentValue;
        }

        private int GetNextBit(int currentIndex){
            var rthPosition = currentIndex - r; //array position starts from zero
            var qthPosition = currentIndex - q;

            var operand1 = '0';
            var operand2 = '0';
            foreach (var myClass in seedChar) {
                if (rthPosition == myClass.Index){
                    operand1 = myClass.Value;
                }if (qthPosition == myClass.Index){
                    operand2 = myClass.Value;
                }
            }

            var result = operand1 ^ operand2;
            return result;
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


        public override double Sample(){
            return currentValue / System.Math.Pow(2, wordLength);
        }

        public string GetLogs(){
            return logger.ToString();
        }

        public static int GetBinaryIntegerEqui(string binaryString){
            return Convert.ToInt32(binaryString, 2);
        }


        public override void NextBytes(byte[] b){
            throw new NotImplementedException();
        }

        private class MyClass{
            public MyClass(int index, char value) {
                this.Index = index;
                this.Value = value;
            }

            public int Index{ get; private set; }

            [System.ComponentModel.DefaultValue('0')]
            public char Value{ get; private set; }

            public override string ToString() {
                return "item at " + Index + " = " + Value;
            }
        }
    }

}