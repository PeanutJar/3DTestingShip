using UnityEngine;
using UnityEngine.EventSystems;

public class PawnSpeeder : Pawn
{
    public float speed;
    public float rotatespeed;
    private Rigidbody rb;
    private ControllerPlayer pawnparent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.tag = "Player";
        healthcomponent = GetComponent<Health>();
    }

    public void IstantiateControlConnection(ControllerPlayer parent)
    {
        pawnparent = parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(Vector3 movevector)
    {
        //transform.position += (movevector * speed) * Time.deltaTime;
        // rb.AddForce ((movevector * speed) * 50 * Time.deltaTime);
        rb.AddForce((movevector * speed), ForceMode.Force); //fyi don't use Time.deltatime on an addforce unless within a fixedupdate function


    }
    public override void Rotate(Vector3 angle)
    {
        transform.Rotate((angle * rotatespeed) * Time.deltaTime);

    }
}
