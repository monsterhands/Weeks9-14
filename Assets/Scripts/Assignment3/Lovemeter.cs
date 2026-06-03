using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Lovemeter : MonoBehaviour
{
    //get a reference for slider UI
    public Slider slider;
    //determine the slider value range status
    public bool isInFriend = false;
    public bool isInLove = false;
    public bool isInEnemy = false;
    //define unity events for slider range entrance
    public UnityEvent OnLoveEnter;
    public UnityEvent OnFriendEnter;
    public UnityEvent OnEnemyEnter;
    //references for UI barks
    public GameObject friendBarkA;
    public GameObject loveBarkA;
    public GameObject enemyBarkA;
    public GameObject friendBarkB;
    public GameObject loveBarkB;
    public GameObject enemyBarkB;
    //references for relevant scripts in the scene
    public Rhythmdate rhythmScriptA;
    public Rhythmdate rhythmScriptB;
    public CharacterSelect characterScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if either of the songs are playing
        if (rhythmScriptA.songIsPlaying == true || rhythmScriptB.songIsPlaying == true)
        {
            //if the value of the slider is at or above 70
            //sense the entering of the range for love
            if (slider.value >= 70)
            {
                if (isInLove == true)
                {

                }
                else
                {
                    //you've just entered the love zone
                    //invoke unity event for entering range
                    isInLove = true;
                    OnLoveEnter.Invoke();
                }
            }
            else
            {
                if (isInLove == true)
                {
                    //you're out of the zone
                    //reset to no longer detecting zone
                    isInLove = false;
                }
                else
                {

                }
            }

            //if the value of the slider is between 70 and 45
            //sense the entering of the range for friend
            if (slider.value < 70 && slider.value > 45)
            {
                if (isInFriend == true)
                {

                }
                else
                {
                    //you've just entered the friend zone
                    //invoke unity event for entering range
                    isInFriend = true;
                    OnFriendEnter.Invoke();
                }
            }
            else
            {
                if (isInFriend == true)
                {
                    //you're out of the zone
                    //reset to no longer detecting zone
                    isInFriend = false;
                }
                else
                {

                }
            }

            //if the value of the slider is less than 45
            //sense the entering of the range for friend
            if (slider.value <= 45)
            {
                if (isInEnemy == true)
                {

                }
                else
                {
                    //you've just entered the enemy zone
                    //invoke unity event for entering range
                    isInEnemy = true;
                    OnEnemyEnter.Invoke();
                }
            }
            else
            {
                if (isInEnemy == true)
                {
                    //you're out of the zone
                    //reset to no longer detecting zone
                    isInEnemy = false;
                }
                else
                {

                }
            }
        } else
        {

        }               
    }

    public void AddLove()
    {
        //if the slider value is below the max value
        if (slider.value < slider.maxValue)
        {
            //add to slider value
            slider.value++;
        } else
        {
            
        }
    }

    public void DecreaseLove()
    {
        //if the slider value is above the min value
        if (slider.value > slider.minValue)
        {
            //reduce slider value
            slider.value--;
        }
        else
        {
            
        }
    }

    public void LoveBarks()
    {
        //toggle on the love bark for monster A
        if(characterScript.monsterASelected == true)
        {
            if (isInLove == true)
            {
                loveBarkA.SetActive(true);
            }
            else
            {

            }
        }

        //toggle on the love bark for monster B
        if (characterScript.monsterBSelected == true)
        {
            if (isInLove == true)
            {
                loveBarkB.SetActive(true);
            }
            else
            {

            }
        }

    }

    public void FriendBarks()
    {
        //toggle on the friend bark for monster A
        if (characterScript.monsterASelected == true)
        {
            if (isInFriend == true)
            {
                friendBarkA.SetActive(true);
            }
            else
            {

            }
        }

        //toggle on the friend bark for monster B
        if (characterScript.monsterBSelected == true)
        {
            if (isInFriend == true)
            {
                friendBarkB.SetActive(true);
            }
            else
            {

            }
        }
    }

    public void EnemyBarks()
    {
        //toggle on the enemy bark for monster A
        if (characterScript.monsterASelected == true)
        {
            if (isInEnemy == true)
            {
                enemyBarkA.SetActive(true);
            }
            else
            {

            }
        }

        //toggle on the enemy bark for monster B
        if (characterScript.monsterBSelected == true)
        {
            if (isInEnemy == true)
            {
                enemyBarkB.SetActive(true);
            }
            else
            {

            }
        }
    }
}
