using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private int VelocityHash;
    public float acceleration;
    private float _velocity;
    void Start()
    {
        VelocityHash = Animator.StringToHash("Velocity");
    }

    public void A_SprintForward(float value)
    {
        _velocity = Mathf.Lerp(_velocity, value, Time.deltaTime * acceleration);
        _animator.SetFloat(VelocityHash, _velocity);
    }
   
}
