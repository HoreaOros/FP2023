using System.ComponentModel;
using System.Net.WebSockets;
Dictionary<(int x, int y), int> cache = new Dictionary<(int x, int y), int>();

//**************************************************
int n = 5; // factorial
Console.WriteLine($"Factorial: {n}! = {Factorial(n)}");
Console.WriteLine($"Factorial: {n}! = {FactorialR(n)}");

//**************************************************
int a = 60, b = 48; //CMMDC
Console.WriteLine($"gcd({a}, {b}) = {gcd(a, b)}");
Console.WriteLine($"gcd({a}, {b}) = {gcd2(a, b)}");
Console.WriteLine($"gcd({a}, {b}) = {gcdR(a, b)}");
Console.WriteLine($"gcd({a}, {b}) = {gcdR2(a, b)}");

//**************************************************
int x = 16, y = 16; // scor FOTBAL
Console.WriteLine($"La scorul {x}-{y} se poate ajunge in {Scor(x, y)} moduri");



//**************************************************
n = 1234; // 1234 ==> 24, 135 ==> -1, 103 ==> 0, 1003 ==> 0; 
Console.WriteLine($"{n} ==> {Pare(n)}");
n = 135;
Console.WriteLine($"{n} ==> {Pare(n)}");
n = 103;
Console.WriteLine($"{n} ==> {Pare(n)}");
n = 1003;
Console.WriteLine($"{n} ==> {Pare(n)}");
n = 5;
Console.WriteLine($"{n} ==> {Pare(n)}");
n = 6;
Console.WriteLine($"{n} ==> {Pare(n)}");
n = 0;
Console.WriteLine($"{n} ==> {Pare(n)}");



//**************************************************
// Se citeste un vector de n numere (recursiv)
// Se elimina din fiecare numar cifrele impare. Daca numarul nu are cifre pare atunci rezultatul este -1 
// Se afieseaza elementele vecturului in ordine inversa (recursiv)
F();

void F()
{
	int n;
    Console.WriteLine("Introduceti numarul de elemente pe care vreti sa le procesati");
	n = int.Parse(Console.ReadLine());
	int[] v = new int[n];
	CitireVector(v, n);
	Inlocuire(v, n);
	AfisareInversVector(v, n);
}

void Inlocuire(int[] v, int n)
{
	if (n == 0)
		return;
	Inlocuire(v, n - 1);
	v[n - 1] = Pare(v[n - 1]);
}

void AfisareInversVector(int[] v, int n)
{
	if (n == 0)
		return;

    Console.Write($"{v[n - 1]} ");
	AfisareInversVector(v, n - 1);
}

void CitireVector(int[] v, int n)
{
	if (n == 0)
		return;
	CitireVector(v, n - 1);
    Console.WriteLine($"Introduceti elementul {n}");
	v[n - 1] = int.Parse(Console.ReadLine());
}


int Scor(int x, int y)
{
	if (x == 0 || y == 0)
		return 1;
	
	if(cache.ContainsKey((x, y)))
		return cache[(x, y)];
	int result = Scor(x - 1, y) + Scor(x, y - 1);
	cache[(x, y)] = result;

	return result;
}

int gcdR2(int a, int b)
{
	if (a == b)
		return a;
	else
	{
		if (a > b)
			return gcdR2(a - b, b);
		else
			return gcdR2(a, b - a);
	}
}

int gcdR(int a, int b)
{
	if (b == 0)
		return a;
	else
		return gcdR(b, a % b);
}

int gcd(int a, int b)
{
	int r;
	while(b != 0)
	{
		r = a % b;
		a = b;
		b = r;
	}
	return a; 
}
int gcd2(int a, int b)
{
    while (a != b)
    {
		if (a > b)
			a = a - b;
		else
			b = b - a;
    }
    return a;
}

int FactorialR(int n)
{
	if (n == 0)
		return 1;
	else
		return FactorialR(n - 1) * n;
}

int Factorial(int n)
{
    int p = 1;
	for (int i = 1; i <= n; i++)
	{
		p = p * i;
	}
	return p;
}
int Pare(int n)
{
    if(n < 10)
	{
		if (n % 2 == 0)
			return n;
		else
			return -1;
	}
	else
	{
		// 134 ->4
		int result = Pare(n / 10);
        int c = n % 10;
		if (c % 2 == 1)
			return result;
		else // ultima cifra este para
		{
			if (result == -1)
				return n % 10;
			else
				return result * 10 + n % 10;
		}
	}
}