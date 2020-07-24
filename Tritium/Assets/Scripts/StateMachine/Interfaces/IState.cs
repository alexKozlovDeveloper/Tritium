using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachine.Interfaces
{
    interface IState
    {
        string StateName { get; }
        void Reset();
        void Update();
        void CheckTransition(MachineContext context);
    }
}
