using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class PlayerSearch : MonoBehaviour
{
    private PlayerInputAction input;

    #region RayCast
    [SerializeField] Transform raycastPosition;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float raycastDistance = 10f;

    RaycastHit hitInfo;
    #endregion

    [SerializeField] GameObject puzzle;

    HighlightItem _searchItem;

    ItemManager currentSearchingItem;

    List<ItemManager> items = new List<ItemManager>();
    StarterAssetsInputs fpsInputManager;

    Bag bag;

    bool isPauseMenuOpen = false;
    [SerializeField]CanvasRenderer  pauseMenuUI;

    public static Action OnResetAllPuzzle;



    private void Awake()
    {
        input = new PlayerInputAction();
        fpsInputManager = GetComponent<StarterAssetsInputs>();
        bag = GetComponent<Bag>();
    }


    private void OnEnable()
    {
        input.Enable();
        TestPuzzle.OnpuzzleEnd += OnpuzzleEnd;
        PauseMenu.OnResumeButtonPressed += PauseResume;
    }

    private void OnDisable()
    {
        input.Disable();
        TestPuzzle.OnpuzzleEnd -= OnpuzzleEnd;
        PauseMenu.OnResumeButtonPressed -= PauseResume;
    }

    private void Start()
    {
        AssignKeyItem();
        pauseMenuUI.gameObject.SetActive(false);
    }
    void Update()
    {
        Ray ray = new Ray(raycastPosition.position, raycastPosition.TransformDirection(Vector3.forward));
        if (_searchItem != null)
        {
            _searchItem.ApplyDefaultMaterial();
        }
        if (Physics.Raycast(ray, out hitInfo, raycastDistance))
        {
            SearchItem();
            UseKey();
        }
        else
        {
            Debug.DrawRay(raycastPosition.position, raycastPosition.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
        }

        // if (input.Player.Reload.WasPerformedThisFrame())
        // {
        //     OnResetAllPuzzle?.Invoke();
        // }
        if (input.Player.Escape.WasPerformedThisFrame())
        {
           PauseResume();
        }
    }

    void InteractWithItem(ItemManager item)
    {
        if (input.Player.Interact.WasPerformedThisFrame())
        {
            Debug.Log("interact");
            currentSearchingItem = item;
            puzzle.SetActive(true);
            fpsInputManager.LockMovement(true);
            fpsInputManager.LockMouse(true);
        }
    }

    void OnpuzzleEnd()
    {
        GiveReward();
        puzzle.SetActive(false);
        fpsInputManager.LockMovement(false);
        fpsInputManager.LockMouse(false);
    }

    void GiveReward()
    {
        currentSearchingItem.Reward();
    }

    void AssignKeyItem()
    {

        ItemManager[] itemManagers = FindObjectsOfType<ItemManager>();
        foreach (ItemManager item in itemManagers)
        {
            items.Add(item);
        }
        ItemManager item_1 = items[Random.Range(0, items.Count)];
        items.Remove(item_1);
        ItemManager item_2 = items[Random.Range(0, items.Count)];
        Debug.Log(item_1 + "AND" + item_2);
        item_1.keyItem = true;
        item_2.keyItem = true;
        items.Clear();

    }

    void SearchItem()
    {
        if (hitInfo.transform.gameObject.CompareTag("SearchItem"))
        {
            Debug.DrawRay(raycastPosition.position, raycastPosition.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            // Debug.Log("ItemName = " + hitInfo.transform.gameObject.name);
            HighlightItem hitObj = hitInfo.transform.gameObject.GetComponent<HighlightItem>();
            hitObj.ApplyHighlightMaterial();
            InteractWithItem(hitInfo.transform.GetComponent<ItemManager>());
            _searchItem = hitObj;
        }
    }

    void UseKey()
    {
        if (hitInfo.transform.gameObject.CompareTag("Lock"))
        {
            if (input.Player.Interact.WasPerformedThisFrame())
            {
                Debug.Log("Key Count = " + bag.KeyCheck());
                if (bag.KeyCheck() == 2)
                {
                    hitInfo.transform.parent.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Not enough Keys!!!");
                }
            }
        }

    }

    void PauseResume()
    {
 isPauseMenuOpen = !isPauseMenuOpen;
            fpsInputManager.LockCursor(!isPauseMenuOpen);
            fpsInputManager.LockMouse(isPauseMenuOpen);
            fpsInputManager.LockMovement(isPauseMenuOpen);
            pauseMenuUI.gameObject.SetActive(isPauseMenuOpen);
    }   
}
