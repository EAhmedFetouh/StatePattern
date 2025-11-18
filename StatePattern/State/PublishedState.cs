using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.State
{
    internal class PublishedState : IState
    {
        public string Name => "Published";

        public void Edit(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot edit a published document.");
        }

        public void Submit(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot submit after publishing.");
        }

        public void Publish(NewDocument doc)
        {
            Console.WriteLine("ℹ️ Already published.");
        }

        public void Reject(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot reject a published document.");
        }

        public void Expire(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot expire a published document.");
        }
    }
}
