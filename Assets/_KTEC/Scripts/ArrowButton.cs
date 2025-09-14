using UnityEngine;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour
{
    [Header("ボタン設定")]
    [SerializeField] private float gazeTime = 2.0f;
    [SerializeField] private ArrowButtonType type = ArrowButtonType.Next;

    public enum ArrowButtonType
    {
        Next,
        Previous
    }

    private float gazeTimer = 0f;
    private bool isGazing = false;
    private DocumentRoot documentRoot;
    private Image progressImage;

    public float GazeProgress => gazeTimer / gazeTime;

    void Start()
    {
        documentRoot = transform.root.GetComponent<DocumentRoot>();
        progressImage = GetComponent<Image>();
    }

    void Update()
    {
        if (isGazing)
        {
            gazeTimer += Time.deltaTime;
            progressImage.fillAmount = GazeProgress;
            if (gazeTimer >= gazeTime)
            {
                OnGazeComplete();
            }
        }
        else
        {
            progressImage.fillAmount = 0f;
        }
    }

    public void OnGazeStart()
    {
        isGazing = true;
        gazeTimer = 0f;
    }

    public void OnGazeEnd()
    {
        isGazing = false;
        gazeTimer = -1f;
    }

    private void OnGazeComplete()
    {
        switch (type)
        {
            case ArrowButtonType.Next:
                documentRoot.NextPage();
                break;
            case ArrowButtonType.Previous:
                documentRoot.PreviousPage();
                break;
        }
        gazeTimer = 0f;
    }
}
