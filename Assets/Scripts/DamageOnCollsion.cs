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
                gameObject.GetComponent<Health>().TakeDamage(gameObject.GetComponent<Health>().GetMaxHealth());
                //gameObject.GetComponent<DeathDestroy>().Die();
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
                        collision.gameObject.GetComponent<AudioPlayer>().PlayAudio(collision.gameObject.GetComponent<Pawn>().getAudio("impactsound"), 1f);
                        collision.gameObject.GetComponent<Health>().ChangeHealthBar(impactdamage, collision.gameObject.GetComponent<Pawn>().gethealthbar(), collision.gameObject.GetComponent<Pawn>().returnHealthScale());
                        gameObject.GetComponent<UFOScript>().ResetPosition();
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
                    collision.gameObject.GetComponent<Health>().ChangeHealthBar(impactdamage, collision.gameObject.GetComponent<Pawn>().gethealthbar(), collision.gameObject.GetComponent<Pawn>().returnHealthScale());
                    collision.gameObject.GetComponent<AudioPlayer>().PlayAudio(collision.gameObject.GetComponent<Pawn>().getAudio("collisionsound"), 1f);
                    collision.gameObject.GetComponent<Health>().TakeDamage(impactdamage);
                }

            }
        }
    }
}
