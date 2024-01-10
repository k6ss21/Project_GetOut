using System.Collections;
using System.Collections.Generic;
using System.Threading;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
public class Bag : MonoBehaviour
{
   private PlayerInputAction input;
   List<InventoryItem> CollectedItems = new List<InventoryItem>();

   StarterAssetsInputs fpsInputManager;
   int count = 0;

   //UI
   [SerializeField] RectTransform content;
   [SerializeField] CanvasRenderer inventoryUI;

   [SerializeField] Button usableButton;
   bool isInventoryOpen = false;

   private void Awake()
   {
      input = new PlayerInputAction();
      fpsInputManager = GetComponent<StarterAssetsInputs>();
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
      inventoryUI.gameObject.SetActive(false);
      usableButton.interactable = false;
   }

   private void Update()
   {
      OpenBag();

   }

   private void OpenBag()
   {
      if (input.Player.Inventory.WasPerformedThisFrame())
      {
         isInventoryOpen = !isInventoryOpen;
         fpsInputManager.LockCursor(!isInventoryOpen);
         fpsInputManager.LockMouse(isInventoryOpen);
         fpsInputManager.LockMovement(isInventoryOpen);
         inventoryUI.gameObject.SetActive(isInventoryOpen);
         UpdateInventory();
      }
   }

   public void AddToBag(GameObject item)
   {
      CollectedItems.Add(item.GetComponent<InventoryItem>());
   }

   public int KeyCheck()
   {
      count = 0;
      foreach (InventoryItem item in CollectedItems)
      {
         if (item.CompareTag("Key"))
         {
            count++;
         }
      }
      return count;

   }

   public void UpdateInventory()
   {
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }
      foreach (InventoryItem item in CollectedItems)
      {
         Instantiate(item, content);
      }
   }


   public GameObject selectedItem;

   public void OnSelectedItem(GameObject item)
   {
      if (selectedItem != null)
      {
         selectedItem.GetComponent<Image>().color = Color.gray;
         usableButton.interactable = false;

      }
      item.GetComponent<Image>().color = Color.red;
      if (item.GetComponent<InventoryItem>().usableItem)
      {
         usableButton.interactable = true;
      }
      else
      {
         usableButton.interactable = false;
      }
      selectedItem = item;

   }

   public void Use()
   {
      if (selectedItem != null)
      {
         selectedItem.GetComponent<IUsableItem>().Use();
         // CollectedItems.Remove(selectedItem);
         UpdateInventory();

      }
   }
   public void Remove()
   {
      Debug.Log("Remove : " + selectedItem.name);
      CollectedItems.Remove(selectedItem.GetComponent<InventoryItem>());

   }
}
