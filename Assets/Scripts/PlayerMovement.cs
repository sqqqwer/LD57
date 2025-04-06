using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<AudioClip> footStepsSfx;
    [SerializeField] private AudioSource footStepsAudioSource;

    [SerializeField] private CharacterController characterController;
    [SerializeField] public float moveSpeed = 3.5f;
    [SerializeField] public float gravity = 9.8f;

    private Vector2 inputDirection;
    private Vector3 move;

    private Vector3 lastPosition;
    private float distanceMoved;
    [SerializeField] private float stepDistance = 2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!G.isPause)
        {
            inputDirection = GetInput();
            RotatePlayerTowardsCamera(mainCamera.transform);
            inputDirection = inputDirection.normalized;
            move =
                transform.forward * inputDirection.y + transform.right * inputDirection.x;
            move.y = 0f;
            if (!characterController.isGrounded)
            {
                move.y -= gravity / (moveSpeed / 10);
            }
            characterController.Move(move * (moveSpeed / 10) * Time.deltaTime);

            distanceMoved += (transform.position - lastPosition).magnitude;
            lastPosition = transform.position;
            if (characterController.velocity.magnitude > 0.1f && distanceMoved >= stepDistance)
            {
                PlayFootstepSound();
                distanceMoved = 0f;
            }
        }
    }
    private void PlayFootstepSound()
    {
        if (footStepsAudioSource != null)
        {
            if (footStepsSfx.Count > 0)
            {
                int index = Random.Range(0, footStepsSfx.Count);
                footStepsAudioSource.pitch = 0.85f + Random.Range(-0.15f, 0.15f);
                footStepsAudioSource.PlayOneShot(footStepsSfx[index]);
            }
        }
    }

    private Vector2 GetInput()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return inputVector;
    }

    private void RotatePlayerTowardsCamera(Transform transformCamera)
    {
        Vector3 cameraForward = transformCamera.forward;
        cameraForward.y = 0f;

        if (cameraForward != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(cameraForward);
            transform.rotation = newRotation;
        }
    }
}
