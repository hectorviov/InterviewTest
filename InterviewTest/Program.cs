using System;
using System.Collections.Generic;

namespace InterviewTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestBrackets test = new();
            test.AddTestCase("{}");
            test.AddTestCase("}{");
            test.AddTestCase("{{}");
            test.AddTestCase("\"\"");
            test.AddTestCase("{abcdefghijklmnopqrstuvwxyz}");
            test.AddTestCase("fdsfasd{fsadfaerad}s");
            test.AddTestCase("ffhsdafha}dafdsafadsf{fsdafasf");
            test.AddTestCase("fdafha{dafdsafadsf{fsdafas}f");
            test.AddTestCase("fdafha{dafdsafadsf}fsdafas}f{");
            test.AddTestCase("fdafha{dafd{safadsf}fsdafas}f");
            test.AddTestCase("fdafha{dafd{safa}dsf}fsdafas}f");

            test.RunTests();
        }
    }

    internal class TestBrackets
    {
        private List<string> testCases;
        public TestBrackets()
        {
            this.testCases = new();
        }
        public void AddTestCase(string scenario)
        {
            this.testCases.Add(scenario);
        }
        public string GetTestCase(int index)
        {
            try
            {
                return this.testCases[index];
            } catch (ArgumentOutOfRangeException ex)
            {
                // Console.WriteLine(ex.Message);
                return ("Item does not exist.");
            }
        }
        public List<String> GetTestCases()
        {
            return this.testCases;
        }
        public void RunTests()
        {
            char openingBracket = '{';
            char closingBracket = '}';

            foreach (string testCase in this.testCases)
            {
                // We'll increase the sum if it's an opening bracket and decrease if closing,
                // the sum must be 0 for it to be true.
                int sum = 0;
                foreach (char character in testCase)
                {
                    if (character == openingBracket)
                    {
                        sum++;
                    } else if (character == closingBracket)
                    {
                        sum--;
                    }
                    // Check if the sum < 0, because if it goes below 0, it means a closing bracket appeared
                    // before it's corresponding opening bracket.
                    if (sum < 0)
                    {
                        break;
                    }
                }
                Console.WriteLine(testCase + " is " + (sum == 0 ? "True" : "False"));
            }
        }
    }
}