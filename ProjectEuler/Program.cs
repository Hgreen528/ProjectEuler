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

                case 8:
                    Problem8();
                    break;

                case 9:
                    Problem9();
                    break;

                case 10:
                    Problem10();
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

        static void Problem8()
        {
            String giantNumber = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            long product = 1;

            for (int i = 0; i < 13; i++)
            {
                if(giantNumber[i] - '0' == 0)
                {
                    product = 1;
                    continue;
                }
                product *= giantNumber[i] - '0';
            }
            
            long max = product;

            int productLength = 13;
            
            for(int i = 13; i < giantNumber.Length; i++)
            {
                if(giantNumber[i] - '0' == 0)
                {
                    product = 1;
                    productLength = 0;
                    continue;
                }
                if(giantNumber[i-productLength] - '0' != 0 && productLength == 13)
                {
                    product /= giantNumber[i - 13] - '0';
                }

                product *= giantNumber[i] - '0';
                if (productLength < 13)
                    productLength++;

                if (product > max)
                    max = product;
            }

            Console.WriteLine(max);
        }

        static void Problem9()
        {
            for(int a = 1; a < 333; a++)
            {
                for(int b = a+1; b < 499 - a/2; b++)
                {
                    int c = 1000-b-a;
                    if(a*a + b*b == c*c)
                    {
                        Console.WriteLine("a = " + a + ", b = " + b + ", c = " + c);
                        Console.WriteLine(a*b*c);
                        return;
                    }
                }
            }
        }

        static void Problem10()
        {
            List<long> primes = GetPrimesUnder(2000000);

            long sum = 0;
            foreach (long prime in primes)
                sum += prime;

            Console.WriteLine(sum);
        }

        static List<long> GetPrimesUnder(long n)
        {
            List<long> primes = new List<long>();

            bool[] sieve = new bool[n];

            for (int i = 2; i < n; i++)
                sieve[i] = true;

            for (int num = 2; num < n; num++)
            {
                if(sieve[num])
                {
                    for (int multiple = num * 2; multiple < n; multiple += num)
                    {
                        sieve[multiple] = false;
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                if (sieve[i])
                    primes.Add(i);
            }

            return primes;
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
