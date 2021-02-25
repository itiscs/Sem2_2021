#include <iostream>
#include <chrono>

using namespace std;

void merge(int arr[], int l, int m, int r)
{
    int n1 = m - l + 1;
    int n2 = r - m;

    // Create temp arrays
    int* L = new int[n1];
    int* R = new int[n2];

    // Copy data to temp arrays L[] and R[]
    for (int i = 0; i < n1; i++)
        L[i] = arr[l + i];
    for (int j = 0; j < n2; j++)
        R[j] = arr[m + 1 + j];

    // Merge the temp arrays back into arr[l..r]

    // Initial index of first subarray
    int i = 0;

    // Initial index of second subarray
    int j = 0;

    // Initial index of merged subarray
    int k = l;

    while (i < n1 && j < n2) {
        if (L[i] <= R[j]) {
            arr[k] = L[i];
            i++;
        }
        else {
            arr[k] = R[j];
            j++;
        }
        k++;
    }

    // Copy the remaining elements of
    // L[], if there are any
    while (i < n1) {
        arr[k] = L[i];
        i++;
        k++;
    }

    // Copy the remaining elements of
    // R[], if there are any
    while (j < n2) {
        arr[k] = R[j];
        j++;
        k++;
    }
}

// l is for left index and r is
// right index of the sub-array
// of arr to be sorted */
void mergeSort(int arr[], int l, int r) {
    if (l >= r) {
        return;//returns recursively
    }
    int m = l + (r - l) / 2;
    mergeSort(arr, l, m);
    mergeSort(arr, m + 1, r);
    merge(arr, l, m, r);
}



void BubbleSort(int* mas, int n)
{
	for(int j = n-1; j > 0; j--)
		for(int i = 0; i < j; i++)
			if (mas[i] > mas[i + 1])
			{
				int t = mas[i];
				mas[i] = mas[i + 1];
				mas[i + 1] = t;
			}
}

void ShowMas(int* mas, int length)
{
	for (int i = 0; i < length; i++)
		cout << mas[i] << " ";

}




int main()
{
	int k, N;

	cout << "Input N: ";
	cin >> N;
	//scanf_s("%d %d", &N, &k);

	int* mas = new int[N];

	for (int i = 0; i < N; i++)
		mas[i] = rand() % 100 - 50;
		
	
	//ShowMas(mas, N);
	
	
	using namespace std::chrono;

	high_resolution_clock::time_point t1 = high_resolution_clock::now();

	//BubbleSort(mas, N);
    mergeSort(mas, 0, N - 1);

	high_resolution_clock::time_point t2 = high_resolution_clock::now();

	cout << endl << "*******************************"<<endl;
	
	duration<double, std::milli> time_span = t2 - t1;

	std::cout << "It took me " << time_span.count() << " milliseconds.";
	std::cout << std::endl; 
	
	//ShowMas(mas, N);













}
