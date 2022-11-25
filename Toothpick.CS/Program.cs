/*
 将15根牙签
分成三行
每行自上而下（其实方向不限）分别是3、5、7根
安排两个玩家，每人可以在一轮内，在任意行拿任意根牙签，但不能跨行
拿最后一根牙签的人即为输家
 */
var list = new List<List<int>> {
    new List<int> { 1, 1, 1 },
    new List<int> { 1, 1, 1,1,1 },
    new List<int> { 1, 1, 1,1,1,1,1 },
};
string msg = "请选择你要挑选的行(注：只能选择1、2、3行)";
int rowIndex = 0;
bool isEnd = false;
while (!isEnd)
{
    Console.WriteLine(msg);
    string? row = Console.ReadLine();
    while (row == null || !int.TryParse(row, out rowIndex) || (rowIndex > 3 || rowIndex < 1))
    {
        Console.WriteLine(msg);
        row = Console.ReadLine();
    }
    int beginCount = list[rowIndex - 1].Where(c => c == 1).Count();
    int times = 0;
    for (int i = 0; i < list[rowIndex - 1].Count; i++)
    {
        var indexValue = list[rowIndex - 1][i];
        if (indexValue == 0) continue;
        if (times == 2) break;
        list[rowIndex - 1][i] = 0;
        times++;
    }
    int endCount = list[rowIndex - 1].Where(c => c == 1).Count();
    if (endCount == 1)
    {
        Console.WriteLine("你输了(you lose)");
        isEnd = true;
    }
}


