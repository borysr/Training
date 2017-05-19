using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.EvalServiceReference;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to run a client.");
            Console.ReadLine();
            EvalServiceClient client = new EvalServiceClient("BasicHttpBinding_IEvalService");
            Eval eval = new Eval {
                Comments = "Some comment",
                Submitter = "Somebody",
                TimeSubmitted = DateTime.Now
            };
            client.SubmitEval(eval);
            client.SubmitEval(eval);
            client.SubmitEval(eval);
            client.SubmitEval(eval);

            Eval[] evals = client.GetEvals();

            foreach (Eval ev in evals)
            {
                Console.WriteLine(ev.Comments);
            }
            Console.ReadLine();

        }
    }
}
