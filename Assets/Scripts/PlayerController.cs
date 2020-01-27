using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    IguanaController iguanaCharacter;
    public float speed = 10;
    public Text lives;
    public Text score;

    private int _lives = 3;
    private int _score = 0;

    void Start ()
    {
		iguanaCharacter = GetComponent<IguanaController> ();
        lives.text = $"Lives: {_lives}.";
        score.text = $"Score: {_score}";
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, -1, 0);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, 1, 0);
    }
	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		iguanaCharacter.Move(v, h);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Damage")
        {
            _lives--;
            lives.text = $"Lives: {_lives}.";

            if (_lives <= 0)
                SceneManager.LoadScene("Loose");
        }

        if (col.gameObject.tag == "Score")
        {
            _score += 100;
            Destroy(col.gameObject);
            score.text = $"Score: {_score}";
        }
    }
}