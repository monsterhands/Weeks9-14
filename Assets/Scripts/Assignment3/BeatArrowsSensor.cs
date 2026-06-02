using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BeatArrowsSensor : MonoBehaviour
{
    public UnityEvent OnSuccessHit;
    public UnityEvent OnFailHit;
    public bool isInSensorN = false;
    public bool isInSensorS = false;
    public bool isInSensorE = false;
    public bool isInSensorW = false;
    public bool missedBeatN = false;
    public bool missedBeatS = false;
    public bool missedBeatE = false;
    public bool missedBeatW = false;
    public BeatArrowSpawner spawnerScript;
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
        for (int north = 0; north < spawnerScript.spawnedBeatsN.Count; north++)
        {
            if (spawnerScript.spawnedBeatsN[north] != null)
            {
                Vector3 CurrentBeatNPosition = spawnerScript.spawnedBeatsN[0].transform.position;
                float distance1 = Vector2.Distance(CurrentBeatNPosition, sensorN.transform.position);
                if (distance1 < 0.5f)
                {
                    if (isInSensorN == true)
                    {

                    }
                    else
                    {
                        isInSensorN = true;
                        //Debug.Log("in sensor N");
                    }
                }
                else
                {                    
                    if (isInSensorN == true)
                    {                        
                        missedBeatN = true;
                        //Debug.Log("left sensor N");
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

        for (int south = 0; south < spawnerScript.spawnedBeatsS.Count; south++)
        {
            if (spawnerScript.spawnedBeatsS[south] != null)
            {
                Vector3 CurrentBeatSPosition = spawnerScript.spawnedBeatsS[0].transform.position;
                float distance2 = Vector2.Distance(CurrentBeatSPosition, sensorS.transform.position);
                if (distance2 < 0.5f)
                {
                    if (isInSensorS == true)
                    {

                    }
                    else
                    {
                        isInSensorS = true;
                        //Debug.Log("in sensor S");
                    }
                }
                else
                {
                    if (isInSensorS == true)
                    {
                        missedBeatS = true;
                        //Debug.Log("left sensor S");
                        isInSensorS = false;
                    }
                    else
                    {

                    }
                }
            }
            else
            {

            }
        }

        for (int east = 0; east < spawnerScript.spawnedBeatsE.Count; east++)
        {
            if (spawnerScript.spawnedBeatsE[east] != null)
            {
                Vector3 CurrentBeatEPosition = spawnerScript.spawnedBeatsE[0].transform.position;
                float distance3 = Vector2.Distance(CurrentBeatEPosition, sensorE.transform.position);
                if (distance3 < 0.5f)
                {
                    if (isInSensorE == true)
                    {

                    }
                    else
                    {
                        isInSensorE = true;
                    }
                }
                else
                {
                    if (isInSensorE == true)
                    {
                        missedBeatE = true;
                        isInSensorE = false;
                    }
                    else
                    {

                    }
                }
            }
            else
            {

            }
        }

        for (int west = 0; west < spawnerScript.spawnedBeatsW.Count; west++)
        {
            if (spawnerScript.spawnedBeatsW[west] != null)
            {
                Vector3 CurrentBeatWPosition = spawnerScript.spawnedBeatsW[0].transform.position;
                float distance4 = Vector2.Distance(CurrentBeatWPosition, sensorW.transform.position);
                if (distance4 < 0.5f)
                {
                    if (isInSensorW == true)
                    {

                    }
                    else
                    {
                        isInSensorW = true;
                    }
                }
                else
                {
                    if (isInSensorW == true)
                    {
                        missedBeatW = true;
                        isInSensorW = false;
                    }
                    else
                    {

                    }
                }
            }
            else
            {

            }
        }

    }

    public void OnBeatN(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            if (isInSensorN == true)
            {
                OnSuccessHit.Invoke();                
                Destroy(spawnerScript.spawnedBeatsN[0]);
                spawnerScript.spawnedBeatsN.Remove(spawnerScript.spawnedBeatsN[0]);
                isInSensorN = false;
            } else
            {

            }
            
        } else
        {

        }
        
    }
    public void OnBeatS(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            if (isInSensorS == true)
            {
                OnSuccessHit.Invoke();
                Destroy(spawnerScript.spawnedBeatsS[0]);
                spawnerScript.spawnedBeatsS.Remove(spawnerScript.spawnedBeatsS[0]);
                isInSensorS = false;
            } else
            {

            }                
        }
        else
        {

        }

    }
    public void OnBeatE(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            if (isInSensorE == true)
            {
                OnSuccessHit.Invoke();
                Destroy(spawnerScript.spawnedBeatsE[0]);
                spawnerScript.spawnedBeatsE.Remove(spawnerScript.spawnedBeatsE[0]);
                isInSensorE = false;
            } else
            {

            }            
        }
        else
        {

        }

    }
    public void OnBeatW(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            if (isInSensorW == true)
            {
                OnSuccessHit.Invoke();
                Destroy(spawnerScript.spawnedBeatsW[0]);
                spawnerScript.spawnedBeatsW.Remove(spawnerScript.spawnedBeatsW[0]);
                isInSensorW = false;
            } else
            {

            }                
        }
        else
        {

        }

    }

    public void SuccessBeat()
    {
        Debug.Log("Successful Beat!");
    }

    public void FailBeat()
    {
        Debug.Log("Failed Beat.");
    }

}
