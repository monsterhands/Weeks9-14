using UnityEngine;

public class BeatArrowActions : MonoBehaviour
{
    public float speed;
    public SpriteRenderer body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime;
    }
}
