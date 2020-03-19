namespace InvasionRPG.Scripts.Exceptions.Modifiers
{
    public abstract class ValueModifier : Modifier
    {
        public ValueModifier(int sortOrder) : base(sortOrder){}

        public abstract float Modify(float value);
    }
}