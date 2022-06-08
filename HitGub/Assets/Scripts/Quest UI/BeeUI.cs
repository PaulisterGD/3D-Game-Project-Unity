using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeUI : MonoBehaviour
{
    public QuestUIConditionals questUIConditionals;
    public QuestUIManager questUIManager;
    public ItemObject[] requirementArray;

    private bool[] flowerFlags, waterFlags;

    // Start is called before the first frame update
    void Start()
    {
        flowerFlags = new bool[6];
        waterFlags = new bool[6];
        for (int i = 0; i < flowerFlags.Length; i++) { flowerFlags[i] = false; waterFlags[i] = false; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
