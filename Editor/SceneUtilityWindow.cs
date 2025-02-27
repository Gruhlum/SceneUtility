using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace HexTecGames.SceneUtility
{
    public class SceneUtilityWindow : EditorWindow
    {
        [MenuItem("Tools/Settings/SceneUtility")]
        public static void ShowWindow()
        {
            GetWindow(typeof(SceneUtilityWindow));
        }
        private void OnGUI()
        {
            Editor m_MyScriptableObjectEditor = Editor.CreateEditor(SceneUtility.instance);
            m_MyScriptableObjectEditor.OnInspectorGUI();
            SceneUtility.instance.Save();
        }
    }
}