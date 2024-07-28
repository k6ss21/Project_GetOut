using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Desk : MonoBehaviour
{
    [SerializeField] Drawer drawer_1;
     [SerializeField] Drawer drawer_2;

    public void CloseDrawer_1()
    {   
        drawer_1.Close();
    }
     public void CloseDrawer_2()
    {
        drawer_2.Close();
    }
}
