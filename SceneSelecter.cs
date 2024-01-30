using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public string sceneName;

    void Update()
    {
        // 画面のどこかをクリックしたら Quiz シーンに遷移
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}