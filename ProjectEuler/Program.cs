using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the problem number: ");
            int problem = Int32.Parse(Console.ReadLine());
            switch(problem) {
                case 1:
                    Problem1();
                    break;

                case 2:
                    Problem2();
                    break;

                case 3:
                    Problem3();
                    break;

                case 4:
                    Problem4();
                    break;

                case 5:
                    Problem5();
                    break;

                case 6:
                    Problem6();
                    break;

                case 7:
                    Problem7();
                    break;

                default:
                    //Do Nothing
                    break;
            }

            Console.ReadLine();
        }

        static void Problem1()
        {
            int sum = 0;
            for(int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            Console.WriteLine(sum);
        }

        static void Problem2()
        {
            long fibo1 = 1, fibo2 = 2, sum = 0;
            while(fibo2 < 4000000)
            {
                if (fibo2 % 2 == 0)
                    sum += fibo2;
                fibo2 = fibo2 + fibo1;
                fibo1 = fibo2 - fibo1;
            }
            Console.WriteLine(sum);
        }

        static void Problem3()
        {
            List<long> factors = GetPrimeFactors(600851475143);
            Console.WriteLine(factors[factors.Count-1]);
        }

        static void Problem4()
        {
            List<int> palindromeNumbers = new List<int>();

            for(int i = 999; i >= 100; i--)
            {
                for(int j = 999; j >= 100; j--)
                {
                    int product = i * j;
                    if(isPalindrome(product.ToString()))
                    {
                        palindromeNumbers.Add(product);
                    }
                }
            }
            
            Console.WriteLine(palindromeNumbers.Max());
        }

        static void Problem5()
        {
            List<int> primeFactors = new List<int>();
            for(int i = 2; i <= 20; i++)
            {
                int numberToFactor = i;
                for(int j = 0; j < primeFactors.Count; j++)
                {
                    if(numberToFactor%primeFactors[j] == 0)
                    {
                        numberToFactor /= primeFactors[j];
                    }
                }
                if(numberToFactor != 1)
                    primeFactors.Add(numberToFactor);
            }

            long product = 1;

            for(int i = 0; i < primeFactors.Count; i++)
            {
                product *= primeFactors[i];
                Console.WriteLine(primeFactors[i]);
            }

            Console.WriteLine(product);
        }

        static void Problem6()
        {
            long sumOfSquares = 0;
            long sum = 0;
            for(int i = 1; i <= 100; i++)
            {
                sumOfSquares += i * i;
                sum += i;
            }
            long squareOfSum = sum * sum;
            Console.WriteLine(squareOfSum - sumOfSquares);
        }

        static void Problem7()
        {
            Console.WriteLine(GetNPrimes(10001)[10000]);
        }

        static List<long> GetNPrimes(int n)
        {
            List<long> primes = new List<long>();

            int numberToCheck = 2;
            bool isPrime = true;
            while(primes.Count < n)
            {
                isPrime = true;

                foreach(long l in primes)
                {
                    if (numberToCheck % l == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    primes.Add(numberToCheck);

                numberToCheck++;
            }

            return primes;
        }

        static List<long> GetPrimeFactors(long n)
        {
            List<long> factors = new List<long>();

            for(long i = 2; i < n/2 + 1; i++)
            {
                if (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                    i--;
                }
            }

            factors.Add(n);

            return factors;
        }

        static bool isPalindrome(string s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
