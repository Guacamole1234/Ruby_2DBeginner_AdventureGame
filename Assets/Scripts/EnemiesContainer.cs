using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesContainer : MonoBehaviour
{
    public static EnemiesContainer instance;
    public int enemiesAlive;
    public int count { get { return enemiesTotal; } }
    public int enemiesTotal;

    [SerializeField] private TextMeshProUGUI numberText;

    [SerializeField] private GameObject enemiesContainer;

    [SerializeField] private GameObject enemyPrefab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        enemiesTotal = enemiesContainer.transform.childCount;
        enemiesAlive = enemiesTotal;
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateEnemy();
        }
    }

    private void UpdateText()
    {
        numberText.text = enemiesAlive.ToString() + "/" + enemiesTotal.ToString();
    }

    public void RemoveEnemy()
    {
        enemiesAlive--;
        UpdateText();
    }

    public void AddEnemy()
    {
        enemiesAlive++;
        enemiesTotal++;
        UpdateText();
    }

    void CreateEnemy()
    {
        GameObject currentEnemy = Instantiate(enemyPrefab, new Vector2(-5f, 10f), enemyPrefab.transform.rotation);
        currentEnemy.transform.parent = enemiesContainer.transform;
        AddEnemy();
    }
}
