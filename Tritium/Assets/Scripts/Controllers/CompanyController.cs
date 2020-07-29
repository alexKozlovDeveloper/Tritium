using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompanyController : MonoBehaviour
{
    [SerializeField] private StarshipSpawnController starshipSpawnController;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject hero;

    [SerializeField] private KillCountController killCountController;

    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject ResultUI;
    [SerializeField] private TextMeshProUGUI ResultScore;


    public float starshipCount = 10;
    public float deathmatchTime = 200f;

    private Timer _timer;

    public float RestTime { get { return _timer.Time; } }

    void Start()
    {
        _timer = new Timer(deathmatchTime);

        if (starshipSpawnController == null)
        {
            return;
        }

        starshipSpawnController.AddStarship(hero);
        killCountController?.AddStarship(hero);

        while (starshipSpawnController.StarshipCount < starshipCount)
        {
            var enemy = Instantiate(enemyPrefab);

            enemy.name = "Bot_" + NameHelper.GetRandomName();

            enemy.transform.SetParent(transform);

            starshipSpawnController.AddStarship(enemy, Random.Range(0.9f, 2.4f));
            killCountController?.AddStarship(enemy);
        }
    }

    void Update()
    {
        _timer.AddPassedTime(Time.deltaTime);

        if (_timer.IsTimeEnd)
        {
            //SceneManager.LoadScene("Result");

            var result = DictionaryHelper.GetSortedResult(killCountController.Score);

            MainUI.SetActive(false);
            ResultUI.SetActive(true);

            ResultScore.text = result;

            if(hero.GetComponent<UserController>() != null)
            {
                hero.GetComponent<UserController>().Destroy();
                var enemyController = hero.AddComponent<EnemyController>();
            }          

            _timer.ResetTime(20);

            StartCoroutine("LoadMenu");
        }
    }

    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(13);

        SceneManager.LoadScene("Menu");
    }
}
