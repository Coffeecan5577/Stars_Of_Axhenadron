using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float XSpeed = 4f;
    [SerializeField] private float xClampValue = 4.75f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	    float xOffset = XSpeed * xThrow * Time.deltaTime;
        print(xOffset);
	    float rawXPos = transform.localPosition.x + xOffset;

	    float clampedXPos = Mathf.Clamp(rawXPos, -xClampValue, xClampValue);

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);

    }

}
