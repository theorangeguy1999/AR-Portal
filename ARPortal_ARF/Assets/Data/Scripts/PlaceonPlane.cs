using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceonPlane : MonoBehaviour
{
    public GameObject Portal;
    public GameObject M_Cam;

    private ARRaycastManager _arraycastmanager;
    private Vector2 touchpos;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake() 
    {
        _arraycastmanager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPos(out Vector2 touchpos)
    {
        if(Input.touchCount > 0)
        {
            touchpos = Input.GetTouch(0).position;
            return true;
        }

        touchpos = default;
        return false;
    }
    void Update()
    {
        if(!TryGetTouchPos(out touchpos))
            return;
        if(_arraycastmanager.Raycast(touchpos,hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            //Anchor anchor = hits[0].Trackable.CreateAnchor(hits[0].pose);
            Portal.SetActive(true);

            Portal.transform.position = hits[0].pose.position;
            Portal.transform.rotation = hits[0].pose.rotation;

            Vector3 cam_pos = M_Cam.transform.position;

            cam_pos.y = hits[0].pose.position.y;

            Portal.transform.LookAt(cam_pos,Portal.transform.up);
            //Portal.transform.parent = anchor.transform;

        }
        
    }
}
