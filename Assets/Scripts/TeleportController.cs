using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportController : MonoBehaviour
{
    private bool isTeleporting = false;

    // Start is called before the first frame update
    void Start()
    {
        isTeleporting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.T) && !isTeleporting) {
            isTeleporting = true;
            if (SceneManager.GetActiveScene().buildIndex == 1) {
                SceneManager.LoadSceneAsync(2);
            } else {
                SceneManager.LoadSceneAsync(1);
            }
        }
    }
}
