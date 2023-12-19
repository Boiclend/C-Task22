// Дана матрица. Найти сумму элементов в тех столбцах, которые не содержат отрицательные элементы.
// Количество столбцов и строк матрицы должен вводить пользователь. 
// По введенным данным, динамически, должна выделиться память под матрицу. 
// Матрицу заполнять случайными значениями, как отрицательными так и положительными.


int Message(string text) { 
    Console.WriteLine(text);
    int num = int.Parse(Console.ReadLine());
    return num;
}

int[,] FillArray(int r, int c) // заполнение матрицы
{
    Random rnd = new Random();
    int[,] arr = new int[r,c];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i,j] = rnd.Next(-1,9);
        }
    }
    return arr;
}

void PrintArray(int[,] arr) { // печать матрицы
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,3}", arr[i, j])); // красивый вывод матрицы
        }
        Console.WriteLine();
    }
}

void FindSummForPositiveColumns(int[,] arr) { // поиск столбцов без отрицательных чисел и вывод их сумм
    int count = 0;
    int summ = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        if(arr[i,count] >= 0) 
        {
            summ = summ + arr[i,count];
        } 
        else
        {
            count++;
            i = -1;
            summ = 0;
        }
        if (i == arr.GetLength(0) - 1) 
        {
            Console.WriteLine($"Столбец {count + 1} сумма = {summ}");
            summ = 0;
            i = -1;
            count++;
        }
       if(count == arr.GetLength(1))
        {
        break;
        }
    }
}

int rows = Message("Введите количество строк");
int columns = Message("Введите количество столбцов");
int[,] MyArray = FillArray(rows,columns);
Console.WriteLine();
PrintArray(MyArray);
Console.WriteLine();
FindSummForPositiveColumns(MyArray);
