using System.Globalization;
using System.Security.Cryptography;

public static class Program
{
    public static int FindLongestSubsequence(IEnumerable<int> enteros)
    {
        enteros = enteros.Order();
        HashSet<List<int>> subsequence = new();
        for (int i = 0; i < enteros.Count() * 2; i++)
        {
            List<int> usados = new();
            List<int> sequence = new();
            for(int j = 0; j < enteros.Count(); j++){
                int a = RandomNumberGenerator.GetInt32(0,enteros.Count());
                if(!usados.Any(e => e ==a )){
                    usados.Add(a);
                    sequence.Add(enteros.ToArray()[a]);
                }
            } 
            subsequence.Add(sequence.Order().ToList());
            usados.Clear();
        }
        List<int> Sumas = new();
        foreach(var a in subsequence){
            int sum = 0;
            for(int j = 0; j < a.Count(); j++){
                if(j < a.Count() - 1)sum += a[j+1] - a[j];
            }
            if(sum % 2 == 0){
                Sumas.Add(a.Count());
            }
        }
        return Sumas.OrderDescending().ToArray()[0];
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Ingresa el numero");
        int a = int.Parse(Console.ReadLine());
        List<int> arr = new();
        for(int i = 0; i < a; i++){
            Console.WriteLine("Ponga un numero para la secuencia");
            arr.Add(int.Parse(Console.ReadLine()));
        }
        Console.WriteLine(FindLongestSubsequence(arr));
    }
}