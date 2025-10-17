using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Reflection;
using System.Linq;

public class UFOScript : Pawn
{
    private GameObject gamemanager;
    private Rigidbody rb;
    [SerializeField] private float slowdownrate;
    //[SerializeField] private Image healthbar;
    //private Vector3 defaulthealthbarscale;
    private AiController obstacleparent;
    public int scoreincreaser;
    public float speed;
    public float rotatespeed;

    //[Header("AudioClips")]
    //public AudioClip collisionsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody>();
        this.gameObject.tag = "Obstacle";
        healthcomponent = GetComponent<Health>();
        //defaulthealthbarscale = healthbar.transform.localScale;
        //initalposition = transform.position;
    }

    public void IstantiateControlConnection(AiController parent)
    {
        obstacleparent = parent;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.GetComponent<GeneralScript>().playerobj.pawnobject == null)
        {
            return;
        }
    }

    public override void Move(Vector3 movevector)
    {         
        rb.MovePosition(transform.position + (movevector * speed * slowdownrate));
    }
    public override void Rotate(Vector3 angle)
    {
        transform.Rotate((angle * rotatespeed) * Time.deltaTime);

    }

    public AiController getParent()
    {
        return obstacleparent;
    }

    /*
    public override Image gethealthbar()
    {
        return (healthbar);
    }

    public override Vector3 returnHealthScale()
    {
        return (defaulthealthbarscale);
    }
    */
}
