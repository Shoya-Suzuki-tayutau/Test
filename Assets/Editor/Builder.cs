using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Builder : MonoBehaviour {



    // ビルド実行でAndroidのapkを作成する例
    [UnityEditor.MenuItem("Tools/Build Project AllScene Android")]
    public static void BuildProjectAllSceneAndroid()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
        List<string> allScene = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                allScene.Add(scene.path);
            }
        };
     
        PlayerSettings.statusBarHidden = true;
        BuildPipeline.BuildPlayer(
            allScene.ToArray(),
            "newgame.apk",
            BuildTarget.Android,
            BuildOptions.None
        );
    }
}
