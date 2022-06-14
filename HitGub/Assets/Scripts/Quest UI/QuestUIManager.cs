using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    //Declaring the UI element that handles the popup Quest UI sprite.
    public Image popUp;

    //Declare the animator that moves the quest UI sprite in and out of the screen.
    public Animator animator;

    //Declare the sprite that will be given by other scripts for the pop-in Quest UI.
    public Sprite selectedPopUpSprite;
    public Sprite[] clipBoardQuestSprite = new Sprite[12];
    public Image[] UISprites = new Image[9];

    // Start is called before the first frame update
    private void Start()
	{
        clipBoardQuestSprite = null;
        animator = GameObject.FindWithTag("QuestUI").GetComponent<Animator>();
        animator.SetBool("PopUpFlag", false);
	}

    public void SetClipboardSprite (Sprite cbSprite, int id)
	{
        UISprites[id].sprite = cbSprite;
        //UpdateClipboard();
	}

    public void SetPopUpSprite (Sprite sprite)
	{                  
        popUp.sprite = sprite;                              //Clear out the last sprite and replace it with the new one.
        animator.SetBool("PopUpFlag", true);                //Start the quest pop-up animation
        StartCoroutine(EndPopUp());
    }

    IEnumerator EndPopUp()
	{
        yield return new WaitForSeconds(5);
        animator.SetBool("PopUpFlag", false);
    }

    /*
    public void UpdateClipboard()
	{
        if (clipBoardQuestSprite != null)
		{
            for (int i = 0; i < clipBoardQuestSprite.Length; i++)
			{
                if(clipBoardQuestSprite[i] != null)
				{
                    UISprites[i].sprite = clipBoardQuestSprite[i];
				}
			}
		}
	}
    */
}
