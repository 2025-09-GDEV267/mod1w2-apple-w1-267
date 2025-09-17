using UnityEngine;

public class TreeScript : MonoBehaviour
{
    const int RANGE = 5;
  
    public GameObject applePrefab;

    public float speed = 1;

    public float appleDropDelay = 1;

    public float changeDirChance = 0.1f;

    private void Start()
    {
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple",appleDropDelay);
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -RANGE)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > RANGE)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
