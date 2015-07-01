//Author: Hunter Green
//Created: 5/31/15
//Problems 13-26 were done during Winter of 2014, Problems 1-12 have been redone and progress is continuing
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
            Stopwatch sw = new Stopwatch();

            Console.Write("Enter the Project Euler problem number: ");
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

            Console.WriteLine("Time taken: " + sw.ElapsedMilliseconds + " milliseconds");
            sw.Stop();

            Console.ReadLine();
        }


        //Problem 1
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

        static bool isPalindrome(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }

            return true;
        }
        //End of problem 1

        //Problem 2
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

        static List<long> GetPrimeFactors(long n)
        {
            List<long> factors = new List<long>();

            for (long i = 2; i < n / 2 + 1; i++)
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
        //End of problem 2

        //Problem 3
        static void Problem3()
        {
            List<long> factors = GetPrimeFactors(600851475143);
            Console.WriteLine(factors[factors.Count-1]);
        }

        //End of problem 3

        //Problem 4
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
        //End of problem 4

        //Problem 5
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
        //End of problem 5

        //Problem 6
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

        //End of problem 6

        //Problem 7
        static void Problem7()
        {
            Console.WriteLine(GetNPrimes(10001)[10000]);
        }

        static List<long> GetNPrimes(int n)
        {
            List<long> primes = new List<long>();

            int numberToCheck = 2;
            bool isPrime = true;
            while (primes.Count < n)
            {
                isPrime = true;

                foreach (long l in primes)
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
        //End of Problem 7

        //Problem 8
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
        //End of problem 8

        //Problem 9
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
        //End of problem 9

        //Problem 10
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

            bool[] isPrime = new bool[n];

            for (int i = 2; i < n; i++)
                isPrime[i] = true;

            for (int number = 2; number < n / 2; number++)
            {
                if (isPrime[number])
                {
                    for (int multiple = number * 2; multiple < n; multiple += number)
                    {
                        isPrime[multiple] = false;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (isPrime[i])
                    primes.Add(i);
            }

            return primes;
        }
        //End of problem 10

        //Problem 11
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

            //A faster alternative would be to set up a sliding calculation for each row, column, and diagonal, resulting in 6n time instead of n^2 time
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
        //End of problem 11

        //Problem 12
        static void problem12()
        {
            int term = 7;
            long triangleNumber = TriangleNumberAt(term);
            long numFactors = DivisorCount(triangleNumber);

            while (numFactors <= 500)
            {
                term++;
                triangleNumber = TriangleNumberAt(term);
                numFactors = DivisorCount(triangleNumber);
            }

            Console.WriteLine(triangleNumber);
        }

        static long TriangleNumberAt(int n)
        {
            long sum = n * (n - 1) / 2;
            return sum;
        }

        static long DivisorCount(long n)
        {
            long divisors = 0;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    divisors++;
            }

            return 2 * divisors;
        }
        //End of problem 12

        //Problem 13
        static void problem13()
        {
            BigInteger bi = new BigInteger();

            string line;
            StreamReader sr = new StreamReader("big number.txt");

            while ((line = sr.ReadLine()) != null)
            {
                bi += BigInteger.Parse(line);
            }

            Console.WriteLine(bi.ToString());

            sr.Close();
        }
        //End of problem 13

        //Problem 14
        static void problem14()
        {
            int startingNumber = 2;
            int longestChainStart = startingNumber;
            long length = CollatzLength(2, 1);
            long longestLength = length;
            while (startingNumber < 1000000)
            {
                startingNumber++;
                length = CollatzLength(startingNumber, 1);
                if (length > longestLength)
                {
                    longestLength = length;
                    longestChainStart = startingNumber;
                }
            }

            Console.WriteLine(longestChainStart);
        }

        static long CollatzLength(long number, int length)
        {
            if (number == 1)
                return ++length;
            if (number % 2 == 0)
                return CollatzLength(number / 2, ++length);
            else
                return CollatzLength(3 * number + 1, ++length);
        }
        //End of problem 14

        //Problem 15
        static void problem15()
        {
            long[,] map = new long[21, 21];

            for (int i = 0; i < 20; i++)
            {
                map[i, 20] = 1;
                map[20, i] = 1;
            }

            for (int i = 19; i >= 0; i--)
            {
                for (int j = 19; j >= 0; j--)
                {
                    map[i, j] = map[i + 1, j] + map[i, j + 1];
                }
            }

            Console.WriteLine(map[0, 0]);
        }
        //End of problem 15

        //Problem 16
        static void problem16()
        {
            BigInteger bi = new BigInteger();

            bi = BigInteger.Pow(2, 1000);

            long sum = 0;

            while (bi > 0)
            {
                int r = (int)(bi % 10);
                sum += r;
                bi /= 10;
            }

            Console.WriteLine(sum);
        }
        //End of problem 16

        //Problem 17
        static void problem17()
        {
            string one = "one";
            string two = "two";
            string three = "three";
            string four = "four";
            string five = "five";
            string six = "six";
            string seven = "seven";
            string eight = "eight";
            string nine = "nine";
            string ten = "ten";
            string eleven = "eleven";
            string twelve = "twelve";
            string thirteen = "thirteen";
            string fourteen = "fourteen";
            string fifteen = "fifteen";
            string sixteen = "sixteen";
            string seventeen = "seventeen";
            string eighteen = "eighteen";
            string nineteen = "nineteen";
            string twenty = "twenty";
            string thirty = "thirty";
            string forty = "forty";
            string fifty = "fifty";
            string sixty = "sixty";
            string seventy = "seventy";
            string eighty = "eighty";
            string ninety = "ninety";

            int singles = one.Length + two.Length + three.Length + four.Length + five.Length
                + six.Length + seven.Length + eight.Length + nine.Length;

            int teens = ten.Length + eleven.Length + twelve.Length + thirteen.Length + fourteen.Length
                + fifteen.Length + sixteen.Length + seventeen.Length + eighteen.Length + nineteen.Length;

            int tens = 10 * (twenty.Length + thirty.Length + forty.Length + fifty.Length + sixty.Length + seventy.Length + eighty.Length + ninety.Length) + 8 * singles;

            int hundreds = singles * 100 + 9 * 7 + 9 * 99 * 10 + 9 * (tens + teens + singles);

            Console.WriteLine(11 + hundreds + tens + teens + singles);
        }
        //End of problem 17

        //Problem 18
        static void problem18()
        {
            int[,] tree = readTree("minimum path sum 1 tree.txt");

            for (int i = tree.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    tree[i, j] += max(tree[i + 1, j], tree[i + 1, j + 1]);
                }
            }

            Console.WriteLine(tree[0, 0]);
        }

        static int max(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        static int[,] readTree(string filename)
        {
            string line;
            string[] linePieces;
            int lines = 0;

            StreamReader r = new StreamReader(filename);
            while ((line = r.ReadLine()) != null)
                lines++;

            int[,] tree = new int[lines, lines];

            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    tree[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }
            r.Close();
            return tree;
        }
        //End of problem 18

        static void problem19()
        {
            int totalDays = 0;
            int numSundays = 0;

            totalDays += 4 * 30; //September, April, June, November
            totalDays += 7 * 31; //The rest except February
            totalDays += 28;     //The first February
            totalDays += 1; //Sets it up to the first of the next year

            for (int i = 1901; i < 2001; i++)
            {
                if ((totalDays) % 7 == 0) //Check Jan 1st
                    numSundays++;
                totalDays += 31; //Add the days in Jan

                if ((totalDays) % 7 == 0) //Check Feb 1st
                    numSundays++;

                //Add the days in Feb
                if (i % 4 == 0 && (i % 100 != 0) || (i % 400 == 0))
                {
                    totalDays += 29;
                }
                else
                    totalDays += 28;

                if ((totalDays) % 7 == 0) //Check March 1st
                    numSundays++;
                totalDays += 31; //Add the days in March

                if ((totalDays) % 7 == 0) //Check April 1st
                    numSundays++;
                totalDays += 30; //Add the days in April

                if ((totalDays) % 7 == 0) //Check May 1st
                    numSundays++;
                totalDays += 31; //Add the days in May

                if ((totalDays) % 7 == 0) //Check Jun 1st
                    numSundays++;
                totalDays += 30; //Add the days in Jun

                if ((totalDays) % 7 == 0) //Check Jul 1st
                    numSundays++;
                totalDays += 31; //Add the days in Jul

                if ((totalDays) % 7 == 0) //Check Aug 1st
                    numSundays++;
                totalDays += 31; //Add the days in Aug

                if ((totalDays) % 7 == 0) //Check Sep 1st
                    numSundays++;
                totalDays += 30; //Add the days in Sep

                if ((totalDays) % 7 == 0) //Check Oct 1st
                    numSundays++;
                totalDays += 31; //Add the days in Oct

                if ((totalDays) % 7 == 0) //Check Nov 1st
                    numSundays++;
                totalDays += 30; //Add the days in Nov

                if ((totalDays) % 7 == 0) //Check Dec 1st
                    numSundays++;
                totalDays += 31; //Add the days in Dec
            }

            Console.WriteLine(numSundays);
        }
        //End of problem 19

        //Problem 20
        static void problem20()
        {
            BigInteger bi = new BigInteger();
            bi = 1;
            for (int i = 100; i > 0; i--)
                bi *= i;

            long sum = 0;

            while (bi > 0)
            {
                int r = (int)(bi % 10);
                sum += r;
                bi /= 10;
            }

            Console.WriteLine(sum);
        }
        //End of problem 20

        //Problem 21
        static void problem21()
        {
            int[,] map = new int[10000, 2];

            for (int i = 0; i < 10000; i++)
            {
                map[i, 0] = i;
                map[i, 1] = sumOfDivisors(i);
            }

            int[] amicableNumbers = new int[10000];
            int index = 0;

            for (int i = 0; i < 10000; i++)
            {
                for (int j = i; j < 10000; j++)
                {
                    if (map[i, 0] == 0)
                        break;
                    if (map[j, 0] == 0)
                        break;
                    if (map[i, 1] == map[j, 0] && map[i, 0] == map[j, 1] && map[i, 0] != map[j, 0])
                    {
                        amicableNumbers[index++] = map[i, 0];
                        map[i, 0] = 0;
                        amicableNumbers[index++] = map[j, 0];
                        map[j, 0] = 0;
                    }
                }
            }

            long amicableSum = 0;

            for (int i = 0; i < index; i++)
            {
                amicableSum += amicableNumbers[i];
            }

            Console.WriteLine(amicableSum);
        }

        static int sumOfDivisors(int n)
        {
            int sod = 0;

            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                    sod += i;
            }

            return sod;
        }
        //End of problem 21

        //Problem 22
        static void problem22()
        {
            string[] names;

            string n = File.ReadAllText("names.txt");

            n = n.Replace("\"", "");

            names = n.Split(',');

            Array.Sort(names);

            BigInteger sum = new BigInteger();
            sum = 0;

            for (int i = 0; i < names.Length; i++)
            {
                int tempSum = 0;
                for (int j = 0; j < names[i].Length; j++)
                {
                    tempSum += (int)(names[i][j] - '@');
                }
                sum += (i + 1) * tempSum;
            }

            Console.WriteLine(sum);
        }
        //End of problem 22

        //Problem 23
        static void problem23()
        {
            bool[] numList = new bool[20162];
            long sum = 0;

            List<int> abundantNumbers = new List<int>();

            for (int i = 1; i < 20162; i++)
            {
                if (!numList[i])
                    sum += i;

                if (isAbundant(i))
                {
                    abundantNumbers.Add(i);
                    for (int j = 0; j < abundantNumbers.Count; j++)
                    {
                        int abundantSum = i + abundantNumbers[j];
                        if (abundantSum < 20162)
                            numList[abundantSum] = true;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        static bool isAbundant(int n)
        {
            int sum = 1;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                    if (i != n / i)
                    {
                        sum += n / i;
                    }
                }
            }

            return sum > n;
        }
        //End of problem 23

        //Problem 24
        static void problem24()
        {
            int digits = 10;

            string permutation = "";

            long remainder = 1000000 - 1;

            List<int> numbers = new List<int>();
            for (int i = 0; i < digits; i++)
            {
                numbers.Add(i);
            }

            for (int i = 1; i < digits; i++)
            {
                long F = factorial(digits - i);
                int j = (int)(remainder / F);
                remainder %= F;
                permutation = permutation + numbers[j];
                numbers.RemoveAt(j);
                if (remainder == 0)
                    break;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                permutation = permutation + numbers[i];
            }

            Console.WriteLine(permutation);
        }

        static long factorial(long n)
        {
            if (n <= 1)
                return 1;
            else
                return n * factorial(n - 1);
        }
        //End of problem 24

        //Problem 25
        static void problem25()
        {
            List<BigInteger> fibo = new List<BigInteger>();

            fibo.Add(1);
            fibo.Add(1);

            while (fibo[fibo.Count - 1].ToString().Length < 1000)
            {
                fibo.Add(fibo[fibo.Count - 1] + fibo[fibo.Count - 2]);
            }

            Console.WriteLine(fibo.Count);
        }

        //Problem 26
        static void problem26()
        {
            int sequenceLength = 0;
            int num = 0;

            for (int i = 1000; i > 1; i--)
            {
                if (sequenceLength >= i)
                {
                    break;
                }

                int[] foundRemainders = new int[i];
                int value = 1;
                int position = 0;

                while (foundRemainders[value] == 0 && value != 0)
                {
                    foundRemainders[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if (position - foundRemainders[value] > sequenceLength)
                {
                    num = i;
                    sequenceLength = position - foundRemainders[value];
                }
            }

            Console.WriteLine(num);
        }
        //End of problem 26
    }
}
