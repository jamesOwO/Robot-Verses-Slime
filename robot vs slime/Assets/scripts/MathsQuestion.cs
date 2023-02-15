using UnityEngine.SceneManagement;
using System;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class MathsQuestion : MonoBehaviour
{
    public Text question;
    int number1, number2, total;
    public InputField input;
    int answer;
    public GameObject menuUI;
    bool CorrectAnswer = false;
    int activescene;



    void Start()
    {
        CorrectAnswer = false;

        number1 = UnityEngine.Random.Range(0, 13);
        number2 = UnityEngine.Random.Range(0, 13);
        total = number1 * number2;
        question.text = number1 + " X " + number2;
        Convert.ToString(total);
    }

    void Update()
    {
        Debug.Log(input.text);
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("enter");
            if (Convert.ToString(total) == input.text)
            {
                Debug.Log("equal");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }
    
}