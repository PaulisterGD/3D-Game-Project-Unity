using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{
    public GameObject Textbox;
    public GameObject Choice1;
    public GameObject Choice12;
    public GameObject Choice13;
    public int ChoiceMade;

    public void ChoiceOption1 () {
        Textbox.GetComponent<Text>().text = "First choice made. Good decision. You're an ass man.";
        ChoiceMade = 1;
    }

    public void ChoiceOption2 () {
        Textbox.GetComponent<Text>().text = "Second choice made. Good decision. You like tatas.";
        ChoiceMade = 2;
    }

    public void ChoiceOption3 () {
        Textbox.GetComponent<Text>().text = "Third choice. Lame. Really?";
        ChoiceMade = 3;
    }

    void Update()
    {
        if (ChoiceMade >= 1){
            Choice1.SetActive(false);
            Choice12.SetActive(false);
            Choice13.SetActive(false);
        }

    }
}
