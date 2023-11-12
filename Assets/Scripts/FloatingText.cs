using System;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;
    public Boolean forever;
    public void Show(){
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }
    public void Hide(){
        active = false;
        go.SetActive(active);
    }
    public void UpdateFloatingText(){
        if(!active || forever) return;
        if(Time.time-lastShown>duration) Hide();
        go.transform.position+=motion*Time.deltaTime;
    }
}
