using UnityEngine;

public class DetectionTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            if (other.gameObject != null && other.gameObject.tag == "HealthPack")
            {
                gameObject.GetComponent<Health>().Heal(other.gameObject.GetComponent<HealthPackScript>().healnum);
                Destroy(other.gameObject);
            }
            else if (other.gameObject != null && other.gameObject.tag == "Astronaut")
            {
                //increase score thing
                Destroy(other.gameObject);
            }
        }
    }
}
