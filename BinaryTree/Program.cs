using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree binaryTree = new Tree();

            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(5);
            binaryTree.Add(8);

            int depth = binaryTree.GetTreeDepth();
            Console.WriteLine("глубина дерева");
            Console.WriteLine(depth);

            Console.WriteLine("прямой обход в глубину:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("Максимальный элемент :");
            int max = binaryTree.MaxValue(binaryTree.Root);
            Console.WriteLine(max);

            Console.WriteLine("Минимальный элемент :");
            int min = binaryTree.MinValue(binaryTree.Root);
            Console.WriteLine(min);

            binaryTree.Remove(7);
            binaryTree.Remove(8);

            Console.WriteLine("Обьход в глубину после удаления 7 и 8");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
