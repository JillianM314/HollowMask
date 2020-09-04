using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour

{
    [SerializeField]
    private Transform _playerRoot, _lookRoot;

    [SerializeField]
    private bool _invert;

    [SerializeField]
    private bool _canUnlock = true; //for mousecursor

    [SerializeField]
    private float _sensitivity = 5f;

    [SerializeField]
    private int _smoothSteps = 10;

    [SerializeField]
    private float _smoothWeight = 0.4f;

    [SerializeField]
    private float _rollAngle = 10f;

    [SerializeField]
    private float _rollSpeed = 3f;

    [SerializeField]
    private Vector2 _defaultLookLimits = new Vector2(-70f, 80f);

    private Vector2 _lookAngles;

    private Vector2 _currentMouseLook;

    private Vector2 _smoothMove;

    private float _currentRollAngle;

    private int _lastLookFrame;




    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LockandUnlockCursor();


        if (Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }

    void LockandUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None; // if escape is pressed when cursor is locked the cursor then becomes visible
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            } // lock and unlock the cursor
        }
    }

    void LookAround()
    {
        _currentMouseLook = new Vector2(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));

        _lookAngles.x += _currentMouseLook.x * _sensitivity * (_invert ? 1f : -1f); // detecting movement of mouse. for x angles moving mouse y. Sensitivity smooths the movement.
        _lookAngles.y += _currentMouseLook.y * _sensitivity;

        _lookAngles.x = Mathf.Clamp(_lookAngles.x, _defaultLookLimits.x, _defaultLookLimits.y); //won't allow the value of _lookAngles.x to go below _defaultLookLimits.x or above the y value

        _currentRollAngle = Mathf.Lerp(_currentRollAngle, Input.GetAxisRaw("Mouse X") * _rollAngle, Time.deltaTime * _rollSpeed);// LINEARLY INTERPOLATES BETWEEN A AND B IN T

        _lookRoot.localRotation = Quaternion.Euler(_lookAngles.x, 0f, 0f);
        _playerRoot.localRotation = Quaternion.Euler(0f, _lookAngles.y, 0f);
    }
}