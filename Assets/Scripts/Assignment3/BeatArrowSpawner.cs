using System.Collections.Generic;
using UnityEngine;

public class BeatArrowSpawner : MonoBehaviour
{
    //get a reference for the prefab arrows
    public GameObject beatarrowN;
    public GameObject beatarrowS;
    public GameObject beatarrowE;
    public GameObject beatarrowW;
    //lists for the times beats should spawn at
    public List<int> beatsTimerN;
    public List<int> beatsTimerS;
    public List<int> beatsTimerE;
    public List<int> beatsTimerW;
    //the beats to be targeted by the sensor script
    public int currentBeatN;
    public int currentBeatS;
    public int currentBeatE;
    public int currentBeatW;
    //timer value variables
    public float t;
    public int timerMax;
    //determines when the timer for the song has hit max
    public bool hitTimerMax = false;
    //latest spawned object and a list of all in the scene
    public GameObject spawnedBeatN;
    public List<GameObject> spawnedBeatsN;
    public GameObject spawnedBeatS;
    public List<GameObject> spawnedBeatsS;
    public GameObject spawnedBeatE;
    public List<GameObject> spawnedBeatsE;
    public GameObject spawnedBeatW;
    public List<GameObject> spawnedBeatsW;
    //determines when the song has fully ended
    public bool songEnded = false;
    //references to other relevant scripts in the scene
    public BeatArrowsSensor sensorScript;
    public Rhythmdate rhythmScriptA;
    public Rhythmdate rhythmScriptB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //at the beginning, set timer variables to 0
        t = 0;
        timerMax = 0;
        //set the current beat to 0
        currentBeatN = 0;
        currentBeatS = 0;
        currentBeatE = 0;
        currentBeatW = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        //if the timer goes over the timer max, it indicates the max has been hit
        if (t > timerMax)
        {
            hitTimerMax = true;
        }
        //if the song/level has ended, reset all variables set to 0 at start
        if (songEnded == true)
        {
            t = 0;
            timerMax = 0;
            currentBeatN = 0;
            currentBeatS = 0;
            currentBeatE = 0;
            currentBeatW = 0;
        }
        //otherwise if the song is playing, the timer runs
        else if (rhythmScriptA.songIsPlaying == true || rhythmScriptB.songIsPlaying == true)
        {
            t += Time.deltaTime;
        }
            
        //NOTE:
        //Pseudocode will explain the North beats example, as the rest of the directions
        //are almost identical
        //only differences will be commented


        //if there are no beat times in the list, the list is done
        if (beatsTimerN.Count == 0)
        {
            //Debug.Log("Finished north beats");
        } 
        //otherwise if there is one or more in the list
        //and the timer has reached the current time at the top of the list
        else if (beatsTimerN.Count > 0 && t > beatsTimerN[0])
        {
            //Debug.Log("Beat hit");
            //a beat is spawned from prefab
            spawnedBeatN = Instantiate(beatarrowN);
            //spawned beat is added to the list
            spawnedBeatsN.Add(spawnedBeatN);
            //the current beat to be used by the sensor is the first/top of the list beat 
            //not the most recently spawned
            currentBeatN = (int)beatsTimerN[0];
            //the time that spawned the beat to be hit is removed from the list
            beatsTimerN.Remove(currentBeatN);            
        }

        //if a beat is missed, as caught by the sensor
        if (sensorScript.missedBeatN == true)
        {
            //destroy the spawned beat
            Destroy(spawnedBeatsN[0]);
            //remove that beat from the list of spawned beats
            spawnedBeatsN.Remove(spawnedBeatsN[0]);
            //invoke unity event to alert a beat has been failed
            sensorScript.OnFailHit.Invoke();
            //reset the missed beat bool to catch future ones
            sensorScript.missedBeatN = false;
            //Debug.Log("Removed missed N");
        }

        if (beatsTimerS.Count == 0)
        {
            //Debug.Log("Finished south beats");
        }
        else if (beatsTimerS.Count > 0 && t > beatsTimerS[0])
        {
            //Debug.Log("Beat hit");
            spawnedBeatS = Instantiate(beatarrowS);
            spawnedBeatsS.Add(spawnedBeatS);
            currentBeatS = (int)beatsTimerS[0];
            beatsTimerS.Remove(currentBeatS);
        }

        if (sensorScript.missedBeatS == true)
        {
            Destroy(spawnedBeatsS[0]);
            spawnedBeatsS.Remove(spawnedBeatsS[0]);
            sensorScript.OnFailHit.Invoke();
            sensorScript.missedBeatS = false;
            //Debug.Log("Removed missed S");
        }

        if (beatsTimerE.Count == 0)
        {
            //Debug.Log("Finished east beats");
        }
        else if (beatsTimerE.Count > 0 && t > beatsTimerE[0])
        {
            //Debug.Log("Beat hit");
            spawnedBeatE = Instantiate(beatarrowE);
            spawnedBeatsE.Add(spawnedBeatE);
            currentBeatE = (int)beatsTimerE[0];
            beatsTimerE.Remove(currentBeatE);
        }

        if (sensorScript.missedBeatE == true)
        {
            Destroy(spawnedBeatsE[0]);
            spawnedBeatsE.Remove(spawnedBeatsE[0]);
            sensorScript.OnFailHit.Invoke();
            sensorScript.missedBeatE = false;
            //Debug.Log("Removed missed E");
        }

        //each song ends on a West beat
        //therefore, if there are no more beats in the list and the timer is at max
        //the song has ended
        if (beatsTimerW.Count == 0 && hitTimerMax == true)
        {
            songEnded = true;
        }
        else if (beatsTimerW.Count > 0 && t > beatsTimerW[0])
        {
            //Debug.Log("Beat hit");
            spawnedBeatW = Instantiate(beatarrowW);
            spawnedBeatsW.Add(spawnedBeatW);
            currentBeatW = (int)beatsTimerW[0];
            beatsTimerW.Remove(currentBeatW);
        }

        if (sensorScript.missedBeatW == true)
        {
            Destroy(spawnedBeatsW[0]);
            spawnedBeatsW.Remove(spawnedBeatsW[0]);
            sensorScript.OnFailHit.Invoke();
            sensorScript.missedBeatW = false;
            //Debug.Log("Removed missed W");
        }

    }

    public void PlayMonsterASong()
    {
        //this class is called to add the timestamps to a list of beats
        Debug.Log("Song A is playing");
        beatsTimerS.Add(1);
        beatsTimerN.Add(2);
        beatsTimerE.Add(3);
        beatsTimerW.Add(4);
        beatsTimerN.Add(5);
        beatsTimerS.Add(5);
        beatsTimerE.Add(6);
        beatsTimerS.Add(8);
        beatsTimerW.Add(9);
        beatsTimerE.Add(10);
        beatsTimerN.Add(12);
        beatsTimerW.Add(14);
        beatsTimerN.Add(14);
        beatsTimerE.Add(15);
        beatsTimerS.Add(16);
        beatsTimerE.Add(17);
        beatsTimerW.Add(18);
        beatsTimerN.Add(19);
        beatsTimerE.Add(20);
        beatsTimerN.Add(22);
        beatsTimerS.Add(22);
        beatsTimerW.Add(24);
        beatsTimerW.Add(26);
        beatsTimerS.Add(26);
        beatsTimerE.Add(27);
        beatsTimerS.Add(29);
        beatsTimerN.Add(31);
        beatsTimerE.Add(34);
        beatsTimerN.Add(35);
        beatsTimerE.Add(36);
        beatsTimerE.Add(37);
        beatsTimerW.Add(37);
        beatsTimerN.Add(39);
        beatsTimerS.Add(41);
        beatsTimerW.Add(44);
        beatsTimerN.Add(47);
        beatsTimerS.Add(48);
        beatsTimerS.Add(50);
        beatsTimerE.Add(52);
        beatsTimerW.Add(53);
        beatsTimerN.Add(54);
        beatsTimerS.Add(55);
        beatsTimerN.Add(56);
        beatsTimerW.Add(57);
        beatsTimerS.Add(59);
        beatsTimerE.Add(60);
        beatsTimerN.Add(60);
        beatsTimerW.Add(61);
        beatsTimerN.Add(62);
        beatsTimerW.Add(62);
        beatsTimerS.Add(63);
        beatsTimerS.Add(65);
        beatsTimerE.Add(66);
        beatsTimerW.Add(66);

        //set the timer to the unique max per the song
        timerMax = 70;
    }


    public void PlayMonsterBSong()
    {
        Debug.Log("Song B is playing");
        beatsTimerN.Add(1);
        beatsTimerW.Add(2);
        beatsTimerE.Add(3);
        beatsTimerS.Add(4);
        beatsTimerN.Add(4);
        beatsTimerN.Add(5);
        beatsTimerE.Add(7);
        beatsTimerN.Add(8);
        beatsTimerW.Add(9);
        beatsTimerS.Add(10);
        beatsTimerN.Add(12);
        beatsTimerE.Add(12);
        beatsTimerN.Add(14);
        beatsTimerE.Add(15);
        beatsTimerS.Add(17);
        beatsTimerW.Add(17);
        beatsTimerS.Add(18);
        beatsTimerN.Add(19);
        beatsTimerE.Add(20);
        beatsTimerW.Add(21);
        beatsTimerS.Add(22);
        beatsTimerN.Add(24);
        beatsTimerS.Add(25);
        beatsTimerN.Add(26);
        beatsTimerE.Add(27);
        beatsTimerN.Add(30);
        beatsTimerW.Add(31);
        beatsTimerS.Add(33);
        beatsTimerN.Add(35);
        beatsTimerW.Add(36);
        beatsTimerE.Add(37);
        beatsTimerS.Add(38);
        beatsTimerN.Add(39);
        beatsTimerW.Add(41);
        beatsTimerE.Add(43);
        beatsTimerN.Add(47);
        beatsTimerS.Add(47);
        beatsTimerN.Add(50);
        beatsTimerE.Add(52);
        beatsTimerW.Add(53);
        beatsTimerE.Add(55);
        beatsTimerW.Add(57);
        beatsTimerS.Add(58);
        beatsTimerN.Add(61);
        beatsTimerS.Add(61);
        beatsTimerE.Add(63);
        beatsTimerN.Add(64);
        beatsTimerS.Add(65);
        beatsTimerE.Add(66);
        beatsTimerN.Add(69);
        beatsTimerE.Add(70);
        beatsTimerW.Add(71);

        timerMax = 75;
    }

}
