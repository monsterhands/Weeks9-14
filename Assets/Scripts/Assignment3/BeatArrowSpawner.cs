using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatArrowSpawner : MonoBehaviour
{
    public GameObject beatarrowN;
    public GameObject beatarrowS;
    public GameObject beatarrowE;
    public GameObject beatarrowW;
    public List<int> beatsTimerN;
    public List<int> beatsTimerS;
    public List<int> beatsTimerE;
    public List<int> beatsTimerW;
    public int currentBeatN;
    public int currentBeatS;
    public int currentBeatE;
    public int currentBeatW;
    public float t;
    public bool timerMax = false;
    public GameObject spawnedBeatN;
    //public GameObject currentSpawnBeatN;
    public List<GameObject> spawnedBeatsN;
    public GameObject spawnedBeatS;
    public List<GameObject> spawnedBeatsS;
    public GameObject spawnedBeatE;
    public List<GameObject> spawnedBeatsE;
    public GameObject spawnedBeatW;
    public List<GameObject> spawnedBeatsW;
    public bool songEnded = false;
    public BeatArrowsSensor sensorScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = 0;
        currentBeatN = 0;
        currentBeatS = 0;
        currentBeatE = 0;
        currentBeatW = 0;
        PlayMonsterASong();
        Debug.Log("Song is playing");
    }

    // Update is called once per frame
    void Update()
    {
        //add if condition for bool to pick song
        t += Time.deltaTime;

        if (beatsTimerN.Count == 0 && spawnedBeatsN.Count < 0)
        {
            Debug.Log("Finished north beats");
        } else if (beatsTimerN.Count > 0 && t > beatsTimerN[0])
        {
            Debug.Log("Beat hit");
            spawnedBeatN = Instantiate(beatarrowN);
            spawnedBeatsN.Add(spawnedBeatN);
            //currentSpawnBeatN = spawnedBeatsN[0];
            currentBeatN = (int)beatsTimerN[0];
            beatsTimerN.Remove(currentBeatN);            
        }
        if (sensorScript.missedBeat == true)
        {
            //GameObject currentSpawnBeatN = spawnedBeatsN[0];
            Destroy(spawnedBeatsN[0]);
            spawnedBeatsN.Remove(spawnedBeatsN[0]);
            sensorScript.OnFailHit.Invoke();
        }

        if (beatsTimerS.Count == 0)
        {
            Debug.Log("Finished south beats");
        }
        else if (beatsTimerS.Count > 0 && t > beatsTimerS[0])
        {
            Debug.Log("Beat hit");
            spawnedBeatS = Instantiate(beatarrowS);
            spawnedBeatsS.Add(spawnedBeatS);
            currentBeatS = (int)beatsTimerS[0];
            beatsTimerS.Remove(currentBeatS);
        }

        if (beatsTimerE.Count == 0 && timerMax == true)
        {
            Debug.Log("Finished east beats");
        }
        else if (beatsTimerE.Count > 0 && t > beatsTimerE[0])
        {
            Debug.Log("Beat hit");
            spawnedBeatE = Instantiate(beatarrowE);
            spawnedBeatsE.Add(spawnedBeatE);
            currentBeatE = (int)beatsTimerE[0];
            beatsTimerE.Remove(currentBeatE);
        }

        if (beatsTimerW.Count == 0 && timerMax == true)
        {
            songEnded = true;
            t = 0;
        }
        else if (beatsTimerW.Count > 0 && t > beatsTimerW[0])
        {
            Debug.Log("Beat hit");
            spawnedBeatW = Instantiate(beatarrowW);
            spawnedBeatsW.Add(spawnedBeatW);
            currentBeatW = (int)beatsTimerW[0];
            beatsTimerW.Remove(currentBeatW);
        }

    }

    public void PlayMonsterASong()
    {
        beatsTimerN.Add(1);
        beatsTimerW.Add(2);
        beatsTimerE.Add(3);
        beatsTimerS.Add(4);
        beatsTimerN.Add(4);
        //beatsTimerN.Add(5);
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
        beatsTimerE.Add(67);
        beatsTimerN.Add(69);
        beatsTimerN.Add(70);
        beatsTimerE.Add(70);
        beatsTimerW.Add(71);


        if (t>72)
        {
            timerMax = true;
        }
    }


    void PlayMonsterBSong()
    {

    }

}
