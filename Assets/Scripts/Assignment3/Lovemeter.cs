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
    public GameObject friendBark;
    public GameObject loveBark;
    public GameObject enemyBark;
    public Rhythmdate rhythmScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.value = 35;
    }

    // Update is called once per frame
    void Update()
    {
        if (rhythmScript.songIsPlaying == true)
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
        if (isInLove == true)
        {
            loveBark.SetActive(true);
        } else
        {

        }
    }

    public void FriendBarks()
    {
        if (isInFriend == true)
        {
            friendBark.SetActive(true);
        }
        else
        {

        }
    }

    public void EnemyBarks()
    {
        if (isInEnemy == true)
        {
            enemyBark.SetActive(true);
        }
        else
        {

        }
    }
}
