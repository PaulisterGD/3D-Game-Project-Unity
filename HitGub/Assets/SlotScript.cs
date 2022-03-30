using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{

    [SerializeField]
    private Image m_icon;

    [SerializeField]
    private Text m_label;

    [SerializeField]
    private GameObject m_stackObj;

    [SerializeField]
    private Text m_stackLabel;

    public void Set(InventoryItem item)
    {
        //item = GetComponent<InventoryItem>();

        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        if(item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        } 
        else 
        {
            m_stackObj.SetActive(true);
        }

        m_stackLabel.text = item.stackSize.ToString();
    }
}
