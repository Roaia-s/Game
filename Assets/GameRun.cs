using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRun : MonoBehaviour
{
    public RuntimeAnimatorController firstAnim;
    public RuntimeAnimatorController secondAnim;
    public RuntimeAnimatorController wrongAnswerAnim;
    public RuntimeAnimatorController correctAnswerAnim;
    public GameObject gameObj;

    public Image[] answerImg;
    public Sprite[] answerSprit;
    public Sprite[] questionSprit;
    public Image questionImg;

    public static int questionIndex;
    string actionSpriteName;
    public Text answerText;
    public Text ScoreText;
    public int Score = 0;
    public bool IsLevelComplete;



    public float transitionDelay = 0.05f;
    [SerializeField] private AudioSource SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        questionIndex = 1;
        IsLevelComplete = false;

        //nextBtn.interactable = false;
        gameObj.GetComponent<Animator>().runtimeAnimatorController = firstAnim;
        setSprite();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsLevelComplete)
        {

            Invoke("LoadNextLevel", transitionDelay);
        }
    }
    //set animation against
    public IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        gameObj.GetComponent<Animator>().runtimeAnimatorController = firstAnim;
        setSprite();
        answerText.text = "";
        ScoreText.text = Score.ToString();


    }
    public void setSprite()
    {
        // set sprite to question
        questionImg.GetComponent<Image>().sprite = questionSprit[questionIndex - 1];
        for (int i = 0; i < 6; i++)
        {
            answerImg[i].GetComponent<Image>().sprite = answerSprit[i];
            answerImg[i].GetComponent<Animator>().runtimeAnimatorController = null;
        }
    }
    public void correctAnswer()
    {
        // set question image sprite name 
        string questionName = questionImg.sprite.name;
        if (questionName.Equals(actionSpriteName))
        {
            answerText.text = "Correct Answer !";
            answerImg[questionIndex - 1].GetComponent<Animator>().runtimeAnimatorController = correctAnswerAnim;
            Score++;
            ScoreText.text = Score.ToString();
            nextQuestion();
        }
        else
        {
            answerText.text = "Wrong Answer !";
        }
    }
    //this meathod for answer button action
    public void answerSpriteAction(Image image)
    {
        actionSpriteName = image.sprite.name;
        image.GetComponent<Animator>().runtimeAnimatorController = wrongAnswerAnim;
        correctAnswer();
    }
    public void nextQuestion()
    {
        answerText.text = "";
        ScoreText.text = Score.ToString();
        if (questionIndex < 6)
        {
            ++questionIndex;
        }
        else
        {
            IsLevelComplete = true;
        }
        gameObj.GetComponent<Animator>().runtimeAnimatorController = secondAnim;
        StartCoroutine(startAnimation());
    }

    void LoadNextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
