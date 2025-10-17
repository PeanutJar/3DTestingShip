using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public GameObject gamemanager;
    public float heightlimit;
    public List<GameObject> spawners;
    private bool hasspawn;
    private int numspawners;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawners = new List<GameObject>();
        numspawners = 0;

        Reset();
    }

    public void Reset()
    {
        hasspawn = false;
        if (spawners.Count > 0)
        {
            for (int i = 0; i < spawners.Count; i++)
            {
                spawners[i].SetActive(false);
            }
        }
        if (spawners.Count > 0)
        {
            //numspawners = Random.Range(1, spawners.Count); //1-list count
            for (int i = 0; i < spawners.Count; i++)
            {
                numspawners = Random.Range(1, 3); //305 chance for given spawner to be active
                if (numspawners == 1)
                {
                    spawners[i].SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasspawn)
        {
            for (int i = 0; i < spawners.Count; i++)
            {
                if (spawners[i].activeSelf)
                {
                    spawners[i].GetComponent<SpawnerScript>().SpawnAwake();
                }
            }
            hasspawn = true;
        }
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
