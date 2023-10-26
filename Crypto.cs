using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Numerics;

namespace Parametr_El_Gamal_homomorph
{
    class Crypto
    {
        public int GenPrime()
        {
            //tasodifiy tub sonni generatsiya qilish
            bool isprime = false;
           // byte[] buf = new byte[64];
           int  n = 0;
            while (isprime == false)
            {
                // Tasodifiy son generatsiya qilish
                Random num = new Random();
                n = num.Next(1, int.MaxValue);
                
                
                // sonni tublikka tekshirish

                if ((n == 2) || (n == 3))
                {
                    isprime = true;

                }
                if ((n < 2) || (n % 2 == 0))
                {
                    isprime = false;
                }

                // Rabin Miller testi
                BigInteger t = n - 1;
                int s = 0;
                // s va t larni qiymatini aniqlash
                while (t % 2 == 0)
                {
                    t = t / 2;
                    s++;

                }

                int a = 2;//  a=3,4,5...n-1 bo'lishi mumkin
                BigInteger x = BigInteger.ModPow(a, t, n);// x=a^t modn
                if (x == 1 || x == n - 1)
                    isprime = true;
                    /////
                else
                {
                    for (int r = 1; r < s; r++)
                    {
                        // x ← x^2 mod n
                        x = BigInteger.ModPow(x, 2, n);// x=x^2 mod n hisoblanadi

                        // если x == 1, то вернуть "составное"
                        if (x == 1)
                            isprime = false;

                        // если x == n − 1, то перейти на следующую итерацию внешнего цикла
                        if (x == n - 1)
                            break;
                    }

                    if (x != n - 1)
                        isprime = false;
                    
                }

            }

            return n;
        }

        public int EKUB(int r1, int r2)
        {
           //int t1 = 0, t2 = 1;
            while (r2 > 0)
            {

                int r = 0, q=0;
                q = r1 / r2;
                r = r1 - q * r2;
                r1 = r2;
                r2 = r;


            }
            return r1;
        }

        public BigInteger teskari(BigInteger r1, BigInteger r2)
        {
           BigInteger t1 = 0, t2 = 1;
            while (r2 > 0)
            {

               BigInteger r = 0, q, t;
                q = r1 / r2;
                r = r1 - q * r2;
                r1 = r2;
                r2 = r;
                t = t1 - q * t2;
                t1 = t2;
                t2 = t;
            }
            return t1;
        }

        public BigInteger diadaraja(BigInteger R, BigInteger M, BigInteger a, BigInteger k)
        {
            BigInteger fu = 0, d, qadam;
            if (k == 0)
            {
                fu = 1;
            }
            else
            {
                if (k == 1)
                {
                    fu = a;
                }
                else
                {
                    qadam = 1; d = a;
                    do
                    {
                        d = (a + d * (1 + R * a)) % M;
                        qadam++;
                    }

                    while (qadam < k);
                    fu = d;
                }
            }
            return fu;
        }
    }
}
