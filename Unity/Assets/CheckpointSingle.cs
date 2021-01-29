using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoints tracker;

    //runs when player runs through a checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            //notify tracker that this single checkpoint has been reached
            tracker.CheckpointReached(this);
        }
    }
    public void setTrackCheckpoints(TrackCheckpoints tracker)
    {
        this.tracker = tracker;
    }
}
