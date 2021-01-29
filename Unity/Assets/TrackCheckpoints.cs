using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    private List<CheckpointSingle> checkpointList;

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

    }
}
