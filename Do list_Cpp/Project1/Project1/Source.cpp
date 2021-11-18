//Пытаюсь разобраться в  теме обработка ошибок,но пока не очень получается.
//1
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <time.h>
#include <fstream>
#include <Windows.h>
#include <stdlib.h>
#include <stdio.h>

using namespace std;

class ElectronicDiary
{
private:
	char** array;
	int row;
	int col;
	int top;



	FILE* file;
public:

	ElectronicDiary()
	{
		array = new char*[200];
		for (int i = 0; i < 200; i++)
		{
			array[i] = new char[200];
		}
		row = 200;
		col = 200;
		top = 0;



	}

	ElectronicDiary(int row, int col)
	{
		try
		{
			if (row < 200 && col < 200)
			{
				throw 100;
			}
			this->row = row;
			this->col = col;
			array = new char*[this->row];
			for (int i = 0; i < this->row; i++)
			{
				array[i] = new char[this->col];
			}
			top = 0;

		}
		catch (int val)
		{
			cout << "Enter Error" << endl;
		}

	}

	void Add(const char date[12], const char message[40])
	{
		if (row <= top)
		{
			cout << "Diary Full\n";
		}
		else
		{
			char allmeassage[50];

			strcpy(allmeassage, date);
			strcat(allmeassage, " - ");
			strcat(allmeassage, message);

			strcpy(array[top], allmeassage);
			top++;
		}
	}

	void Save()
	{
		char** FileDir;


		FileDir = new char*[this->row];
		for (int i = 0; i < this->row; i++)
		{
			FileDir[i] = new char[200];
		}

		for (int i = 0; i < top; i++)
		{
			FileDir[i] = array[i];


		}


		file = fopen("Электронный дневник.txt", "a+");
		if (file != 0)
		{

			for (int i = 0; i < top; i++)
			{
				fputs("\n", file);
				fputs(FileDir[i], file);

			}


		}

		if (file == NULL)
		{
			cout << "1";
			system("pause");
			return;
		}
		if (file != NULL)
		{
			fseek(file, 0, SEEK_SET);
			cout << "\n--------+-+--------\n";
			char value[200];
			while (!feof(file))
			{
				fgets(value, 200, file);
				cout << value << endl;
			}
			cout << "\n---------++---------\n";
		}
		fclose(file);
		cin.get();

	}


	void Search_zamena(char message[40])
	{
		cout << "\n=======================\n";
		for (int i = 0; i < top; i++)
		{
			if (strstr(array[i], message) != NULL)

			{

				if (row <= top)
				{
					cout << "Diary Full\n";
				}


				else

				{
					char date[12];
					char message2[50];
					cout << " Введите дату для замены  " << "\n";
					cin >> date;
					cout << " Введите строку для замены  " << "\n";
					char Stroka2[40];


					cin >> Stroka2;

					strcpy(message2, date);
					strcat(message2, " - ");
					strcat(message2, Stroka2);

					strcpy(array[i], message2);
				}





			}

		}
		cout << "\n=======================\n";

	}


	void Show()
	{
		cout << "\n=======================\n";
		for (int i = 0; i < top; i++)
		{
			cout << array[i] << "\n";
		}
		cout << "\n=======================\n";
	}






	void DelStroka(char mess[40])
	{


		cout << "\n=======================\n";
		for (int i = 0; i < top; i++)
		{

			if (strstr(array[i], mess) != NULL)



			{
				if (row <= top)
				{
					cout << "Diary Full\n";
				}
				else
				{


					strcpy(mess, array[i]);//if (array[i+1]!="\0")
					strcpy(array[i], array[i + 1]);

					top--;


				}


			}

		}
		cout << "\n=======================\n";

	}

};




int main()
{
	SetConsoleCP(1251);// установка кодовой страницы win-cp 1251 в поток ввода
	SetConsoleOutputCP(1251); // установка кодовой страницы win-cp 1251 в поток вывода
	srand(time(NULL));
	setlocale(0, "");
	ElectronicDiary Dir;

	int choice;

	do
	{
		cout << endl << "Наименование действий: " << endl
			<< endl << "Выберите позицию:" << endl
			<< "1- Добавить " << endl

			<< "2- Вывод " << endl//
			<< "3- Поиск замена " << endl
			<< "4- Удаление " << endl

			<< "5- Сохранение в файле " << endl

			<< "6- Выход" << endl;

		cin >> choice;


		switch (choice) {
		case 1:
			cout << "Пропишите дату и действия" << "\n";
			char date[9];  char message[40];
			cin >> date >> message;
			Dir.Add(date, message);


			break;
		case 2:
			Dir.Show();

			break;
		case 3:
			cout << "Пропишите слово для поиска и замены  " << "\n";
			char message2[40];
			try
			{
				cin >> message2;
				if (strstr(message2, "#") != 0)
				{
					throw " Enter Error!";
				}
				if (strstr(message2, "$") != 0)
				{
					throw " Enter Error!";
				}
				if (strstr(message2, "@") != 0)
				{
					throw " Enter Error!";
				}
				Dir.Search_zamena(message2);

			}
			catch (const char* str)
			{
				cout << "Enter String" << endl;

			}


			break;
		case 4:

			cout << "Пропишите слово для удаления  " << "\n";
			char message3[40];


			try
			{
				cin >> message3;
				if (strstr(message3, "#") != 0)
				{
					throw " Enter Error!";
				}
				if (strstr(message3, "$") != 0)
				{
					throw " Enter Error!";
				}
				if (strstr(message3, "@") != 0)
				{
					throw " Enter Error!";
				}
				Dir.DelStroka(message3);

			}
			catch (const char* str)
			{
				cout << "Enter String" << endl;

			}



			break;
		case 5:
			cout << " Сохранение в файле " << endl;
			Dir.Save();
			break;



		/*default:
			cout << "Некорректный ввод" << endl;
			break;*/

		}

	} while (choice != 6);




	system("pause");
	return 0;

}