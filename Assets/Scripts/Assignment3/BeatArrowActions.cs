using UnityEngine;

public class BeatArrowActions : MonoBehaviour
{
    //set a speed customizable in the inspector
    public float speed;
    //get the sprite renderer component
    public SpriteRenderer body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move downwards with time and at the speed set in inspector
        transform.position -= transform.up * speed * Time.deltaTime;
    }
}
