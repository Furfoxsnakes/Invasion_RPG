using Godot;

namespace InvasionRPG.Scripts.Exceptions.Modifiers
{
    public class ClampValueModifier : ValueModifier
    {
        public readonly float Min;
        public readonly float Max;
        
        public ClampValueModifier(int sortOrder, float min, float max) : base(sortOrder)
        {
            Min = min;
            Max = max;
        }

        public override float Modify(float value)
        {
            return Mathf.Clamp(value, Min, Max);
        }
    }
}