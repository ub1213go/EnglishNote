using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public static class FullService
    {
        private static string _asbName = Assembly.GetExecutingAssembly().GetName().Name;

        public static T GetService<T>()
        {
            typeof(T).GetType();

            Assembly assembly = Assembly.Load(_asbName);

            if(assembly == null)
            {
                throw new Exception("找無" + _asbName + ".dll");
            }

            string instanceName = typeof(T).Name;

            if (instanceName.StartsWith("I", StringComparison.OrdinalIgnoreCase))
            {
                instanceName = instanceName.replaceStartWith("I", "", true);
            }

            object instance = assembly.CreateInstance(_asbName + "." + instanceName);

            if(instance == null)
            {
                throw new Exception("空間" + _asbName + "沒有" + instanceName);
            }

            return (T)instance;
        }
    }
}
