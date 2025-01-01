
using UnityEngine;

public class TargetEffector : TargetEffectorBase
{
	private SmartARController smartARController_; // 0xA0

	// RVA: 0x12FD604 Offset: 0x12FD604 VA: 0x12FD604 Slot: 4
	protected override void Awake()
    {
        smartARController_ = FindObjectsOfType<SmartARController>()[0];
        //UMO
        GameObject g = new GameObject("LandmarkObjects");
        LandmarkEffector l = g.AddComponent<LandmarkEffector>();
        g.transform.SetParent(transform, false);
        l.showLandmarks = true;
        GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        s.transform.SetParent(g.transform, false);
        l.sphere_ = s;
        //UMO
        base.Awake();
    }

	// RVA: 0x12FD87C Offset: 0x12FD87C VA: 0x12FD87C
	public void SetSmartARController(SmartARController arCont)
    {
        smartARController_ = arCont;
    }

	// RVA: 0x12FD884 Offset: 0x12FD884 VA: 0x12FD884 Slot: 5
	protected override void Start()
    {
        if(!smartARController_.smart_.isConstructorFailed())
        {
            bool b = false;
            for(int i = 0; i < smartARController_.recognizerSettings_.targets.Length; i++)
            {
                b |= smartARController_.recognizerSettings_.targets[i].id == targetID;
            }
            gameObject.SetActive(b);
            if(smartARController_.recognizerSettings_.recognitionMode == smartar.RecognitionMode.RECOGNITION_MODE_SCENE_MAPPING && smartARController_.recognizerSettings_.sceneMappingInitMode != smartar.SceneMappingInitMode.SCENE_MAPPING_INIT_MODE_TARGET)
                targetID = null;
            base.Start();
            return;
        }
        showOrHideChildrens(false);
    }

	// RVA: 0x12FDB08 Offset: 0x12FDB08 VA: 0x12FDB08 Slot: 6
	protected override void Update()
    {
        return;
    }

	// // RVA: 0x12FA244 Offset: 0x12FA244 VA: 0x12FA244
	public void UpdateContents()
    {
        if(smartARController_ != null)
        {
            if(smartARController_.enabled_)
            {
                if(!smartARController_.smart_.isConstructorFailed())
                {
                    if(smartARController_.isLoadSceneMap_ && targetID != null)
                    {
                        if(smartARController_.recognizerSettings_.targets[0].id != targetID)
                        {
                            gameObject.SetActive(false);
                            return;
                        }
                        targetID = null;
                    }
                    base.Update();
                    Transform l = transform.Find("LandmarkObjects");
                    if(l != null)
                    {
                        LandmarkEffector le = l.GetComponent<LandmarkEffector>();
                        if(le != null)
                        {
                            le.UpdateContents();
                        }
                    }
                    l = transform.Find("InitPointObjects");
                    if(l != null)
                    {
                        InitPointEffector le = l.GetComponent<InitPointEffector>();
                        if(le != null)
                        {
                            le.UpdateContents();
                        }
                    }
                }
            }
        }
    }
}
