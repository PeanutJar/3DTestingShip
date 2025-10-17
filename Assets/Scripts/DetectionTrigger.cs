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
                other.gameObject.GetComponent<AudioPlayer>().PlayAudio(other.gameObject.GetComponent<HealthPackScript>().getAudio("pickupsound"), 1f);
                Destroy(other.gameObject);
            }
            else if (other.gameObject != null && other.gameObject.tag == "Astronaut")
            {
                GameObject.Find("GameManager").GetComponent<GeneralScript>().score += other.gameObject.GetComponent<AstronautScript>().scoreincreaser;
                GameObject.Find("GameManager").GetComponent<GeneralScript>().scoretext.text = "Score: " + GameObject.Find("GameManager").GetComponent<GeneralScript>().score;
                other.gameObject.GetComponent<AudioPlayer>().PlayAudio(other.gameObject.GetComponent<AstronautScript>().getAudio("pickupsound"), 1f);
                Destroy(other.gameObject);
            }
        }
    }
}
