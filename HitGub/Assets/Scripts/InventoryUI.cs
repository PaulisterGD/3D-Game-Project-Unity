using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject m_slotPrefab;
    public Sprite m_slotSprite;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        InventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
        image = GetComponent<Image>();
        image.color = Color.clear;
        image.sprite = null;
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

        if (InventorySystem.current.inventory == null)
        {
            image.color = Color.clear;
            image.sprite = null;
        }
        else
        {
            image.color = Color.white;
            image.sprite = m_slotSprite;
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
            Debug.LogError("Item is null, gotta fix!");
        }
        
    }

    /*public void OnDestroy()
    {
        InventorySystem.current.onInventoryChangedEvent -= OnUpdateInventory;
    }*/
}
