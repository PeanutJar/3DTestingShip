using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public abstract void Move(Vector3 movevector);
    public abstract void Rotate(Vector3 angle);
}
