using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStartButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("conversation-01");
    }
}