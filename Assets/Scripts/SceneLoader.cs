using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ReturnToStart()
    {
        SceneManager.LoadScene("Start");
    }
}