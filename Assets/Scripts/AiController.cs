using UnityEngine;
using UnityEngine.EventSystems;

public class AiController : Controller
{
    private GameObject gamemanager;
    public Pawn pawnobject;
    private Vector3 moveDirection;
    private Vector3 initialposition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public override void IstantiateControlConnection()
    {
        pawnobject.GetComponentInChildren<UFOScript>().IstantiateControlConnection(this);
    }

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (pawnobject == null || gamemanager.GetComponent<GeneralScript>().playerobj.pawnobject == null) //doing this just so I don't have to deal with error messages for now
        {
            return;
        }

        setDirection(gamemanager.GetComponent<GeneralScript>().playerobj.pawnobject.gameObject.transform.position);
        if (initialposition != null || moveDirection != null)
        {
            pawnobject.GetComponent<Pawn>().Move(moveDirection);
            pawnobject.GetComponent<Pawn>().Rotate(new Vector3(0,moveDirection.y,0));
        }
    }

    public void setDirection(Vector3 pos)
    {
        initialposition = pos;
        moveDirection = (initialposition - pawnobject.transform.position).normalized; //point in direction of player position when istanciated
    }
}
