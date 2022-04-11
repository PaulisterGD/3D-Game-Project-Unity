using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Abstract class that defines the various types of interaction available and the functions behind them.
    public enum InteractionType
    {
        Click,              //PRESS E to interact
        Hold,               //HOLD E to interact
        Minigame            //This is for minigames and custom code. (currently unused)
    }

    public InteractionType interactionType;

    public abstract string GetDescription();        //Function that displays text on screen when you approach an interactable object
    public abstract void Interact();                //Function that begins interaction when you press the E button.

    /*
    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    */
}
