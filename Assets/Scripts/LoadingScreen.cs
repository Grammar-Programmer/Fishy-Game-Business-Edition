using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    public string startGame;
    private long start;
    private long waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        start = DateTime.Now.Ticks;
    }


    // Update is called once per frame
    void Update()
    {
        // Create a new thread and pass in a method that will handle the waiting and notification
        waitingTime = DateTime.Now.Ticks - start;
        if (new TimeSpan(waitingTime).TotalMilliseconds > 4300) SceneManager.LoadScene(startGame);
    }
}
