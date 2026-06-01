using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject monsterAButton;
    public GameObject monsterBButton;
    public GameObject instructionsButton;
    public bool monsterASelected;
    public bool monsterBSelected;
    public GameObject MonsterA;
    public GameObject MonsterB;

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
    }

    public void ChooseMonsterB()
    {
        monsterBSelected = true;
        MonsterB.SetActive(true);
        monsterAButton.SetActive(false);
        monsterBButton.SetActive(false);
        instructionsButton.SetActive(true);
    }

    public void ResetMonster()
    {
        if (monsterASelected == true)
        {
            monsterASelected = false;
        } else if (monsterBSelected == true)
        {
            monsterBSelected = false;
        }
    }
}
