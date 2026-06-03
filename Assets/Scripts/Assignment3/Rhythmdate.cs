using System.Collections;
using UnityEngine;

public class Rhythmdate : MonoBehaviour
{
    //reference audio source component
    public AudioSource musicAudio;
    //reference relevant scripts from scene
    public CharacterSelect characterScript;
    public Lovemeter lovemeterScript;
    public BeatArrowSpawner spawnerScript;
    public BeatArrowsSensor sensorScript;
    //reference UI objects
    public GameObject instructionsUI;
    public GameObject instructionsGraphic;
    public GameObject currentMonster;    
    public GameObject friendEndUI;
    public GameObject loveEndUI;
    public GameObject enemyEndUI;
    public GameObject resetButton;
    //reference for animator
    public Animator monsterAnimator;
    //determine if song is playing
    public bool songIsPlaying = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //if the instructions were read and the song is not playing and not just ended
        if(characterScript.instructionsRead == true && !songIsPlaying && !spawnerScript.songEnded)
        {            
            //pick the song being played
            PickSong();
        } else
        {
            //do nothing
        }
        
        //if the song has just ended and the timer is at max
        if (spawnerScript.songEnded == true && spawnerScript.hitTimerMax == true)
        {
            //the song is no longer playing
            songIsPlaying = false;
            //cease coroutine for animating between ranges
            StopCoroutine(AnimateMonster());
            //evaluate what kind of ending you achieved
            EvaluateEnding();
        } else
        {
            //do nothing
        }
    }

    void PickSong()
    {
        //set the initial value of the lovemeter slider
        lovemeterScript.slider.value = 35;
        //song has begun playing
        songIsPlaying = true;
        //if monster A is active, play their song
        //otherwise play monster B's song
        if (characterScript.monsterASelected == true)
        {
            spawnerScript.PlayMonsterASong();
        }
        else if (characterScript.monsterBSelected == true)
        {
            spawnerScript.PlayMonsterBSong();
        }
        //begin audio
        musicAudio.Play();
        //begin cycling through relevant animations for the monster
        StartCoroutine(AnimateMonster());
    }

    //coroutine to assess lovemeter range you're in
    //and activate the relevant animation clip on loop
    IEnumerator AnimateMonster()
    {
        //active while the song is playing
        while (spawnerScript.songEnded == false)
        {
            if (lovemeterScript.isInEnemy == true)
            {
                monsterAnimator.SetBool("isEnemy", true);
            } else
            {
                monsterAnimator.SetBool("isEnemy", false);
            }

            if (lovemeterScript.isInFriend == true)
            {
                monsterAnimator.SetBool("isFriend", true);
            } else
            {
                monsterAnimator.SetBool("isFriend", false);
            }

            if (lovemeterScript.isInLove == true)
            {
                monsterAnimator.SetBool("isLove", true);
            } else
            {
                monsterAnimator.SetBool("isLove", false);
            }
            yield return null;
        }
    }

    public void EvaluateEnding()
    {
        //if you ended the song in the friend zone,
        //toggle the friend ending
        if(lovemeterScript.isInFriend == true)
        {
            friendEndUI.SetActive(true);
        } else
        {
            //do nothing
        }

        //if you ended the song in the love zone,
        //toggle the love ending
        if (lovemeterScript.isInLove == true)
        {
            loveEndUI.SetActive(true);
        } else
        {
            //do nothing
        }

        //if you ended the song in the enemy zone,
        //toggle the enemy ending
        if (lovemeterScript.isInEnemy == true)
        {
            enemyEndUI.SetActive(true);
        }
        else
        {
            //do nothing
        }

        //toggle on the reset UI button
        resetButton.SetActive(true);
    }

}
