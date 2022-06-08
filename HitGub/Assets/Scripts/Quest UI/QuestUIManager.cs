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
    public List<Sprite> clipBoardQuestSprite = new List<Sprite>;

    // Start is called before the first frame update
    private void Start()
	{
        clipBoardQuestSprite = null;
        animator = popUp.GetComponent<Animator>();
        animator.SetBool("PopUpFlag", false);
	}

    public void SetClipboardSprite (Sprite sprite)
	{
        clipBoardQuestSprite.Add(sprite);
	}

    public void SetPopUpSprite (Sprite sprite)
	{                  
        popUp.sprite = sprite;                              //Clear out the last sprite and replace it with the new one.
        animator.SetBool("PopUpFlag", true);                //Start the quest pop-up animation
        Invoke("EndPopUp", 3);
    }

    public void EndPopUp()
	{
        animator.SetBool("PopUpFlag", false);
    }
}
