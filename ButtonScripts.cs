using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string[] sceneNames = { "maze-01-play", "maze-01-2-play", "maze-01-3-play" }; // シーン名の配列

    public void OnClick()
    {
        if (sceneNames.Length > 0)
        {
            int randomIndex = Random.Range(0, sceneNames.Length);

            SceneManager.LoadScene(sceneNames[randomIndex]);
        }
    }
}
