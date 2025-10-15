using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; //target for camera to look at
    public float distance; // distance between target and camera
    public float sensitivityX;
    public float sensitivityY; 
    public float minimumY; //recommended - -60f
    public float maximumY; //recommended - 20f
    private float rotationX;
    private float rotationY;
    public float lookmultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationX = 0f;
        rotationY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vTargetOffset; //store vertical target offset amount (x,y,z)

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime * lookmultiplier;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime * lookmultiplier;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        Quaternion rotation = Quaternion.Euler(-rotationY, rotationX, 0); //set rotation value to equal the rotation of the camera and time

        vTargetOffset = new Vector3(0, -target.GetComponent<Collider>().bounds.size.y - 1f, 0); //calculate desired camera position (bounds.size.y is the target's collider height)
        Vector3 position = target.position - (rotation * new Vector3(0, 0, distance) + vTargetOffset); //set camera position and angle based on rotation, wanted distance and target offset amount
        transform.rotation = rotation; //set camera rotation to current rotation amount
        transform.position = position;
    }
}
