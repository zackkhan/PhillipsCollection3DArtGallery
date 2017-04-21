﻿using UnityEngine;
using System.Collections;

public class DrawLineManager : MonoBehaviour {
	public SteamVR_TrackedObject trackedObj;
	public MeshLineRenderer currLine;
	private int numClicks = 0;
	// Update is called once per frame
	void Update () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			GameObject go = new GameObject ();
			go.AddComponent<MeshFilter> ();
			go.AddComponent<MeshRenderer> ();
			go.AddComponent<MeshLineRenderer> ();
			currLine.setWidth (.1f);

		
			numClicks = 0;
		} else if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			//currLine.setVertexCount (numClicks + 1);
			//currLine.SetPosition (numClicks, trackedObj.transform.position);
			currLine.AddPoint (trackedObj.transform.position);
			numClicks++;
		} else if (device.getTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			numClicks = 0;
			currLine = null;
		}

		if (currLine != null){
			currLine.lmat.color = ColorManager.GetCurrentColor ();
}
}
}