using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeathDestroy : Death
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        if(gameObject.tag == "Obstacle")
        {
            if (gameObject.GetComponent<UFOScript>().healthcomponent.GetHealth() <= 0) //prevents score being added unless player actualy shoots them down
            {
                GameObject.Find("GameManager").GetComponent<GeneralScript>().score += gameObject.GetComponent<UFOScript>().scoreincreaser;
                GameObject.Find("GameManager").GetComponent<GeneralScript>().scoretext.text = "Score: " + GameObject.Find("GameManager").GetComponent<GeneralScript>().score;
                GameObject.Find("GameManager").GetComponent<GeneralScript>().numenemies -= 1;
                GameObject.Find("GameManager").GetComponent<GeneralScript>().haswon = GameObject.Find("GameManager").GetComponent<GeneralScript>().GameEnd();
                Destroy(gameObject.GetComponent<UFOScript>().getParent().gameObject);
            }
        }
        else if(gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GeneralScript>().GameEnd(false);
        }
        Destroy(gameObject);
    }
}
