using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    private static SceneController _instance;
    public static SceneController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SceneController();
            return _instance;
        }
    }

    private SceneController() { }

    public static readonly Dictionary<Define.Scene, string> sceneNames = new Dictionary<Define.Scene, string>()
    {
        { Define.Scene.Menu, "Main" },
        { Define.Scene.Play, "Play" },
        { Define.Scene.Rank, "Rank" }
    };

    public void LoadScene(Define.Scene scene)
    {
        if (sceneNames.TryGetValue(scene, out string sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene == null" + " " + sceneName);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}