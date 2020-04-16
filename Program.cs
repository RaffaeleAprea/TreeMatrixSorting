using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> Nodes = new List<List<string>> ();
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });
            Nodes.Add(new List<string> { "aaa", "aaa", "aaa", "aaa" });

            Nodes[0][0] = "h01"; Nodes[0][1] = "g01";  Nodes[0][2] = "x-1";  Nodes[0][3] = "###";
            Nodes[1][0] = "h01"; Nodes[1][1] = "a01";  Nodes[1][2] = "d01";  Nodes[1][3] = "x-2";
            Nodes[2][0] = "h02"; Nodes[2][1] = "a02";  Nodes[2][2] = "x-3";  Nodes[2][3] = "###";
            Nodes[3][0] = "h01"; Nodes[3][1] = "g01";  Nodes[3][2] = "f01";  Nodes[3][3] = "x-1";
            Nodes[4][0] = "h01"; Nodes[4][1] = "g01";  Nodes[4][2] = "x-3";  Nodes[4][3] = "###";
            Nodes[5][0] = "h02"; Nodes[5][1] = "d01";  Nodes[5][2] = "d01";  Nodes[5][3] = "x-1";
            Nodes[6][0] = "h01"; Nodes[6][1] = "d02";  Nodes[6][2] = "x-9";  Nodes[6][3] = "###";
            Nodes[7][0] = "h02"; Nodes[7][1] = "a01";  Nodes[7][2] = "x-8";  Nodes[7][3] = "###";
            Nodes[8][0] = "h01"; Nodes[8][1] = "d01";  Nodes[8][2] = "d01";  Nodes[8][3] = "x-9";
            Nodes[9][0] = "h01"; Nodes[9][1] = "g01";  Nodes[9][2] = "f01";  Nodes[9][3] = "x-2";

      


            for (int i=0; i <10; i++)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3}", Nodes[i][ 0], Nodes[i][ 1], Nodes[i][ 2], Nodes[i][3]));
            }
            Console.WriteLine("");
            MatrixColumnSorting(0, 9, ref Nodes,0, new List<int>(),4);
            Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3}", Nodes[i][0], Nodes[i][1], Nodes[i][2], Nodes[i][3]));
            }
            Console.ReadLine();
        }

        private static void MatrixColumnSorting(int firstIndex, int lastIndex, ref List<List<string>> Nodes, int colFixed, List<int> blackList,int matrixColNumber)
        {
            List<string> list = new List<string>();
            Dictionary < string ,List<int>> list0 = new Dictionary<string, List<int> > ();
            List<string> temp_row = new List<string>();

            
            int firstIndex2 = firstIndex;
            int lastIndex2 = firstIndex2;

            list.Add((Nodes[firstIndex])[colFixed]);
            list0.Add((Nodes[firstIndex])[colFixed],new List<int> { 0,0 });

            for (int elem = 0; elem < list.Count;elem++)
            {
                list0[list[elem]][0] = firstIndex2;
                
                for (int row = firstIndex; row <= lastIndex; row++)
                {
                    //if (matrixColNumber > colFixed)  // && (!(blackList.Contains(row))  
                    //{
                        if (list.Contains((Nodes[row])[colFixed]))
                        {

                            if ((row > lastIndex2) && ((Nodes[row])[colFixed].Equals(list[elem])))
                            {
                                
                                lastIndex2++;
                                if (row > lastIndex2)
                                {
                                   // for (; blackList.Contains(lastIndex2); lastIndex2++) ; //avoiding to point void cells of the matrix
                                }

                                /*Swap*/
                                temp_row = Nodes[row];
                                Nodes[row] = Nodes[lastIndex2];  //dovrebbe funzionare anche per un'identità
                                Nodes[lastIndex2] = temp_row;

                            }
                        }
                        else
                        {
                            if (row > lastIndex2)
                            {
                                list.Add((Nodes[row])[colFixed]);

                                list0.Add((Nodes[row])[colFixed], new List<int> { 0, 0 });
                            }
                        }
                    //}
                    //else
                    //{
                    //    //blackList.Add(row);
                    //}
                }
    
                     list0[list[elem]][1] = lastIndex2;

                    //lastIndex2++;
                    firstIndex2 = lastIndex2 + 1;

                //Console.WriteLine(list.Count);
            }
            foreach (string elem in list0.Keys)
            {
               // Console.WriteLine(elem + "= > " +list0[elem][0] + " ; " + list0[elem][1]);

            }
            
            foreach (string elem in list0.Keys)
            {
               
                if (( colFixed+1<matrixColNumber) && (list0[elem][0] < list0[elem][1]))//((matrixRowIndex > colFixed) && (list0[elem][0] < list0[elem][1]))
                {
                    //Console.WriteLine(list0[elem][0]+ " ; "+ list0[elem][1]);
                    MatrixColumnSorting(list0[elem][0], list0[elem][1], ref Nodes, colFixed + 1, blackList, matrixColNumber);
                }
            }
            //foreach (int elem in blackList)
            //{
            //    Console.WriteLine("black :" + elem );

            //}
        }
    }
}
