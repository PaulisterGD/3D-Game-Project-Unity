using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ButtonBehaviour : MonoBehaviour
{
    public CinemachineFreeLook vcam;
    public bool zoomCheck;
    public QuestProgressManager progressManager;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Zoom()
    {
        if (zoomCheck == true)
        {
            vcam.m_CommonLens = true;
            vcam.m_Lens.FieldOfView = 10;

            zoomCheck = false;
        }
        else
        {
            vcam.m_CommonLens = true;
            vcam.m_Lens.FieldOfView = 40;
            zoomCheck = true;
        }

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

    public void FinishGame()
	{
        if (progressManager.completionTally >= 6)
		{
            LoadScene("OUTRO");
		}
	}

    public void QuitGame()
	{
        Application.Quit();
	}
}
