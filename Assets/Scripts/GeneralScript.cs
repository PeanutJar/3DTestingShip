using NUnit.Framework.Internal;
using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.PlayerSettings;

public class GeneralScript : MonoBehaviour
{

    [Header("GameLayers")]
    public GameObject gamelayer;

    [Header("Players")]
    public ControllerPlayer playerobj;

    [Header("Prefabs")]
    public GameObject playerpawnprefab;
    public GameObject playercontrollerprefab;
    public GameObject bulletprojectile;
    public GameObject ufopawnprefab;
    public GameObject aicontrollerprefab;

    //[Header("Misc")]
    //private float timecount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerobj = null;
        Reset();
    }

    public void Reset()
    {

        foreach (Transform gameobj in gamelayer.transform) //destoryed gameobjects in the gamelayer that aren't the canvas elements (UI)
        {
            //if (gameobj.gameObject != gamecanvas.gameObject)
            {
                Destroy(gameobj.gameObject);
            }
        }
        SpawnPlayerController();
        SpawnPlayer();
        //timecount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlayer()
    {
        if (playerobj.pawnobject != null)
        {
            Destroy(playerobj.pawnobject.gameObject);
        }

        GameObject _pawn = Instantiate(playerpawnprefab, new Vector3(0, 10, 0), Quaternion.identity, gamelayer.transform) as GameObject;
        if (_pawn != null)
        {
            Pawn newpawn = _pawn.GetComponent<Pawn>();
            if (newpawn != null)
            {
                playerobj.pawnobject = newpawn;
                playerobj.gameObject.GetComponent<Controller>().IstantiateControlConnection();
            }
        }

    }
    public void SpawnPlayerController()
    {
        if (playerobj != null) //if there is already a controller
        {
            Destroy(playerobj.gameObject);
            GameObject _controller = Instantiate(playercontrollerprefab, new Vector3(0, 0, 0), Quaternion.identity, gamelayer.transform) as GameObject; //instantiated controller and as a child of gamelayer
            ControllerPlayer newcontroller = _controller.GetComponent<ControllerPlayer>();
            playerobj = newcontroller;     
        }
        else
        {
            GameObject _controller = Instantiate(playercontrollerprefab, new Vector3(0, 0, 0), Quaternion.identity, gamelayer.transform) as GameObject; //instantiated controller and as a child of gamelayer
            ControllerPlayer newcontroller = _controller.GetComponent<ControllerPlayer>();
            playerobj = newcontroller;
        }
    }

    public void SpawnUFO()
    {
        if (playerobj != null || playerobj.pawnobject != null)
        {
            GameObject controller = Instantiate(aicontrollerprefab, new Vector3(0, 0, 0), Quaternion.identity, gamelayer.transform) as GameObject; //spawns top left from character

            GameObject obstacle = Instantiate(ufopawnprefab, new Vector3(10, 10, 10), Quaternion.identity, controller.transform) as GameObject; //spawns top left from character

            AiController newcontroller = controller.GetComponent<AiController>();
            Pawn newpawn = obstacle.GetComponent<Pawn>();
            if (newpawn != null)
            {
                newcontroller.pawnobject = newpawn;
                newcontroller.gameObject.GetComponent<Controller>().IstantiateControlConnection();

                Vector3 pos = playerobj.pawnobject.gameObject.transform.position;
                newcontroller.GetComponent<AiController>().setDirection(pos);
            }
        }

        

    }

}
