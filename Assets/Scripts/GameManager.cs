using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
    private PlayerController playerControllerScript;
    public Transform startingPoint;
    public float lerpSpeed;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
        score = 0;

        playerControllerScript.gameStart = true;
        playerControllerScript.isOnGround = false;
        playerControllerScript.doubleJumpUsed = true;
        StartCoroutine(PlayIntro());
    }
    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        0.5f);
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos,
            fractionOfJourney);
            yield return null;
        }
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        1.0f);
        playerControllerScript.gameStart = false;
        playerControllerScript.isOnGround = true;
        playerControllerScript.doubleJumpUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
        if (!playerControllerScript.gameStart)
        {
            if (playerControllerScript.doubleSpeed)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("Score: " + score);
        }
    }
}