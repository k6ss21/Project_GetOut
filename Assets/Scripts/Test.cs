using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Test : MonoBehaviour
{
    [SerializeField] private float nummber = 10;
    private void Start() {
     
    }

    private void Update()
    {
        
    }

    void OnClickButton()
    {
        Debug.Log("Number = " + nummber);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
    }

}
