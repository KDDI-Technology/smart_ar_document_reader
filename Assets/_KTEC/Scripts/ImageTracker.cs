using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageTracker : MonoBehaviour
{

    [SerializeField] private GameObject[] docs;
    private Dictionary<string, GameObject> docPairs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;


    void Start()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += OnChanged;

        for (int i = 0; i < docs.Length; i++)
        {
            docPairs.Add(trackedImageManager.referenceLibrary[i].name, docs[i]);
            docs[i].SetActive(false);
        }
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            UpdateDoc(newImage);
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            UpdateDoc(updatedImage);
        }

        foreach (var removedImage in eventArgs.removed)
        {
            UpdateDoc(removedImage);
        }
    }

    private void UpdateDoc(ARTrackedImage trackedImage)
    {
        GameObject g = docPairs[trackedImage.referenceImage.name];
        g.SetActive(trackedImage.trackingState != TrackingState.None);

        Transform t = trackedImage.transform;
        Quaternion q = t.rotation * Quaternion.Euler(90f, 0, 0);
        g.transform.SetPositionAndRotation(t.position, q);
    }
}
