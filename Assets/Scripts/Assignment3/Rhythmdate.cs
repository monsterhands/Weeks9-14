using System.Collections;
using UnityEngine;

public class Rhythmdate : MonoBehaviour
{
    public AudioSource musicAudio;
    public CharacterSelect characterScript;
    public Lovemeter lovemeterScript;
    public BeatArrowSpawner spawnerScript;
    public BeatArrowsSensor sensorScript;
    public GameObject instructionsUI;
    public GameObject instructionsGraphic;
    public GameObject currentMonster;
    public Animator monsterAnimator;
    public bool songIsPlaying = false;
    public GameObject friendEndUI;
    public GameObject loveEndUI;
    public GameObject enemyEndUI;
    public GameObject resetButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(characterScript.instructionsRead == true && !songIsPlaying && !spawnerScript.songEnded)
        {            
            PickSong();
            songIsPlaying = true;
        } else
        {

        }
        
        if (spawnerScript.songEnded == true && spawnerScript.hitTimerMax == true)
        {
            songIsPlaying = false;
            StopCoroutine(AnimateMonster());
            EvaluateEnding();
        } else
        {

        }
    }

    void PickSong()
    {
        lovemeterScript.slider.value = 35;
        songIsPlaying = true;
        if (characterScript.monsterASelected == true)
        {
            spawnerScript.PlayMonsterASong();
        }
        else if (characterScript.monsterBSelected == true)
        {
            spawnerScript.PlayMonsterBSong();
        }
        musicAudio.Play();
        StartCoroutine(AnimateMonster());
    }

    IEnumerator AnimateMonster()
    {
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
        if(lovemeterScript.isInFriend == true)
        {
            friendEndUI.SetActive(true);
        } else
        {

        }

        if(lovemeterScript.isInLove == true)
        {
            loveEndUI.SetActive(true);
        } else
        {

        }

        if (lovemeterScript.isInEnemy == true)
        {
            enemyEndUI.SetActive(true);
        }
        else
        {

        }
        resetButton.SetActive(true);
    }

}
