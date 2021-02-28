using System;

namespace AuthorProblem

{
    [AuthorAttribute("Ventsi")]
    class StartUp
    {
        [AuthorAttribute("Gosho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }

}
