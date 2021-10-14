using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUiManager : MonoBehaviour
{

    public void StartBtn()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("스타또!");
    }
    public void LoadBtn()
    {
        Debug.Log("로드...");
    }
    public void QuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        

    }
}
