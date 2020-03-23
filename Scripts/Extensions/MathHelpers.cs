using Godot;
using System;

public static class MathHelpers
{
    // Returns a decimal between 0 and 1 based on 2 values
    public static float Clamp01(float minValue, float maxValue)
    {
        return minValue / maxValue;
    }

    // Override to allow ints to be passed in as well
    public static float Clamp01(int minValue, int maxValue) => Clamp01((float) minValue, (float) maxValue);
}
