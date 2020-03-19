namespace InvasionRPG.Scripts.Exceptions.Modifiers
{
    public class AddValueModifier : ValueModifier
    {
        public readonly float ToAdd;
        
        public AddValueModifier(int sortOrder, float toAdd) : base(sortOrder)
        {
            ToAdd = toAdd;
        }

        public override float Modify(float value)
        {
            return value + ToAdd;
        }
    }
}