namespace Week5_84
{
    internal class Program
    {
        public class Solution
        {
            public int LargestRectangleArea(int[] heights)
            {
                int ans = 0; // 최종값
                int h = 0; // 세로
                int w = 0;  //가로
                Stack<int> stack = new Stack<int>(); // 빈스택

                for (int i = 0; i <= heights.Length; ++i)// 배열값 살피기, i는 가로길이가 된다.
                {
                    try // 스택 에러 대비 예외처리
                    {
                        Console.WriteLine(" " + stack.Peek() + " " + i);
                        while (stack.Count != 0 && (i == heights.Length || heights[stack.Peek()] > heights[i]))// 스택이 비지않고 &&(i값  == 배열의 길이 || 배열 맨위 값 > 현재 배열값)
                        {
                            h = heights[stack.Pop()]; // 높이는 배열의 맨 위값 빼오기
                            Console.WriteLine("현재 세로길이 : " + h);

                            //w = stack.Count == 0 ? i : i - stack.Peek() - 1; 나는 람다식이 싫다
                            if (stack.Count == 0)
                            {
                                w = i;  // 스택이 남은게 없으면, 가로에 i값
                            }
                            else
                            {
                                w = i - stack.Peek() - 1; // 스택이 남으면, [현재 w값  - 현재 스택의 맨위값 - 1;
                            }
                            Console.WriteLine("현재 가로길이 : " + w);

                            ans = Math.Max(ans, h * w); // 최대값 비교
                            Console.WriteLine("현재 넓이 : " + ans);
                        }

                    }
                    catch (Exception)
                    {

                    }
                    stack.Push(i); // 현재 i 값 스택 포함
                }
                return ans; // 반환
            }
        }

        static void Main(string[] args)
        {
            int[] j = new int[7] { 5, 5, 5, 10, 5, 5, 5 };
            Solution s = new Solution();
            int i = s.LargestRectangleArea(j);
            Console.WriteLine(i);
        }
    }
}