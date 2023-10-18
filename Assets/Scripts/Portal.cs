using UnityEngine;

public class Portal
{
    public string[] sceneNames;
    protected void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            GameManager.instance.SaveState();
            string sceneName = sceneNames[0];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
