using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndTextAdaptor : MonoBehaviour
{
    public TextMeshProUGUI textDisplayer;
    public Image icon;
    public Image icon2;

    public Sprite goodSprite;
    public Sprite badSprite;

    private void Start()
    {
        if (DataSaver.Instance.satisfactionValue > 60)
        {
            icon.sprite = goodSprite;
            icon2.sprite = goodSprite;
            textDisplayer.text = "Felicitations ! Vous etes parvenus a satisfaire la plupart de vos voyageurs. Mais comment pensez-vous que tout ceci s'organise dans la vraie vie ? De nombreuses organisations mettent tout en oeuvre pour combler les inegalites qui existent entre les personnes valides et invalides. Pour plus d'informations, nous vous invitons a consulter le site: www.aviq.be/handicap.";
        }
        else
        {
            icon.sprite = badSprite;
            icon2.sprite = badSprite;
            textDisplayer.text = "Malheureusement, votre station ne semble pas avoir rencontre un franc succes aupres de tous les voyageurs. Mais comment pensez-vous que tout ceci s'organise dans la vraie vie ? De nombreuses organisations mettent tout en oeuvre pour combler les inegalites qui existent entre les personnes valides et invalides. Pour plus d'informations, nous vous invitons a consulter le site: www.aviq.be/handicap.";
        }
    }
}
