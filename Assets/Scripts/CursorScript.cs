using UnityEngine;

public class CursorScript : MonoBehaviour
{
    private Camera cam;
    public int desvioX;
    public int desvioY;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = false;
        cam = Camera.main;
    }

    void OnGUI()
    {
        if (GameManager.instance != null)
        {
            Vector2 v = GameManager.instance.player.velocity;
            if (v.x != 0 || v.y != 0) return;
        }

        Vector3 mousePosition = Input.mousePosition;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = mousePosition.x + desvioX;
        mousePos.y = mousePosition.y + desvioY;

        transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 12));
    }

    // Update is called once per frame
    void Update()
    {
        OnGUI();
    }

}
