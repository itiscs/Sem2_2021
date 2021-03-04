#include <fstream>
using namespace std;

void write_file()
{
	ofstream fout;

	fout.open("input.txt");
	srand(time(0));

	int count = rand() % 1000;
	fout << count << endl;

	int* a = new int[count];

	for (int i = 0; i < count; i++)
	{
		a[i] = rand() % 1000 - 500;
		fout << a[i] << " ";
	}

	fout.close();


}

void write_graph()
{
	ofstream fout;

	fout.open("graph.txt");
	srand(time(0));

	int count = 10 + rand() % 10;
	fout << count << endl;

	for (int i = 0; i < count; i++)
	{
		for (int j = 0; j < count; j++)
			if (i == j)
				fout << "0 ";
			else
				fout << rand() % 10 << " ";
		fout << endl;
	}

	fout.close();


}
int* read_graph(int& count)
{
	ifstream fin;

	fin.open("graph.txt");

	fin >> count;

	printf("count = %d\n", count);

	int* a = new int[count*count];

	int i = 0;
	while (!fin.eof())
	{
		fin >> a[i++];
	}
	printf("kolvo in file = %d\n", i-1);

	fin.close();
	
	return a;
}




int* read_file(int &count)
{
	ifstream fin;

	fin.open("input.txt");
	
	fin >> count;

	printf("count = %d\n", count);
	int* a = new int[count];
	int i = 0;
	while (!fin.eof())
	{
		fin>>a[i++];
	}
	printf("kolvo in file = %d\n", i-1);
	
	fin.close();
	int sum = 0;
	for (int i = 0; i < count; i++)
		sum += a[i];

	printf("Average = %d\n", sum/count);

	return a;
}



int main()
{

	setlocale(LC_ALL, "Russian");
	int* mas;
	int size=0;
	
	
	//write_file();
	//write_graph();

	//mas = read_file(size);
	mas = read_graph(size);

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			printf("%d ", mas[i * size + j]);
		}
		printf("\n");
	}
	printf("прочитали файл - %d\n", size);



	return EXIT_SUCCESS;
}