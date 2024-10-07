using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace HexTecGames.SceneUtility
{
    //[CreateAssetMenu(menuName = "HexTecGames/SceneUtility/Settings")]
    public class SceneUtility : ScriptableObject
    {
        public bool useCurrentScene;
        public SceneAsset startScene;

        public event Action OnChanged;

        public void OnValidate()
        {
            OnChanged?.Invoke();
        }

       public SceneAsset GetStartScene()
        {
            if (!useCurrentScene && startScene != null)
            {
                return startScene;
            }
            else
            {
                Debug.Log(EditorSceneManager.GetActiveScene().path);
                var result = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorSceneManager.GetActiveScene().path);
                return result;
            } 
        }

        // Have an option to select a specific scene to start, or the current scene
        // Select all scenes from a dropdown (maybe only those that are in a collection somewhere)
        // Load a specific scene when play mode is started
    }
}