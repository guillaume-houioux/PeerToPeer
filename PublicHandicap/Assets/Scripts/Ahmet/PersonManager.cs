using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManager : MonoBehaviour
{
    [SerializeField] private GameObject Person = null;
    [SerializeField] private GameObject Deaf = null;
    [SerializeField] private GameObject Wheelchair = null;
    [SerializeField] private GameObject Blind = null;

    private ObstaclesManager cm;
    private List<GameObject> spawners;
    public float Timer = 1;
    public float timerRef = 0.5f;

    void Start()
    {
        cm = GameObject.Find("Obstacles_Manager").GetComponent<ObstaclesManager>();
        spawners = cm.spawners;
        Timer = timerRef;
    }

    private void FixedUpdate()
    {
        int randSpawn = Random.Range(0, spawners.Count);
        int randCharacter = Random.Range(0, 4);
        float x = spawners[randSpawn].transform.position[0];
        float y = spawners[randSpawn].transform.position[1];
        float z = spawners[randSpawn].transform.position[2];

        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            switch (randCharacter)
            {

                case 0:
                    Instantiate(Person, new Vector3(x, y, z), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Blind, new Vector3(x, y, z), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Deaf, new Vector3(x, y, z), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Wheelchair, new Vector3(x, y, z), Quaternion.identity);
                    break;
            }
            Timer = timerRef;
        }
    }


}
