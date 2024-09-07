using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Resetart_game()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
