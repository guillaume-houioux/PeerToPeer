using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{
    public SpriteRenderer objectRenderer;
    public Image buttonImage;
    public TextMeshProUGUI buttonMoneyText;
    public MoneyManager moneyManager;

    public Sprite baseSprite;
    public Sprite workingSprite;
    public Sprite downSprite;

    public Sprite buildSprite;
    public Sprite repairSprite;

    public Door logicalDoor;

    public int minUsing = 10;
    public int maxUsing = 20;
    public int moneyBuild;
    public int moneyRepair;
    private int UsingCountDown = 0;

    private float timerRef = 1f;
    private float timer = 0;

    public Status status = Status.UNEXIST;

    // Start is called before the first frame update
    private void Start()
    {
        UsingCountDown = Random.Range(minUsing, maxUsing);

        objectRenderer.sprite = baseSprite;
    }

    // Update is called once per frame
    private void Update()
    {
        if (status == Status.UNEXIST)
        {
            if (moneyManager.money >= moneyBuild)
            {
                SetupBuildButton();
            }
            else
            {
                UnsetBuildButton();
            }
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void DecreaseUsingCountDown()
    {
        if (timer <= 0)
        {
            UsingCountDown--;

            if (UsingCountDown <= 0 && status == Status.WORKING)
            {
                BreakInstallation();
            }

            timer = timerRef;
        }
    }

    public void InterractUIButton()
    {
        if (status == Status.UNEXIST)
        {
            BuildInstallation();
        }
        else if (status == Status.BREAK)
        {
            RepairInstallation();
        }
    }

    public void SetupBuildButton()
    {
        buttonImage.sprite = buildSprite;
        buttonMoneyText.text = moneyBuild.ToString() + "$";
        buttonImage.GetComponent<Button>().interactable = true;
        buttonImage.gameObject.SetActive(true);

        if (objectRenderer.transform.childCount > 0)
        {
            objectRenderer.gameObject.SetActive(false);
        }
        if (objectRenderer.gameObject.GetComponent<Animator>() != null)
        {
            objectRenderer.gameObject.SetActive(false);
        }
    }

    public void UnsetBuildButton()
    {
        buttonImage.sprite = null;
        buttonImage.GetComponent<Button>().interactable = false;
        buttonImage.gameObject.SetActive(false);
    }

    public void BreakInstallation()
    {
        status = Status.BREAK;
        objectRenderer.sprite = downSprite;
        logicalDoor.isWorking = false;

        buttonImage.sprite = repairSprite;
        buttonMoneyText.text = moneyRepair.ToString() + "$";
        buttonImage.GetComponent<Button>().interactable = true;
        buttonImage.gameObject.SetActive(true);

        if (objectRenderer.transform.childCount > 0)
        {
            objectRenderer.gameObject.SetActive(false);
        }
        if (objectRenderer.gameObject.GetComponent<Animator>() != null)
        {
            objectRenderer.gameObject.SetActive(false);
        }
    }

    public void RepairInstallation()
    {
        if (moneyManager.money >= moneyRepair)
        {
            status = Status.WORKING;
            objectRenderer.sprite = downSprite;
            logicalDoor.isWorking = true;
            moneyManager.Pay(moneyRepair);

            buttonImage.sprite = null;
            buttonImage.GetComponent<Button>().interactable = false;
            buttonImage.gameObject.SetActive(false);

            if (objectRenderer.transform.childCount > 0)
            {
                objectRenderer.gameObject.SetActive(true);
            }
            if (objectRenderer.gameObject.GetComponent<Animator>() != null)
            {
                objectRenderer.gameObject.SetActive(true);
            }

            UsingCountDown = Random.Range(minUsing, maxUsing);
        }
    }

    public void BuildInstallation()
    {
        status = Status.WORKING;
        objectRenderer.sprite = downSprite;
        logicalDoor.isWorking = true;

        moneyManager.Pay(moneyBuild);

        buttonImage.sprite = null;
        buttonImage.GetComponent<Button>().interactable = false;
        buttonImage.gameObject.SetActive(false);

        if (objectRenderer.transform.childCount > 0)
        {
            objectRenderer.gameObject.SetActive(true);
        }
        if (objectRenderer.gameObject.GetComponent<Animator>() != null)
        {
            objectRenderer.gameObject.SetActive(true);
        }
    }
}

public enum Status
{
    UNEXIST,
    WORKING,
    BREAK
}
