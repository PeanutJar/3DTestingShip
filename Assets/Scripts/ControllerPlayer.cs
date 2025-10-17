using UnityEngine;

public class ControllerPlayer : Controller
{
    public Pawn pawnobject;
    //private Vector3 moveDirection = Vector3.forward;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public override void IstantiateControlConnection()
    {
        pawnobject.GetComponentInChildren<PawnSpeeder>().IstantiateControlConnection(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (pawnobject == null) //doing this just so I don't have to deal with error messages for now
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pawnobject.Move(pawnobject.transform.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pawnobject.Move(-pawnobject.transform.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            pawnobject.Rotate(new Vector3(0,-1,0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pawnobject.Rotate(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.Z))
        {
            pawnobject.Rotate(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKey(KeyCode.X))
        {
            pawnobject.Rotate(new Vector3(1, 0, 0));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            pawnobject.Rotate(new Vector3(0, 0, 1));
        }
        else if (Input.GetKey(KeyCode.E))
        {
            pawnobject.Rotate(new Vector3(0, 0, -1));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pawnobject.gameObject.GetComponent<AudioPlayer>().PlayAudio(pawnobject.gameObject.GetComponent<Pawn>().getAudio("firingsound"), 0.7f);
            pawnobject.GetComponent<Shooter>().Shoot();
        }
    }
}
