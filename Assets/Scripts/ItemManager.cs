using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class ItemManager : MonoBehaviour
{
    public SearchableItem searchableItem;
    public bool keyItem;

    private Bag Bag;

    private void Start()
    {
        Bag = FindAnyObjectByType<Bag>();
    }
    public void Reward()
    {
        if (!keyItem)
        {
            GameObject rewardItem = searchableItem.dropItems[(Random.Range(0, searchableItem.dropItems.Length))].gameObject;
            Debug.Log("Reward = " + rewardItem);
            Bag.AddToBag(rewardItem);
        }
        else
        {
            GameObject rewardItem = searchableItem.key;
            Bag.AddToBag(rewardItem);
        }
    }

}
