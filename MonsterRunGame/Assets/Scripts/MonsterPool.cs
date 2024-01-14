using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public static MonsterPool instance;
    public GameObject monsterPref; //monster prefab
    private List<GameObject> monsterlist; //A list of monsters for the monster pool
    private int poolSize = 1; //Initial size of the pool 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        monsterlist = new List<GameObject>();
    }
    //Add initials monsters to the pool, and Start first round
    void Start()
    {
        AddMonstersToPool(poolSize);
        RoundsManager.instance.StartNextRound();
    }
    public int GetNumberOfMonstersInList()
    {
        Debug.Log(monsterlist.Count);
        return monsterlist.Count;
    }
    // Add monsters to the pool, desactive them and set it as childs of the pool
    public void AddMonstersToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject monster = Instantiate(monsterPref);
            monster.SetActive(false);
            monsterlist.Add(monster);
            monster.transform.parent = transform;
        }
    }

    //Activates a monster.
    private GameObject GetMonster()
    {
        for(int i=0; i < monsterlist.Count; i++)
        {
            if(!monsterlist[i].activeSelf)
            {
                monsterlist[i].SetActive(true);
                return monsterlist[i];
            }
        }
        //If there arent enough monsters:
        GameObject newMonster = Instantiate(monsterPref);
        monsterlist.Add(newMonster);
        newMonster.transform.parent = transform;
        return newMonster;
    }
    //Get a monster in the initial position, that is where the monster pool is
    public void SpawnMonster()
    {
        GameObject monster = GetMonster();
        monster.transform.position = transform.position;
    }

}
