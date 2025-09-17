using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -10f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}