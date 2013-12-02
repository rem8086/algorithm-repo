using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshallAlgoritm
{
    class Algoritm
    {
        AdjacencyMatrix previousMatrix;
        AdjacencyMatrix nextMatrix;
        
        public Algoritm(AdjacencyMatrix inputMatrix)
        {
            previousMatrix = (AdjacencyMatrix)inputMatrix.Clone();
            nextMatrix = (AdjacencyMatrix)inputMatrix.Clone();
        }

        public void AlgoritmStep()
        {
            for (int k = 0; k < previousMatrix.NodeCount; k++)
            {
                for (int i = 0; i < previousMatrix.NodeCount; i++)
                {
                    for (int j = 0; j < previousMatrix.NodeCount; j++)
                    {
                        if ((previousMatrix.GetElement(i,k).HasValue)&&(previousMatrix.GetElement(k,j).HasValue))
                        {
                            int prev = previousMatrix.GetElement(i,j) ?? Int32.MaxValue;
                            int next = previousMatrix.GetElement(i,k).Value + previousMatrix.GetElement(k,j).Value;
                            nextMatrix.SetElement(i,j, prev <= next ? prev : next); 
                        }
                    }
                }
                previousMatrix = (AdjacencyMatrix)nextMatrix.Clone();
            }
        }

        public string ShowResult()
        {
            return nextMatrix.ToString();
        }
    }
}
