using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int> { 9, 8 ,7, 6, 5, 4, 3, 2, 1};
            Console.WriteLine("Input: " + PrintArray(array));
            var sortedArray = Sorting.QuickSort(array, 0, array.Count - 1);
            Newtonsoft.Json.Converters.BinaryConverter converter = new Newtonsoft.Json.Converters.BinaryConverter();
            Console.WriteLine("Output: " + PrintArray(sortedArray));
            Console.ReadKey();
        }

        static string PrintArray(List<int> array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in array)
                sb.Append(String.Format("{0} ", item.ToString()));
            return sb.ToString(); 
        }
    }
}
