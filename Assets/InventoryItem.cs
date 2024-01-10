using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.Data;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{

    public Bag bag;

    public bool usableItem;


    private void Awake()
    {

        bag = FindAnyObjectByType<Bag>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        bag.OnSelectedItem(this.gameObject);
    }




}
