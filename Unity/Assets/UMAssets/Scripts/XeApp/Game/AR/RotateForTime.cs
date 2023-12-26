
using System.Collections;
using UnityEngine;

namespace XeApp.Game.AR
{
    public class RotateForTime : MonoBehaviour
    {
        // RVA: 0x13B4084 Offset: 0x13B4084 VA: 0x13B4084
        public void StartRotate(float time, float rotSpeed)
        {
            this.StartCoroutineWatched(CoRotateZ(time, rotSpeed));
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67AB9C Offset: 0x67AB9C VA: 0x67AB9C
        // // RVA: 0x13B40A8 Offset: 0x13B40A8 VA: 0x13B40A8
        private IEnumerator CoRotateZ(float time, float totalAngle)
        {
            RectTransform rect; // 0x1C
            float startTime; // 0x20
            Quaternion rot; // 0x24

            //0x13B41A4
            rect = GetComponent<RectTransform>();
            startTime = Time.unscaledTime;
            rot = rect.localRotation;
            do
            {
                float r = Mathf.Clamp01((Time.unscaledTime - startTime) / time);
                rect.localRotation = rot * Quaternion.Euler(0, 0, r * totalAngle);
                if(r >= 1)
                    break;
                yield return null;
            } while(true);
        }
    }
}