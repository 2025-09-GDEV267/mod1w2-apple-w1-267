using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float speed = 10f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;

    private int applesDropped = 0;
    public int applesInWave = 20;

    float timeBeforeDirectionChange = 1f;

    float timeBetweenWaves = 3f;
    int levelAt = 0;
    bool treePause = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReStart();        
    }

    void ReStart()
    {
        treePause = false;
        levelAt++;
        timeBeforeDirectionChange = Random.Range(1f, 6f);
        Invoke(nameof(ChangeDirection), timeBeforeDirectionChange);
        applesInWave = 15 + (levelAt * 5);
        appleDropDelay = Mathf.Clamp(1f / levelAt * 2, 0.33f, 2f);
         // Start dropping apples                                          
        Invoke(nameof(DropApple), appleDropDelay);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        applesDropped++;
        if (applesDropped == applesInWave)
        {
            // Start a new wave
            applesDropped = 0;            
            treePause = true;
            Invoke(nameof(ReStart), timeBetweenWaves);
            return;
        }        
        Invoke(nameof(DropApple), appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (treePause) return;

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);   // move right
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);  // move left
        }
    }
    private void ChangeDirection()
    {
        speed *= -1;    // Change Direction
        timeBeforeDirectionChange = Random.Range(1f, 6f);
        Invoke(nameof(ChangeDirection), timeBeforeDirectionChange);
    }
    /*private void FixedUpdate()
    {
        // Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance)  // randomly change dir
        {
            speed *= -1;    // Change Direction
        }
    }
    */
}
