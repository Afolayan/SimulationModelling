﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.RNG.GFSR {
 
    public class LSFR {
        bool[] bits;

        public LSFR (int bitCount, string seed) {
            bits = new bool[bitCount];

            for (int i = 0; i < bitCount; i++)
                bits[i] = seed[i] == '1' ? true : false;

        }

        public string Registry {
            get {
                char[] t = new char[bits.Length];
                for (int i = 0; i < bits.Length; i++)
                    t[i] = bits[i] ? '1' : '0';

                return new string(t);
            }
        }

        public void Shift() {
            // Wikipedia Logic.. Override if necessary
            var bnew = bits[bits.Length - 1] != bits[bits.Length - 2];

            for (var i = bits.Length - 1; i > 0; i--) {
                bits[i] = bits[i - 1];
            }
            bits[0] = bnew;
        }

    }
}
