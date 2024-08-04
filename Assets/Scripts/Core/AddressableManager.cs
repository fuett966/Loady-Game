using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesManager : MonoBehaviour
{
    [Header("GameClicker")]
    [SerializeField]
    private AssetReferenceTexture2D _catAssetReference;

    


    [Header("GameRunner")]
    [SerializeField]
    private AssetReference _playerRunner;

    [SerializeField]
    private AssetReference _finishRunner;

    [SerializeField]
    private AssetReference _startRunner;

    [SerializeField]
    private RawImage _rawImageCat;

    void Start()
    {
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
    }

    public void LoadCatTextureFromCloud()
    {
        _catAssetReference.LoadAssetAsync<Texture2D>().Completed += (texture) => {
            _rawImageCat.texture = _catAssetReference.Asset as Texture2D;
            Color currentColor = _rawImageCat.color;
            currentColor.a = 1f;
            _rawImageCat.color = currentColor;
        };
    }

    public void UnloadCatTextureFromCloud()
    {
        _catAssetReference.ReleaseAsset();
    }

    public void LoadGameClickerResourses()
    {
        _catAssetReference.LoadAssetAsync<Texture2D>();
    }

    public void UnLoadGameClickerResourses()
    {
        _catAssetReference.ReleaseAsset();
    }

    public void LoadGameRunnerResourses()
    {
        _playerRunner.LoadAssetAsync<GameObject>();
        _finishRunner.LoadAssetAsync<GameObject>();
        _startRunner.LoadAssetAsync<GameObject>();
    }

    public void UnLoadGameRunnerResourses()
    {
        _playerRunner.ReleaseAsset();
        _finishRunner.ReleaseAsset();
        _startRunner.ReleaseAsset();
    }

    private void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        //allow to download addressables from cloud
    }

}

