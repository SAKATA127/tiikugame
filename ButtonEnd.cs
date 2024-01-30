using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEnd : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("conversation-02");
    }
}