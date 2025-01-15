using Cysharp.Threading.Tasks;

public interface ISceneLoader
{
    UniTask LoadSceneAsync(string sceneName);
    float Progress { get; }
    bool IsLoading { get; }
}