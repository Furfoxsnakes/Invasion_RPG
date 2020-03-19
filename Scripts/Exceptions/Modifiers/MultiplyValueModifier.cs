namespace InvasionRPG.Scripts.Exceptions.Modifiers
{
    public class MultiplyValueModifier : ValueModifier
    {
        public readonly float ToMultiply;
        
        public MultiplyValueModifier(int sortOrder, float toMultiply) : base(sortOrder)
        {
            ToMultiply = toMultiply;
        }

        public override float Modify(float value)
        {
            return value * ToMultiply;
        }
    }
}