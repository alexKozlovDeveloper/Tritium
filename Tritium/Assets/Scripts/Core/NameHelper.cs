using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core
{
    public static class NameHelper
    {
        public static string GetRandomName()
        {
            if(loop == 0)
            {
                return names[GetNextIndex()];
            }
            else
            {
                return names[GetNextIndex()] + $"_{loop}";
            }            
        }

        private static int GetNextIndex()
        {
            if(currentIndex >= names.Length)
            {
                currentIndex = 0;
                loop++;
            }

            return currentIndex++;
        }
        private static int loop = 0;
        private static int currentIndex = 0;
        private static string[] names = new string[] 
        {
            "James",
            "John",
            "Robert",
            "Michael",
            "William",
            "David",
            "Richard",
            "Joseph",
            "Thomas",
            "Charles",
            "Christopher",
            "Daniel",
            "Matthew",
            "Anthony",
            "Donald",
            "Mark",
            "Paul",
            "Steven",
            "Andrew",
            "Kenneth",
            "Joshua",
            "George",
            "Kevin",
            "Brian",
            "Edward",
            "Ronald",
        };
    }
}
