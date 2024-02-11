using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public LevelDataContainer levelDataContainer;
    public float levelTimer = 0;

    public int currentLevel;
    public LevelData currentLevelData;

    public PlayerTower PlayerTower;
    public PlayerTower EnemyTower;

    void Start()
    {
        // set up the current level
        currentLevel = 1;
        currentLevelData = levelDataContainer.levels[currentLevel - 1];
    }

    void Update()
    {
        levelTimer += Time.deltaTime;

        // check timer to spawn a new wave
        foreach(var wave in currentLevelData.waves){
            // we can only spawn an enemy wave if it hasn't been spawned
            // and its time is upon us
            if(!wave.hasSpawned && levelTimer >= wave.time){
                wave.hasSpawned = true;

                foreach(var enemy in wave.enemies){
                    EnemyController enemyInstance = Instantiate(enemy);
                    enemyInstance.transform.position = EnemyTower.transform.position;
                    enemyInstance.playerTower = PlayerTower;
                }
            }
        }

        CheckForEndOfGame();
    }

    private void CheckForEndOfGame()
    {
        if(PlayerTower.health <= 0){
            // you lose
        }

        if(EnemyTower.health <= 0){
            // you win
        }
    }
}

[Serializable]
public class LevelDataContainer{
    public List<LevelData> levels;

}

[Serializable]
public class LevelData{
    public List<Wave> waves;
}

[Serializable]
public class Wave{
    public List<EnemyController> enemies;
    public float time;
    public bool hasSpawned;
}
