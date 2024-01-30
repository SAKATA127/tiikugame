using UnityEngine;
using UnityEngine.SceneManagement;

public class IncorrectSceneController : MonoBehaviour
{
    void Update()
    {
        // 画面のどこかをクリックしたら Quiz シーンに遷移
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("quiz");
        }
    }
}
