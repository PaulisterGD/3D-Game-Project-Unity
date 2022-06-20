using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class INTRO : MonoBehaviour
{
    void OnEnable() 
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }
}
