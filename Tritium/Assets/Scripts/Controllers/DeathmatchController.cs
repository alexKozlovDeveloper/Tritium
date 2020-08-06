using Assets.Scripts.Core;
using Assets.Scripts.Core.Constants;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathmatchController : MonoBehaviour
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

    public float resultDuration = 13;

    private Timer _timer;

    public float RestTime { get { return _timer.Time; } }

    void Start()
    {
        _timer = new Timer(deathmatchTime);

        if (starshipSpawnController == null)
        {
            return;
        }

        hero.GetComponent<TeamController>().TeamId = 0;

        starshipSpawnController.AddStarship(hero);
        killCountController?.AddStarship(hero);

        while (starshipSpawnController.StarshipCount < starshipCount)
        {
            var enemy = Instantiate(enemyPrefab);

            enemy.name = "Bot_" + NameHelper.GetRandomName();
            enemy.GetComponent<TeamController>().TeamId = starshipSpawnController.StarshipCount;

            enemy.transform.SetParent(transform);

            starshipSpawnController.AddStarship(enemy, Random.Range(0.9f, 2.4f));
            killCountController?.AddStarship(enemy);
        }

        Messenger.Broadcast(GameEvent.MISSION_STARTED);
    }

    void Update()
    {
        _timer.AddPassedTime(Time.deltaTime);

        if (_timer.IsTimeEnd)
        {
            var result = DictionaryHelper.GetSortedResult(killCountController.Score);

            MainUI.SetActive(false);
            ResultUI.SetActive(true);

            ResultScore.text = result;

            if(hero.GetComponent<UserController>() != null)
            {
                hero.GetComponent<UserController>().Destroy();
                var enemyController = hero.AddComponent<EnemyController>();
            }          

            _timer.ResetTime(resultDuration + 1);

            StartCoroutine(nameof(LoadMenu));
        }
    }

    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(resultDuration);

        SceneManager.LoadScene(Consts.Scenes.Menu);
    }
}
