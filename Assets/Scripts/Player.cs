using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float XSpeed = 4f;
    [SerializeField] private float xClampValue = 4.75f;
    [SerializeField] private float ySpeed = 4f;
    [SerializeField] private float _yClampValue = 2.75f;

    //Rotation variables for Euler angles
    [SerializeField] private float _roll = 0f;
    [SerializeField] private float _pitch = 0f;
    [SerializeField] private float _yaw = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	    float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
	    MoveHorizontally(xThrow);
        MoveVertically(yThrow);

	    ProcessRotation();
	}

    private void MoveHorizontally(float xThrow)
    {
        float xOffset = XSpeed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampValue, xClampValue);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void MoveVertically(float yThrow)
    {
        float yOffset = ySpeed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -_yClampValue, _yClampValue);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(_pitch, _yaw, _roll);
    }
}
