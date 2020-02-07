using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FreeFallGM : MonoBehaviour
{
    public Canvas formulas;
    public Button dropButton;
    public Button resetButton;
    public InputField gravityPlaceholder;
    public Ball ball1;
    public Ball ball2;
    public float gravity = 9.81f;
    private int score;
    public Text ScoreText;
    public Text Mass1Text;
    public Text Mass2Text;
    private AudioSource audioSource;

    void Update()
    {
        score = GameManager.gm.getScore();
        ScoreText.text = "Score: " + score;
        Mass1Text.text = "Mass: " + ball1.rb.mass;
        Mass2Text.text = "Mass: " + ball2.rb.mass;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dropButton.onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            resetButton.onClick.Invoke();
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   public void HideCanvas()
    {
        formulas.gameObject.SetActive(!formulas.gameObject.activeInHierarchy);
    }
    public void Reset()
    {
        ball1.rb.useGravity = false;
        ball2.rb.useGravity = false;
        ball1.transform.position = ball1.startPos; //new Vector3(-3f, 2.8f, 0);
        ball2.transform.position = ball2.startPos; //new Vector3(3f, 2.8f, 0);
    }
    public void dropBalls()
    {
        ball1.rb.useGravity = true;
        ball2.rb.useGravity = true;
        audioSource.Play();
    }
    public void changeSceneGravity(string newGravity)
    {
        gravity = float.Parse(newGravity);
        Physics.gravity = new Vector3(0, -gravity, 0);
        gravityPlaceholder.placeholder.GetComponent<Text>().text = newGravity;

    }
    public void changeARBall1(string newForce)
    {
        ball1.rb.drag = float.Parse(newForce);
    }
    public void changeARBall2(string newForce)
    {
        ball2.rb.drag = float.Parse(newForce);
    }

}
