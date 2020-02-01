using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    InventoryUI inventory;
    InventorySlot[] slots;

    /* void Start() {
        inventory = InventoryUI.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update() {
        
    }

    void UpdateUI() {
        for(int i = 0; i < slots.Length; i++) {
            if(i < inventory.itemsParent.Count) {
                slots[i].AddItem(inventory.itemsParent[i]);
            }
            else {
                slots[i].ClearSlot();
            }
        }
    } */
}
