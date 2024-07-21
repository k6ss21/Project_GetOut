using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    PlayerInputAction input;

    bool isOpen;

    [SerializeField] Transform door;

    [SerializeField] Animator animator;
    private void Awake()
    {
        input = new PlayerInputAction();

    }


    private void OnEnable()
    {
        input.Enable();

    }

    private void OnDisable()
    {
        input.Disable();

    }

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        if (input.Player.Test.WasPerformedThisFrame())
        {
            isOpen = !isOpen;
            animator.SetBool("IsOpenDoor", isOpen);
        }
    }

}
