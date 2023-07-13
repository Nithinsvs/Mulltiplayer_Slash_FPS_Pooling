﻿/*using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoadAttribute]

// Unload scenes except active scene before Play Mode
// Load them back when enter Editor Mode 

public static class EditorScenes
{
    static EditorScenes()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode) OpenScenes();
        if (state == PlayModeStateChange.ExitingEditMode) CloseScenes();
    }

    // -----------------------------------------------------

    private static void OpenScenes()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (!IsActiveScene(scene)) OpenScene(scene);
        }
    }

    private static void CloseScenes()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (!IsActiveScene(scene)) CloseScene(scene);
        }
    }

    // -----------------------------------------------------

    private static void OpenScene(Scene scene)
    {
        EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Additive);
    }

    private static void CloseScene(Scene scene)
    {
        EditorSceneManager.CloseScene(scene, false);
    }

    // -----------------------------------------------------

    private static Scene activeScene
    {
        get { return SceneManager.GetActiveScene(); }
    }

    private static bool IsActiveScene(Scene scene)
    {
        return scene == activeScene;
    }
}*/