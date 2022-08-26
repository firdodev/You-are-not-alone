using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStoryStart : MonoBehaviour
{
    // Loads Scene titled "Intro 2", aka the next cutscenes
    void OnEnable ()
    {
        SceneManager .LoadScene("Intro 2", LoadSceneMode.Single);
    }
}
