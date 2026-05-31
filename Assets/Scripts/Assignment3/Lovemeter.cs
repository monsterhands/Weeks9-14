using UnityEngine;
using UnityEngine.UI;

public class Lovemeter : MonoBehaviour
{
    public Slider slider;
    public bool isInFriend = false;
    public bool isInLove = false;
    public bool isInEnemy = false;
    public GameObject friendBark;
    public GameObject loveBark;
    public GameObject enemyBark;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.value = 35;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value >= 70)
        {
            isInLove = true;
            isInFriend = false;
            isInEnemy = false;
        } else if (slider.value < 70 && slider.value > 45)
        {
            isInFriend = true;
            isInEnemy = false;
            isInLove = false;
        } else if (slider.value <= 45)
        {
            isInEnemy = true;
            isInLove = false;
            isInFriend = false;
        }

        if (isInFriend == true)
        {
            friendBark.SetActive(true);
        }

        if (isInLove == true)
        {
            loveBark.SetActive(true);
        }

        if (isInEnemy == true)
        {
            enemyBark.SetActive(true);
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
}
