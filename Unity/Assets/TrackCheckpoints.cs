using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    private List<CheckpointSingle> checkpointList = new List<CheckpointSingle>();
    private int nextCheckpointIndex = 0;
    public int laps = 0;
    private Transform checkpointsTransform;

    private void Awake()
    {
        checkpointsTransform = GetComponent<Transform>();

        //initialized list of checkpoints and connects them to the tracker
        //checkpointsTransform = transform.Find("Checkpoints");

        foreach (Transform checkPointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpoint = checkPointSingleTransform.GetComponent<CheckpointSingle>();
            checkpoint.setTrackCheckpoints(this);
            checkpointList.Add(checkpoint);
        }
    }

    public void CheckpointReached(CheckpointSingle checkpoint)
    {
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/checkpoint", 0);

        //right checkpoint
        if (checkpointList.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            Debug.Log("Right");
            nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointList.Count;

            if (nextCheckpointIndex == 1)
            {
                laps++;
            }
        }
        //wrong checkpoint
        else
        {
            Debug.Log("Wrong");
            //wrong sound maybe?

        }
    }
}