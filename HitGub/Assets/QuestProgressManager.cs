using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestProgressManager : MonoBehaviour
{
    public int completionTally;
    public Text completionText;

    // Start is called before the first frame update
    void Start()
    {
        completionTally = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int requiredTotal = 6 - completionTally;
        if (requiredTotal < 0) requiredTotal = 0;
        completionText.text = "You've cleared " + completionTally + " quests!\n" + "Complete " + requiredTotal + " more quests to unlock the Finish button!";
    }

    public void QuestCountUp()
	{
        completionTally++;
	}
}
