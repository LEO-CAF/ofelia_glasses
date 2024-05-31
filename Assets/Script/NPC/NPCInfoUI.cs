using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class NPCInfoUI : MonoBehaviour {


    [SerializeField] private PeopleSO peopleSO;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI ageText;
    [SerializeField] private TextMeshProUGUI jobText;
    [SerializeField] private TextMeshProUGUI hobbyText;
    [SerializeField] private TextMeshProUGUI characterText;
    [SerializeField] private Image nameIcon;
    [SerializeField] private Image ageIcon;
    [SerializeField] private Image jobIcon;
    [SerializeField] private Image hobbyIcon;
    [SerializeField] private Image characterIcon;


    private void Start() {
        nameText.text = peopleSO.Name;
        ageText.text = peopleSO.Age.ToString();
        jobText.text = peopleSO.Job;
        hobbyText.text = peopleSO.Hobby;
        characterText.text = peopleSO.Character;

        nameIcon.sprite = peopleSO.NameIcon.spriteIcon;
        ageIcon.sprite = peopleSO.AgeIcon.spriteIcon;
        jobIcon.sprite = peopleSO.JobIcon.spriteIcon;
        hobbyIcon.sprite = peopleSO.HobbyIcon.spriteIcon;
        characterIcon.sprite = peopleSO.CharacterIcon.spriteIcon;
    }


    public PeopleSO GetPeopleSO() {
        return peopleSO;
    }


}