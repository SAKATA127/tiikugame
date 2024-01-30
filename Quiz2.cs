using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager2 : MonoBehaviour
{
    public Button correctButton2;
    public Button incorrectButton2_1;
    public Button incorrectButton2_2;

    private bool isAnswered2 = false;

    void Start()
    {
        // ボタンにクリックイベントを追加
        correctButton2.onClick.AddListener(() => OnAnswerSelected(true));
        incorrectButton2_1.onClick.AddListener(() => OnAnswerSelected(false));
        incorrectButton2_2.onClick.AddListener(() => OnAnswerSelected(false));
    }

    void OnAnswerSelected(bool isCorrect2)
    {
        if (!isAnswered2)
        {
            isAnswered2 = true;

            if (isCorrect2)
            {
                // 正解の場合、に遷移
                SceneManager.LoadScene("quiz-02-correct");
            }
            else
            {
                // 不正解の場合、に遷移
                SceneManager.LoadScene("quiz-02-incorrect");
            }
        }
    }
}
