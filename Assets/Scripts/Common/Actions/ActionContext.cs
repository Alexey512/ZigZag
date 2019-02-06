using System.Collections.Generic;

namespace Assets.Scripts.Common.Actions
{
    public class ActionContext
    {
        private static ActionContext _global = new ActionContext();

        public ActionContext Global => _global;

        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        public T GetValue<T>(string name)
        {
            object value;
            if (_values.TryGetValue(name, out value))
                return (T)value;
            return default(T);
        }

        public void SetValue(string name, object value)
        {
            _values[name] = value;
        }

        public void Clear()
        {
            _values.Clear();
        }
    }
}
