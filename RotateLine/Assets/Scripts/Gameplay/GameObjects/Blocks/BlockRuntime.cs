using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRuntime : MonoBehaviour
{
    public TransformController TransformController;

    public virtual void Init()
    {

    }

    public virtual void SpawnWithData(BlockSpawnData blockSpawnData)
    {
        TransformController.SetPosition(blockSpawnData.GetPosition);
        TransformController.SetRotation(blockSpawnData.GetDirection);
    }

    public virtual void UpdateBlock()
    {

    }

    public virtual void DestroySelf()
    {

    }

}
