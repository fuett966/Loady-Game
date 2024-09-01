using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadAssetButton : MonoBehaviour
{
    [SerializeField] private Button loadButton;
    [SerializeField] private string assetAddress;
    private AddressablesManager _addressableManager;

    [Inject]
    public void Construct(AddressablesManager addressableManager)
    {
        _addressableManager = addressableManager;
    }

    private void Start()
    {
        loadButton.onClick.AddListener(OnLoadButtonClicked);
    }

    private void OnLoadButtonClicked()
    {
        
    }

    private void OnAssetLoaded(GameObject loadedAsset)
    {
        if (loadedAsset != null)
        {
            Instantiate(loadedAsset, transform.position, Quaternion.identity);
        }
    }
}
