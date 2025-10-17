using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;

public class AstronautScript : MonoBehaviour
{
    public int scoreincreaser;

    [Header("AudioClips")]
    public AudioClip pickupsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioClip getAudio(string audiovariablename) //uses "Reflection" technique
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

        return pickupsound;
    }
}
