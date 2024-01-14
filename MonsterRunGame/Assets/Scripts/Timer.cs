using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    private float currentTime = 0;
    public TMP_Text totalTime;
    public static Timer instance;

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

    //Update timer and timer text
    void Update()
    {
        currentTime += Time.deltaTime;
        if(totalTime != null)
            totalTime.text = currentTime.ToString("0");
    }
    public void Restart()
    {
       currentTime = 0;
    }
}