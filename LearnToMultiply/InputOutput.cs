using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LearnToMultiply
{
    internal class InputOutput
    {
        public List<Challenge> Questions { get; set; } = new List<Challenge>();
        public long TotalAnswerTime { get; set; }

        private void GetQuestions(int numberOfQuestions)
        {
            var generator = new Generator();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Questions.Add(generator.GenerateChallenge());
            }
        }
        public void AskQuestions()
        {
            var numberOfQuestions = 5;
            GetQuestions(numberOfQuestions);

            for (int i = 0; i < numberOfQuestions; i++)
            {
                AskQuestion(Questions[i]);
            }

            Console.WriteLine();
            Console.WriteLine($"Total time: {TotalAnswerTime}ms.");
        }

        private void AskQuestion(Challenge question)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int answer;

            do
            {
                Console.Write(question.Question);
                answer = int.Parse(Console.ReadLine());

                if (answer == question.Answer)
                {
                    stopwatch.Stop();
                    TotalAnswerTime += stopwatch.ElapsedMilliseconds;
                    Console.WriteLine($"Good! Response time: {stopwatch.ElapsedMilliseconds}ms");
                }
                else
                {
                    Console.WriteLine("Wrong. Try again!");
                } 
            } while (answer != question.Answer);
        }
    }
}
