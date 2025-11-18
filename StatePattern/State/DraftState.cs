using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.State
{
    public class DraftState : IState
    {
        public string Name => "Draft";

        public void Submit(NewDocument doc)
        {
            Console.WriteLine("📤 Submitted for review.");
            doc.ChangeState(new UnderReviewState());
        }

        public void Edit(NewDocument doc)
        {
            Console.WriteLine("✏️ Editing the document...");
        }

        public void Expire(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot expire from Draft.");
        }

        public void Publish(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot publish directly from Draft.");
        }

        public void Reject(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot reject in Draft.");
        }
       
    }
}
