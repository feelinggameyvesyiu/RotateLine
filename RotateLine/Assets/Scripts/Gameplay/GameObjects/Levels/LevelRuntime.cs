using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRuntime : MonoBehaviour
{
    private GridContainer _gridContainer;

    public void Init()
    {

    }

    public void SpawnWithData(LevelSpawnData levelSpawnData)
    {
        _gridContainer = new GridContainer(levelSpawnData.Column, levelSpawnData.Row);
    }

    public void UpdateLevel()
    {

    }

    public void DestroySelf()
    {

    }
}
