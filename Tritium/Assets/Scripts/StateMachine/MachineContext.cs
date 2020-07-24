using Assets.Scripts.StateMachine.Interfaces;
using Assets.Scripts.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    class MachineContext
    {
        private IState _currentState;

        private readonly Dictionary<string, IState> _states;

        public MachineContext(IEnumerable<IState> states, string initialState)
        {
            _states = new Dictionary<string, IState>();

            foreach (var state in states)
            {
                _states.Add(state.StateName, state);
            }

            SetState(initialState);
        }

        public void Update() 
        {
            _currentState.Update();
            _currentState.CheckTransition(this);
        }

        public void SetState(string newState)
        {
            //Debug.Log($"MachineContext: change state to '{newState}'");

            if (_states.Keys.Contains(newState))
            {
                _currentState = _states[newState];
                _currentState.Reset();
            }
        }
    }
}
