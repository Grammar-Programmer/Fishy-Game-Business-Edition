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
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
        GameManager.instance.floatingTextManager.image.SetActive(active);
    }
    public void Hide()
    {
        active = false;
        go.SetActive(active);
        GameManager.instance.floatingTextManager.image.SetActive(active);
    }
    public void UpdateFloatingText()
    {
        if (!active || forever) return;
        if (Time.time - lastShown > duration) Hide();
        go.transform.position += motion * Time.deltaTime;
    }

    public Vector3 CalculateTextPosition(Vector3 objectPosition)
    {

        float x = 800 / 2.0f;
        float y = 400 / 2.0f;
        float z = objectPosition.z;

        return new Vector3(x, y, z);
    }

}
