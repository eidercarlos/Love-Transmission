using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    // The target we are following
    [SerializeField]
    private Transform target;
    // The distance in the x-z plane to the target
    [SerializeField]
    private float distance = 10.0f;
    // the height we want the camera to be above the target
    [SerializeField]
    private float height = 5.0f;

    [SerializeField]
    private float rotationDamping;
    [SerializeField]
    private float heightDamping;

    //Mouse Look
    public float mouseSensitivity = 0.5f;
    public float clampAngle = 10.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    // Use this for initialization
    void Start()
    {   
        // if no target specified, assume the player
        if(target == null)
        {   
            if(GameObject.FindWithTag("Player") != null)
            {   
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }   
        }

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }   

    // Update is called once per frame
    void Update()
	{   
		// Early out if we don't have a target
		if (!target)
			return;

		// Calculate the current rotation angles
		var wantedRotationAngle = target.eulerAngles.y;
		var wantedHeight = target.position.y + height;

		var currentRotationAngle = transform.eulerAngles.y;
		var currentHeight = transform.position.y;
            
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height of the camera
		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        rotY = Closed_Basics_3.MathManipulators.ValueChecker(-1, rotY, 1);
        //Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        //transform.RotateAround(target.position, Vector3.up, rotY);
        target.Rotate(Vector3.up, rotY);

        //Debug.Log("Camera Rotation: " + transform.localEulerAngles);
        //Debug.Log("Camera Direction: "+transform.forward);
        //Debug.Log("Player Direction: "+target.forward);

        //target.localEulerAngles = transform.localEulerAngles;

        // Always look at the target
        //transform.LookAt(target);

        //target.transform.forward = target.transform.position + Camera.main.transform.forward * distance * Time.deltaTime;

        //Debug.DrawRay(transform.position, )
    }

    /*
    void Update()
    {   
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }   
    */
}
