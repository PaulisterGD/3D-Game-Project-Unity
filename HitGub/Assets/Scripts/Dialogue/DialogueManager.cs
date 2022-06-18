using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Declaring the GameObjects on the Canvas in the scene that handle the dialogue.
    public Text nameText;
    public Text dialogueText;

    //Declaring the animator that makes the dialogue box go in and out of the screen
    public Animator animator;

    //Declaring the queue that handles the sequence of sentences in dialogue.
    public Queue<string> names;
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();            //Initialise the queue of dialogues
        names = new Queue<string>();
    }

    //Function that starts the dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);                   //Start the animation that brings the dialogue box on-screen.

        names.Clear();                                      //Clear the previous queue of names.
        sentences.Clear();                                  //Clear the previous queue of sentences.

        //Queue the new names
        foreach (string name in dialogue.name) { names.Enqueue(name); }
        //Queue the new sentences
        foreach (string sentence in dialogue.sentences) { sentences.Enqueue(sentence); }

        //Start the function that displays the next sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Check first if there's no more sentences.
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Ready up the next sentence AND name for printing
        string name = names.Dequeue();
        string sentence = sentences.Dequeue();

        StopAllCoroutines();                        //If the previous sentence is still being typed, stop that...
        StartCoroutine(TypeSentence(name, sentence));     //...and start typing the next sentence.
        //dialogueText.text = sentence;
    }

    //Coroutine to type the next sentence in the queue
    IEnumerator TypeSentence(string name, string sentence)
    {
        //Start with an empty dialogue text box
        nameText.text = "";
        dialogueText.text = "";

        //Then, type the sentence, letter-by-letter
        nameText.text = name;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //Function that happens when there's no more sentences to type.
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);      //Bring the dialogue box off-screen.
        Debug.Log("End of conversation.");
    }
}