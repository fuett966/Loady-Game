using Firebase.Extensions;
using Firebase.Storage;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    public RawImage _testImage;

    FirebaseStorage firebaseStorage;
    StorageReference storageReference;

    [SerializeField] private string _firebaseStorageUrl = "gs://loady-game.appspot.com";
    [SerializeField] private string _fileReference = "jazzcat.AgADGAADIyIEBg.512.png";


    private IEnumerator LoadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            _testImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    private void Awake()
    {
        firebaseStorage = FirebaseStorage.DefaultInstance;
        //storageReference = firebaseStorage.GetReferenceFromUrl("gs://loady-game.appspot.com");
        storageReference = firebaseStorage.GetReferenceFromUrl(_firebaseStorageUrl);
        //StorageReference image = storageReference.Child("jazzcat.AgADGAADIyIEBg.512.png");
    }

    public void DownloadFile()
    {
        StorageReference image = storageReference.Child(_fileReference);
        image.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
                {
                    if (!task.IsFaulted && !task.IsCanceled)
                    {
                        StartCoroutine(LoadImage(Convert.ToString(task.Result)));
                    }
                    else
                    {
                        Debug.Log(task.Exception);
                    }
                });
    }

}
