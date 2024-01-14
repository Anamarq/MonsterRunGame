using UnityEngine;
using TMPro;
//Controls the rounds of the game,
//and the number of monsters that must be instantiated according to the round,
//based on the Fibonacci sequence
public class RoundsManager : MonoBehaviour
{
   // public int maxRounds = 10;  // max rounds
    private int currentRound = 1;  // current round
    private int monsterCount = 0;  // Counts monsters that have arrived to the border of the screen
    private int fibonacciValue = 1; // fibonacci value
    public static RoundsManager instance; //Rounds manager is a global instance
    public TMP_Text numberOfMonsters;
    public TMP_Text roundNumber;

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
    }

    public int GetCurrentRound()
    {
        return currentRound;    
    }


    //Add 1 to the monster counter and, if everyone has reached the edge of the screen,
    //start the next round after a brief interval
    public void IncrementMonsterCount()
    {
        monsterCount++;
        if(monsterCount >= fibonacciValue)
        {
            monsterCount = 0;
            int previusFibonacci = fibonacciValue; 
            fibonacciValue = CalculateFibonacci(currentRound);
            MonsterPool.instance.AddMonstersToPool(fibonacciValue - previusFibonacci);
            Invoke("StartNextRound", 1.5f);
        }
    }
    public void StartNextRound()
    {
        // Configure Fibonacci Secuence
        if(numberOfMonsters != null)
            numberOfMonsters.text = fibonacciValue.ToString();
        Timer.instance.Restart();
        // Instantiate monsters without loops
        InstantiateMonsters(fibonacciValue, 0);
        if (roundNumber != null)
            roundNumber.text = currentRound.ToString();
        // Increases round number 
        currentRound++;  
    }

    //Recursive function that is responsible for instantiating monsters
    void InstantiateMonsters(float remainingMonsters, int currentIndex)
    {
        if (remainingMonsters > 0)
        {
            MonsterPool.instance.SpawnMonster();
            InstantiateMonsters(remainingMonsters - 1, currentIndex + 1);
        }
    }


    //Recursive function that is responsible for calculate Fibonacci value
    public int CalculateFibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        else
        {
            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }
    }
}
