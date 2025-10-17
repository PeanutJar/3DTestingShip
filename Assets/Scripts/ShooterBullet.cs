using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShooterBullet : Shooter
{
    private GameObject gamemanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        Shoot(projectile);
    }

    public void Shoot(GameObject proj)
    {
        Vector3 pawposition = gameObject.transform.position - ((transform.rotation * new Vector3(0, 0, -2f)));
        Quaternion spawnRotation = transform.rotation * Quaternion.Euler(90f, 0f, 0f);
        GameObject shot = Instantiate(proj, pawposition, spawnRotation, gamemanager.GetComponent<GeneralScript>().gamelayer.transform) as GameObject;
        shot.GetComponent<BulletScript>().ship = gameObject;
    }
}
