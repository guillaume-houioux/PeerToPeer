using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public enum TYPE
{
    isBlind,
    isDeaf,
    isWheelchair,
    isPerson
}

internal enum STATE
{
    SAD,
    DOORS,
    DOOREXIT,
    STAIRS,
    STAIRSEXIT,
    BRAILLE,
    PANNEL,
    TRAIN,
    BRAILLE_TOP,
    DOORS_TOP,
    DOORS_TOP_EXIT
}
public class Person : MonoBehaviour
{
    private ObstaclesManager cm;
    private Door entranceDoor;
    private Door exitDoor;
    private Door entranceDoorTop;
    private Door exitDoorTop;
    private Door entranceStair;
    private Door exitStair;
    private Door entranceBraille;
    private Door entrancePannel;
    private Door entranceBraille_top;
    private GameObject entranceTrain;
    private GameObject sad;
    private List<GameObject> sad2;
    private float shortlyDestroyPoint;
    private bool flag=false;
    private int index;

    public TYPE type;
    private STATE state = STATE.DOORS;
    private Vector2 initPosition;
    private float Timer = 2;

    public MoneyManager moneyManager;
    public SatisfactionManager satisfactionManager;

    private void Start()
    {
        this.loadDoors();
        this.loadBraille();
        this.loadStairs();
        this.loadPannels();
        this.loadBrailleTop();
        this.loadDoorsTop();
        this.loadTrainDoors();
        this.loadSad();

        moneyManager = FindObjectOfType<MoneyManager>();
        satisfactionManager = FindObjectOfType<SatisfactionManager>();

    }

    private void loadSad()
    {   
        this.sad2 = cm.sad;
        // Random between 1-2 
        int rand = Random.Range(0, sad2.Count);
        this.sad = sad2[rand];
    }

    private void loadTrainDoors()
    {
        List<GameObject> doors = cm.train_doors;
        // Random between 1-2 
        int rand = Random.Range(0, doors.Count);
        this.entranceTrain = doors[rand];
    }

    private void loadDoors()
    {
        this.cm = GameObject.Find("Obstacles_Manager").GetComponent<ObstaclesManager>();
        this.initPosition = transform.position;
        List<Door> entrances = new List<Door>();
        List<Door> exits = new List<Door>();
        List<GameObject> doors = cm.doors;
        for (int i = 0; i < doors.Count; i++)
        {
            GameObject child0 = doors[i].transform.GetChild(0).gameObject; //dangeureux
            Door entrance = child0.GetComponent<Door>();

            GameObject child1 = doors[i].transform.GetChild(1).gameObject; //dangeureux
            Door exit = child1.GetComponent<Door>();
            switch (this.type)
            {
                case TYPE.isBlind:
                    if (entrance.allowBlind == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }

                    break;
                case TYPE.isDeaf:
                    if (entrance.allowDeaf == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }

                    break;
                case TYPE.isWheelchair:
                    if (entrance.allowWheelchair == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }
                      ;
                    break;
                case TYPE.isPerson:
                    if (entrance.allowPerson == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }
                    break;
            };
        }
        if (entrances.Count == 0)
        {
            int rand = Random.Range(0, entrances.Count);
            GameObject randomEntrance = doors[rand].transform.GetChild(0).gameObject; //dangeureux
            this.entranceDoor = randomEntrance.GetComponent<Door>();
        }
        else
        {
            int rand = Random.Range(0, entrances.Count);
            this.entranceDoor = entrances[rand];
            this.exitDoor = exits[rand];
        }
    }

    private void loadDoorsTop()
    {
        this.cm = GameObject.Find("Obstacles_Manager").GetComponent<ObstaclesManager>();
        this.initPosition = transform.position;
        List<Door> entrances = new List<Door>();
        List<Door> exits = new List<Door>();
        List<GameObject> doors = cm.doors_top;
        for (int i = 0; i < doors.Count; i++)
        {
            GameObject child0 = doors[i].transform.GetChild(0).gameObject; //dangeureux
            Door entrance = child0.GetComponent<Door>();

            GameObject child1 = doors[i].transform.GetChild(1).gameObject; //dangeureux
            Door exit = child1.GetComponent<Door>();
            switch (this.type)
            {
                case TYPE.isBlind:
                    if (entrance.allowBlind == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }

                    break;
                case TYPE.isDeaf:
                    if (entrance.allowDeaf == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }

                    break;
                case TYPE.isWheelchair:
                    if (entrance.allowWheelchair == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }
                      ;
                    break;
                case TYPE.isPerson:
                    if (entrance.allowPerson == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }
                    break;
            };
        }
        if (entrances.Count == 0)
        {
            int rand = Random.Range(0, entrances.Count);
            GameObject randomEntrance = doors[rand].transform.GetChild(0).gameObject; //dangeureux
            this.entranceDoorTop = randomEntrance.GetComponent<Door>();
        }
        else
        {
            int rand = Random.Range(0, entrances.Count);
            this.entranceDoorTop = entrances[rand];
            this.exitDoorTop = exits[rand];
        }
    }

    private void loadStairs()
    {
        List<GameObject> stairs = cm.stairs;
        List<Door> entrances = new List<Door>();
        List<Door> exits = new List<Door>();


        for (int i = 0; i < stairs.Count; i++)
        {
            GameObject child0 = stairs[i].transform.GetChild(0).gameObject; //dangeureux
            Door entrance = child0.GetComponent<Door>();

            GameObject child1 = stairs[i].transform.GetChild(1).gameObject; //dangeureux
            Door exit = child1.GetComponent<Door>();
            switch (this.type)
            {
                case TYPE.isBlind:
                    if (entrance.allowBlind == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }

                    break;
                case TYPE.isDeaf:
                    if (entrance.allowDeaf == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }

                    break;
                case TYPE.isWheelchair:
                    if (entrance.allowWheelchair == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }
                      ;
                    break;
                case TYPE.isPerson:
                    if (entrance.allowPerson == true)
                    {
                        entrances.Add(entrance);
                        exits.Add(exit);
                    }
                    break;
            };
        }
        if (entrances.Count == 0)
        {
            int rand = Random.Range(0, stairs.Count);
            GameObject randomEntrance = stairs[rand].transform.GetChild(0).gameObject; //dangeureux
            this.entranceStair = randomEntrance.GetComponent<Door>();
        }
        else
        {
            int rand = Random.Range(0, entrances.Count);
            this.entranceStair = entrances[rand];
            this.exitStair = exits[rand];
        }

    }

    private void loadBraille()
    {
        List<GameObject> brailles = cm.brailles;
        // Random between 1-2 
        int rand = Random.Range(0, brailles.Count);
        GameObject child0 = brailles[rand].transform.GetChild(0).gameObject; //dangeureux
        this.entranceBraille = child0.GetComponent<Door>();
    }

    private void loadPannels()
    {
        List<GameObject> pannels = cm.pannels;
        // Random between 1-2 
        int rand = Random.Range(0, pannels.Count);
        GameObject child0 = pannels[rand].transform.GetChild(0).gameObject; //dangeureux
        this.entrancePannel = child0.GetComponent<Door>();
    }

    private void loadBrailleTop()
    {
        List<GameObject> braille = cm.brailles_top;
        // Random between 1-2
        int rand = Random.Range(0, braille.Count);
        GameObject child0 = braille[rand].transform.GetChild(0).gameObject; //dangeureux
        this.entranceBraille_top = child0.GetComponent<Door>();
    }

    private void FixedUpdate()
    {

        switch (this.state)
        {
            case STATE.DOORS:
                transform.position = Vector2.MoveTowards(transform.position, this.entranceDoor.transform.position, 3f * Time.deltaTime);
                if (this.entranceDoor.transform.position == transform.position)
                {
                    switch (this.type)
                    {
                        case TYPE.isPerson:
                            if (this.entranceDoor.allowPerson && this.entranceDoor.isWorking) this.state = STATE.DOOREXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isBlind:
                            if (this.entranceDoor.allowBlind && this.entranceDoor.isWorking) this.state = STATE.DOOREXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isDeaf:
                            if (this.entranceDoor.allowDeaf && this.entranceDoor.isWorking) this.state = STATE.DOOREXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isWheelchair:
                            if (this.entranceDoor.allowWheelchair && this.entranceDoor.isWorking) this.state = STATE.DOOREXIT;
                            else this.state = STATE.SAD;
                            break;
                    }
                }
                break;
            case STATE.DOOREXIT:
                transform.position = Vector2.MoveTowards(transform.position, this.exitDoor.transform.position, 3f * Time.deltaTime);

                if (this.exitDoor.doorManager != null)
                {
                    this.exitDoor.doorManager.DecreaseUsingCountDown();
                }

                if (this.exitDoor.transform.position == transform.position)
                {
                    switch (this.type)
                    {
                        case TYPE.isPerson:
                            if (this.entranceDoor.allowPerson) this.state = STATE.STAIRS;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isBlind:
                            if (this.entranceDoor.allowBlind) this.state = STATE.BRAILLE;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isDeaf:
                            if (this.entranceDoor.allowDeaf) this.state = STATE.PANNEL;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isWheelchair:
                            if (this.entranceDoor.allowWheelchair) this.state = STATE.STAIRS;
                            else this.state = STATE.SAD;
                            break;
                    }
                }
                break;
            case STATE.BRAILLE:
                if (entranceBraille.isWorking)
                {

                    if (this.entranceBraille.doorManager != null)
                    {
                        this.entranceBraille.doorManager.DecreaseUsingCountDown();
                    }

                    transform.position = Vector2.MoveTowards(transform.position, this.entranceBraille.transform.position, 3f * Time.deltaTime);
                    if (this.entranceBraille.transform.position == transform.position)
                    {
                        this.Timer -= Time.deltaTime;

                        if (Timer <= 0f)
                        {
                            this.state = STATE.STAIRS;
                            this.Timer = 2f;
                        }

                    }
                }
                else
                {
                    this.state = STATE.SAD;
                }
                break;
            case STATE.PANNEL:
                if (entrancePannel.isWorking)
                {
                    transform.position = Vector2.MoveTowards(transform.position, this.entrancePannel.transform.position, 3f * Time.deltaTime);
                    if (this.entrancePannel.transform.position == transform.position)
                    {
                        this.Timer -= Time.deltaTime;

                        if (Timer <= 0f)
                        {
                            this.state = STATE.STAIRS;
                            this.Timer = 2f;
                        }

                    }
                }
                else
                {
                    this.state = STATE.SAD;
                }
                break;
            case STATE.BRAILLE_TOP:
                if (entranceBraille_top.isWorking)
                {

                    if (this.entranceBraille_top.doorManager != null)
                    {
                        this.entranceBraille_top.doorManager.DecreaseUsingCountDown();
                    }

                    transform.position = Vector2.MoveTowards(transform.position, this.entranceBraille_top.transform.position, 3f * Time.deltaTime);
                    if (this.entranceBraille_top.transform.position == transform.position)
                    {
                        this.Timer -= Time.deltaTime;

                        if (Timer <= 0f)
                        {
                            this.state = STATE.DOORS_TOP;
                            this.Timer = 2f;
                        }
                    }
                }
                else
                {
                    this.state = STATE.SAD;
                }
                break;
            case STATE.DOORS_TOP:
                transform.position = Vector2.MoveTowards(transform.position, this.entranceDoorTop.transform.position, 3f * Time.deltaTime);
                if (this.entranceDoorTop.transform.position == transform.position)
                {
                    switch (this.type)
                    {
                        case TYPE.isPerson:
                            if (this.entranceDoorTop.allowPerson && this.entranceDoorTop.isWorking) this.state = STATE.DOORS_TOP_EXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isBlind:
                            if (this.entranceDoorTop.allowBlind && this.entranceDoorTop.isWorking) this.state = STATE.DOORS_TOP_EXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isDeaf:
                            if (this.entranceDoorTop.allowDeaf && this.entranceDoorTop.isWorking) this.state = STATE.DOORS_TOP_EXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isWheelchair:
                            if (this.entranceDoorTop.allowWheelchair && this.entranceDoorTop.isWorking) this.state = STATE.DOORS_TOP_EXIT;
                            else this.state = STATE.SAD;
                            break;
                    }
                }
                break;
            case STATE.DOORS_TOP_EXIT:
                transform.position = Vector2.MoveTowards(transform.position, this.exitDoorTop.transform.position, 3f * Time.deltaTime);
                if (this.exitDoorTop.transform.position == transform.position)
                {
                    this.state = STATE.TRAIN;
                }
                break;
            case STATE.STAIRS:
                transform.position = Vector2.MoveTowards(transform.position, this.entranceStair.transform.position, 3f * Time.deltaTime);

                if (this.entranceStair.transform.position == transform.position)
                {
                    switch (this.type)
                    {
                        case TYPE.isPerson:
                            if (this.entranceStair.allowPerson && this.entranceStair.isWorking) this.state = STATE.STAIRSEXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isBlind:
                            if (this.entranceStair.allowBlind && this.entranceStair.isWorking) this.state = STATE.STAIRSEXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isDeaf:
                            if (this.entranceStair.allowDeaf && this.entranceStair.isWorking) this.state = STATE.STAIRSEXIT;
                            else this.state = STATE.SAD;
                            break;
                        case TYPE.isWheelchair:
                            if (this.entranceStair.allowWheelchair && this.entranceStair.isWorking) this.state = STATE.STAIRSEXIT;
                            else this.state = STATE.SAD;
                            break;
                    }
                }
                break;
            case STATE.STAIRSEXIT:
                transform.position = Vector2.MoveTowards(transform.position, this.exitStair.transform.position, 3f * Time.deltaTime);

                if (this.exitStair.doorManager != null)
                {
                    this.exitStair.doorManager.DecreaseUsingCountDown();
                }

                if (this.exitStair.transform.position == transform.position)
                {
                    switch (this.type)
                    {
                        case TYPE.isPerson:
                            this.state = STATE.DOORS_TOP;
                            break;
                        case TYPE.isBlind:
                            this.state = STATE.BRAILLE_TOP;
                            break;
                        case TYPE.isDeaf:
                            this.state = STATE.DOORS_TOP;
                            break;
                        case TYPE.isWheelchair:
                            this.state = STATE.DOORS_TOP;
                            break;
                    }
                }
                break;
            case STATE.SAD:
                float test;
                int i=0;
                foreach(GameObject item in this.sad2)
                {
                    if (this.flag==false)
                    {
                        this.shortlyDestroyPoint = 10000000.0F;
                        this.flag = true;
                    }
                    test = Vector2.Distance(transform.position, item.transform.position);
                    if (this.shortlyDestroyPoint > test)
                    {
                        this.shortlyDestroyPoint = test;
                        this.index = i;
                    }
                    i++;
                }
                transform.position = Vector2.MoveTowards(transform.position, this.sad2[index].transform.position, 3f * Time.deltaTime);
                if (transform.position == this.sad.transform.position)
                {
                    satisfactionManager.DecreaseSatisfaction(5);
                    Destroy(this.gameObject);
                }
                break;
            case STATE.TRAIN:
                transform.position = Vector2.MoveTowards(transform.position, this.entranceTrain.transform.position, 3f * Time.deltaTime);
                if (this.entranceTrain.transform.position == transform.position)
                {
                    // GET MONEY
                    moneyManager.WinMoney(1);
                    satisfactionManager.IncreaseSatisfaction(2);
                    Destroy(this.gameObject);
                }
                break;
        }

    }
}
