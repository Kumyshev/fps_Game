using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterControllerMove : MonoBehaviour
{
    
    [SerializeField] public bool m_IsWalking;
    [SerializeField] [Range(0f, 1f)] public float m_RunstepLenghten;
    [SerializeField] public float m_StepInterval;
    [SerializeField] public AudioClip[] m_FootstepSounds;    
    [SerializeField] public AudioClip m_JumpSound;           
    [SerializeField] public AudioClip m_LandSound;

    private float m_StepCycle;
    private float m_NextStep;

    private bool m_PreviouslyGrounded = true;

    private AudioSource m_AudioSource;

    public float speed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 10.0f;
    private CharacterController controller;
    private Vector3 moveDirection;
    [HideInInspector]
    public bool m_Jump;
    [HideInInspector]
    public float Hinput;
    [HideInInspector]
    public float Vinput;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        m_AudioSource = GetComponent<AudioSource>();

        m_StepCycle = 0f;
        m_NextStep = m_StepCycle / 2f;
    }


    private void Update()
    {

    }



    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = new Vector3(Hinput, 0.0f, Vinput);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
            
            if (/*Input.GetButton("Jump")*/m_Jump == true)
            {
                m_PreviouslyGrounded = false;
                PlayJumpSound();
                moveDirection.y = jumpSpeed;
            }
            else if (m_Jump == false && controller.isGrounded && m_PreviouslyGrounded == false)
            {
                PlayLandSound();
                m_PreviouslyGrounded = true;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
        ProgressStepCycle(speed);
    }

    private void PlayJumpSound()
    {
        m_AudioSource.PlayOneShot(m_JumpSound, 1.0F);
    }
    private void PlayLandSound()
    {
        m_AudioSource.PlayOneShot(m_LandSound, 1.0F);
        m_NextStep = m_StepCycle + .5f;
    }


    private void ProgressStepCycle(float speed)
    {
        if (controller.velocity.sqrMagnitude > 0 && (Hinput != 0 || Vinput != 0))
        {
            m_StepCycle += (controller.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) *
                         Time.fixedDeltaTime;
        }

        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();
    }


    private void PlayFootStepAudio()
    {
        if (!controller.isGrounded)
        {
            return;
        }

        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);

        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }
}
