using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MonsterTests
{
    [Test]
    public void BasicTest()
    {
        Assert.AreEqual(1, 1);
    }

    //Test if speed is set correctly
    [UnityTest]
    public IEnumerator MonsterMoveRandomSpeedSet()
    {
        GameObject monsterObject = new GameObject();
        MonsterMove monsterMove = monsterObject.AddComponent<MonsterMove>();

        yield return null;
        Assert.AreEqual(monsterMove.GetSpeed(), 0f);

        monsterObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(monsterMove.GetSpeed(), 0f);
    }
    //Test if fibonacci number is calculated correctly
    [Test]
    public void CorrectFibonacci()
    {
        GameObject gameObject = new GameObject();
        RoundsManager roundsManager = gameObject.AddComponent<RoundsManager>();

        Assert.AreEqual(roundsManager.CalculateFibonacci(1), 1);
        Assert.AreEqual(roundsManager.CalculateFibonacci(2), 1);
        Assert.AreEqual(roundsManager.CalculateFibonacci(3), 2);
        Assert.AreEqual(roundsManager.CalculateFibonacci(4), 3);
        Assert.AreEqual(roundsManager.CalculateFibonacci(5), 5);
        Assert.AreEqual(roundsManager.CalculateFibonacci(6), 8);
        Assert.AreEqual(roundsManager.CalculateFibonacci(7), 13);
        Assert.AreEqual(roundsManager.CalculateFibonacci(8), 21);
        Assert.AreEqual(roundsManager.CalculateFibonacci(9), 34);
        Assert.AreEqual(roundsManager.CalculateFibonacci(10), 55);
    }
    //Test if monsters are added to the pool correctly
    [UnityTest]
    public IEnumerator AddMonstersToPool_CorrectPoolSize()
    {
        GameObject TimerObject = new GameObject();
        Timer timer = TimerObject.AddComponent<Timer>();
        GameObject gameObject = new GameObject();
        MonsterPool monsterPool = gameObject.AddComponent<MonsterPool>();
        GameObject monsterObject = new GameObject();
        monsterPool.monsterPref = monsterObject;
        GameObject roundsObject = new GameObject();
        RoundsManager roundsManager = roundsObject.AddComponent<RoundsManager>();

        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(1, monsterPool.GetNumberOfMonstersInList());

        monsterPool.AddMonstersToPool(5);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(6, monsterPool.GetNumberOfMonstersInList());
    }
    //Test if the round number are correct
    [UnityTest]
    public IEnumerator CorrectRoundNumber()
    {
        GameObject TimerObject = new GameObject();
        Timer timer = TimerObject.AddComponent<Timer>();
        GameObject gameObject = new GameObject();
        MonsterPool monsterPool = gameObject.AddComponent<MonsterPool>();
        GameObject monsterObject = new GameObject();
        monsterPool.monsterPref = monsterObject;
        GameObject roundsObject = new GameObject();
        RoundsManager roundsManager = roundsObject.AddComponent<RoundsManager>();

        roundsManager.StartNextRound();
        yield return null;
        Assert.AreEqual(2, roundsManager.GetCurrentRound());
        roundsManager.StartNextRound();
        yield return null;
        Assert.AreEqual(3, roundsManager.GetCurrentRound());
    }

}
