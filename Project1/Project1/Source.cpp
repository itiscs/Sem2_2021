#include <iostream>
//#define N 10

using namespace std;

int sumArr(int* a, int length)
{
	int sum = 0;
	for (int i = 0; i < length; i++)
		sum += a[i];
	return sum;

}


void swap(int &k, int &l)
{
	int m = l;
	l = k;
	k = m;
}

void swapByRef(int* k, int* l)
{
	int m = *l;
	*l = *k;
	*k = m;
}




int main(int argc, char** argv)
{
	const int N = 10; 
	int a[N];

	int* b;   // указатель на переменную типа int
	char* h;
	
	b = new int[N];
	//srand(time(0));
	
	for (int i = 0; i < N; i++)
		b[i] = rand() % 100;
		
	for (int i = 0; i < N ; i++)
		cout << b[i] << ' ';
	
	cout << sumArr(b, N);

	printf("Hello world!\n");
	
	int k = 5, m = 7;
	//scanf_s("%d", &k);   //читаем целое число в переменную k
	//cin >> k;
	cout << k << ' ' << m << endl;
	swap(k, m);
	//swapByRef(&k, &m);
	cout << k << ' ' << m << endl;

	double x, y ;
	double* px, *py;

	x = 2.01;
	y = x;

	px = &x;    // & - операция взятия адреса переменная 
	py = px;
	*px = *px + 1;     //* - получение значения переменной по адресу
	
	//printf("px = %pf\n", px);

	//px += 1;

	printf("k = %i x = %f  px = %pf  %s\n", k, *py, px, "abc");

	k -= x;

	cout << "Hello Danil " << k << endl;

	
	delete b;

	return EXIT_SUCCESS;
}