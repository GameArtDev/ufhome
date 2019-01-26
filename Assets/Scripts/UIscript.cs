using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void StartGame()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        Time.timeScale = 1;

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
