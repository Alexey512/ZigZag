namespace Assets.Scripts.Common.Actions
{
    public class SharedValue<T> where T: struct
    {
        public T Value;

        public SharedValue(T value)
        {
            Value = value;
        }
    }
}
