using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SwitchUI(string nameUI)
	{
        var userInterface = GameObject.Find(nameUI);
        if (userInterface != null)
		{
            userInterface.SetActive(true);
            gameObject.SetActive(false);
		}
	}
}
