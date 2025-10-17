using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

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

    [Header("AudioClips")]
    public AudioClip collisionsound;
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

    public override AudioClip getAudio(string audiovariablename) //uses "Reflection" technique
    {
        AudioClip localaudio;
        Type targettype = this.GetType();
        FieldInfo[] fields = targettype.GetFields(BindingFlags.Public | BindingFlags.Instance); //create an array of all public AudioClip within this instance of the script
        // This example gets public instance fields. Adjust BindingFlags as needed.
        foreach (FieldInfo field in fields)
        {
            if (field.Name == audiovariablename && field.FieldType == typeof(AudioClip))
            {
                AudioClip fieldValue = (AudioClip)field.GetValue(this); // 'this' is the instance
                localaudio = fieldValue;
                return (localaudio);
            }
        }


        return collisionsound;
    }
}
