using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoints tracker;

    private void Awake()
    {
        tracker = gameObject.GetComponentInParent<TrackCheckpoints>();
    }

    //runs when player runs through a checkpoint
    private void OnTriggerEnter(Collider other)
    {
        //Nathan's collider
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            tracker.CheckpointReached(this);
        }

        //old collider
        /*if(other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            //notify tracker that this single checkpoint has been reached
            tracker.CheckpointReached(this);
        }*/
    }
    public void setTrackCheckpoints(TrackCheckpoints tracker)
    {
        this.tracker = tracker;
    }
}


