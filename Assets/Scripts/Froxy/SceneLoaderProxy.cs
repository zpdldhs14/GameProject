using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RealSceneLoader : ISceneLoader
{
    private float _progress = 0f;
    private bool _isLoading = false;
    
    public float Progress => _progress;
    public bool IsLoading => _isLoading;
    public async UniTask LoadSceneAsync(string sceneName)
    {
        _isLoading = true;
        
        var operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        
        while (!operation.isDone)
        {
            _progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log($"Scene Loading Progress: {_progress * 100}%");
            
            if (operation.progress >= .9f)
            {
                operation.allowSceneActivation = true;
            }
            await UniTask.Yield();
        }
        _isLoading = false;
    }
}

public class SceneLoaderProxy : MonoBehaviour, ISceneLoader
{
    private ISceneLoader realloader;
    [SerializeField] private Slider progress;
    [SerializeField] private TextMeshProUGUI text;

    public float Progress => realloader?.Progress ?? 0f;
    public bool IsLoading => realloader?.IsLoading ?? false;

    // Initialize 메서드 추가 (생성자 대신 사용)
    public void Initialize(ISceneLoader loader)
    {
        this.realloader = loader;
        progress = GameObject.Find("ProgressBar")?.GetComponent<Slider>();
        text = GameObject.Find("LoadingText")?.GetComponent<TextMeshProUGUI>();
    }

    public async UniTask LoadSceneAsync(string sceneName)
    {
        if (realloader == null)
        {
            Debug.LogError("Real loader is not assigned!");
            return;
        }

        await ShowLoadingScreen();
        await realloader.LoadSceneAsync(sceneName);
        HideLoadingScreen();
    }

    private async UniTask ShowLoadingScreen()
    {
        if (progress != null) progress.value = 0;
        if (text != null) text.text = "Loading...";
        await UniTask.NextFrame();
    }

    private void HideLoadingScreen()
    {
        if (progress != null) progress.gameObject.SetActive(false);
        if (text != null) text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (realloader == null || progress == null || text == null)
        {
            Debug.LogWarning("Missing references: realloader, progress, or text.");
            return;
        }

        if (realloader.IsLoading)
        {
            Debug.Log($"Progress: {realloader.Progress * 100}%"); // 디버그 출력
            progress.value = realloader.Progress;
            text.text = $"Loading... {Mathf.RoundToInt(realloader.Progress * 100)}%";
        }
    }
}