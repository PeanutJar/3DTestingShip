using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ControllerPlayer : Controller
{
    public Pawn pawnobject;
    [SerializeField] private Image healthbar;
    [SerializeField] private int lives;
    [SerializeField] private GameObject heartsobj;
    private List<Image> hearts;
    private Vector3 defaulthealthbarscale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaulthealthbarscale = healthbar.transform.localScale;
        hearts = new List<Image>();
        //heartsobj.transform.position = new Vector3(210, 32.5f, 0); // just to make sure (even though this is already set in preset could just get rid of this)
        Image _heart;
        for (int i = 0; i < lives; i++)
        {
            _heart = Instantiate(GameObject.Find("GameManager").GetComponent<GeneralScript>().heartimage, new Vector3(heartsobj.transform.position.x + (30 * i), heartsobj.transform.position.y, 0), Quaternion.identity, heartsobj.transform) as Image;
            hearts.Add(_heart);
        }
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

    public Image gethealthbar()
    {
        return (healthbar);
    }

    public Vector3 returnHealthScale()
    {
        return (defaulthealthbarscale);
    }

    public int getLives()
    {
        return (lives);
    }
    public void setLives(int _lives)
    {
        lives += _lives;
    }
    public List<Image> getHeartsList()
    {
        return (hearts);
    }
    public void setHeartsList(List<Image> list)
    {
        hearts = list;
    }
    public void ResetHeartsList()
    {
        if (hearts.Count > 0)
        {
            for (int i = 0; i < hearts.Count; i++)
            {
                Destroy(hearts[i].gameObject);
                hearts.Remove(hearts[i]);
            }
            Image _heart;
            for (int i = 0; i < lives; i++)
            {
                _heart = Instantiate(GameObject.Find("GameManager").GetComponent<GeneralScript>().heartimage, new Vector3(heartsobj.transform.position.x + (30 * i), heartsobj.transform.position.y, 0), Quaternion.identity, heartsobj.transform) as Image;
                hearts.Add(_heart);
            }
        }
    }
}
