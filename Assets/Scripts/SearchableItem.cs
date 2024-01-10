using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Items/SerchableItem", order = 0)]
public class SearchableItem : ScriptableObject
{
    public string name;
    public string discription;

    public GameObject[] dropItems;
    public GameObject key;
}

