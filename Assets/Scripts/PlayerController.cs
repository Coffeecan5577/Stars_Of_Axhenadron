using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    //TODO work out why sometimes slow on first play of scene.


    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlSpeed = 14f;
    [SerializeField] private float xClampValue = 4.75f;
    [SerializeField] private float _yClampValue = 2.75f;
    [SerializeField] private GameObject[] guns;

    //Rotation variables for Euler angles
    [Header("Screen-position Based")]
    [SerializeField] private float _positionPitchFactor = -5f;
    [SerializeField] private float _positionYawFactor = 5f;

    [Header("Control-Throw Based")]
    [SerializeField] private float _controlPitchFactor = -20f;
    [SerializeField] private float _controlRollFactor = -20f;

    private float xThrow, yThrow;
    private bool _isControlEnabled = true;
	
	// Update is called once per frame
	void Update ()
	{
	    if (_isControlEnabled)
	    {
            xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            yThrow = CrossPlatformInputManager.GetAxis("Vertical");
            MoveHorizontally(xThrow);
            MoveVertically(yThrow);

            ProcessRotation();
	        ProcessFiring();
	    }
	    
	}

    private void MoveHorizontally(float xThrow)
    {
        float xOffset = controlSpeed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampValue, xClampValue);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void MoveVertically(float yThrow)
    {
        float yOffset = controlSpeed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -_yClampValue, _yClampValue);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * _positionPitchFactor;
        float pitchDueToControlThrow = yThrow * _controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * _positionYawFactor;

        float rollDueToControlThrow = xThrow * _controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yawDueToPosition, rollDueToControlThrow);
    }

    void OnPlayerDeath() // Called by string reference.
    {
        _isControlEnabled = false;
        print("Controls frozen.");
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }   
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (var gun in guns)// care may affect death FX
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }


}
