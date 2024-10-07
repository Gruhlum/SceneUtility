using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace HexTecGames.SceneUtility
{
    public class SceneUtilityWindow : EditorWindow
    {
        [SerializeField] private SceneUtility sceneUtility = default;

        void OnEnable()
        {
            sceneUtility.OnChanged += SceneUtility_OnChanged;
        }

        void OnDisable()
        {
            sceneUtility.OnChanged -= SceneUtility_OnChanged;
        }
        private void SceneUtility_OnChanged()
        {
            var result = sceneUtility.GetStartScene();
            EditorSceneManager.playModeStartScene = result;
            Debug.Log("Setting start scene to: " + result.name);
        }

        [MenuItem("Tools/Settings/SceneUtility")]
        public static void ShowWindow()
        {
            GetWindow(typeof(SceneUtilityWindow));
        }
        private void OnGUI()
        {
            UnityEditor.Editor m_MyScriptableObjectEditor = UnityEditor.Editor.CreateEditor(sceneUtility);
            m_MyScriptableObjectEditor.OnInspectorGUI();
        }
    }
}