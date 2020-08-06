using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadnoughtController : MonoBehaviour
{
    public HealthController[] Towers;

    public bool IsDead
    {
        get
        {
            foreach (var tower in Towers)
            {
                if(tower.IsDead == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
