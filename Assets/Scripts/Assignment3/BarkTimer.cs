using UnityEngine;

public class BarkTimer : MonoBehaviour
{
    //current bark UI game object
    public GameObject currentObject;
    //set up timer values
    private float timerValue;
    private float timerMaxValue = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //at start, set timer to 0
        timerValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if the current bark is active, start the timer
        if (currentObject.activeInHierarchy)
        {
            timerValue += Time.deltaTime;
        }

        //if the timer value exceeds the max value
        if (timerValue >= timerMaxValue)
        {
            //reset the timer to 0
            timerValue = 0;
            //toggle off the bark
            currentObject.SetActive(false);            
        }
    }
}
