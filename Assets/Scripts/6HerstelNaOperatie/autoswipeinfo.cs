using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoSwipeInfo : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float swipeInterval = 3f;
    public float swipeSpeed = 0.5f;

    public Button nextButton;
    public Button prevButton;

    private int totalPages;
    private int currentPage = 0;
    private float[] positions;
    private Coroutine swipeCoroutine;

    public void Start()
    {
        totalPages = scrollRect.content.childCount;
        positions = new float[totalPages];

        for (int i = 0; i < totalPages; i++)
        {
            positions[i] = (float)i / (totalPages - 1);
        }

        nextButton.onClick.AddListener(NextPage);
        prevButton.onClick.AddListener(PreviousPage);

        swipeCoroutine = StartCoroutine(AutoSwipe());
    }

    IEnumerator AutoSwipe()
    {
        while (true)
        {
            yield return new WaitForSeconds(swipeInterval);
            NextPage();
        }
    }

    public void NextPage()
    {
        if (swipeCoroutine != null) StopCoroutine(swipeCoroutine);

        currentPage = (currentPage + 1) % totalPages;
        swipeCoroutine = StartCoroutine(SmoothSwipe(positions[currentPage]));
        swipeCoroutine = StartCoroutine(AutoSwipe());
    }

    public void PreviousPage()
    {
        if (swipeCoroutine != null) StopCoroutine(swipeCoroutine);

        currentPage = (currentPage - 1 + totalPages) % totalPages;
        swipeCoroutine = StartCoroutine(SmoothSwipe(positions[currentPage]));
        swipeCoroutine = StartCoroutine(AutoSwipe());
    }

    IEnumerator SmoothSwipe(float targetPosition)
    {
        float start = scrollRect.horizontalNormalizedPosition;
        float time = 0f;

        while (time < swipeSpeed)
        {
            time += Time.deltaTime;
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(start, targetPosition, time / swipeSpeed);
            yield return null;
        }

        scrollRect.horizontalNormalizedPosition = targetPosition;
    }
}
