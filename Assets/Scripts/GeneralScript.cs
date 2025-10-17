using NUnit.Framework.Internal;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class GeneralScript : MonoBehaviour
{
    [Header("GameLayers")]
    public GameObject gamelayer;
    public GameObject menulayer;
    public GameObject creditslayer;
    public GameObject gameoverlayer;
    public GameObject startlayer;
    [SerializeField] private Canvas gamecanvas;

    [Header("Players")]
    public ControllerPlayer playerobj;

    [Header("Prefabs")]
    public GameObject playerpawnprefab;
    public GameObject playercontrollerprefab;
    public GameObject bulletprojectile;
    public GameObject ufopawnprefab;
    public GameObject aicontrollerprefab;

    [Header("Misc")]
    public int score;
    private int highscore;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI highscoretext;
    public TextMeshProUGUI losetext;
    public TextMeshProUGUI wintext;
    public bool haswon;
    public int numenemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        gamelayer.SetActive(false);
        creditslayer.SetActive(false);
        gameoverlayer.SetActive(false);
        losetext.gameObject.SetActive(false);
        wintext.gameObject.SetActive(false);
        menulayer.SetActive(false);
        startlayer.SetActive(true);
    }
    void Start()
    {
        playerobj = null;
        highscore = 0;
        Reset();
    }

    public void Reset()
    {
        foreach (Transform gameobj in gamelayer.transform) //destoryed gameobjects in the gamelayer that aren't the canvas elements (UI)
        {
            if (gameobj.gameObject != gamecanvas.gameObject)
            {
                Destroy(gameobj.gameObject);
            }
        }
        SpawnPlayerController();
        SpawnPlayer();
        Camera.main.GetComponent<CameraScript>().target = playerobj.pawnobject.gameObject.transform;
        score = 0;
        scoretext.text = "Score: " + score;
        haswon = false;
        numenemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startlayer.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gamelayer.SetActive(false);
                creditslayer.SetActive(false);
                gameoverlayer.SetActive(false);
                losetext.gameObject.SetActive(false);
                wintext.gameObject.SetActive(false);
                menulayer.SetActive(true);
            }
            if (!menulayer.activeSelf && !creditslayer.activeSelf && !gameoverlayer.activeSelf && gamelayer.activeSelf) //game only runs if in "game mode" 
            {
                if(score >= highscore)
                {
                    highscore = score;
                    highscoretext.text = "HighScore: " + score;
                }
                if (haswon)
                {
                    GameEnd(true);
                }
            }
        }
        else if(Input.anyKeyDown)
        {
            startlayer.SetActive(false);
            menulayer.SetActive(true);
        }
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

    public void SpawnUFO(Vector3 _pos)
    {
        if (playerobj != null || playerobj.pawnobject != null)
        {
            GameObject controller = Instantiate(aicontrollerprefab, new Vector3(0, 0, 0), Quaternion.identity, gamelayer.transform) as GameObject; //spawns top left from character

            GameObject obstacle = Instantiate(ufopawnprefab, _pos, Quaternion.identity, controller.transform) as GameObject; //spawns top left from character

            AiController newcontroller = controller.GetComponent<AiController>();
            Pawn newpawn = obstacle.GetComponent<Pawn>();
            if (newpawn != null)
            {
                newcontroller.pawnobject = newpawn;
                newcontroller.gameObject.GetComponent<Controller>().IstantiateControlConnection();

                Vector3 pos = playerobj.pawnobject.gameObject.transform.position;
                newcontroller.GetComponent<AiController>().setDirection(pos);
                numenemies += 1;
            }
        }   
    }

    public void GameEnd(bool iswin)
    {
        gameoverlayer.SetActive(true);
        if (!iswin)
        {
            losetext.gameObject.SetActive(true);
        }
        else
        {
            wintext.gameObject.SetActive(true);
        }
        gamelayer.SetActive(false);
    }

    public bool GameEnd() //if player can win
    {
        if (numenemies == 0)
        {         
            return true;          
        }
        return false;
    }

}
