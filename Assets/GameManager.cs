using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TreeScript tree;
    [SerializeField]
    float timerValue = 0;
    float timerTime;
    int points;
    private void Start()
    {
        timerTime = timerValue;
    }

    private void Update()
    {
        if (timerTime > 0)
        {
            timerTime -= Time.deltaTime;
        }
        else
        {
            moveTree();
            timerTime = timerValue;
        }
    }

    void moveTree()
    {
        tree.moveTree();
    }
}
