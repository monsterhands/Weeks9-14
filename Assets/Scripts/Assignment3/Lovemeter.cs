using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Lovemeter : MonoBehaviour
{
    public Slider slider;
    public bool isInFriend = false;
    public bool isInLove = false;
    public bool isInEnemy = false;
    public UnityEvent OnLoveEnter;
    public UnityEvent OnFriendEnter;
    public UnityEvent OnEnemyEnter;
    public GameObject friendBarkA;
    public GameObject loveBarkA;
    public GameObject enemyBarkA;
    public GameObject friendBarkB;
    public GameObject loveBarkB;
    public GameObject enemyBarkB;
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
        if (rhythmScriptA.songIsPlaying == true || rhythmScriptB.songIsPlaying == true)
        {
            if (slider.value >= 70)
            {
                if (isInLove == true)
                {

                }
                else
                {
                    isInLove = true;
                    OnLoveEnter.Invoke();
                }
            }
            else
            {
                if (isInLove == true)
                {
                    isInLove = false;
                }
                else
                {

                }
            }

            if (slider.value < 70 && slider.value > 45)
            {
                if (isInFriend == true)
                {

                }
                else
                {
                    isInFriend = true;
                    OnFriendEnter.Invoke();
                }
            }
            else
            {
                if (isInFriend == true)
                {
                    isInFriend = false;
                }
                else
                {

                }
            }

            if (slider.value <= 45)
            {
                if (isInEnemy == true)
                {

                }
                else
                {
                    isInEnemy = true;
                    OnEnemyEnter.Invoke();
                }
            }
            else
            {
                if (isInEnemy == true)
                {
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
        if (slider.value <= slider.maxValue)
        {
            slider.value++;
        } else
        {
            
        }
    }

    public void DecreaseLove()
    {
        if (slider.value <= slider.minValue)
        {
            
        }
        else
        {
            slider.value--;
        }
    }

    public void LoveBarks()
    {
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
