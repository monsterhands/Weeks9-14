using System.Collections;
using UnityEngine;

public class Rhythmdate : MonoBehaviour
{
    public AudioSource musicAudio;
    public CharacterSelect characterScript;
    public Lovemeter lovemeterScript;
    public BeatArrowSpawner spawnerScript;
    public BeatArrowsSensor sensorScript;
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
        if (characterScript.monsterASelected == true || characterScript.monsterBSelected == true)
        {
            songIsPlaying = true;
            PickSong();
        } else if (characterScript.monsterASelected == false && characterScript.monsterBSelected == false && spawnerScript.songEnded == true)
        {
            songIsPlaying = false;
            StopCoroutine(AnimateMonster());
            EvaluateEnding();
        }
    }

    void PickSong()
    {
        if (currentMonster.activeInHierarchy)
        {
            float t = 0;
            t += Time.deltaTime;

            if (t > 3)
            {
                t = 0;
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
            
        } else
        {

        }
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

    public void ResetRhythm()
    {
        friendEndUI.SetActive(false);
        loveEndUI.SetActive(false);
        enemyEndUI.SetActive(false);
        characterScript.ResetMonster();
        lovemeterScript.slider.value = 35;
        lovemeterScript.isInEnemy = false;
        lovemeterScript.isInFriend = false;
        lovemeterScript.isInLove = false;
        resetButton.SetActive(false);
        characterScript.monsterAButton.SetActive(true);
        characterScript.monsterBButton.SetActive(true);
    }
}
