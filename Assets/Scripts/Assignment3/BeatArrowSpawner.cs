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
    public int timerMax;
    public bool hitTimerMax = false;
    public GameObject spawnedBeatN;
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
        timerMax = 0;
        currentBeatN = 0;
        currentBeatS = 0;
        currentBeatE = 0;
        currentBeatW = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        //add if condition for bool to pick song
        if (t > timerMax)
        {
            hitTimerMax = true;
        }
        if (songEnded == true)
        {
            t = 0;
            timerMax = 0;
            currentBeatN = 0;
            currentBeatS = 0;
            currentBeatE = 0;
            currentBeatW = 0;
        }
        else
        {
            t += Time.deltaTime;
        }
            

        if (beatsTimerN.Count == 0)
        {
            //Debug.Log("Finished north beats");
        } 
        else if (beatsTimerN.Count > 0 && t > beatsTimerN[0])
        {
            //Debug.Log("Beat hit");
            spawnedBeatN = Instantiate(beatarrowN);
            spawnedBeatsN.Add(spawnedBeatN);
            currentBeatN = (int)beatsTimerN[0];
            beatsTimerN.Remove(currentBeatN);            
        }

        if (sensorScript.missedBeatN == true)
        {
            Destroy(spawnedBeatsN[0]);
            spawnedBeatsN.Remove(spawnedBeatsN[0]);
            sensorScript.OnFailHit.Invoke();
            sensorScript.missedBeatN = false;
            Debug.Log("Removed missed N");
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
            Debug.Log("Removed missed S");
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
            Debug.Log("Removed missed E");
        }

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
            Debug.Log("Removed missed W");
        }

    }

    public void PlayMonsterASong()
    {
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
