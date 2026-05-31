using UnityEngine;

public class BarkTimer : MonoBehaviour
{
    public GameObject currentObject;
    //public GameObject otherBark1;
    //public GameObject otherBark2;
    private float timerValue;
    private float timerMaxValue = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObject.activeInHierarchy)
        {
            timerValue += Time.deltaTime;
            //otherBark1.SetActive(false);
            //otherBark2.SetActive(false);
        }

        if (timerValue >= timerMaxValue)
        {
            timerValue = 0;
            currentObject.SetActive(false);            
        }
    }
}
