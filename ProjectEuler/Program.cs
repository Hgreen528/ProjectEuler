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

                case 11:
                    Problem11();
                    break;

                case 12:
                    Problem12();
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

        //A faster alternative would be to set up a sliding calculation for each row, column, and diagonal, resulting in 6n time instead of n^2 time
        static void Problem11()
        {
            int[,] grid = new int[20, 20] { { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 }, 
                                            { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 },
                                            { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 },
                                            { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 },
                                            { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 },
                                            { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 },
                                            { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 },
                                            { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 },
                                            { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 },
                                            { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 },
                                            { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 },
                                            { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 },
                                            { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 },
                                            { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 },
                                            { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 },
                                            { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 },
                                            { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 },
                                            { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 },
                                            { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 },
                                            { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 } };

            int product = 0;
            int max = 0;

            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    //Calculate forward across the column
                    if(j+3 < 20)
                        product = grid[i, j] * grid[i, j + 1] * grid[i, j + 2] * grid[i, j + 3];

                    if (product > max)
                        max = product;

                    //Calculate down across the rows
                    if(i+3 < 20)
                        product = grid[i, j] * grid[i + 1, j] * grid[i + 2, j] * grid[i + 3, j];

                    if (product > max)
                        max = product;

                    //Calculate along the forward diagonal
                    if(i+3 < 20 && j+3 < 20)
                        product = grid[i, j] * grid[i + 1, j + 1] * grid[i + 2, j + 2] * grid[i + 3, j + 3];

                    if (product > max)
                        max = product;

                    //Calculate along the backward diagonal
                    if (i + 3 < 20 && j - 3 >= 0)
                        product = grid[i, j] * grid[i + 1, j - 1] * grid[i + 2, j - 2] * grid[i + 3, j - 3];

                    if (product > max)
                        max = product;
                }
            }

            Console.WriteLine(max);
        }

        
        static void Problem12()
        {
            int seriesIndex = 1;
            long factorCount = 1;

            long[] subFactorCounts = new long[2];
            subFactorCounts[0] = 1;
            subFactorCounts[1] = 1;
            
            while (factorCount <= 500)
            {
                //Since each triangle number can be written as n*(n+1)/2, where n is the index, the total number of factors is the factors of n plus the factors of n+1 minus 1

                subFactorCounts[0] = subFactorCounts[1];
                subFactorCounts[1] = GetDivisorCount(seriesIndex + 1);

                factorCount = subFactorCounts[0] + subFactorCounts[1] - 1;
            }

            Console.WriteLine(Sum1toN(seriesIndex));
        }

        static long GetDivisorCount(long n)
        {
            //First generate a list of primes to test as potential divisors
            List<long> primes = GetPrimesUnder(n + 1);

            List<long> divisors = new List<long>();
            List<long> divisorCounts = new List<long>();
            

            for(int primeIndex = 1; primeIndex < primes.Count; primeIndex++)
            {
                if (n % primes[primeIndex] == 0)
                {
                    n /= primes[primeIndex];
                    if (divisors[divisors.Count - 1] != primes[primeIndex])
                    {
                        divisors.Add(primes[primeIndex]);
                        divisorCounts.Add(1);
                    }
                    else
                        divisorCounts[divisorCounts.Count - 1]++;

                    primeIndex--;
                }
            }

            long divisorCount = 1;

            foreach(long l in divisorCounts)
            {
                divisorCount *= (l + 1);
            }

            return divisorCount;
        }

        static long Sum1toN(long n)
        {
            return (n * (n + 1)) / 2;
        }

        static List<long> GetPrimesUnder(long n)
        {
            List<long> primes = new List<long>();

            bool[] isPrime = new bool[n];

            for (int i = 2; i < n; i++)
                isPrime[i] = true;

            for (int number = 2; number < n/2; number++)
            {
                if(isPrime[number])
                {
                    for (int multiple = number * 2; multiple < n; multiple += number)
                    {
                        isPrime[multiple] = false;
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                if (isPrime[i])
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
