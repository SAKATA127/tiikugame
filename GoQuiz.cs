using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSceneSelector : MonoBehaviour
{
    public string[] sceneNames;

    void Update()
    {
        // 画面のどこかをクリックしたらランダムにシーン遷移
        if (Input.GetMouseButtonDown(0))
        {
            // ランダムにシーンを選択
            string randomSceneName = GetRandomSceneName();

            // 選択したランダムなシーンに遷移
            SceneManager.LoadScene(randomSceneName);
        }
    }

    string GetRandomSceneName()
    {
        // 配列からランダムに選択
        int randomIndex = Random.Range(0, sceneNames.Length);
        return sceneNames[randomIndex];
    }
}
