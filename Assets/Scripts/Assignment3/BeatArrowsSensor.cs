using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BeatArrowsSensor : MonoBehaviour
{
    //define the unity events for success and failure
    public UnityEvent OnSuccessHit;
    public UnityEvent OnFailHit;
    //determines if a beat is in the right sensor
    public bool isInSensorN = false;
    public bool isInSensorS = false;
    public bool isInSensorE = false;
    public bool isInSensorW = false;
    //determines if a beat was missed
    public bool missedBeatN = false;
    public bool missedBeatS = false;
    public bool missedBeatE = false;
    public bool missedBeatW = false;
    //determines if a beat is early
    public bool earlyBeatN = false;
    public bool earlyBeatS = false;
    public bool earlyBeatE = false;
    public bool earlyBeatW = false;
    //reference for relevant script in scene
    public BeatArrowSpawner spawnerScript;
    //sensor prefabs
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
        //a loop for cycling through and checking in the list of spawned beat objects
        for (int north = 0; north < spawnerScript.spawnedBeatsN.Count; north++)
        {
            //if there are objects in the list of spawned beats
            if (spawnerScript.spawnedBeatsN[north] != null)
            {
                //get the position of the beat to be picked up by the sensor from the list in the spawner script
                Vector3 CurrentBeatNPosition = spawnerScript.spawnedBeatsN[0].transform.position;
                //get the distance between the current sensed beat and the sensor for that beat's direction
                float distance1 = Vector2.Distance(CurrentBeatNPosition, sensorN.transform.position);
                //if the distance is less than a value,
                //indicate whether you are in the sensor
                if (distance1 < 0.5f)
                {
                    if (isInSensorN == true)
                    {
                        //in the sensor
                    }
                    else
                    {
                        //just entered the sensor
                        isInSensorN = true;
                        earlyBeatN = false;
                        //Debug.Log("in sensor N");
                    }
                }
                else
                {                    
                    if (isInSensorN == true)
                    {        
                        //the beat left the sensor
                        //the beat was missed!
                        missedBeatN = true;
                        //Debug.Log("left sensor N");
                        //reset the sensor detection for the next beat
                        isInSensorN = false;
                    }
                    else
                    {
                        //the beat hasn't touched the sensor a day in its life
                        earlyBeatN = true;
                    }
                }
            } else
            {
            
            }
        }

        //same kind of code for the other directions
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
                        earlyBeatS = false;
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
                        //the beat is on its way
                        //too early to hit
                        earlyBeatS = true;
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
                        earlyBeatE = false;
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
                        earlyBeatE = true;
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
                        earlyBeatW = false;
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
                        earlyBeatW = true;
                    }
                }
            }
            else
            {

            }
        }

    }

    //on a specific input (multiple tracked types), call a Unity Event
    public void OnBeatN(InputAction.CallbackContext context)
    {
        //if the context meets 'performed', aka the input is active,
        //assess further conditions
        if (context.performed == true)
        {
            //if the input is happening and the sensor is being tripped
            if (isInSensorN == true)
            {
                //the beat was hit and success was achieved
                //call the Unity Event for success
                OnSuccessHit.Invoke();    
                //destroy the spawned beat
                Destroy(spawnerScript.spawnedBeatsN[0]);
                //remove the spawned beat from the list
                spawnerScript.spawnedBeatsN.Remove(spawnerScript.spawnedBeatsN[0]);
                //toggle the sensor off after removal/destruction
                isInSensorN = false;
            } else if (earlyBeatN == true)
            {
                //if you hit the input too early before the sensor is tripped
                //you get a failed beat Unity Event
                OnFailHit.Invoke();
            }
            
        } else
        {

        }
        
    }

    //same commenting for the other inputs
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
            } else if (earlyBeatS == true)
            {
                OnFailHit.Invoke();
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
            } else if (earlyBeatE == true)
            {
                OnFailHit.Invoke();
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
            } else if (earlyBeatW == true)
            {
                OnFailHit.Invoke();
            }                
        }
        else
        {

        }

    }

    //this unity event indicates in console that the beat was a success
    public void SuccessBeat()
    {
        Debug.Log("Successful Beat!");
    }

    //this unity event indicates in console that the beat was a failure
    public void FailBeat()
    {
        Debug.Log("Failed Beat.");
    }

}
