using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager _instance;
        public static LevelManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<LevelManager>();
                }
                return _instance;
            }
        }

        private LevelRuntime _levelRuntime;


        public void Init()
        {

        }

        public void LoadLevel(LevelSpawnData levelSpawnData)
        {

        }
    }
}
