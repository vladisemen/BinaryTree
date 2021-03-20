using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree
    {
        public Node Root { get; set; }

        public bool Add(int value)
        {
            Node before = null;
            Node after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data) //Если меньше то  влево
                    after = after.LeftNode;
                else if (value > after.Data) //Если больше то вправо
                    after = after.RightNode;
                else
                {
                    //То же самое значение
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)//Дерево пусто
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        /// <summary>
        /// найти элемент
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node Find(int value)
        {
            return this.Find(value, this.Root);
        }

        /// <summary>
        /// удалить элемент
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);

            // если значение совпадает с родительским значением, то это узел, который нужно удалить
            else
            {
                // узел только с одним дочерним элементом или без него
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // узел с двумя дочерними элементами: получить преемника inorder (наименьшего в правом поддереве) 
                parent.Data = MinValue(parent.RightNode);

                // удаление
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        /// <summary>
        /// минимальный элемент
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int MinValue(Node node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }
        /// <summary>
        /// максимальный элемент
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int MaxValue(Node node)
        {
            int manv = node.Data;

            while (node.RightNode != null)
            {
                manv = node.RightNode.Data;
                node = node.RightNode;
            }

            return manv;
        }

        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        /// <summary>
        /// получить глубину дерева
        /// </summary>
        /// <returns></returns>
        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        /// <summary>
        /// обход в глубину (прямой)
        /// </summary>
        /// <param name="parent"></param>
        public void TraversePreOrder(Node parent)
        {
            //корень
            //Пройти по левому поддереву
            //Пройти по правому поддереву
            if (parent != null)
            {
                // !! ДЛЯ ДРУГОГО ПРОХОДА - ПОМЕНТЬ СТРОКИ МЕСТАМИ!!
                Console.Write(parent.Data + " "); // эту 
                TraversePreOrder(parent.LeftNode); // с этой
                TraversePreOrder(parent.RightNode);
            }
        }

    }
}
