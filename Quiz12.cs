using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager12 : MonoBehaviour
{
    public Button correctButton;
    public Button incorrectButton1;
    public Button incorrectButton2;

    private bool isAnswered = false;

    void Start()
    {
        // ボタンにクリックイベントを追加
        correctButton.onClick.AddListener(() => OnAnswerSelected(true));
        incorrectButton1.onClick.AddListener(() => OnAnswerSelected(false));
        incorrectButton2.onClick.AddListener(() => OnAnswerSelected(false));
    }

    void OnAnswerSelected(bool isCorrect)
    {
        if (!isAnswered)
        {
            isAnswered = true;

            if (isCorrect)
            {
                // 正解の場合、に遷移
                SceneManager.LoadScene("quiz-12-correct");
            }
            else
            {
                // 不正解の場合、に遷移
                SceneManager.LoadScene("quiz-12-incorrect");
            }
        }
    }
}
