using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneController : MonoBehaviour {

    private void Start()
    {
        PlayerPrefs.SetInt("difficulty", -1);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneLoadingController.Instance.LoadScene((GameScenes)sceneIndex, true);
    }
    public void LoadSceneWithCPU(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
        LoadScene(1);
    }
}
