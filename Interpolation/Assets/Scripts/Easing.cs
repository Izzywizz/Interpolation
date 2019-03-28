using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easing
{
    private const float V = .5f;

    // Declared within the Easing Type so that when called outside of the calss it would look like
    // Easing.Type -> this makes the intention clear outside of the class but inside the class you can just Type
    public enum Type
    {
        linear, 
        easeIn,
        easeOut,
        easeInOut,
        sin,
        sinIn,
        sinOut
    }

    public static float Ease(float u, Type eType, float eMod = 2)
    {
        float u2 = u;

        // Handles evey Type akak exhaustive
        // eMod is an optional modifier of u, so in the case of easeIn, the value of u is raised to power of eMod,
        // and can be used an multiplier to increase the amplitude of the sin wave in Type.sin 
        switch (eType)
        {
            case Type.linear:
                u2 = u;
                break;

            case Type.easeIn:
                u2 = Mathf.Pow(u, eMod);
                break;

            case Type.easeOut:
                u2 = Mathf.Pow(1 - u, eMod);
                break;

            case Type.easeInOut:
                if ( u <= 0.5f)
                {
                    u2 = 0.5f * Mathf.Pow(u * 2, eMod);
                }
                else
                {
                    u2 = 0.5f + 0.5f * (1 - Mathf.Pow(1 - (2 * (u - 0.5f)), eMod));
                }
                break;

            case Type.sin:
                // Try eMod values of 0.15f and -0.2f for Easing.Type.Sin
                u2 = u + eMod * Mathf.Sin(2 * Mathf.PI * u);
                break;

            case Type.sinIn:
                // eMod is ignored for sinIn
                u2 = 1 - Mathf.Cos(2 * Mathf.PI * 0.5f);
                break;

            case Type.sinOut:
                // eMod is ignored for sinout
                u2 = Mathf.Sin(u * Mathf.PI * 0.5f);
                break;

            default:
                break;
        }

        return (u2);
    }
}
