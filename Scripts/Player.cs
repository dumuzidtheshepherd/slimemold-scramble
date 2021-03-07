using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxVelocity;
    public Text scoreText;
    public Text endScoreText;
    public Text highScoreText;
    public GameObject endScreen;
    private float _score;
    private bool _dead;
    private Animator _anim;
    public float sensitivity;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _dead = false;
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _anim.SetBool("dead", _dead);
        _rb.velocity = Vector2.zero;
        if (!_dead)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 velocity = Input.GetTouch(0).deltaPosition;
                if (velocity.magnitude > maxVelocity)
                {
                    velocity = velocity.normalized * maxVelocity;
                }
                _rb.velocity = velocity;
                //transform.Translate(touchDeltaPosition * Time.deltaTime * sensitivity);
            }
            _score += Time.deltaTime;
            scoreText.text = ((int)_score).ToString();
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && endScreen.activeSelf)
        {
            SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _dead = true;
            if (PlayerPrefs.GetInt("High Score", 0) < (int)_score)
            {
                PlayerPrefs.SetInt("High Score", (int)_score);
            }
            StartCoroutine(ShowEndScreen());
        }
    }

    public bool IsDead()
    {
        return _dead;
    }

    public IEnumerator ShowEndScreen()
    {
        yield return new WaitForSeconds(1.0f);
        endScreen.SetActive(true);
        highScoreText.text = PlayerPrefs.GetInt("High Score", 0).ToString();
        endScoreText.text = scoreText.text;
    }

}
