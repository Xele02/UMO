
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using smartar;
using UnityEngine;

public abstract class LandmarkEffectorBase : MonoBehaviour
{
	public GameObject sphere_; // 0xC
	public bool showLandmarks; // 0x10
	protected IntPtr landmarkBuffer_ = IntPtr.Zero; // 0x14
	protected IntPtr nodePointBuffer_ = IntPtr.Zero; // 0x18
	protected RecognitionResult result_; // 0x20
	protected List<GameObject> landmarkObjects_ = new List<GameObject>(); // 0x98
	protected List<GameObject> nodePointObjects_ = new List<GameObject>(); // 0x9C

	// RVA: 0xB4A8A4 Offset: 0xB4A8A4 VA: 0xB4A8A4
	private void Awake() 
    {
        landmarkBuffer_ = Marshal.AllocCoTaskMem(Recognizer.MAX_NUM_LANDMARKS * Marshal.SizeOf(typeof(Landmark)));
        nodePointBuffer_ = Marshal.AllocCoTaskMem(Recognizer.MAX_NUM_NODE_POINTS * Marshal.SizeOf(typeof(NodePoint)));
    }

	// RVA: 0xB48C58 Offset: 0xB48C58 VA: 0xB48C58 Slot: 4
	protected virtual void Start()
    {
        result_ = new RecognitionResult();
        result_.maxLandmarks_ = Recognizer.MAX_NUM_LANDMARKS;
        result_.landmarks_ = landmarkBuffer_;
        result_.maxNodePoints_ = Recognizer.MAX_NUM_NODE_POINTS;
        result_.nodePoints_ = nodePointBuffer_;
    }

	// RVA: 0xB48D14 Offset: 0xB48D14 VA: 0xB48D14 Slot: 5
	protected virtual void OnGUI()
    {
        return;
    }

	// RVA: 0xB4AA14 Offset: 0xB4AA14 VA: 0xB4AA14
	private void OnDestroy()
    {
        for(int i = 0; i < nodePointObjects_.Count; i++)
        {
            nodePointObjects_[i].SetActive(false);
            Destroy(nodePointObjects_[i]);
        }
        nodePointObjects_.Clear();
        for(int i = 0; i < landmarkObjects_.Count; i++)
        {
            landmarkObjects_[i].SetActive(false);
            Destroy(landmarkObjects_[i]);
        }
        landmarkObjects_.Clear();
    }

	// // RVA: -1 Offset: -1 Slot: 6
	protected abstract void GetResult(ref RecognitionResult result);

	// // RVA: -1 Offset: -1 Slot: 7
	protected abstract Rotation GetScreenRotation();

	// // RVA: -1 Offset: -1 Slot: 8
	protected abstract Rotation GetCameraRotation();

	// // RVA: -1 Offset: -1 Slot: 9
	protected abstract bool IsFlipX();

	// // RVA: -1 Offset: -1 Slot: 10
	protected abstract bool IsFlipY();

	// // RVA: -1 Offset: -1 Slot: 11
	protected abstract void SetPose(Transform transformObject, RecognitionResult result, smartar.Vector3 rotPosition);

	// RVA: 0xB48E5C Offset: 0xB48E5C VA: 0xB48E5C Slot: 12
	protected virtual void Update()
    {
        if(showLandmarks)
        {
            GetResult(ref result_);
            if(result_.isRecognized_)
            {
                Rotation r1 = GetScreenRotation();
                Rotation r2 = GetCameraRotation();
                bool flipX = IsFlipX();
                bool flipY = IsFlipY();
                smartar.Vector3 rotP;
                smartar.Quaternion rotQ;
                SmartARControllerBase.adjustPose(r2, r1, flipX, flipY, result_.position_, result_.rotation_, out rotP, out rotQ);
                if(result_.nodePoints_ != IntPtr.Zero && result_.numNodePoints_ > 0)
                {
                    IntPtr p = result_.nodePoints_;
                    for(int i = 0; i < result_.numNodePoints_; i++)
                    {
                        NodePoint np = (NodePoint)Marshal.PtrToStructure(p, typeof(NodePoint));
                        smartar.Vector3 rotP2;
                        smartar.Quaternion rotQ2;
                        SmartARControllerBase.adjustPose(r2, r1, flipX, flipY, np.position_, result_.rotation_, out rotP2, out rotQ2);
                        if(landmarkObjects_.Count - 1 > i)
                        {
                            nodePointObjects_[i].SetActive(true);
                        }
                        else
                        {
                            GameObject g = Instantiate(sphere_, UnityEngine.Vector3.zero, UnityEngine.Quaternion.identity);
                            g.transform.localScale = new UnityEngine.Vector3(18, 18, 18);
                            g.transform.parent = transform;
                            Renderer r = g.GetComponent<Renderer>();
                            r.material.SetColor("_Color", new Color(1, 1, 1, 1));
                            g.SetActive(true);
                            nodePointObjects_.Add(g);
                        }
                        SetPose(nodePointObjects_[i].transform, result_, rotP);
                        int s = Marshal.SizeOf<NodePoint>(np);
                        p += s;
                    }
                    for(int i = result_.numNodePoints_; i < nodePointObjects_.Count; i++)
                    {
                        nodePointObjects_[i].SetActive(false);
                    }
                }
                if(result_.landmarks_ != IntPtr.Zero && result_.numLandmarks_ > 0)
                {
                    IntPtr p = result_.landmarks_;
                    for(int i = 0; i < result_.numLandmarks_; i++)
                    {
                        Landmark lm = (Landmark)Marshal.PtrToStructure(p, typeof(Landmark));
                        smartar.Vector3 rotP2;
                        smartar.Quaternion rotQ2;
                        SmartARControllerBase.adjustPose(r2, r1, flipX, flipY, lm.position_, result_.rotation_, out rotP2, out rotQ2);
                        if(i < landmarkObjects_.Count - 1)
                        {
                            ;
                        }
                        else
                        {
                            GameObject g = Instantiate(sphere_, UnityEngine.Vector3.zero, UnityEngine.Quaternion.identity);
                            g.transform.localScale = new UnityEngine.Vector3(20, 20, 20);
                            g.transform.parent = transform;
                            landmarkObjects_.Add(g);
                        }
                        SetPose(landmarkObjects_[i].transform, result_, rotP);
                        Color col;
                        switch(lm.state_)
                        {
                            case LandmarkState.LANDMARK_STATE_TRACKED:
                                col = new Color(0, 1, 0, 1);
                                break;
                            case LandmarkState.LANDMARK_STATE_LOST:
                                col = new Color(1, 0, 0, 1);
                                break;
                            case LandmarkState.LANDMARK_STATE_SUSPENDED:
                                col = new Color(0, 1, 1, 1);
                                break;
                            case LandmarkState.LANDMARK_STATE_MASKED:
                                col = new Color(1, 1, 0, 1);
                                break;
                            default:
                                col = new Color(0, 0, 0, 1);
                                break;
                        }
                        Material m = landmarkObjects_[i].GetComponent<Renderer>().material;
                        if(m.color != col)
                        {
                            m.color = col;
                        }
                        landmarkObjects_[i].SetActive(true);
                        p += Marshal.SizeOf<Landmark>(lm);
                    }
                    for(int i = result_.numLandmarks_; i < landmarkObjects_.Count; i++)
                    {
                        landmarkObjects_[i].SetActive(false);
                    }
                }
                return;
            }
        }
        disableLandmarkAndNodes();
    }

	// // RVA: 0xB4ACB0 Offset: 0xB4ACB0 VA: 0xB4ACB0
	private void disableLandmarkAndNodes() 
    {
        for(int i = 0; i < nodePointObjects_.Count; i++)
        {
            nodePointObjects_[i].SetActive(false);
        }
        for(int i = 0; i < landmarkObjects_.Count; i++)
        {
            landmarkObjects_[i].SetActive(false);
        }
    }
}
