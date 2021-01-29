using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    private List<CheckpointSingle> checkpointList;
    private int nextCheckpointIndex = 0;
    public int laps = 0;

    private void Awake()
    {
        //initialized list of checkpoints and connects them to the tracker
        Transform checkpointsTransform = transform.Find("Checkpoints");

        foreach(Transform checkPointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpoint = checkPointSingleTransform.GetComponent<CheckpointSingle>();
            checkpoint.setTrackCheckpoints(this);
            checkpointList.Add(checkpoint);
        }
    }

    public void CheckpointReached(CheckpointSingle checkpoint)
    {
        //right checkpoint
        if(checkpointList.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            Debug.Log("Right");
            nextCheckpointIndex = (nextCheckpointIndex + 1)%checkpointList.Count;
            //make checkpoint sound

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
