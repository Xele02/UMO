using UnityEngine;

public class N : MonoBehaviour
{
        [SerializeField]
        public GameObject c; // 0xC
        [SerializeField]
        public D d; // 0x10
        public S e; // 0x14

        public static N a { get; set; } // 0x0 / get_a / set_a

        private void Awake() 
		{ 
			a = this;
			e = new S();
			e.A(this);
		}

        // RVA: 0x17BED40 Offset: 0x17BED40 VA: 0x17BED40
        public GameObject A()
		{
			return UnityEngine.Object.Instantiate<GameObject>(c);
		}

        private void Update() 
		{ 
			e.C(this);
		}

        // RVA: 0x17BEE08 Offset: 0x17BEE08 VA: 0x17BEE08
        private void OnApplicationPause(bool a)
		{
			if(e != null)
			{
				e.F(a);
			}
		}

        public void OnDestroy() 
		{ 
			if(e != null)
			{
				e.G();
				e = null;
			}
		}

}
