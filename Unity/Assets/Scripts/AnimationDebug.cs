
using UnityEngine;

class AnimationDebug : MonoBehaviour
{
	void Update()
	{
		Animator anim = GetComponent<Animator>();
		if(anim != null)
		{
			string r = "";
			for (int l = 0; l < anim.layerCount; l++)
			{
				r += "Layer " + l + " : ";
				var stateInfo = anim.GetCurrentAnimatorStateInfo(l);
				r += "FullHash : " + stateInfo.fullPathHash+" ";
				r += "Norm : " + stateInfo.normalizedTime + " ";
				r += "Loop : " + stateInfo.loop + " ";
				r += "ShortHash : " + stateInfo.shortNameHash + " ";
				r += "Speed : " + stateInfo.speed + "\n";
				var clipsInfo = anim.GetCurrentAnimatorClipInfo(l);
				for(int i = 0; i < clipsInfo.Length; i++)
				{
					r += " Clips " + i + " :  " + clipsInfo[i].clip.name + " -  " + clipsInfo[i].weight;
				}
			}
			Debug.LogError(r);
		}
	}

}
