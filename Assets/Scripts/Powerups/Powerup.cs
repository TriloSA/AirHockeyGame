using UnityEngine;

[System.Serializable]
public class Powerup
{
    public string name;

    /// <summary>
    /// Apply an effect.
    /// </summary>
    public virtual void ApplyEffect()
    {
        Debug.Log("EMPTY EFFECT");
    }

    public override string ToString()
    {
        return name;
    }
}
