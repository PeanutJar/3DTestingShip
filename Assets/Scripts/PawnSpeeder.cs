using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class PawnSpeeder : Pawn
{
    public float speed;
    public float rotatespeed;
    private Rigidbody rb;
    private ControllerPlayer pawnparent;

    [Header("AudioClips")]
    public AudioClip impactsound;
    public AudioClip firingsound;
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


        return impactsound;
    }
}
