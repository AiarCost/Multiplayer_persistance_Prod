using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed;

    private float startTime;
    private float timeTaken;

    private int collectablesPicked;
    public int maxCollectables = 10;

    public GameObject playButton;
    public TextMeshProUGUI curTimeText;

    private bool isPlaying = false;

    public delegate void GameStartChange();
    public static event GameStartChange GameStartChanged;


    private void OnEnable()
    {
        GameStartChanged += ChangeBool;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
            return;

        curTimeText.text = (Time.time - startTime).ToString("F2");
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Collectable"))
        {
            collectablesPicked++;
            Destroy(col.gameObject);

            if(collectablesPicked == maxCollectables)
            {
                Debug.Log("Collectables Done!");
                End();
            }
        }
    }

    public void Begin()
    {
        startTime = Time.time;
        GameStartChanged();
        playButton.SetActive(false);
    }

    void End()
    {
        Debug.Log("End function Started");
        timeTaken = Time.time - startTime;
        Debug.Log("End 1");
        GameStartChanged();
        Debug.Log("End 2");
        playButton.SetActive(true);
        Debug.Log("End 3");
        Leaderboard.instance.SetLeaderboardEntry(-Mathf.RoundToInt(timeTaken * 1000.0f));
        Debug.Log("End 4");
    }

    public void ChangeBool()
    {
        isPlaying = !isPlaying;
        Debug.Log("Is Playing = "+ isPlaying);
    }
}
