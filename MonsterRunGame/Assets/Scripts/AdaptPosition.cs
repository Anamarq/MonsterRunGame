using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapt to any screen
public class AdaptPosition : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject monsterSpawner;
    public GameObject limitRight;
    // Start is called before the first frame update
    void Update()
    {
        // Left Border of the screeen
        Vector3 posLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 3, mainCamera.transform.position.z));

        // Right Border of the screeen
        Vector3 posRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, mainCamera.transform.position.z));

        // Set positions
        monsterSpawner.transform.position = new Vector3(posLeft.x, posLeft.y, 0f);
        limitRight.transform.position = new Vector3(posRight.x, posRight.y, 0f);
    }
}

