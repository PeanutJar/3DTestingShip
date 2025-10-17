using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject gamemanager;
    public Transform target; //target for camera to look at
    public float distance; // distance between target and camera
    public float sensitivityX;
    public float sensitivityY; 
    public float minimumY; //recommended - -60f
    public float maximumY; //recommended - 20f
    private float rotationX;
    private float rotationY;
    public float lookmultiplier;
    public Vector3 lockedlookdirection;
    public Vector3 Offset;

    private bool freelook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //target = gamemanager.GetComponent<GeneralScript>().playerobj.pawnobject.gameObject.transform;
        rotationX = 0f;
        rotationY = 0f;
        freelook = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //doing this just so I don't have to deal with error messages for now
        {
            return;
        }

        Vector3 vTargetOffset; //store vertical target offset amount (x,y,z)

        if(Input.GetKeyDown(KeyCode.P))
        {
            freelook = !freelook;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            distance += 1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            distance -= 1;
        }

        if (freelook)
        {
            rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime * lookmultiplier;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime * lookmultiplier;
            //rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            Quaternion rotation = Quaternion.Euler(-rotationY, rotationX, 0); //set rotation value to equal the rotation of the camera and time

            vTargetOffset = new Vector3(0, -target.GetComponent<Collider>().bounds.size.y - 1f, 0); //calculate desired camera position (bounds.size.y is the target's collider height)
            Vector3 position = target.position - (rotation * new Vector3(0, 0, distance) + vTargetOffset); //set camera position and angle based on rotation, wanted distance and target offset amount
            transform.rotation = rotation; //set camera rotation to current rotation amount
            transform.position = position;
        }
        else
        {
            rotationX = target.transform.localEulerAngles.y;
            rotationY = target.transform.localEulerAngles.x;
            float rotationZ = target.transform.localEulerAngles.z;
            Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0); //set rotation value to equal the rotation of the camera and time

            transform.localEulerAngles = new Vector3(rotationY, rotationX, rotationZ);

            //transform.position = (target.transform.up * 4) + target.position - rotation * ((lockedlookdirection * distance));

            transform.position = target.transform.TransformDirection(Offset) + target.position - rotation * ((lockedlookdirection * distance));
        }
    }
}
