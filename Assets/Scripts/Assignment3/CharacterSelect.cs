using UnityEngine;
using UnityEngine.UIElements;

public class CharacterSelect : MonoBehaviour
{
    //UI gameobjects defined in the inspector
    public GameObject monsterAButton;
    public GameObject monsterBButton;
    public GameObject monsterSelectUI;
    public GameObject instructionsButton;
    public GameObject instructionsGraphic;
    public GameObject friendEndUIA;
    public GameObject friendEndUIB;
    public GameObject loveEndUIA;
    public GameObject loveEndUIB;
    public GameObject enemyEndUIA;
    public GameObject enemyEndUIB;
    public GameObject resetButton;
    //boolean to determine if instructions were read
    public bool instructionsRead;
    //booleans to determine which monster was selected
    public bool monsterASelected;
    public bool monsterBSelected;
    //the monster game objects
    public GameObject MonsterA;
    public GameObject MonsterB;
    //two relevant scripts to connect this script to
    public Lovemeter lovemeterScript;
    public BeatArrowSpawner spawnerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //begin with no monster selections
        monsterASelected = false;
        monsterBSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseMonsterA()
    {
        //monster A is selected and the game object for it is activated in hierarchy
        monsterASelected = true;
        MonsterA.SetActive(true);
        //toggle off the UI for character selection
        monsterAButton.SetActive(false);
        monsterBButton.SetActive(false);
        monsterSelectUI.SetActive(false);
        //toggle on instructions UI
        instructionsButton.SetActive(true);
        instructionsGraphic.SetActive(true);
    }

    public void ChooseMonsterB()
    {
        //monster B is selected and the game object for it is activated in hierarchy
        monsterBSelected = true;
        MonsterB.SetActive(true);
        //toggle off the UI for character selection
        monsterAButton.SetActive(false);
        monsterBButton.SetActive(false);
        monsterSelectUI.SetActive(false);
        //toggle on instructions UI
        instructionsButton.SetActive(true);
        instructionsGraphic.SetActive(true);
    }
    public void ReadInstructions()
    {
        //the UI button press confirms the instructions were read
        instructionsRead = true;
        //toggle off instructions UI
        instructionsButton.SetActive(false);
        instructionsGraphic.SetActive(false);
    }

    public void ResetMonster()
    {
        //if monster A was just run, toggle off monster A game object and boolean
        if (monsterASelected == true)
        {
            monsterASelected = false;
            MonsterA.SetActive(false);
        } else if (monsterBSelected == true)
        {
            //otherwise if monster B was just run, toggle off monster B game object and boolean
            monsterBSelected = false;
            MonsterB.SetActive(false);
        }
    }

    public void ResetRhythm()
    {
        //when reset UI button is pressed
        //toggle off any active ending UI bark
        friendEndUIA.SetActive(false);
        friendEndUIB.SetActive(false);
        loveEndUIA.SetActive(false);
        loveEndUIB.SetActive(false);
        enemyEndUIA.SetActive(false);
        enemyEndUIB.SetActive(false);
        //run reset monster class
        ResetMonster();
        //reset timer and song end
        spawnerScript.hitTimerMax = false;
        spawnerScript.songEnded = false;
        //set the lovemeter slider value to base at 35
        lovemeterScript.slider.value = 35;
        //reset the emotional range of lovemeter
        lovemeterScript.isInEnemy = false;
        lovemeterScript.isInFriend = false;
        lovemeterScript.isInLove = false;
        //instructions are reset
        instructionsRead = false;
        //reset UI button is toggled off
        resetButton.SetActive(false);
        //character selection UI toggled on
        monsterSelectUI.SetActive(true);
        monsterAButton.SetActive(true);
        monsterBButton.SetActive(true);
    }
}
