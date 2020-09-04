using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private CharacterController charControl;

    public float SprintSpeed = 8f;
    public float SprintSpeedNormal;
    public float MoveSpeed = 4f;
    public float CrouchSpeed = 1f;

    private Transform _lookRoot;
    private float _standHeight = 0f;
    private float _crouchHeight = -0.5f;

    private bool _isCrouching;

    private PlayerFootsteps _playerFootsteps;

    private float _sprintVolume = 1f;
    private float _crouchVolume = 0.1f;
    private float _walkVolumeMinimum = 0.1f, _walkVolumeMaximum = 0.3f;

    private float _walkStepDistance = 0.4f;
    private float _sprintStepDistance = 0.25f;
    private float _crouchStepDistance = 0.5f;


    //Stamina and stamina UI

    public Slider staminaBar;

    public float playerStamina;
    public float maxPlayerStamina = 100f;
    public int staminaFallRate;
    public int staminaFallMult;
    public int staminaRegainRate;
    public int staminaRegainMult;

    //Rigidbody myBody;

    void Awake()
    {

        _playerMovement = GetComponent<PlayerMovement>();

        charControl = GetComponent<CharacterController>();

        _lookRoot = transform.GetChild(0);

        _playerFootsteps = GetComponentInChildren<PlayerFootsteps>();

       

       
    }

    void Start()
    {
        _playerFootsteps.VolumeMinimum = _walkVolumeMinimum;
        _playerFootsteps.VolumeMaximum = _walkVolumeMaximum;
        _playerFootsteps.StepDistance = _walkStepDistance;
    }
    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
        
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isCrouching)
        {
            _playerMovement.speed = SprintSpeed; // when crouching can't sprint

            _playerFootsteps.StepDistance = _sprintStepDistance;
            _playerFootsteps.VolumeMinimum = _sprintVolume;
            _playerFootsteps.VolumeMaximum = _sprintVolume;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !_isCrouching)
        {
            _playerMovement.speed = MoveSpeed; // move at walk speed when not crouching

            _playerFootsteps.StepDistance = _walkStepDistance;
            _playerFootsteps.VolumeMinimum = _walkVolumeMinimum;
            _playerFootsteps.VolumeMaximum = _walkVolumeMaximum;

        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_isCrouching)
            {
                _lookRoot.localPosition = new Vector3(0f, _standHeight, 0f);
                _playerMovement.speed = MoveSpeed;

                _playerFootsteps.StepDistance = _walkStepDistance;
                _playerFootsteps.VolumeMinimum = _walkVolumeMinimum;
                _playerFootsteps.VolumeMaximum = _walkVolumeMaximum;


                _isCrouching = false;
            }
            else
            {
                _lookRoot.localPosition = new Vector3(0f, _crouchHeight, 0f);
                _playerMovement.speed = CrouchSpeed;

                _playerFootsteps.StepDistance = _walkStepDistance;
                _playerFootsteps.VolumeMinimum = _crouchVolume;
                _playerFootsteps.VolumeMaximum = _crouchVolume;

                _isCrouching = true;
            }
        }
    }

    //Calculate the stamina of the player
    
    }

