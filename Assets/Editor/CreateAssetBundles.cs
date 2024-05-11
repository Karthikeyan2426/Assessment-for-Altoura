using System;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    [MenuItem("Assets/CreateAssetBundles")]
    private static void BuildAllAssetBundles()
    {
        // Define the directory path where the asset bundles will be stored
        string assetBundleDirectoryPath = Application.streamingAssetsPath;

        try
        {
            // Build asset bundles
            BuildPipeline.BuildAssetBundles(assetBundleDirectoryPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        }
        catch (Exception e)
        {
            // Log any exceptions that occur during the build process
            Debug.LogWarning(e);
        }
    }
}

