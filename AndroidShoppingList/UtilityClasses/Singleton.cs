

namespace AndroidShoppingList.UtilityClasses
{
    public class Singleton<T> where T : new()
    {
        private static T _instance;
        private static object syncLock = new Object();

        protected Singleton() { }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        _instance = new T();
                    }
                }

                return _instance;
            }
        }
    }
}
