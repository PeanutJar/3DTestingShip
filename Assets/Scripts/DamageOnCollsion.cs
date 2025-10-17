using System.ComponentModel;
using UnityEngine;

public class DamageOnCollsion : MonoBehaviour
{
    [SerializeField] private int impactdamage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Player")
        {
            if (collision.gameObject != null && collision.gameObject.tag == "Boundry")
            {
                gameObject.GetComponent<DeathDestroy>().Die();
            }
        }
        else if (gameObject.tag == "Obstacle") //all collision triggers conditions relating to obstacles
        {
            if (collision.gameObject.tag != "Obstacle")
            {
                if (collision.gameObject.GetComponent<Health>() != null)
                {
                    if (collision.gameObject.tag == "Player")
                    {
                        //other.gameObject.GetComponent<AudioPlayer>().PlayAudio(other.gameObject.GetComponent<PawnSpaceShip>().getAudio("impactsound"), 1f);
                        //other.gameObject.GetComponent<Health>().ChangeHealthBar(impactdamage, other.gameObject.GetComponent<PawnSpaceShip>().gethealthbar(), other.gameObject.GetComponent<PawnSpaceShip>().returnHealthScale());
                    }
                    collision.gameObject.GetComponent<Health>().TakeDamage(impactdamage);
                }

            }
        }
        else if (gameObject.tag == "Projectile") //all collision triggers conditions relating to projectiles
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                if (collision.gameObject.GetComponent<Health>() != null)
                {
                    //other.gameObject.GetComponent<Health>().ChangeHealthBar(impactdamage, other.gameObject.GetComponent<Obstacle>().gethealthbar(), other.gameObject.GetComponent<Obstacle>().returnHealthScale());
                    //other.gameObject.GetComponent<AudioPlayer>().PlayAudio(other.gameObject.GetComponent<Obstacle>().getAudio("collisionsound"), 1f);
                    collision.gameObject.GetComponent<Health>().TakeDamage(impactdamage);
                }

            }
        }
    }
}
