using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.State
{
    public class UnderReviewState : IState
    {
        public string Name => "UnderReview";

        public void Edit(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot edit while under review.");
        }

        public void Submit(NewDocument doc)
        {
            Console.WriteLine("❌ Already under review.");
        }

        public void Publish(NewDocument doc)
        {
            Console.WriteLine("✅ Published.");
            doc.ChangeState(new PublishedState());
        }

        public void Reject(NewDocument doc)
        {
            Console.WriteLine("🤔 Choose rejection type:");
            Console.WriteLine("1) Final Reject");
            Console.WriteLine("2) Needs Revision");
            Console.Write("> ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("❌ Document permanently rejected.");
                doc.ChangeState(new RejectedState());
            }
            else if (choice == "2")
            {
                Console.WriteLine("🔁 Document needs revision.");
                doc.ChangeState(new NeedsRevisionState());
            }
            else
            {
                Console.WriteLine("⚠️ Invalid choice. No change.");
            }
        }

        public void Expire(NewDocument doc)
        {
            Console.WriteLine("⏰ The document has expired.");
            doc.ChangeState(new ExpiredState());
        }
    }
}