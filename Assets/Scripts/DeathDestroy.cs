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
                //if (gameObject.GetComponent<MeteorScript>() != null)
                {
                    //gameObject.GetComponent<MeteorScript>().SpawnDeathRocks();
                }
                //Camera.main.GetComponent<GneralScript>().haswon = Camera.main.GetComponent<GneralScript>().GameEnd();
                //Camera.main.GetComponent<GneralScript>().enemyspawnlist.Remove(gameObject);
                Destroy(gameObject.GetComponent<UFOScript>().getParent().gameObject);
            }
        }
        else if(gameObject.tag == "Player")
        {
            //Camera.main.GetComponent<GneralScript>().GameEnd(false);
        }
        Destroy(gameObject);
    }
}
