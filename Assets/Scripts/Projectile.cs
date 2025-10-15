using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Health healthcomponent;
    //public int lifetimeduration;
    public abstract float GetSpeed();
}
