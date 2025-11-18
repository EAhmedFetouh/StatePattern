using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.State
{
    public class RejectedState : IState
    {
        public string Name => "Rejected";

        public void Edit(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot edit a rejected document.");
        }

        public void Submit(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot submit a rejected document. Reset to Draft first.");
        }

        public void Publish(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot publish a rejected document.");
        }

        public void Reject(NewDocument doc)
        {
            Console.WriteLine("ℹ️ Already rejected.");
        }

        public void Expire(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot expire a rejected document.");
        }
    }
}
