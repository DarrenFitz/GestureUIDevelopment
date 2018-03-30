using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class Bubble : MonoBehaviour
{
    public Vector3 mMovementDirection = Vector3.zero;
    public Coroutine mCurrentChanger = null;

    private void OnEnable()
    {
        mCurrentChanger = StartCoroutine(DirectionChanger());
    }

    private void OnDisable()
    {
        StopCoroutine(mCurrentChanger);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        // Return to BubbleManager
    }

    private void Update()
    {
        // Movement
        transform.position += mMovementDirection * Time.deltaTime * 0.5f;
    }

    private IEnumerator DirectionChanger()
    {
        while (gameObject.activeSelf)
        {
            mMovementDirection = new Vector2(Random.Range(0,100) * 0.01f, Random.Range(0,100) * 0.01f);

            yield return new WaitForSeconds(3.0f);
        }
    }
}
