using System;
using System.Globalization;
using System.Security.Cryptography;

namespace Math.RNG.GFSR{
    public class GeneralizedFeedbackShiftRegister : Random{
        private int q, r, delay;
        private int wordLength;
        private string _seed;

        public GeneralizedFeedbackShiftRegister()
            : base(){ }

        /**
         * @seed = initial bit of length q
         * l = word length
         *
         */
        public GeneralizedFeedbackShiftRegister(string seed, int q, int r, int l, int delay)
            : base(long.Parse(seed)){
            this.q = q;
            this.r = r;
            wordLength = l;
            this.delay = delay;
            this._seed = seed;
            if (_seed.Length != q){
                throw new ArgumentException("Length of seed not equal to the value of q supplied.");
            }
            //d must not be less than q

            Console.WriteLine(CalculateSamplePeriod(q));
        }

        /// <summary>
        /// construct mixed LCG
        /// </summary>
        /// <param name="seed">seed</param>
        /// <param name="a">multiplier</param>
        /// <param name="b">number of bits</param>
        /// <param name="c">increment</param>
        public GeneralizedFeedbackShiftRegister(long seed, long a, long b){ }

        public string Next(int i){
            var rthPosition = i - r - 1; //array position starts from zero
            var qthPosition = i - q - 1;

            var seedCharArray = _seed.ToCharArray();
            var operand1 = seedCharArray[rthPosition];
            var operand2 = seedCharArray[qthPosition];


            var result = operand1 ^ operand2;
            _seed = _seed + "" + result;
            if (_seed.Length % CalculateSamplePeriod(q) == 0){
                //Console.WriteLine(_seed);
            }

            return _seed;
        }

        public string GenerateNextX(int end){
            int startI = _seed.Length + 1;
            string toReturn = "";
            for (var i = startI; i <= end; i++){
                Next(i);
            }

            //Console.WriteLine("Len->" + _seed.Length);
            var j = 0;
            while (j < end){
                var value = _seed.Substring(j, wordLength);
                //Console.WriteLine(Convert.ToInt32(value, 2) + ", ");
                j = j + wordLength;
            }

            return toReturn;
        }

        public string[] GenerateWi(int limit){
            //get initial seed length
            //Console.WriteLine(_seed.Length);
            //get the complete sequence to the limit specified
            GenerateNextX(limit);

            //Console.WriteLine("Seed->" + _seed);
            //Console.WriteLine("Seed Length->" + _seed.Length);

            var output = new string[limit];
            for (var bitIndex = wordLength; bitIndex > 0; bitIndex--){
                var jumper = delay * (wordLength - bitIndex);
                //Console.WriteLine("jumper->" + jumper);
                for (var index = 0; index < limit; index++){
                    var indexToUse = index + jumper;
                    if (jumper > 0){
                        indexToUse = indexToUse - 1; //give room for array indexing
                    }

                    //Console.WriteLine("indexToUse->" + indexToUse);
                    if (indexToUse >= _seed.Length){
                        var newIndexToUse = indexToUse - _seed.Length;
                        output[index] += _seed[newIndexToUse];
                    }
                    else{
                        output[index] += _seed[indexToUse];
                    }
                }
            }


            return output;
        }

        public double[] generateUis(string[] outputs){
            var outputsDecimals = new double[outputs.Length];
            for (var index = 0; index < outputs.Length; index++){
                var output = outputs[index];
                var outputDecimal = GetBinaryIntegerEqui(output);
                var divisor = System.Math.Pow(2, wordLength);
                var Ui = outputDecimal / divisor;
                outputsDecimals[index] = Ui;
            }


            return outputsDecimals;
        }

        public void verifySequence(string[] outputs){
            //verify Yi = Yi-r xor Yi-q
            for (var count = 6; count < outputs.Length; count++) {
                var output = outputs[count];
                var outputValueInt = GetIntArrayFromChar(output);

                var rthPosition = count - r; //array position starts from zero
                var qthPosition = count - q;

                var yir = GetIntArrayFromChar(outputs[rthPosition]);
                var yiq = GetIntArrayFromChar(outputs[qthPosition]);
                

                var newOutput = "";
                for (var i = 0; i < output.Length; i++) {
                    var valueCheck = yir[i, 0] ^ yiq[i, 0];
                    newOutput += valueCheck;
                }

                Console.WriteLine("Generated-->" + output + "============Calculated==>" + newOutput);
            }
        }
        private static int[,] GetIntArrayFromChar(string bitValue) {
            char[] outputValue = bitValue.ToCharArray();
            int[,] outputValueInt = new int[outputValue.Length, 1];
            for (var index = 0; index < outputValue.Length; index++) {
                var VARIABLE = outputValue[index];
                outputValueInt[index, 0] = VARIABLE;
            }

            return outputValueInt;
        }
        public override long Next(){
            return 0;
        }

        public override void NextBytes(byte[] b){
            throw new NotImplementedException();
        }

        private void stringToBinary(string seed){
            foreach (char c in seed)
                Console.WriteLine(Convert.ToString(c, 2).PadLeft(5, '0'));
        }

        private int CalculateSamplePeriod(){
            var power = System.Math.Pow(2, q) - 1;
            return int.Parse(power.ToString(CultureInfo.CurrentCulture));
        }

        private static int CalculateSamplePeriod(int q){
            var power = System.Math.Pow(2, q) - 1;
            return int.Parse(power.ToString(CultureInfo.CurrentCulture));
        }

        public static int GetBinaryIntegerEqui(string binaryString){
            return Convert.ToInt32(binaryString, 2);
        }
    }
}