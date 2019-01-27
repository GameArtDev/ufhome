using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject ufo;
    List<GameObject> ufos = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        //for (int i=0; i< 3; i++)
        //{
        //    MovesManager moves =  ufo.GetComponent(typeof(MovesManager)) as MovesManager;
        //    moves.startPosition = new Vector3(ufo.transform.position.x + i, ufo.transform.position.y + i, 0);

        //    Instantiate(ufo);
        //}
    }

    // Update is called once per frame
    void Update()
    {


        if (GameObject.FindGameObjectsWithTag("ufo").Length < 1)
        {
            MovesManager moves = ufo.GetComponent(typeof(MovesManager)) as MovesManager;
            moves.startPosition = new Vector3(ufo.transform.position.x + 1, ufo.transform.position.y + 1, 0);
            ufo.tag = "ufo";
            Instantiate(ufo);

        }
    }
}
