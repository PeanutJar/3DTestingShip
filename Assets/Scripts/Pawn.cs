using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Health healthcomponent;
    //public abstract void IstantiateControlConnection(Controller parent);
    public abstract void Move(Vector3 movevector);
    public abstract void Rotate(Vector3 angle);
}
