using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace HexTecGames.SceneUtility
{
    [FilePath("SceneUtility/Data", FilePathAttribute.Location.ProjectFolder)]
    public class SceneUtility : ScriptableSingleton<SceneUtility>
    {
        [SerializeField] private bool useCurrentScene;
        [SerializeField] private SceneAsset startScene;


        [InitializeOnLoadMethod]
        public static void SetData()
        {
            instance.SetStartScene();
        }

        private SceneAsset GetStartScene()
        {
            if (!useCurrentScene && startScene != null)
            {
                return startScene;
            }
            else
            {
                //Debug.Log(EditorSceneManager.GetActiveScene().path);
                var result = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorSceneManager.GetActiveScene().path);
                return result;
            }
        }
        public void SetStartScene()
        {
            EditorSceneManager.playModeStartScene = GetStartScene();
        }
        public void Save()
        {
            Save(true);
        }
        // Have an option to select a specific scene to start, or the current scene
        // Select all scenes from a dropdown (maybe only those that are in a collection somewhere)
        // Load a specific scene when play mode is started
    }
}