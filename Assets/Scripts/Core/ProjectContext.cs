
using UnityEngine;
using Utils.Assets;

public sealed class ProjectContext : MonoBehaviour
{
    public static ProjectContext I { get; private set; }

    private void Awake()
    {
        I = this;
        DontDestroyOnLoad(this);
    }

    public void Initialize()
    {

    }
}