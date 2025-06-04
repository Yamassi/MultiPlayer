using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FusionEntryPoint : MonoBehaviour
{
    [SerializeField] private NetworkSceneManagerDefault _sceneManager;
    [SerializeField] private NetworkRunner _networkRunner;
    [SerializeField] private string _sessionName = "GameSession";

    private void Start() =>
        StartSession(GameMode.AutoHostOrClient);

    private async UniTaskVoid StartSession(GameMode gameMode)
    {
        _networkRunner.ProvideInput = true;

        await _networkRunner.StartGame(new StartGameArgs()
        {
            GameMode = gameMode,
            SceneManager = _sceneManager,
            Scene = GetScene(),
            SessionName = _sessionName
        });
    }

    private SceneRef GetScene() =>
        SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
}