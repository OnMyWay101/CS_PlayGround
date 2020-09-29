using System;
using System.Collections.Generic;

namespace GraphAlgorithm
{
    /// <summary>
    /// 定点类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        //数据域
        public T Data { get; set; }

        public Node(T v)
        {
            Data = v;
        }
    }

    /// <summary>
    /// 图的接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGraph<T>
    {
        //获取定点数
        int GetNumOfVertex();

        //获取边的数量
        int GetNumOfEdge();

        //在两个顶点之间添加权为v的边或弧
        void SetEdge(Node<T> v1, Node<T> v2, int v);

        //删除两个顶点之间的边或弧
        void DelEdge(Node<T> v1, Node<T> v2);

        //判断两个顶点之间是否有边或弧
        bool IsEdge(Node<T> v1, Node<T> v2);

    }

    //无向图邻接矩阵类
    public class GraphAdjMatrix<T> : IGraph<T>
    {
        //顶点数组
        private Node<T>[] nodes;
        //边数目
        public int NumEdges{get; set;}
        //邻接矩阵数组
        private int[,] matrix;
        
        //构造器
        public GraphAdjMatrix(int n)
        {
            nodes = new Node<T>[n];
            matrix = new int[n, n];
            NumEdges = 0;
        }

        //获取索引为index的顶点信息
        public Node<T> GetNode(int index)
        {
            return nodes[index];
        }
        //设置索引为index的顶点信息
        public void SetNode(int index, Node<T> v)
        {
            nodes[index] = v;
        }

        //获取matrix[index1,index2]的值
        public int GetMatrix(int index1, int index2)
        {
            return matrix[index1, index2];
        }

        //设置matrix[index1,index2]的值
        public void SetMatrix(int index1, int index2)
        {
            matrix[index1, index2] = 1;
        }

        //获取顶点数目
        public int GetNumOfVertex()
        {
            return nodes.Length;
        }

        //获取边的数目
        public int GetNumOfEdge()
        {
            return NumEdges;
        }

        //判断v是否是图的顶点
        public bool IsNode(Node<T> v)
        {
            //遍历顶点数组
            foreach (Node<T> nd in nodes)
            {
                //如果顶点nd与v相等，则v是图的顶点，返回true;
                if (v.Equals(nd))
                    return true;
            }
            return false;
        }

        //获取顶点v在顶点数组中的索引
        public int GetIndex(Node<T> v)
        {
            int i = -1;
            //遍历顶点数组
            for (i = 0; i < nodes.Length; i++)
            {
                //如果顶点v与nodes[i]相等，则v是图的顶点，返回索引值i
                if (nodes[i].Equals(v))
                    return i;
            }
            return i;
        }

        //在顶点v1和v2之间添加权值为v的边
        public void SetEdge(Node<T> v1, Node<T> v2, int v)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            //不是无向图
            if (v != 1)
            {
                Console.WriteLine("Weight is not right!");
                return;
            }
            //矩阵是对称矩阵
            matrix[GetIndex(v1), GetIndex(v2)] = v;
            matrix[GetIndex(v2), GetIndex(v1)] = v;
            NumEdges++;
        }

        //删除顶点v1和v2之间的边
        public void DelEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            //v1和v2之间存在边
            if (matrix[GetIndex(v1), GetIndex(v2)] == 1)
            {
                //矩阵是对称矩阵
                matrix[GetIndex(v1), GetIndex(v2)] = 0;
                matrix[GetIndex(v2), GetIndex(v1)] = 0;
                NumEdges--;
            }
        }

        //判断顶点v1与v2之间是否存在边
        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return false;
            }
            //顶点v1与v2之间存在边
            if (matrix[GetIndex(v1), GetIndex(v2)] == 1)
                return true;
            else
                return false;
        }
    }
    
    //无向图邻接表结点类
    public class AdjListNode<T>
    {
        public int Adjvex{get; set;}//邻接顶点
        public AdjListNode<T> Next { get; set; }//下一个邻接表结点

        //构造器
        public AdjListNode(int vex)
        {
            Adjvex = vex;
            Next = null;
        }
    }

    //无向图邻接表顶点结点类
    public class VexNode<T>
    {
        public Node<T> Data{get; set;}//图的顶点
        public AdjListNode<T> FirstAdj{get; set;}//邻接表的第1个结点(邻接表是一个链表，通过第一个，可以找到后面所有的)

        //构造器
        public VexNode()
        {
            Data = null;
            FirstAdj = null;
        }
        public VexNode(Node<T> nd)
        {
            Data = nd;
            FirstAdj = null;
        }
        public VexNode(Node<T> nd, AdjListNode<T> aLNode)
        {
            Data = nd;
            FirstAdj = aLNode;
        }
    }

    //无向图邻接表及图的深度、广度优先遍历算法实现
    public class GraphAdjList<T> : IGraph<T>
    {
        //邻接表数组
        private VexNode<T>[] adjList;
        //顶点访问数组
        private int[] visited;

        //构造器
        public GraphAdjList(Node<T>[] nodes)
        {
            adjList = new VexNode<T>[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                adjList[i].Data = nodes[i];
                adjList[i].FirstAdj = null;
            }
            visited = new int[adjList.Length];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = 0;
            }
        }
        //索引器
        public VexNode<T> this[int index]
        { 
            get 
            {
                return adjList[index];
            }
            set
            {
                adjList[index] = value;
                return;
            }
        }

        //获取结点数目
        public int GetNumOfVertex()
        {
            return adjList.Length;
        }

        //获取边的数目
        public int GetNumOfEdge()
        {
            int i = 0;
            //遍历邻接表数组
            foreach (VexNode<T> nd in adjList)
            {
                AdjListNode<T> p = nd.FirstAdj;
                while (p != null)
                {
                    i++;
                    p = p.Next;
                }
            }
            return i / 2;
        }

        //判断v是否是图的顶点
        public bool IsNode(Node<T> v)
        {
            //遍历邻接表数组
            foreach (VexNode<T> nd in adjList)
            {
                //如果v等于nd的data，则v是图中顶点，返回true
                if (v.Equals(nd.Data))
                    return true;
            }
            return false;
        }

        //获取顶点v在邻接表数组中的索引
        public int GetIndex(Node<T> v)
        {
            int i = -1;
            //遍历邻接表数组
            for (i = 0; i < adjList.Length; i++)
            {
                //邻接表数组第i项的data值等于v，则顶点v的索引为i
                if (adjList[i].Data.Equals(v))
                    return i;
            }
            return i;
        }
        //在顶点v1和v2之间添加权值为v的边
        public void SetEdge(Node<T> v1, Node<T> v2, int v)
        {
            //v1或v2不是图顶点或者v1和v2之间存在边
            if (!IsNode(v1) || !IsNode(v2) || IsEdge(v1, v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            //权值不对
            if (v != 1)
            {
                Console.WriteLine("Weight is not right!");
                return;
            }
            //处理顶点v1的邻接表
            AdjListNode<T> p = new AdjListNode<T>(GetIndex(v2));
            //顶点v1没有邻接顶点
            if (adjList[GetIndex(v1)].FirstAdj == null)
                adjList[GetIndex(v1)].FirstAdj = p;
            else
            {
                p.Next = adjList[GetIndex(v1)].FirstAdj;
                adjList[GetIndex(v1)].FirstAdj = p;
            }
            //处理顶点v2的邻接表
            p = new AdjListNode<T>(GetIndex(v1));
            //顶点v2没有邻接顶点
            if (adjList[GetIndex(v2)].FirstAdj == null)
                adjList[GetIndex(v2)].FirstAdj = p;
            //顶点v2有邻接顶点
            else
            {
                p.Next = adjList[GetIndex(v2)].FirstAdj;
                adjList[GetIndex(v2)].FirstAdj = p;
            }
        }

        //删除顶点v1和v2之间的边
        public void DelEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            //顶点v1和v2之间有边
            if (IsEdge(v1, v2))
            {
                //处理顶点v1的邻接表中顶点v2的邻接表结点
                AdjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
                AdjListNode<T> pre = null;
                while (p != null)
                {
                    if (p.Adjvex != GetIndex(v2))
                    {
                        pre = p;
                        p = p.Next;
                    }
                }
                pre.Next = p.Next;
                //处理顶点v2的邻接表中的顶点v1的邻接表结点
                p = adjList[GetIndex(v2)].FirstAdj;
                pre = null;
                while (p != null)
                {
                    if (p.Adjvex != GetIndex(v1))
                    {
                        pre = p;
                        p = p.Next;
                    }
                }
                pre.Next = p.Next;
            }
        }
        //判断v2和v1之间是否存在边
        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return false;
            }
            AdjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
            while (p != null)
            {
                if (p.Adjvex == GetIndex(v2))
                    return true;
                p = p.Next;
            }
            return false;
        }

        //无向图的深度优先遍历算法实现
        public void DFS()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == 0)
                    DFSAL(i);
            }
        }
        //从某个顶点出发进行深度优先遍历
        public void DFSAL(int i)
        {
            visited[i] = 1;
            AdjListNode<T> p =
                adjList[i].FirstAdj;
            while (p != null)
            {
                if (visited[p.Adjvex] == 0)
                    DFSAL(p.Adjvex);
                p = p.Next;
            }
        }
        //无向图的广度优先遍历算法实现
        public void BFS()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == 0)
                {
                    BFSAL(i);
                }
            }
        }
        //从某个顶点出发进行广度优先遍历
        public void BFSAL(int i)
        {
            visited[i] = 1;
            Queue<int> qu = new Queue<int>(visited.Length);
            qu.Enqueue(i);
            while (qu.Count != 0)
            {
                int k = qu.Dequeue();
                AdjListNode<T> p = adjList[k].FirstAdj;
                while (p != null)
                {
                    if (visited[p.Adjvex] == 0)
                    {
                        visited[p.Adjvex] = 1;
                        qu.Enqueue(p.Adjvex);
                    }
                    p = p.Next;
                }
            }
        }
    }

    //无向网邻接矩阵类--普里姆算法
    public class NetAdjMatrix<T> : IGraph<T>
    {
        private Node<T>[] nodes;//顶点数组
        public int NumEdges{get; set;}//边的数目
        private int[,] matrix;//邻接矩阵数组

        //构造器
        public NetAdjMatrix(int n)
        {
            nodes = new Node<T>[n];
            matrix = new int[n, n];
            NumEdges = 0;
        }

        //获取索引为index的顶点的信息
        public Node<T> GetNode(int index)
        {
            return nodes[index];
        }

        //设置索引为index的顶点信息
        public void SetNode(int index, Node<T> v)
        {
            nodes[index] = v;
        }

        //获取matrix[index1,index2]的值
        public int GetMatrix(int index1, int index2)
        {
            return matrix[index1, index2];
        }
        //设置matrix[index1,index2]的值
        public void SetMatrix(int index1, int index2, int v)
        {
            matrix[index1, index2] = v;
        }
        //获取顶点数目
        public int GetNumOfVertex()
        {
            return nodes.Length;
        }
        //获取边的数目
        public int GetNumOfEdge()
        {
            return NumEdges;
        }
        //v是否是无向网的顶点
        public bool IsNode(Node<T> v)
        {
            //遍历顶点数组
            foreach (Node<T> nd in nodes)
            {
                //如果顶点nd与v相等，则v是图的顶点，返回true
                if (v.Equals(nd))
                    return true;
            }
            return false;
        }
        public int GetIndex(Node<T> v)
        {
            int i = -1;
            //遍历顶点数组
            for (i = 0; i < nodes.Length; i++)
            {
                //如果顶点nd与v相等，则v是图的顶点，返回索引值
                if (nodes[i].Equals(v))
                    return i;
            }
            return i;
        }
        //在顶点v1、v2之间添加权值为v的边
        public void SetEdge(Node<T> v1, Node<T> v2, int v)
        {
            //v1或v2不是无向往的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            //矩阵是对称矩阵
            matrix[GetIndex(v1), GetIndex(v2)] = v;
            matrix[GetIndex(v2), GetIndex(v1)] = v;
            ++NumEdges;
        }
        //删除v1和v2之间的边
        public void DelEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是无向网的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            //v1和v2之间存在边
            if (matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue)
            {
                //矩阵是对称矩阵
                matrix[GetIndex(v1), GetIndex(v2)] = int.MaxValue;
                matrix[GetIndex(v2), GetIndex(v1)] = int.MaxValue;
                --NumEdges;
            }
        }
        //判断v1和v2之间是否存在边
        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是无向网的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return false;
            }
            //v1和v2之间存在边
            if (matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue)
                return true;
            else//v1和v2之间不存在边
                return false;
        }

        //普里姆算法(Prim)=>得到最小生成树
        public int[] Prim()
        {
            int[] lowcost = new int[nodes.Length];//权值数组
            int[] closevex = new int[nodes.Length];//顶点数组
            int mincost = int.MaxValue;//最小权值
            //辅助数组初始化
            for (int i = 1; i < nodes.Length; i++)
            {
                lowcost[i] = matrix[0, i];
                closevex[i] = 0;
            }
            //某个顶点加入集合U
            lowcost[0] = 0;
            closevex[0] = 0;
            for (int i = 0; i < nodes.Length; i++)
            {
                int k = 1, j = 1;
                //选取权值最小的边和相应的顶点
                while (j < nodes.Length)
                {
                    if (lowcost[j] < mincost && lowcost[j] != 0)
                        k = j;
                    ++j;
                }
                //新顶点加入集合U
                lowcost[k] = 0;
                //重新计算该顶点到其余顶点的边的权值
                for (j = 1; j < nodes.Length; j++)
                {
                    if (matrix[k, j] < lowcost[j])
                    {
                        lowcost[j] = matrix[k, j];
                        closevex[j] = k;
                    }
                }
            }
            return closevex;
        }
    }
    //有向网的邻接矩阵类--狄克斯特拉算法
    public class DirecNetAdjMatrix<T> : IGraph<T>
    {
        private Node<T>[] nodes;//有向网的顶点数组
        private int numArcs;//弧的数目
        private int[,] matrix;//邻接矩阵数组
        //构造器
        public DirecNetAdjMatrix(int n)
        {
            nodes = new Node<T>[n];
            matrix = new int[n, n];
            numArcs = 0;
        }
        //获取索引为index的顶点信息
        public Node<T> GetNode(int index)
        {
            return nodes[index];
        }
        //设置索引为index的顶点信息
        public void SetNode(int index, Node<T> v)
        {
            nodes[index] = v;
        }
        //弧数目属性
        public int NumArcs { get => numArcs; set => numArcs = value; }
        //获取matrix[index1,index2]的值
        public int GetMatrix(int index1, int index2)
        {
            return matrix[index1, index2];
        }
        //设置matrix[index1,index2]的值
        public void SetMatrix(int index1, int index2, int v)
        {
            matrix[index1, index2] = v;
        }
        //获取顶点数目
        public int GetNumOfVertex()
        {
            return nodes.Length;
        }
        //获取弧的数目
        public int GetNumOfEdge()
        {
            return numArcs;
        }
        //判断v是否是网的顶点
        public bool IsNode(Node<T> v)
        {
            //遍历顶点数组
            foreach (Node<T> nd in nodes)
            {
                //如果顶点nd与v相等，则v是图的顶点，返回true
                if (v.Equals(nd))
                    return true;
            }
            return false;
        }
        //获取v在顶点数组中的索引
        public int GetIndex(Node<T> v)
        {
            int i = -1;
            //遍历顶点数组
            for (i = 0; i < nodes.Length; i++)
            {
                //如果顶点nd与v相等，则v是图的顶点，返回索引值
                if (nodes[i].Equals(v))
                    return i;
            }
            return i;
        }
        //在v1和v2之间添加权为v的弧
        public void SetEdge(Node<T> v1, Node<T> v2, int v)
        {
            //v1或v2不是网的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            matrix[GetIndex(v1), GetIndex(v2)] = v;
            ++numArcs;
        }
        //删除v1和v2之间的弧
        public void DelEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是网的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return;
            }
            //v1和v2之间存在弧
            if (matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue)
            {
                matrix[GetIndex(v1), GetIndex(v2)] = int.MaxValue;
                --numArcs;
            }
        }
        //判断v1和v2之间是否存在弧
        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            //v1或v2不是网的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Console.WriteLine("Node is not belong to Graph!");
                return false;
            }
            //v1和v2之间存在弧
            if (matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue)
                return true;
            else
                return false;
        }
        //狄克斯特拉算法
        public void Dijkstra(ref bool[,] pathMatricArr,
            ref int[] shortPathArr,Node<T> n)
        {
            int k = 0;
            bool[] final = new bool[nodes.Length];
            //初始化
            for (int i = 0; i < nodes.Length; i++)
            {
                final[i] = false;
                shortPathArr[i] = matrix[GetIndex(n), i];
                for (int j = 0; j < nodes.Length; j++)
                {
                    pathMatricArr[i, j] = false;
                }
                if (shortPathArr[i] != 0 && shortPathArr[i] < int.MaxValue)
                {
                    pathMatricArr[i, GetIndex(n)] = true;
                    pathMatricArr[i, i] = true;
                }
            }
            //n为源点
            shortPathArr[GetIndex(n)] = 0;
            final[GetIndex(n)] = true;
            //处理从源点到其余顶点的最短路径
            for (int i = 0; i < nodes.Length; i++)
            {
                int min = int.MaxValue;
                //比较从源点到其余顶点的路径长度
                for (int j = 0; j < nodes.Length; j++)
                {
                    //从源点到j顶点的最短路径还没有找到
                    if (!final[j])
                    {
                        //从源点到j顶点的路径长度最小
                        if (shortPathArr[j] < min)
                        {
                            k = j;
                            min = shortPathArr[j];
                        }
                    }
                }
                //源点到顶点k的路径长度最小
                final[k] = true;
                //更新当前最短路径及距离
                for (int j = 0; j < nodes.Length; j++)
                {
                    if (!final[j] && (min + matrix[k, j] < shortPathArr[j]))
                    {
                        shortPathArr[j] = min + matrix[k, j];
                        for (int w = 0; w < nodes.Length; w++)
                        {
                            pathMatricArr[j, w] = pathMatricArr[k, w];
                        }
                        pathMatricArr[j, j] = true;
                    }
                }
            }
        }
}
