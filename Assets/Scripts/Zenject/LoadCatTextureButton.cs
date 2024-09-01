using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadCatTextureButton : MonoBehaviour
{
    [SerializeField] private Button loadButton;
    [SerializeField] private RawImage rawImage;

    private AddressablesManager _addressablesManager; 

    [Inject]
    public void Construct(AddressablesManager addressablesManager)
    {
        _addressablesManager = addressablesManager;
    }

    private void Start()
    {
        loadButton.onClick.AddListener(OnLoadButtonClicked); 
    }

    private void OnLoadButtonClicked()
    {
        _addressablesManager.LoadCatTextureFromCloud();
    }
}
