using Godot;

namespace InvasionRPG.Scripts.Exceptions.Modifiers
{
    public class MinValueModifier : ValueModifier
    {
        public readonly float Min;
        
        public MinValueModifier(int sortOrder, float min) : base(sortOrder)
        {
            Min = min;
        }

        public override float Modify(float value)
        {
            return Mathf.Min(value, Min);
        }
    }
}