
using UnityEngine;

namespace XeApp
{
    public class DecorationPoster : DecorationItemBase
    {
        private Material m_kiraMaterial; // 0x9C
        private Material m_kiraMaterialFlip; // 0xA0
        public int IsKiraShaderParam = Shader.PropertyToID("_IsKira"); // 0xA4

        // RVA: 0xBB0E24 Offset: 0xBB0E24 VA: 0xBB0E24 Slot: 16
        protected override void PreDestroy()
        {
            if(m_kiraMaterial != null)
                m_kiraMaterial = null;
            if(m_kiraMaterialFlip != null)
                m_kiraMaterialFlip = null;
        }

        // RVA: 0xBB0F08 Offset: 0xBB0F08 VA: 0xBB0F08 Slot: 17
        protected override void PostDestroy()
        {
            return;
        }

        // // RVA: 0xBB0F0C Offset: 0xBB0F0C VA: 0xBB0F0C Slot: 6
        protected override void PostLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
        {
            return;
        }

        // // RVA: 0xBB0F10 Offset: 0xBB0F10 VA: 0xBB0F10 Slot: 9
        protected override void PostInitController()
        {
            if(UseRareBrakePosterAnim)
            {
                SpriteRenderer sr = m_object.GetComponentInChildren<SpriteRenderer>();
                sr.transform.localScale = new Vector3(9.960938f, 9.960938f, 1);
                sr.GetComponent<BoxCollider2D>().size *= 9.960938f;
            }
        }

        // // RVA: 0xBB10C0 Offset: 0xBB10C0 VA: 0xBB10C0 Slot: 7
        protected override void CreateAppendAsset(DecorationItemArgsBase args)
        {
            DecorationPosterArgs arg = args as DecorationPosterArgs;
            if(ViewData.NPADACLCNAN_Category != EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef && 
                ViewData.NPADACLCNAN_Category != EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
                return;
            if(arg.m_kiraMaterialSource != null)
            {
                m_kiraMaterial = new Material(arg.m_kiraMaterialSource);
                SetTexture(m_kiraMaterial, m_baseTexture, m_maskTexture);
            }
            if(arg.m_kiraMaterialFlipSource != null)
            {
                m_kiraMaterialFlip = new Material(arg.m_kiraMaterialFlipSource);
                if(UseFlipTexture)
                {
                    SetTexture(m_kiraMaterialFlip, m_baseTextureFlip, m_maskTextureFlip);
                }
            }
        }

        // RVA: 0xBB130C Offset: 0xBB130C VA: 0xBB130C Slot: 23
        protected override Material GetCurrentMaterial()
        {
            if(IsKiraPoster && UseFlipTexture)
            {
                if(!m_isFlip)
                    return m_kiraMaterial;
                else
                    return m_kiraMaterialFlip;
            }
            SetKiraCurrentMaterial(IsKiraPoster, IsKiraShaderParam);
            return base.GetCurrentMaterial();
        }
    }
}