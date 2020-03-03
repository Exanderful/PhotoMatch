using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

using GEM.Game.Common;

namespace GEM.Editor
{
    /// <summary>
    /// This class handles the Puzzle Match Kit editor window.
    /// </summary>
    public class PuzzleMatchKitEditor : EditorWindow
    {
        public GameConfiguration gameConfig;

        private readonly List<EditorTab> tabs = new List<EditorTab>();

        private int selectedTabIndex = -1;
        private int prevSelectedTabIndex = -1;

        /// <summary>
        /// Static initialization of the editor window.
        /// </summary>
        [MenuItem("Window/Project/Editor", false, 0)]
        private static void Init()
        {
            var window = GetWindow(typeof(PuzzleMatchKitEditor));
            window.titleContent = new GUIContent("InstaMatch 3 Editor");
        }

        /// <summary>
        /// Unity's OnEnable method.
        /// </summary>
        private void OnEnable()
        {
            tabs.Add(new GameSettingsTab(this));
            tabs.Add(new LevelEditorTab(this));
            tabs.Add(new AboutTab(this));
            selectedTabIndex = 0;
        }

        /// <summary>
        /// Unity's OnGUI method.
        /// </summary>
        private void OnGUI()
        {
            selectedTabIndex = GUILayout.Toolbar(selectedTabIndex,
                new[] { "Настройки игры", "Редактор уровней", "Описание" });
            if (selectedTabIndex >= 0 && selectedTabIndex < tabs.Count)
            {
                var selectedEditor = tabs[selectedTabIndex];
                if (selectedTabIndex != prevSelectedTabIndex)
                {
                    selectedEditor.OnTabSelected();
                    GUI.FocusControl(null);
                }
                selectedEditor.Draw();
                prevSelectedTabIndex = selectedTabIndex;
            }
        }
    }
}