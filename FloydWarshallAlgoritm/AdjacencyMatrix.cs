using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm 
{
    public class AdjacencyMatrix : ICloneable
    {
        int?[][] matrix;
        int nodesCount;

        public AdjacencyMatrix(int count)
        {
            matrix = new int?[count][];
            nodesCount = count;
            for (int i = 0; i < count; i++)
            {
                matrix[i] = new int?[count];
                for (int j = 0; j < count; j++)
                {
                    if (i == j) matrix[i][j] = 0; else matrix[i][j] = null;
                }
            }
        }
        public int NodeCount
        {
            get { return nodesCount; }
        }
        public int? GetElement(int i, int j)
        {
            if ((i>=matrix.Length)||(j>=matrix.Length))
            {throw new System.IndexOutOfRangeException("Big number");}
            return matrix[i][j];
        }
        public void SetElement(int i, int j, int weight)
        {
            if ((i >= matrix.Length) || (j >= matrix.Length))
            { throw new System.IndexOutOfRangeException("Big number"); }
            matrix[i][j] = weight;
        }

        public object Clone()
        {
            AdjacencyMatrix newMatrix = new AdjacencyMatrix(this.NodeCount);
            for (int i = 0; i < this.matrix.Length; i++)
            {
                for (int j = 0; j < this.matrix[i].Length; j++)
                {
                    if (this.matrix[i][j].HasValue) { newMatrix.AddEdge(i, j, this.matrix[i][j].Value); }
                }
            }
            return newMatrix;
        }

        void AddEdge(int start, int end, int weight)
        {
            if ((start>=matrix.Length)||(end>=matrix.Length))
            {throw new System.IndexOutOfRangeException("Big number");}
            matrix[start][end] = weight;
        }

        public override string  ToString()
        {
            string resultString = "";
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j].HasValue)
                    resultString += matrix[i][j] + " "; else resultString += Char.ToString((char)(byte)236) + " "; 
                }
                resultString += String.Format("\n");
            }
            return resultString;
        }
    }
}
