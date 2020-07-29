using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class GameStatisticController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI KillCount;
    [SerializeField] private TextMeshProUGUI Score;

    [SerializeField] private KillCountController killCountController;

    [SerializeField] private GameObject hero;

    void Start()
    {
        
    }

    void Update()
    {
        KillCount.text = killCountController.Score[hero].ToString();      

        var scoreTable = new StringBuilder();

        var scoreList = killCountController.Score.ToList();

        scoreList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        foreach (var item in scoreList)
        {
            scoreTable.Append($"{item.Key.name}: {item.Value} {Environment.NewLine}");
        }

        Score.text = scoreTable.ToString();
    }
}
