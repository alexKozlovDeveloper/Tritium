using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    class KeyStateController : MonoBehaviour
    {
        [SerializeField] private KeyCode[] keys;

        private Dictionary<KeyCode, bool> _keyStates;

        private void Start()
        {
            _keyStates = new Dictionary<KeyCode, bool>();

            foreach (var key in keys)
            {
                _keyStates.Add(key, false);
            }
        }

        void Update()
        {
            var updatedKeys = new Dictionary<KeyCode, bool>();

            foreach (var item in _keyStates)
            {
                if (Input.GetKeyDown(item.Key))
                {
                    updatedKeys.Add(item.Key, true);
                }
                else if (Input.GetKeyUp(item.Key))
                {
                    updatedKeys.Add(item.Key, false);
                }
                else
                {
                    updatedKeys.Add(item.Key, item.Value);
                }
            }

            _keyStates = updatedKeys;
        }

        public bool this[KeyCode key]
        {
            get 
            {
                if (_keyStates.Keys.Contains(key) == false)
                {
                    return false;
                }

                return _keyStates[key]; 
            }
        }
    }
}
