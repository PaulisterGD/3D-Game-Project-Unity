using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemRequirement
{
    public InventoryItemData itemData;
    public int amount;

    public bool HasRequirement()
	{
        InventoryItem item = InventorySystem.current.Get(itemData);

        if (item == null || item.stackSize < amount) { return false; }

        return true;
	}

}
