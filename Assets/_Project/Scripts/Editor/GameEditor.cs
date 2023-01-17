using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameEditor : EditorWindow
{
    [MenuItem("Game/Game Editor")]
    public static void ShowEditor()
    {
        GameEditor gew = GetWindow<GameEditor>();
        gew.titleContent = new GUIContent("Game Editor");
        gew.minSize = new(400, 112);
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Space(5);
        GUILayout.BeginVertical();
        GUILayout.Space(5);

        EditorGUI.BeginChangeCheck();
        GameEditorConfig.openScene = (OpenScene)EditorGUILayout.EnumPopup("Selected Scene", GameEditorConfig.openScene);
        if (EditorGUI.EndChangeCheck())
        {
            switch (GameEditorConfig.openScene)
            {
                case OpenScene.Game: EditorSceneManager.OpenScene("Assets/_Project/Scenes/Game.unity"); break;
                case OpenScene.Start: EditorSceneManager.OpenScene("Assets/_Project/Scenes/Start.unity"); break;
            }
        }

        GUILayout.Space(5);

        switch (GameEditorConfig.openScene)
        {
            case OpenScene.Game:

                GameEditorConfig.presents = EditorGUILayout.IntSlider("Present Win count", GameEditorConfig.presents, 1, 20);
                GameEditorConfig.booster = EditorGUILayout.IntSlider("Max Booster count", GameEditorConfig.booster, 1, 10);

                GUILayout.Space(5);

                if (GUILayout.Button("Apply Settings", GUILayout.Height(30)))
                {
                    Score sc = FindObjectOfType<Score>();
                    BoosterManager bm = FindObjectOfType<BoosterManager>();

                    sc.winCount = GameEditorConfig.presents;
                    bm.max = GameEditorConfig.booster;
                }
                break;
            case OpenScene.Start:

                if (GUILayout.Button("Reset Highscore", GUILayout.Height(30))) PlayerPrefs.SetFloat("scoreTime", 0);
                break;
        }

        GUILayout.EndVertical();
        GUILayout.Space(5);
        GUILayout.EndHorizontal();
    }
}

public enum OpenScene { Start, Game }

public static class GameEditorConfig
{
    public static int presents = 4, booster = 3;
    public static OpenScene openScene = OpenScene.Start;
}