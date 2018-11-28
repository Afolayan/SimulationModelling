using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Math.RNG.GFSR{

    public class Register{
        private bool[] _register = null;
        private bool[] _feedbackPoints = new bool[256];
        private int _registerLength = 0;

        public Register(int length, int[] feedbackPoints) : this(length, feedbackPoints, new byte[0]){ }

        public Register(int length, int[] feedbackPoints, byte[] seed){
            if (length > 256)
                throw new ArgumentOutOfRangeException("length", "Alloewed vaues need to be between 1 and 256");

            _registerLength = length;

            _register = new bool[length];

            foreach (int feedbackPoint in feedbackPoints)
                if (feedbackPoint > 256)
                    throw new ArgumentOutOfRangeException("feedbackPoints",
                        "Alloewed vaues of item of array need to be between 1 and 256");
                else
                    _feedbackPoints[feedbackPoint] = true;


            byte[] randomizedSeed = this.SeedRandomization(seed);

            string temporaryRegisterRepresantation = string.Empty;
            foreach (byte seedItem in randomizedSeed)
                temporaryRegisterRepresantation += Convert.ToString(seedItem, 2);

            int index = 0;
            foreach (char bit in temporaryRegisterRepresantation)
                if (index < length)
                    _register[index++] = bit == '1';
        }

        public bool Clock(){
            lock (this){
                bool output = _register[0];

                for (int index = 0; index < _registerLength - 1; index++)
                    _register[index] = _feedbackPoints[index] ? _register[index + 1] ^ output : _register[index + 1];

                _register[_registerLength - 1] = output;

                return output;
            }
        }

        private byte[] SeedRandomization(byte[] inputSeed){
            SHA256Managed sha256 = new SHA256Managed();
            int seedLength = inputSeed.Length;

            byte[] seed = new byte[seedLength];
            Array.Copy(inputSeed, seed, seedLength);


            Array.Resize<byte>(ref seed, seedLength + 4);
            byte[] dateTime = BitConverter.GetBytes(DateTime.Now.Ticks);
            seed[seedLength] = dateTime[0];
            seed[seedLength + 1] = dateTime[1];
            seed[seedLength + 2] = dateTime[2];
            seed[seedLength + 3] = dateTime[3];

            return sha256.ComputeHash(seed, 0, seed.Length);
        }
    }

}