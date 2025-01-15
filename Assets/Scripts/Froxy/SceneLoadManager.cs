using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "ActionCheck";
    public ISceneLoader _sceneLoader;

    private void Start()
    {
        var realSceneLoader = new RealSceneLoader();
        var sceneLoaderProxyGameObject = new GameObject("SceneLoaderProxy");
        var sceneLoaderProxy = sceneLoaderProxyGameObject.AddComponent<SceneLoaderProxy>();

        // RealSceneLoader를 Proxy에 전달
        sceneLoaderProxy.Initialize(realSceneLoader);

        _sceneLoader = sceneLoaderProxy;
        ChangeScene(sceneToLoad);
    }

    public async void ChangeScene(string sceneName)
    {
        if (_sceneLoader != null)
        {
            await _sceneLoader.LoadSceneAsync(sceneName);
        }
        else
        {
            Debug.LogError("SceneLoaderProxy is null");
        }
    }
}
