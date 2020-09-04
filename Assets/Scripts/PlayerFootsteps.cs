using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource _footStepSounds;

    [SerializeField]
    private AudioClip[] _footStepClip;

    private CharacterController _characterController;

    [HideInInspector]
    public float VolumeMinimum, VolumeMaximum;

    private float _accumulatedDistance; // how far can we go before we play the sound

    [HideInInspector]
    public float StepDistance;




    // Start is called before the first frame update
    void Awake()
    {
        _footStepSounds = GetComponent<AudioSource>();

        _characterController = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootStepSound();
    }

    void CheckToPlayFootStepSound()
    {
        // if we are not on the ground
        if (!_characterController.isGrounded)
            return; // all the code below the return statement will not be executed.

        if (_characterController.velocity.sqrMagnitude > 0)
        {
            _accumulatedDistance += Time.deltaTime; // accumulated distance is the value of how far can we go until we play the footstep sound

            if (_accumulatedDistance > StepDistance)
            {
                _footStepSounds.volume = Random.Range(VolumeMinimum, VolumeMaximum);
                _footStepSounds.clip = _footStepClip[Random.Range(0, _footStepClip.Length)];
                _footStepSounds.Play();

                _accumulatedDistance = 0f;

                Random.Range(0.5f, 1f);
            }
        }
        else
        {
            _accumulatedDistance = 0f;
        }
    }

}