﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAUtils
{
    internal class CyclicCrack
    {
        public static Dictionary<string, BigInteger> Crack(BigInteger c, BigInteger e, BigInteger n)
        {
            try
            {
                var items = new Dictionary<string, BigInteger>();
                int k = 0;
                do
                {
                    k++;
                } while (!MainForm.CancelOperation && BigInteger.ModPow(c, BigInteger.Pow(e, k), n) != c);
                items.Clear();
                items.Add("Количество итераций (k)", k);

                if (!MainForm.CancelOperation)
                    items.Add("Исходное число (m)", BigInteger.ModPow(c, BigInteger.Pow(e, k - 1), n));
                return items;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }
    }
}