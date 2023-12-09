using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Texture2D cursorTex;
    public GameObject loadingScreen, menuScreen;

    // Start is called before the first frame update 
    void Start()
    {
        // Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        loadingScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#endif
    }
}
