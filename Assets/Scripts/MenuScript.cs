using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject gamemanager;
    [SerializeField] private GameObject levelmanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        gamemanager.GetComponent<GeneralScript>().gamelayer.SetActive(true);
        gamemanager.GetComponent<GeneralScript>().Reset();
        gamemanager.GetComponent<GeneralScript>().menulayer.SetActive(false);
        levelmanager.GetComponent<LevelManagerScript>().Reset();
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void RollCredits()
    {
        gamemanager.GetComponent<GeneralScript>().creditslayer.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
