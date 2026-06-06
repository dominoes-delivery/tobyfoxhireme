using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public SpriteRenderer Background;
    public TextMeshProUGUI EndText;

    private void Start()
    {
        if (turny_thing.Instance.isWin)
        {
            Background.color = Color.green;
            EndText.text = "You won!";
        }
        else
        {
            Background.color = Color.red;
            EndText.text = "You lost!";
        }
        
    }

    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
