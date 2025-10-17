using UnityEngine;

public class BulletScript : Projectile
{
    public float speed;
    public float speedmultiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera cam;
    private float halfHeight;
    private float halfWidth;
    private Rigidbody rb;
    public GameObject ship;

    void Start()
    {
        this.gameObject.tag = "Projectile";
        healthcomponent = GetComponent<Health>();
        cam = Camera.main;
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        rb = GetComponent<Rigidbody>();
        rb.AddForce((transform.up * speed), ForceMode.VelocityChange);
        rb.angularVelocity = rb.angularVelocity + ship.GetComponent<Rigidbody>().angularVelocity;
        rb.linearVelocity = rb.linearVelocity + ship.GetComponent<Rigidbody>().linearVelocity;

        //Physics.IgnoreCollision();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override float GetSpeed()
    {
        return (speed * speedmultiplier);
    }
}
