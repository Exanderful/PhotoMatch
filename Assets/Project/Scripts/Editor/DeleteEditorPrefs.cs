using UnityEditor;

namespace GEM.Editor
{
    /// <summary>
    /// Utility class for deleting the EditorPrefs from within the editor.
    /// </summary>
    public class DeleteEditorPrefs
    {
        [MenuItem("Window/Project/Delete EditorPrefs", false, 2)]
        public static void DeleteAllEditorPrefs()
        {
            EditorPrefs.DeleteAll();
        }
    }
}