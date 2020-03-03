using UnityEditor;
using UnityEngine;

namespace GEM.Editor
{
    /// <summary>
    /// The "About" tab in the editor.
    /// </summary>
    public class AboutTab : EditorTab
    {
        private const string purchaseText = "Разработано by Exanderful";
        private const string copyrightText = "InstaMatch 3 by GEM";

        private readonly Texture2D logoTexture;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="editor">The parent editor.</param>
        public AboutTab(PuzzleMatchKitEditor editor) : base(editor)
        {
            logoTexture = Resources.Load<Texture2D>("Logo");
        }

        /// <summary>
        /// Called when this tab is drawn.
        /// </summary>
        public override void Draw()
        {
            GUILayout.Space(15);

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(logoTexture);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.Space(15);

            var windowWidth = EditorWindow.focusedWindow.position.width;
            var centeredLabelStyle = new GUIStyle("label") { alignment = TextAnchor.MiddleCenter };
            GUI.Label(new Rect(0, 0, windowWidth, 650), purchaseText, centeredLabelStyle);
            GUI.Label(new Rect(0, 0, windowWidth, 700), copyrightText, centeredLabelStyle);
        }
    }
}