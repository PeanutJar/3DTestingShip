using Unity.VisualScripting;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public GameObject gamemanager;
    public float heightlimit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.GetComponent<GeneralScript>().playerobj.pawnobject != null)
        {
            GameObject pobj = gamemanager.GetComponent<GeneralScript>().playerobj.pawnobject.gameObject;
            if(pobj.transform.position.y > heightlimit)
            {
                pobj.transform.position = new Vector3(pobj.transform.position.x,heightlimit-10, pobj.transform.position.z);
            }
        }
    }
}
