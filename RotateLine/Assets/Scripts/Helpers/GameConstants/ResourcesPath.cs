using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace GameConstants
//{
    public static partial class GameConstants
    {
        public static class ResourcesPath
        {
            public static class PrefabPath
            {
                public const string Prefabs = "Prefabs/";
                public static string Scenes(SceneId sceneId) => $"{Prefabs}Scenes/{sceneId}";

            }
        }
    }
//}


