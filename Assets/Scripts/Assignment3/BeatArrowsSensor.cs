using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BeatArrowsSensor : MonoBehaviour
{
    public UnityEvent OnSuccessHit;
    public UnityEvent OnFailHit;
    public UnityEvent OnBeatSHit;
    public UnityEvent OnBeatEHit;
    public UnityEvent OnBeatWHit;
    public bool isInSensorN = false;
    public bool missedBeat = false;
    public BeatArrowSpawner spawnerScript;
    //public GameObject currentBeatN;
    public GameObject sensorN;
    public GameObject sensorS;
    public GameObject sensorE;
    public GameObject sensorW;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //
        for (int i = 0; i < spawnerScript.spawnedBeatsN.Count; i++)
        {
        if (spawnerScript.spawnedBeatN != null)
                {
                    Vector3 CurrentBeatNPosition = spawnerScript.spawnedBeatsN[i].transform.position;
                    //Vector3 NextBeatNPosition = spawnerScript.spawnedBeatN.transform.position;
                    float distance1 = Vector2.Distance(CurrentBeatNPosition, sensorN.transform.position);
                    //float distance2 = Vector2.Distance(NextBeatNPosition, sensorN.transform.position);
                    if (distance1 < 0.2f)
                    {
                        if (isInSensorN == true)
                        {

                        }
                        else
                        {
                            isInSensorN = true;
                        }
                    }
                    else
                    {
                        if (isInSensorN == true)
                        {
                            missedBeat = true;
                            isInSensorN = false;
                        }
                        else
                        {

                        }
                    }
                } else
                {
            
                }
        }
            
        
    }

    public void OnBeatN(InputAction.CallbackContext context)
    {
        if (context.performed == true && isInSensorN==true)
        {
            OnSuccessHit.Invoke();
            //GameObject currentSpawnBeatN = spawnerScript.spawnedBeatsN[spawnerScript.spawnedBeatsN.Count -1];
            Destroy(spawnerScript.spawnedBeatsN[0]);
            spawnerScript.spawnedBeatsN.Remove(spawnerScript.spawnedBeatsN[0]);
            isInSensorN = false;
        } else if (context.performed == true && !isInSensorN)
        {

        }
        
    }
    public void OnBeatS(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            OnBeatSHit.Invoke();
        }

    }
    public void OnBeatE(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            OnBeatEHit.Invoke();
        }

    }
    public void OnBeatW(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            OnBeatWHit.Invoke();
        }

    }

    public void SuccessBeat()
    {
        Debug.Log("Successful Beat!");
    }

    public void FailBeat()
    {
        Debug.Log("Failed Beat.");
        missedBeat = false;
    }
}
