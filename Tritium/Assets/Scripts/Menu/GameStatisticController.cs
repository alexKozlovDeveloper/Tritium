using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStatisticController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI KillCount;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI Time;
    [SerializeField] private Slider HealthPointsSlider;

    [SerializeField] private KillCountController killCountController;
    [SerializeField] private CompanyController companyController;

    [SerializeField] private GameObject hero;

    void Start()
    {
        
    }

    void Update()
    {
        SetKillCount();
        SetScoreTable();
        SetHealthPointSlider();
        SetRestTime();
    }

    private void SetKillCount()
    {
        if (killCountController.Score.Keys.Contains(hero))
        {
            KillCount.text = killCountController.Score[hero].ToString();
        }
    }

    private void SetScoreTable()
    {
        //var scoreTable = new StringBuilder();

        //var scoreList = killCountController.Score.ToList();

        //scoreList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        //foreach (var item in scoreList)
        //{
        //    scoreTable.Append($"{item.Key.name}: {item.Value} {Environment.NewLine}");
        //}

        Score.text = DictionaryHelper.GetSortedResult(killCountController.Score);
    }

    private void SetHealthPointSlider()
    {
        var hpController = hero.GetComponent<HealthController>();

        var healthPersent = hpController.HealthPoints / hpController.MaxHealthPoints;

        HealthPointsSlider.value = healthPersent;
    }

    private void SetRestTime()
    {
        var restTime = TimeSpan.FromSeconds(companyController.RestTime);
        
        Time.text = restTime.ToString(@"mm\:ss\:ff");
    }
}
