using UnityEngine;
using UnityEngine.InputSystem.XR;

public class SpawnerScript : MonoBehaviour
{
    public GameObject gamemanager;
    public GameObject spawnprefab;
    public int spawnnumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        for (int i = 0; i < spawnnumber; i++)
        {
            if (spawnprefab == gamemanager.GetComponent<GeneralScript>().ufopawnprefab)
            {
                gamemanager.GetComponent<GeneralScript>().SpawnUFO();
            }
            else
            {
                GameObject obj = Instantiate(spawnprefab, transform.position, Quaternion.identity, gamemanager.GetComponent<GeneralScript>().gamelayer.gameObject.transform) as GameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
