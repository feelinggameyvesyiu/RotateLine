using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneId
{
    None,
    Gameplay,
    Menu,
}

public class GameSceneManager : MonoBehaviour
{
    private static GameSceneManager _instance;
    public static GameSceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameSceneManager>();
            }
            return _instance;
        }
    }

    private SceneRuntime _currentScene;
    public SceneRuntime CurrentScene => _currentScene;

    public void Init()
    {

    }

    public void LoadScene(SceneId sceneId)
    {
        if (_currentScene != null)
        {
            _currentScene.DestroySelf();
            _currentScene = null;
        }
        GameObject prefab = Resources.Load<GameObject>(
        GameConstants.ResourcesPath.PrefabPath.Scenes(sceneId));
        _currentScene = Instantiate(prefab).GetComponent<SceneRuntime>();
        _currentScene.transform.SetParent(transform);
        _currentScene.Init();
        _currentScene.OnLoadingScreenFadeout();
    }
}
