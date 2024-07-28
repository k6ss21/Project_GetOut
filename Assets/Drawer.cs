using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    Animator animator;
    [SerializeField] string aniBoolName;
    bool isOpen = false;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void Open()
    {
        isOpen = !isOpen;
        animator.SetBool(aniBoolName, isOpen);
    }
    public void Close()
    {
        Debug.Log("closr");
        isOpen = false;
         animator.SetBool(aniBoolName, isOpen);
    }


}
