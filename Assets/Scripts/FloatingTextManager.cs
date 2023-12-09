using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    public Font font;
    public GameObject image;
    // private List<FloatingText> floatingTexts = new List<FloatingText>();
    private static FloatingText txt;

    private void Start()
    {
        txt = new FloatingText();
        txt.go = Instantiate(textPrefab);
        txt.go.transform.SetParent(textContainer.transform);
        txt.txt = txt.go.GetComponent<Text>();
    }
    private void Update()
    {
        // foreach (FloatingText txt in floatingTexts)
        //     txt.UpdateFloatingText();
    }
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration, Boolean forever)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize + 2;
        floatingText.txt.color = Color.black;
        floatingText.txt.fontStyle = FontStyle.Normal;
        // Set the font style for a TextBox (you can use other controls as needed)
        floatingText.txt.font = font;
        floatingText.go.transform.position = floatingText.CalculateTextPosition(position); //Transform wolrd space to screen space so we can use it the UI
        floatingText.motion = motion;
        floatingText.duration = duration;
        floatingText.forever = forever;
        floatingText.Show();

    }
    public FloatingText GetFloatingText()
    {
        return txt;
    }
}
