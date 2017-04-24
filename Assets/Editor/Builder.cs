using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Builder : MonoBehaviour {



    // ビルド実行でAndroidのapkを作成する例
    [UnityEditor.MenuItem("Tools/Build Project AllScene Android")]
    public static void BuildProjectAllSceneAndroid()
    {
        //EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
        List<string> allScene = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                allScene.Add(scene.path);
            }
        };

        //Debug.LogError("[Scene!]" + allScene.ToArray().Length);

        string errorMessage = BuildPipeline.BuildPlayer(
            allScene.ToArray(),
            "test",
            BuildTarget.Android,
            BuildOptions.Development
        );


        // 結果出力
        if (!string.IsNullOrEmpty(errorMessage))
        {
            Debug.LogError("[Error!] " + errorMessage);
            //EditorApplication.Exit(1);
        }
        else
        {
            Debug.Log("[Success!]");
            //EditorApplication.Exit(0);
        }
    }

}
