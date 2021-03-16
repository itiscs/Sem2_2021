#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main()
{
	ifstream f1("input.txt");

	//char str[100];

	string s = "abc def  abc  fgfgfgf";
	
	string s1(50,'f');

	int i = 0;
	while (i < s.length() && s[i] != ' ')
	{
		s1.push_back(s[i++]);
	}	

	cout << s1;

	//while(!f1.eof())
	//	getline(f1, s);

	/*cout << s<<endl;

	cout << s.length();
	
	for (int i = 0; i < s.length(); i++)
	{
		cout << s[i] << '\n';
	}*/

	


}