using UnityEngine;
using UnityEngine.UIElements;

public class CharacterSelect : MonoBehaviour
{
    public GameObject monsterAButton;
    public GameObject monsterBButton;
    public GameObject instructionsButton;
    public GameObject instructionsGraphic;
    public bool instructionsRead;
    public bool monsterASelected;
    public bool monsterBSelected;
    public GameObject MonsterA;
    public GameObject MonsterB;
    public GameObject friendEndUIA;
    public GameObject friendEndUIB;
    public GameObject loveEndUIA;
    public GameObject loveEndUIB;
    public GameObject enemyEndUIA;
    public GameObject enemyEndUIB;
    public GameObject resetButton;
    public Lovemeter lovemeterScript;
    public BeatArrowSpawner spawnerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monsterASelected = false;
        monsterBSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseMonsterA()
    {
        monsterASelected = true;
        MonsterA.SetActive(true);
        monsterAButton.SetActive(false);
        monsterBButton.SetActive(false);
        instructionsButton.SetActive(true);
        instructionsGraphic.SetActive(true);
    }

    public void ChooseMonsterB()
    {
        monsterBSelected = true;
        MonsterB.SetActive(true);
        monsterAButton.SetActive(false);
        monsterBButton.SetActive(false);
        instructionsButton.SetActive(true);
        instructionsGraphic.SetActive(true);
    }
    public void ReadInstructions()
    {
        instructionsRead = true;
        instructionsButton.SetActive(false);
        instructionsGraphic.SetActive(false);
    }

    public void ResetMonster()
    {
        if (monsterASelected == true)
        {
            monsterASelected = false;
            MonsterA.SetActive(false);
        } else if (monsterBSelected == true)
        {
            monsterBSelected = false;
            MonsterB.SetActive(false);
        }
    }

    public void ResetRhythm()
    {
        friendEndUIA.SetActive(false);
        friendEndUIB.SetActive(false);
        loveEndUIA.SetActive(false);
        loveEndUIB.SetActive(false);
        enemyEndUIA.SetActive(false);
        enemyEndUIB.SetActive(false);
        ResetMonster();
        spawnerScript.hitTimerMax = false;
        spawnerScript.songEnded = false;
        lovemeterScript.slider.value = 35;
        lovemeterScript.isInEnemy = false;
        lovemeterScript.isInFriend = false;
        lovemeterScript.isInLove = false;
        instructionsRead = false;
        resetButton.SetActive(false);
        monsterAButton.SetActive(true);
        monsterBButton.SetActive(true);
    }
}
