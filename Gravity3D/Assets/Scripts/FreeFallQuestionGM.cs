using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FreeFallQuestionGM : MonoBehaviour
{
    public AudioSource correct;
    public AudioSource wrong;
    private int answeredCorrect = 0;
    public Ball ball1;
    public Ball ball2;
    public int gravity;
    public Text score;
    public Button leftAnswer;
    public Button rightAnswer;
    public Button resetButton;

    public AudioSource audioSource;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private float delayTime = 2f;

    public Text Mass1;
    public Text Mass2;
    public Text AR1;
    public Text AR2;
    public Text gravityText;
    
    
    void Start()
    {
        Reset();
        SetRandomQuestion();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftAnswer.onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightAnswer.onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            resetButton.onClick.Invoke();
        }
    }

    public void SetRandomQuestion()
    {
        
        questionText.color = Color.black;
        questionText.text = "Which ball will drop first?";
        ball1.RandValueChange(UnityEngine.Random.Range(0, 3));
        ball2.RandValueChange(UnityEngine.Random.Range(0, 3));
        ball1.rb.drag = UnityEngine.Random.Range(0, 7);
        ball2.rb.drag = UnityEngine.Random.Range(0, 7);
        gravity = UnityEngine.Random.Range(9, 20);

        Mass1.text = "Mass: " + ball1.rb.mass;
        Mass2.text = "Mass: " + ball2.rb.mass;
        AR1.text = "Air Resistence: " + ball1.rb.drag;
        AR2.text = "Air Resistence: " + ball2.rb.drag;
        gravityText.text = "Gravity: " + gravity;
        

        score.text = "Score: " + GameManager.gm.getScore();
    }
    
    IEnumerator TransitionToNextQuestion()
    {
        yield return new WaitForSeconds(delayTime);
        if (answeredCorrect < 5)
            Start();
        else
            questionText.text = "Congrats! You completed this section!";
    }

    public void UserSelectAnswer1()
    {
        if (ball1.rb.drag < ball2.rb.drag)
        {
            questionText.color = Color.green;
            correct.Play();
            answeredCorrect++;
            questionText.text = "Correct!";
            changeGravity();
            GameManager.gm.incScore();
            StartCoroutine(TransitionToNextQuestion());
        }
        else
        {
            wrong.Play();
            questionText.text = "Sorry, try again!";
            changeGravity();
            StartCoroutine(TransitionToNextQuestion());
        }
    }
    public void UserSelectAnswer2()
    {
        if (ball1.rb.drag > ball2.rb.drag)
        {
            questionText.color = Color.green;
            correct.Play();
            answeredCorrect++;
            questionText.text = "Correct!";
            changeGravity();
            GameManager.gm.incScore();
            StartCoroutine(TransitionToNextQuestion());
        }
        else
        {
            wrong.Play();
            questionText.text = "Sorry, try again!";
            changeGravity();
            StartCoroutine(TransitionToNextQuestion());
        }
    }
   
    public void Reset()
    {
        ball1.rb.useGravity = false;
        ball2.rb.useGravity = false;
        ball1.transform.position = ball1.startPos; //new Vector3(-3f, 2.8f, 0);
        ball2.transform.position = ball2.startPos; //new Vector3(3f, 2.8f, 0);
    }

    public void changeGravity()
    {
        Physics.gravity = new Vector3(0,-gravity);
        ball1.rb.useGravity = true;
        ball2.rb.useGravity = true;
        audioSource.Play();
    }
}
