using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.State
{
    public class NeedsRevisionState : IState
    {
        public string Name => "NeedsRevision";

        public void Edit(NewDocument doc)
        {
            Console.WriteLine("✏️ Editing while addressing review comments.");
        }

        public void Submit(NewDocument doc)
        {
            Console.WriteLine("📤 Resubmitted for review.");
            doc.ChangeState(new UnderReviewState());
        }

        public void Publish(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot publish while it needs revision.");
        }

        public void Reject(NewDocument doc)
        {
            Console.WriteLine("❌ Already needs revision; cannot reject again.");
        }

        public void Expire(NewDocument doc)
        {
            Console.WriteLine("⏰ The document has expired.");
            doc.ChangeState(new ExpiredState());
        }
    }
}
