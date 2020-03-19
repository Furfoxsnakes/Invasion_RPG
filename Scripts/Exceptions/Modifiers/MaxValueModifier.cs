using Godot;

namespace InvasionRPG.Scripts.Exceptions.Modifiers
{
    public class MaxValueModifier : ValueModifier
    {
        public readonly float Max;
        
        public MaxValueModifier(int sortOrder, float max) : base(sortOrder)
        {
            Max = max;
        }

        public override float Modify(float value)
        {
            return Mathf.Max(value, Max);
        }
    }
}