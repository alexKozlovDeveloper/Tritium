using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public static class RaycastHelper
    {
        public static GameObject GetFirstHitForLayer(this RaycastHit2D[] hits, int layer)
        {
            foreach (var hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.layer == layer)
                    {
                        return hit.collider.gameObject;
                    }
                }
            }

            return null;
        }
    }
}
