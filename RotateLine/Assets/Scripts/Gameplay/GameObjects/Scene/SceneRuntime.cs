using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRuntime : MonoBehaviour
{
    private SceneId _sceneId;
    public SceneId SceneId => _sceneId;

    public virtual void Init()
    {
         
    }

    public virtual void OnLoadingScreenFadeout()
    {

    }

    public virtual void UpdateScene()
    {

    }

    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
}
