using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private GameplayButton fireButton;
    [SerializeField] private GameplayButton leftButton;
    [SerializeField] private GameplayButton rightButton;
    [SerializeField] private TextMeshProUGUI timer;
    [Space]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private RectTransform playerPlanePrefab;
    [SerializeField] private RectTransform playerPlanePlace;
    private RectTransform playerPlane;
    [Space]
    [SerializeField] private float playerSideSpeed = 20f;
    [SerializeField] private float shootDelay = 0.2f;
    private float lastShoot = 0;
    [Space]
    [SerializeField] private RectTransform enemyPlace;
    [SerializeField] private RectTransform enemyPrefab;
    [SerializeField] private float delaySpawnEnemy = 5;
    private bool isGameInProcess = true;
    private void Awake()
    {
        if (!instance) instance = this;
        else Debug.LogError("MTOI");
    }

    private void Start()
    {
        leftButton.SetAction(MoveLeft);
        leftButton.SetAction(MoveRight);
        fireButton.SetAction(Fire);
    }

    private void Fire()
    {
        if (lastShoot + shootDelay > Time.time) return;
        lastShoot = Time.time;
        var bullet = Instantiate(bulletPrefab, playerPlanePlace);
        bullet.transform.position = playerPlane.transform.position;
        (bullet.transform as RectTransform).anchoredPosition += playerPlane.sizeDelta.y / 2 * Vector2.up;
        bullet.IsShootPlayer = true;
        MusicController.Instance.PlayShoot();
    }

    private void MoveRight()
    {
        playerPlane.anchoredPosition += Vector2.right * playerSideSpeed;
        ClampPlayer();
    }

    private void MoveLeft()
    {
        playerPlane.anchoredPosition += Vector2.left * playerSideSpeed;
        ClampPlayer();
    }

    private void ClampPlayer()
    {
        var sideOffset = playerPlane.rect.width / 2;
        var playerPos = playerPlane.anchoredPosition;
        var halfPlaneX = playerPlanePlace.rect.width / 2;
        if (playerPos.x < -halfPlaneX + sideOffset)
        {
            playerPos.x = -halfPlaneX + sideOffset;
        }
        if (playerPos.x > halfPlaneX - sideOffset)
        {
            playerPos.x = halfPlaneX - sideOffset;
        }
        playerPlane.anchoredPosition = playerPos;
    }

    internal void StartGame()
    {
        var currentLevel = ProgressHolder.SelectedLevel;
        var timerTime = 20 + currentLevel;
        DestroyAllPlanes();
        SpawnPlayer();
        SetTimerValue(timerTime);
        StartCoroutine(TimerCoroutine(timerTime));
        fireButton.SetAction(Fire);
        leftButton.SetAction(MoveLeft);
        rightButton.SetAction(MoveRight);
        StartCoroutine(SpawnEnemiesCoro());
    }

    private void SpawnPlayer()
    {
        playerPlane = Instantiate(playerPlanePrefab, playerPlanePlace);
        playerPlane.anchoredPosition = Vector2.zero;
    }

    private void DestroyAllPlanes()
    {
        for(int i = enemyPlace.childCount - 1; i >= 0; i--)
        {
            Destroy(enemyPlace.GetChild(i).gameObject);
        }
        for(int i = playerPlanePlace.childCount - 1; i >= 0; i--)
        {
            Destroy(playerPlanePlace.GetChild(i).gameObject);
        }
    }

    private IEnumerator SpawnEnemiesCoro()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delaySpawnEnemy);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void SpawnEnemy()
    {
        var placeForEnemy = enemyPlace.anchoredPosition;
        var placeWidth = enemyPlace.rect.width;
        var enemyHalfWidth = enemyPrefab.rect.width / 2;
        placeForEnemy.x = UnityEngine.Random.Range(-placeWidth/2 + enemyHalfWidth, placeWidth/2 - enemyHalfWidth);
        var enemy = Instantiate(enemyPrefab, enemyPlace);
        enemy.anchoredPosition = placeForEnemy;
    }

    private IEnumerator TimerCoroutine(float levelTime)
    {
        var startTime = Time.time;
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            var timesLeft = startTime + levelTime - Time.time;
            SetTimerValue(timesLeft);
            if (timesLeft <= 0) break;
        }
        EndGame(true);
    }

    private void SetTimerValue(float timeLeft)
    {
        var timeLeftInt = Mathf.RoundToInt(timeLeft);
        string minutes = "0" + (timeLeft > 60 ? (timeLeftInt / 60 - timeLeftInt % 60).ToString() : "0");
        string seconds = (timeLeftInt % 60).ToString();
        timer.text = $"{minutes}:{seconds}";
        //Debug.Log($"times left {timeLeft}, rounded {timeLeftInt}, text {timer.text}");
    }

    public void EndGame(bool isWin)
    {
        StopAllCoroutines();
        DestroyAllPlanes();
        MusicController.Instance.StopMusic();
        if (isWin)
        {

        }
        else
        {

        }
    }
}
