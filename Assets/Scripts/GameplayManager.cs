using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public GameObject ufo;
    public GameObject enemy;
    public GameObject playerPrefab;
    public float numberOfUfos = 1;
    public float numberOfEnemies = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        var dist = (transform.position - Camera.main.transform.position).z;
        ContenxtInfo.LeftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        ContenxtInfo.RightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        ContenxtInfo.TopBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        ContenxtInfo.BottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("ufo").Length == 0)
        {
            GenerateUfo();
        }

        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            GenerateEnemy();
        }


    }

    void GenerateUfo()
    {
        for (int i = 0; i < numberOfUfos; i++)
        {
            MovesManager moves = ufo.GetComponent(typeof(MovesManager)) as MovesManager;
                moves.startPosition = new Vector3(
                    Random.Range(ContenxtInfo.LeftBorder, ContenxtInfo.RightBorder),
                    Random.Range(-5.4f, -4.0f)
                    , 0);

            ufo.tag = "ufo";
            ufo.transform.rotation = new Quaternion(0, 0, 0, 0);
            Instantiate(ufo);
        }
    }

    void GenerateEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {           
            enemy.transform.position = new Vector3(
                ContenxtInfo.RightBorder + Random.Range(0,15),
                Random.Range(-3.0f, 5.0f),
                0
            );

            enemy.transform.rotation = new Quaternion(0, 0, 0, 0);
            Instantiate(enemy);
        }
    }

    public static void GeneratePlayer()
    {
      //  playerPrefab.transform.position = new Vector3(-15, -0.5F, 0);
       // Instantiate(playerPrefab);
    }
}
