using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem current;
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    public event Action onInventoryChangedEvent;
    public void InventoryChangedEvent()
    {
        if(onInventoryChangedEvent != null)
        {
            onInventoryChangedEvent();
        }
    }

    private void Awake()
    {
        current = this;
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void ItemAdd(InventoryItemData referenceData)
    {
        Debug.Log("Item pickup runs itemAdd function.");
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            Debug.Log("if statement returns true");
            value.AddToStack();
        }
        else
        {
            Debug.Log("if statement returns false");
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }

        InventoryChangedEvent();
    }

    public void Remove(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            Debug.Log("Removing from stack");
            if(value.stackSize <= 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }

        InventoryChangedEvent();
    }
}