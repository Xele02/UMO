
using UnityEngine;

namespace XeApp.Game.AR
{
    public class ARDivaFlip : MonoBehaviour
    {
        // RVA: 0x161CA20 Offset: 0x161CA20 VA: 0x161CA20
        private void Update()
        {
            if(VuforiaManager.Instance != null)
            {
                if(VuforiaManager.Instance.IsFlip)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    if(transform.parent != null)
                    {
                        Vector3 v = new Vector3(1 / transform.parent.localScale.x, 
                            1 / transform.parent.localScale.y,
                            1 / transform.parent.localScale.z);
                        if(v != transform.localScale)
                        {
                            transform.localScale = v;
                        }
                    }
                }
            }
        }

        // RVA: 0x161CD88 Offset: 0x161CD88 VA: 0x161CD88
        private void LateUpdate()
        {
            if(VuforiaManager.Instance != null)
            {
                if(VuforiaManager.Instance.IsFlip)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    if(transform.parent != null)
                    {
                        Vector3 v = new Vector3(1 / transform.parent.localScale.x, 
                            1 / transform.parent.localScale.y,
                            1 / transform.parent.localScale.z);
                        if(v != transform.localScale)
                        {
                            transform.localScale = v;
                        }
                    }
                }
            }
        }
    }
}