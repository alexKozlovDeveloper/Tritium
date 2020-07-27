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
        public static GameObject GetFirstHitForLayer(this RaycastHit2D[] hits, int layer, IEnumerable<GameObject> ignoreList = null)
        {
            foreach (var hit in hits)
            {
                if (hit.collider == null)
                {
                    continue;
                }

                if (hit.collider.gameObject.layer != layer)
                {
                    continue;
                }

                if (ignoreList == null)
                {
                    return hit.collider.gameObject;
                }

                if (ignoreList.Contains(hit.collider.gameObject) == false)
                {
                    return hit.collider.gameObject;
                }
            }

            return null;
        }

        public static GameObject GetFirstHitForLayer(this RaycastHit2D[] hits, int layer, GameObject ignoreObject)
        {
            return GetFirstHitForLayer(hits, layer, new List<GameObject> { ignoreObject });
        }
    }
}
