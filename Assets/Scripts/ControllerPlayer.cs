using UnityEngine;

public class ControllerPlayer : Controller
{
    public Pawn pawnobject;
    private Vector3 moveDirection = Vector3.forward;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            pawnobject.Move(moveDirection);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pawnobject.Move(-moveDirection);
        }
    }
}
