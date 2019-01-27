using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject ufo;
    List<GameObject> ufos = new List<GameObject>();
    public float numberOfUfos = 1;
    
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
            GenerateUfo(numberOfUfos);
        }
    }

    void GenerateUfo(float numOfUfo)
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
}
