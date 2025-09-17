using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //Enables use of uGUI classes

public class ScoreCounter : MonoBehaviour 
{

    [Header("Dynamic")]
    public int score = 0;
    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        uiText.text = score.ToString("#,0");
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;
        if (collideWith.CompareTage("Apple")) { 
        
            Destroy(collideWith);
            ScoreCounter.score += 100;
        
        }
    }

}
