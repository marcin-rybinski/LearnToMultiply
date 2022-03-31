using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnToMultiply
{
    public class Generator
    {
        public Challenge GenerateChallenge()
        {
            Random rnd = new Random();
            var a = rnd.Next(1, 11);
            var b = rnd.Next(1, 11);
            return new Challenge { Question = $"What's {a} x {b}? -> ", Answer = a * b };
        }
    }
}
