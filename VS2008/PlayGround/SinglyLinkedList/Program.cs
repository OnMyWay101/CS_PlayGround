using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList list = new LinkList();
            char ch;
            do 
            {
                Console.WriteLine("Singly LinkList Operations");
                Console.WriteLine("1.insert at begining");
                Console.WriteLine("2.insert at end");
                Console.WriteLine("3.insert at position");
                Console.WriteLine("4.delete at position");
                Console.WriteLine("5.check empty");
                Console.WriteLine("6.get size");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter interger element to insert");
                        list.InsertAtStart(int.Parse(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Enter interger element to insert");
                        list.InsertAtEnd(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("Enter interger element to insert");
                        int value = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter position");
                        int pos = int.Parse(Console.ReadLine());
                        list.InsertAtPos(value, pos);
                        break;
                    case 4:
                        Console.WriteLine("Enter interger position to delete");
                        list.DeleteAtPos(int.Parse(Console.ReadLine()));
                        break;
                    case 5:
                        Console.WriteLine("Empty status = " + list.IsEmpty().ToString());
                        break;
                    case 6:
                        Console.WriteLine("Size = {0}", list.GetSize());
                        break;
                    default:
                        Console.WriteLine("Wrong Entry!");
                        break;
                }
                list.Display();
                Console.WriteLine("Do you want to continue (Type Y or N)");
                ch = Console.ReadLine()[0];
            } while (ch == 'Y' || ch == 'y');
            Console.ReadLine();
        }
    }

    class Node
    {
        private int _data;
        private Node _nextNode;

        public Node(int data)
        {
            _data = data;
            _nextNode = null;
        }

        public void SetNextNode(Node node)
        {
            _nextNode = node;
        }

        public Node GetNextNode()
        {
            return _nextNode;
        }
        public int GetValue()
        {
            return _data;
        }
    }

    class LinkList
    {
        private Node _start;
        private Node _end;
        private int _size;

        public LinkList()
        {
            _start = null;
            _end = null;
            _size = 0;
        }

        public bool IsEmpty()
        {
            return (_size == 0) ? true : false;
        }

        public int GetSize()
        {
            return _size;
        }

        public void InsertAtStart(int value)
        {
            var newNode = new Node(value);

            newNode.SetNextNode(_start);

            if (_start == null)
            {//当LinkList为空时
                _end = newNode;
            }
            _start = newNode;
            _size++;
        }
        public void InsertAtEnd(int value)
        {
            if (_start == null)
            {//当LinkList为空时
                InsertAtStart(value);
            }
            var newNode = new Node(value);
            _end.SetNextNode(newNode);
            _end = newNode;
            _size++;
        }

        /// <summary>
        /// 往固定位置添加节点，节点在位置之前
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pos"></param>
        public void InsertAtPos(int value, int pos)
        {
            //当LinkList为空时
            if (_start == null)
            {
                InsertAtStart(value);
                return;
            }
            //int forwardPos =  (pos >= _size ? _size - 1 : pos);   //添加的前面那个点位置
            //Node newNode = new Node(value);

            //Node forwardNode = _start;
            //for (int i = 0; i != forwardNode; i++)
            //{
            //    forwardNode = forwardNode.GetNextNode();
            //}
            //Node backNode = forwardNode.GetNextNode();

            //forwardNode.SetNextNode(newNode);
            //newNode.SetNextNode(backNode);

            int backPos = (pos > _size ? _size : pos);   //添加的后面那个点位置，包含末尾一个null假元素
            Node forwardNode = _start;
            Node backNode = _start;

            for (int i = 0; i != backPos; i++)
            {
                forwardNode = backNode;
                backNode = backNode.GetNextNode();
            }
            //在头
            if (backNode == _start)
            {
                InsertAtStart(value);
                return;
            }
            //在尾
            if (forwardNode == _end)
            {
                InsertAtEnd(value);
                return;
            }
            //在中间
            Node newNode = new Node(value);
            
            forwardNode.SetNextNode(newNode);
            newNode.SetNextNode(backNode);

            _size++;
        }

        public void DeleteAtPos(int pos)
        {
            Node forwardNode = _start;
            Node deleteNode = _start;

            if (pos >= _size || pos < 0)
            {
                Console.WriteLine("DeleteAtPos：无对应位置！");
                return;
            }

            for (int i = 0; i != pos; i++)
            {
                forwardNode = deleteNode;
                deleteNode = deleteNode.GetNextNode();
            }
         
            if (deleteNode == _start)
            {//deleteNode为_start
                _start = deleteNode.GetNextNode();
            }
            else
            {
                forwardNode.SetNextNode(deleteNode.GetNextNode());
            }
            _size--;
        }

        public void Display()
        {
            Node current = _start;
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine("Node({0}):{1}", i, current.GetValue());
                current = current.GetNextNode();
            }
        }
    }
}
