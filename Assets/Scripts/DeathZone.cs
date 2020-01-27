using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    public Text runes;

    void Start()
    {
        runes.text = "Runes: " + GameObject.FindGameObjectsWithTag("Rune").Length;
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);

        if (col.gameObject.tag == "Hero")
            SceneManager.LoadScene("Loose");
        
        if (col.gameObject.tag == "Rune")
        {
            runes.text = "Runes: " + (GameObject.FindGameObjectsWithTag("Rune").Length - 1);
            if (GameObject.FindGameObjectsWithTag("Rune").Length < 1)
                SceneManager.LoadScene("Win");
        }
    }
}