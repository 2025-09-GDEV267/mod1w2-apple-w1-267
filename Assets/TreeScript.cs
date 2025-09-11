using UnityEngine;

public class TreeScript : MonoBehaviour
{
    const int RANGE = 5;
    public void moveTree()
    {
        transform.position = new Vector3(Random.Range(-RANGE, RANGE), transform.position.y, transform.position.z);
    }
}
