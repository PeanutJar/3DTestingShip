using UnityEngine;

public class BulletScript : Projectile
{
    public float speed = 10f;
    public float speedmultiplier = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera cam;
    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        this.gameObject.tag = "Projectile";
        healthcomponent = GetComponent<Health>();
        cam = Camera.main;
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (transform.forward * GetSpeed() * Time.deltaTime);
    }

    public override float GetSpeed()
    {
        return (speed * speedmultiplier);
    }
}
