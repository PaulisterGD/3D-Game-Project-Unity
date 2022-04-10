using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject m_slotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    private void DrawInventory()
    {
        foreach(InventoryItem item in InventorySystem.current.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        SlotScript slot = obj.GetComponent<SlotScript>();

        if (item != null) 
        {
            Debug.Log("Item Exists, running slot.Set script.");
            slot.Set(item);
        }
        else
        {
            Debug.Log("Item is null, gotta fix!");
        }
        
    }

    /*public void OnDestroy()
    {
        InventorySystem.current.onInventoryChangedEvent -= OnUpdateInventory;
    }*/
}
