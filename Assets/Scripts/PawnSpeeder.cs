using UnityEngine;

public class PawnSpeeder : Pawn
{
    public float speed;
    public float rotatespeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(Vector3 movevector)
    {
        transform.position += (movevector * speed) * Time.deltaTime;
    }

    public override void Rotate(Vector3 angle)
    {
        transform.Rotate((angle * rotatespeed) * Time.deltaTime);
    }
}
