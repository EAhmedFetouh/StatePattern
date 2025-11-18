using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.State
{
    public interface IState
    {
        string Name { get; }
        void Edit(NewDocument doc);
        void Submit(NewDocument doc);
        void Publish(NewDocument doc);
        void Reject(NewDocument doc);
        void Expire(NewDocument doc);
    }
}
