using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    class DictionaryHelper
    {
        public static string GetSortedResult(Dictionary<GameObject, int> items)
        {
            var result = new StringBuilder();

            var itemsList = items.ToList();

            itemsList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            foreach (var item in itemsList)
            {
                result.Append($"{item.Key.name}: {item.Value}{Environment.NewLine}");
            }

            return result.ToString();
        }
    }
}
