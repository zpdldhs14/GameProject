using System;
using System.Collections.Generic;
using System.Linq;

namespace Froxy
{
    public class Structure
    {
        static void Main()
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                string[] input = Console.ReadLine().Split();
                int n = int.Parse(input[0]);
                int m = int.Parse(input[1]);
                
                //문서들의 중요도를 입력받음.
                List<int> priorities = Console.ReadLine().Split().Select(int.Parse).ToList();
                
                //문서들의 원래 위치와 중요도를 큐에 저장
                Queue<int> queue = new Queue<int>(priorities); //[1,1,9,1,1,1]
                //각 문서의 원래 위치를 기록하기 위한 큐
                Queue<int> indexQueue = new Queue<int>(Enumerable.Range(0, n)); //[0,1,2,3,4,5]
                
                // m = 0 -> 내가 찾는 문서는 첫 번째 문서
                
                //각 문서를 하나씩 처리하면서, 중요도가 가장 높은 문서를 출력하거나 뒤로 보내는 작업.
                int printOder = 0;
                while (queue.Count > 0)
                {
                    //현재 가장 앞에 있는 문서를 확인
                    int currentPriority = queue.Dequeue(); // 1
                    int currentIndex = indexQueue.Dequeue(); // 0
                    
                    //중요도가 더 높은 문서가 큐에 남아있는지 확인.
                    //[9,1,1,1,1,1], [2,3,4,5,0,1]
                    //[1,1,1,1,1], [3,4,5,0,1]
                    //printOrder = 1
                    /*
                        [1,1,1,1], [4,5,0,1] , printOrder = 2
                        [1,1,1], [5,0,1], printOrder = 3
                        [1,1], [0,1], printOrder = 4
                        
                     
                     */
                    if (queue.Any(p => p > currentPriority)) // 중요도가 9가 존재하므로 1를 뒤로 보낸다.
                    {
                        //중요도가 높은 문서가 있는 경우에는 큐의 뒤로 이동.
                        queue.Enqueue(currentPriority);
                        indexQueue.Enqueue(currentIndex);
                    }
                    else
                    {
                        //현재 문서를 인쇄
                        printOder++; // 1
                        
                        //내가 궁금한 문서라면 출력 순서를 기록
                        if (currentIndex == m)
                        {
                            Console.WriteLine(printOder); //5
                            break;
                        }
                    }
                }
            }
        }
    }
}