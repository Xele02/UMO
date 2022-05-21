// using UnityEngine;
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;

// namespace XeSys
// {
// 	public delegate BEEINMBNKNM FindDecryptor(string path);

// 	public class FileLoader : SingletonBehaviour<FileLoader>, IDisposable, ILoader // TypeDefIndex: 10401
// 	{
// 		// Fields
// 		private const int FILE_REQUEST_QUEUE_ID = 0; // 0x0
// 		public FindDecryptor findDecryptor; // 0x24

// 		// [CompilerGeneratedAttribute] // 0x3E2320
// 		// private bool <isLoading>k__BackingField; // 0xC
// 		// [CompilerGeneratedAttribute] // 0x3E2330
// 		// private string <bytesExtention>k__BackingField; // 0x10
// 		// [CompilerGeneratedAttribute] // 0x3E2340
// 		// private string <textureExtention>k__BackingField; // 0x14
// 		// [CompilerGeneratedAttribute] // 0x3E2350
// 		// private string <assetBundleExtention>k__BackingField; // 0x18
// 		// [CompilerGeneratedAttribute] // 0x3E2360
// 		// private string <secureExtention>k__BackingField; // 0x1C
// 		// [CompilerGeneratedAttribute] // 0x3E2370
// 		// private string <cpkExtention>k__BackingField; // 0x20
// 		// [CompilerGeneratedAttribute] // 0x3E2380
// 		// private CriFsBinder <binder>k__BackingField; // 0x24
// 		// [CompilerGeneratedAttribute] // 0x3E2390
// 		// private Dictionary`2<int, FileLoadInfo> <fileLoadedDic>k__BackingField; // 0x28
// 		// [CompilerGeneratedAttribute] // 0x3E23A0
// 		// private Dictionary`2<int, FileLoadInfo> <fileLoadingDic>k__BackingField; // 0x2C

// 		// Properties
// 		public bool isLoading { get; set; }
// 		public string bytesExtention { get; set; }
// 		public string textureExtention { get; set; }
// 		public string assetBundleExtention { get; set; }
// 		public string secureExtention { get; set; }
// 		public string cpkExtention { get; set; }
// 		//public CriFsBinder binder { get; set; }
// 		private Dictionary<int, FileLoadInfo> fileLoadedDic { get; set; }
// 		private Dictionary<int, FileLoadInfo> fileLoadingDic { get; set; }

// 		// Methods
// 		public FileLoader() // 0x18A0688
// 		{
// 			// 18a0688:	e92d4df0 	push	{r4, r5, r6, r7, r8, sl, fp, lr}
// 			// 18a068c:	e28db018 	add	fp, sp, #24
// 			// 18a0690:	e1a04000 	mov	r4, r0
// 			// 18a0694:	e59f00fc 	ldr	r0, [pc, #252]	; 18a0798 <dladdr@plt+0x15616bc>
// 			// 18a0698:	e59f50fc 	ldr	r5, [pc, #252]	; 18a079c <dladdr@plt+0x15616c0>
// 			// 18a069c:	e08f0000 	add	r0, pc, r0
// 			// 18a06a0:	e0850000 	add	r0, r5, r0
// 			// 18a06a4:	e5d000e0 	ldrb	r0, [r0, #224]	; 0xe0
// 			// 18a06a8:	e3500000 	cmp	r0, #0
// 			// 18a06ac:	1a000008 	bne	18a06d4 <dladdr@plt+0x15615f8>
// 			// 18a06b0:	e59f00e8 	ldr	r0, [pc, #232]	; 18a07a0 <dladdr@plt+0x15616c4>
// 			// 18a06b4:	e59f10e8 	ldr	r1, [pc, #232]	; 18a07a4 <dladdr@plt+0x15616c8>
// 			// 18a06b8:	e08f6000 	add	r6, pc, r0
// 			// 18a06bc:	e7910006 	ldr	r0, [r1, r6]
// 			// 18a06c0:	e5900000 	ldr	r0, [r0]
// 			// 18a06c4:	eb1253ad 	bl	1d35580 <_ZNSt6vectorIjSaIjEE17_M_default_appendEj+0x2ab4>
// 			// 18a06c8:	e0850006 	add	r0, r5, r6
// 			// 18a06cc:	e3a01001 	mov	r1, #1
// 			// 18a06d0:	e5c010e0 	strb	r1, [r0, #224]	; 0xe0
// 			// 18a06d4:	e59f00cc 	ldr	r0, [pc, #204]	; 18a07a8 <dladdr@plt+0x15616cc>
// 			// 18a06d8:	e59f10cc 	ldr	r1, [pc, #204]	; 18a07ac <dladdr@plt+0x15616d0>
// 			// 18a06dc:	e08f6000 	add	r6, pc, r0
// 			// 18a06e0:	e7910006 	ldr	r0, [r1, r6]
// 			// 18a06e4:	e5901000 	ldr	r1, [r0]
// 			// 18a06e8:	e1a00004 	mov	r0, r4
// 			// 18a06ec:	eb1001d0 	bl	1ca0e34 <dladdr@plt+0x1961d58> // Singleton`1 -> 	protected void .ctor(); // 0x1CA0E34
// 			// 18a06f0:	e59f00b8 	ldr	r0, [pc, #184]	; 18a07b0 <dladdr@plt+0x15616d4>
// 			// 18a06f4:	e7908006 	ldr	r8, [r0, r6]
// 			// 18a06f8:	e5980000 	ldr	r0, [r8]
// 			// 18a06fc:	eb13243c 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 			// 18a0700:	e1a05000 	mov	r5, r0
// 			// 18a0704:	e59f00a8 	ldr	r0, [pc, #168]	; 18a07b4 <dladdr@plt+0x15616d8>
// 			// 18a0708:	e3a01040 	mov	r1, #64	; 0x40
// 			// 18a070c:	e7907006 	ldr	r7, [r0, r6]
// 			// 18a0710:	e1a00005 	mov	r0, r5
// 			// 18a0714:	e5972000 	ldr	r2, [r7]
// 			// 18a0718:	ebb20d55 	bl	523c74 <dladdr@plt+0x1e4b98>
// 			// 18a071c:	e5845028 	str	r5, [r4, #40]	; 0x28 // fileLoadedDic
// 			fileLoadedDic = new Dictionary<int, FileLoadInfo>();
// 			// 18a0720:	e5980000 	ldr	r0, [r8]
// 			// 18a0724:	eb132432 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 			// 18a0728:	e5972000 	ldr	r2, [r7]
// 			// 18a072c:	e1a05000 	mov	r5, r0
// 			// 18a0730:	e3a01040 	mov	r1, #64	; 0x40
// 			// 18a0734:	ebb20d4e 	bl	523c74 <dladdr@plt+0x1e4b98>
// 			// 18a0738:	e59f0078 	ldr	r0, [pc, #120]	; 18a07b8 <dladdr@plt+0x15616dc> // 000359c4
// 			// 18a073c:	e59f1078 	ldr	r1, [pc, #120]	; 18a07bc <dladdr@plt+0x15616e0> // 0001444c
// 			// 18a0740:	e59f2078 	ldr	r2, [pc, #120]	; 18a07c0 <dladdr@plt+0x15616e4> // 0000a854
// 			// 18a0744:	e7900006 	ldr	r0, [r0, r6]
// 			// 18a0748:	e584502c 	str	r5, [r4, #44]	; 0x2c // fileLoadingDic
// 			fileLoadingDic = new Dictionary<int, FileLoadInfo>();
// 			// 18a074c:	e7911006 	ldr	r1, [r1, r6]
// 			// 18a0750:	e5900000 	ldr	r0, [r0]
// 			// 18a0754:	e59f3068 	ldr	r3, [pc, #104]	; 18a07c4 <dladdr@plt+0x15616e8>  // 00009860
// 			// 18a0758:	e5840010 	str	r0, [r4, #16] // bytesExtention
// 			bytesExtention = ".bytes";
// 			// 18a075c:	e7922006 	ldr	r2, [r2, r6]
// 			// 18a0760:	e5910000 	ldr	r0, [r1]
// 			// 18a0764:	e5840014 	str	r0, [r4, #20] // textureExtention
// 			textureExtention = ".png";
// 			// 18a0768:	e59f7058 	ldr	r7, [pc, #88]	; 18a07c8 <dladdr@plt+0x15616ec> // 00002914
// 			// 18a076c:	e7931006 	ldr	r1, [r3, r6]
// 			// 18a0770:	e5920000 	ldr	r0, [r2]
// 			// 18a0774:	e5840018 	str	r0, [r4, #24] // assetBundleExtention
// 			assetBundleExtention = ".xab";
// 			// 18a0778:	e5910000 	ldr	r0, [r1]
// 			// 18a077c:	e7972006 	ldr	r2, [r7, r6]
// 			// 18a0780:	e584001c 	str	r0, [r4, #28] // secureExtention
// 			secureExtention = ".dat";
// 			// 18a0784:	e3a00000 	mov	r0, #0
// 			// 18a0788:	e5c4000c 	strb	r0, [r4, #12] // isLoading
// 			isLoading = false;
// 			// 18a078c:	e5920000 	ldr	r0, [r2]
// 			// 18a0790:	e5840020 	str	r0, [r4, #32] // cpkExtention
// 			cpkExtention = ".cpk";
// 			// 18a0794:	e8bd8df0 	pop	{r4, r5, r6, r7, r8, sl, fp, pc}
// 			// 18a0798:	00a38a00 	adceq	r8, r3, r0, lsl #20
// 			// 18a079c:	000e2d0c 	andeq	r2, lr, ip, lsl #26
// 			// 18a07a0:	00a389e4 	adceq	r8, r3, r4, ror #19
// 			// 18a07a4:	00009aa4 	andeq	r9, r0, r4, lsr #21
// 			// 18a07a8:	00a389c0 	adceq	r8, r3, r0, asr #19
// 			// 18a07ac:	0001dc64 	andeq	sp, r1, r4, ror #24
// 			// 18a07b0:	00020128 	andeq	r0, r2, r8, lsr #2
// 			// 18a07b4:	00034b48 	andeq	r4, r3, r8, asr #22
// 			// 18a07b8:	000359c4 	andeq	r5, r3, r4, asr #19
// 			// 18a07bc:	0001444c 	andeq	r4, r1, ip, asr #8
// 			// 18a07c0:	0000a854 	andeq	sl, r0, r4, asr r8
// 			// 18a07c4:	00009860 	andeq	r9, r0, r0, ror #16
// 			// 18a07c8:	00002914 	andeq	r2, r0, r4, lsl r9
// 		}
// 		// [CompilerGeneratedAttribute] // 0x3E23B0
// 		// public bool get_isLoading(); // 0x18A080C
// 		// [CompilerGeneratedAttribute] // 0x3E23C0
// 		// public void set_isLoading(bool value); // 0x18A07FC
// 		// [CompilerGeneratedAttribute] // 0x3E23D0
// 		// public string get_bytesExtention(); // 0x18A0814
// 		// [CompilerGeneratedAttribute] // 0x3E23E0
// 		// public void set_bytesExtention(string value); // 0x18A07DC
// 		// [CompilerGeneratedAttribute] // 0x3E23F0
// 		// public string get_textureExtention(); // 0x18A081C
// 		// [CompilerGeneratedAttribute] // 0x3E2400
// 		// public void set_textureExtention(string value); // 0x18A07E4
// 		// [CompilerGeneratedAttribute] // 0x3E2410
// 		// public string get_assetBundleExtention(); // 0x18A0824
// 		// [CompilerGeneratedAttribute] // 0x3E2420
// 		// public void set_assetBundleExtention(string value); // 0x18A07EC
// 		// [CompilerGeneratedAttribute] // 0x3E2430
// 		// public string get_secureExtention(); // 0x18A082C
// 		// [CompilerGeneratedAttribute] // 0x3E2440
// 		// public void set_secureExtention(string value); // 0x18A07F4
// 		// [CompilerGeneratedAttribute] // 0x3E2450
// 		// public string get_cpkExtention(); // 0x18A0834
// 		// [CompilerGeneratedAttribute] // 0x3E2460
// 		// public void set_cpkExtention(string value); // 0x18A0804
// 		// [CompilerGeneratedAttribute] // 0x3E2470
// 		// public CriFsBinder get_binder(); // 0x18A083C
// 		// [CompilerGeneratedAttribute] // 0x3E2480
// 		// public void set_binder(CriFsBinder value); // 0x18A0844
// 		// [CompilerGeneratedAttribute] // 0x3E2490
// 		// private Dictionary`2<int, FileLoadInfo> get_fileLoadedDic(); // 0x18A084C
// 		// [CompilerGeneratedAttribute] // 0x3E24A0
// 		// private void set_fileLoadedDic(Dictionary`2<int, FileLoadInfo> value); // 0x18A07CC
// 		// [CompilerGeneratedAttribute] // 0x3E24B0
// 		// private Dictionary`2<int, FileLoadInfo> get_fileLoadingDic(); // 0x18A0854
// 		// [CompilerGeneratedAttribute] // 0x3E24C0
// 		// private void set_fileLoadingDic(Dictionary`2<int, FileLoadInfo> value); // 0x18A07D4
// 		public void Dispose() // 0x18A085C
// 		{
// 			// 18a085c:	e92d4c70 	push	{r4, r5, r6, sl, fp, lr}
// 			// 18a0860:	e28db010 	add	fp, sp, #16
// 			// 18a0864:	e1a04000 	mov	r4, r0
// 			// 18a0868:	e59f00b4 	ldr	r0, [pc, #180]	; 18a0924 <dladdr@plt+0x1561848>
// 			// 18a086c:	e59f50b4 	ldr	r5, [pc, #180]	; 18a0928 <dladdr@plt+0x156184c>
// 			// 18a0870:	e08f0000 	add	r0, pc, r0
// 			// 18a0874:	e0850000 	add	r0, r5, r0
// 			// 18a0878:	e5d000e1 	ldrb	r0, [r0, #225]	; 0xe1
// 			// 18a087c:	e3500000 	cmp	r0, #0
// 			// 18a0880:	1a000008 	bne	18a08a8 <dladdr@plt+0x15617cc>
// 			// 18a0884:	e59f00a0 	ldr	r0, [pc, #160]	; 18a092c <dladdr@plt+0x1561850>
// 			// 18a0888:	e59f10a0 	ldr	r1, [pc, #160]	; 18a0930 <dladdr@plt+0x1561854>
// 			// 18a088c:	e08f6000 	add	r6, pc, r0
// 			// 18a0890:	e7910006 	ldr	r0, [r1, r6]
// 			// 18a0894:	e5900000 	ldr	r0, [r0]
// 			// 18a0898:	eb125338 	bl	1d35580 <_ZNSt6vectorIjSaIjEE17_M_default_appendEj+0x2ab4>
// 			// 18a089c:	e0850006 	add	r0, r5, r6
// 			// 18a08a0:	e3a01001 	mov	r1, #1
// 			// 18a08a4:	e5c010e1 	strb	r1, [r0, #225]	; 0xe1
// 			// 18a08a8:	e5940028 	ldr	r0, [r4, #40]	; 0x28 // fileLoadedDic
// 			// 18a08ac:	e3500000 	cmp	r0, #0
// 			// 18a08b0:	0a000018 	beq	18a0918 <dladdr@plt+0x156183c>
// 			// 18a08b4:	e59f1078 	ldr	r1, [pc, #120]	; 18a0934 <dladdr@plt+0x1561858>
// 			// 18a08b8:	e59f5078 	ldr	r5, [pc, #120]	; 18a0938 <dladdr@plt+0x156185c>
// 			// 18a08bc:	e08f1001 	add	r1, pc, r1
// 			// 18a08c0:	e7951001 	ldr	r1, [r5, r1]
// 			// 18a08c4:	e5911000 	ldr	r1, [r1]
// 			// 18a08c8:	ebb2157c 	bl	525ec0 <dladdr@plt+0x1e6de4>
// 			// 18a08cc:	e3a06000 	mov	r6, #0
// 			// 18a08d0:	e5846028 	str	r6, [r4, #40]	; 0x28
// 			// 18a08d4:	e594002c 	ldr	r0, [r4, #44]	; 0x2c // fileLoadingDic
// 			// 18a08d8:	e3500000 	cmp	r0, #0
// 			// 18a08dc:	0a00000d 	beq	18a0918 <dladdr@plt+0x156183c>
// 			// 18a08e0:	e59f1054 	ldr	r1, [pc, #84]	; 18a093c <dladdr@plt+0x1561860>
// 			// 18a08e4:	e08f1001 	add	r1, pc, r1
// 			// 18a08e8:	e7951001 	ldr	r1, [r5, r1]
// 			// 18a08ec:	e5911000 	ldr	r1, [r1]
// 			// 18a08f0:	ebb21572 	bl	525ec0 <dladdr@plt+0x1e6de4>
// 			// 18a08f4:	e584602c 	str	r6, [r4, #44]	; 0x2c
// 			// 18a08f8:	e5940024 	ldr	r0, [r4, #36]	; 0x24
// 			// 18a08fc:	e3500000 	cmp	r0, #0
// 			// 18a0900:	08bd8c70 	popeq	{r4, r5, r6, sl, fp, pc}
// 			// 18a0904:	e3a01000 	mov	r1, #0
// 			// 18a0908:	e3a05000 	mov	r5, #0
// 			// 18a090c:	eb09bc49 	bl	1b0fa38 <dladdr@plt+0x17d095c> // CriFsBinder -> 	public void Dispose(); // 0x1B0FA38
// 			// 18a0910:	e5845024 	str	r5, [r4, #36]	; 0x24
// 			// 18a0914:	e8bd8c70 	pop	{r4, r5, r6, sl, fp, pc}
// 			// 18a0918:	eb130ac3 	bl	1d6342c <_ZNSs12_S_constructIN9__gnu_cxx17__normal_iteratorIPcSt6vectorIcSaIcEEEEEES2_T_S7_RKS4_St20forward_iterator_tag+0x7118>
// 			// 18a091c:	e1a0e00f 	mov	lr, pc
// 			// 18a0920:	eaff75dd 	b	187e09c <dladdr@plt+0x153efc0> // <ProcMessageCoroutine>c__Iterator691 -> 	internal void <>m__153B(IiconTexture tex); // 0x187E09C
// 			// 18a0924:	00a3882c 	adceq	r8, r3, ip, lsr #16
// 			// 18a0928:	000e2d0c 	andeq	r2, lr, ip, lsl #26
// 			// 18a092c:	00a38810 	adceq	r8, r3, r0, lsl r8
// 			// 18a0930:	0001989c 	muleq	r1, ip, r8
// 			// 18a0934:	00a387e0 	adceq	r8, r3, r0, ror #15
// 			// 18a0938:	00017394 	muleq	r1, r4, r3
// 			// 18a093c:	00a387b8 	strhteq	r8, [r3], r8
// 		}
// 		private void Awake() // 0x18A0940
// 		{
// 			// 18a0940:	e12fff1e 	bx	lr
// 		}
// 		public void Update() // 0x18A0944
// 		{
// 			// Caller : 0x1cc324c in SystemManager -> 	private void Update(); // 0x1CC302C
// 			// 18a0944:	e92d4c70 	push	{r4, r5, r6, sl, fp, lr}
// 			// 18a0948:	e28db010 	add	fp, sp, #16
// 			// 18a094c:	e1a04000 	mov	r4, r0
// 			// 18a0950:	e5d4000c 	ldrb	r0, [r4, #12]
// 			// 18a0954:	e3500000 	cmp	r0, #0
// 			// 18a0958:	08bd8c70 	popeq	{r4, r5, r6, sl, fp, pc}
// 			// 18a095c:	e59f007c 	ldr	r0, [pc, #124]	; 18a09e0 <dladdr@plt+0x1561904>
// 			// 18a0960:	e59f507c 	ldr	r5, [pc, #124]	; 18a09e4 <dladdr@plt+0x1561908>
// 			// 18a0964:	e08f0000 	add	r0, pc, r0
// 			// 18a0968:	e0850000 	add	r0, r5, r0
// 			// 18a096c:	e5d000ce 	ldrb	r0, [r0, #206]	; 0xce
// 			// 18a0970:	e3500000 	cmp	r0, #0
// 			// 18a0974:	1a000008 	bne	18a099c <dladdr@plt+0x15618c0>
// 			// 18a0978:	e59f0068 	ldr	r0, [pc, #104]	; 18a09e8 <dladdr@plt+0x156190c>
// 			// 18a097c:	e59f1068 	ldr	r1, [pc, #104]	; 18a09ec <dladdr@plt+0x1561910>
// 			// 18a0980:	e08f6000 	add	r6, pc, r0
// 			// 18a0984:	e7910006 	ldr	r0, [r1, r6]
// 			// 18a0988:	e5900000 	ldr	r0, [r0]
// 			// 18a098c:	eb1252fb 	bl	1d35580 <_ZNSt6vectorIjSaIjEE17_M_default_appendEj+0x2ab4>
// 			// 18a0990:	e0850006 	add	r0, r5, r6
// 			// 18a0994:	e3a01001 	mov	r1, #1
// 			// 18a0998:	e5c010ce 	strb	r1, [r0, #206]	; 0xce
// 			// 18a099c:	e59f004c 	ldr	r0, [pc, #76]	; 18a09f0 <dladdr@plt+0x1561914>
// 			// 18a09a0:	e59f104c 	ldr	r1, [pc, #76]	; 18a09f4 <dladdr@plt+0x1561918>
// 			// 18a09a4:	e08f0000 	add	r0, pc, r0
// 			// 18a09a8:	e7910000 	ldr	r0, [r1, r0]
// 			// 18a09ac:	e5900000 	ldr	r0, [r0]
// 			// 18a09b0:	e5900050 	ldr	r0, [r0, #80]	; 0x50
// 			// 18a09b4:	e5900000 	ldr	r0, [r0]
// 			// 18a09b8:	e3500000 	cmp	r0, #0
// 			// 18a09bc:	0a000004 	beq	18a09d4 <dladdr@plt+0x15618f8>
// 			// 18a09c0:	e5900040 	ldr	r0, [r0, #64]	; 0x40
// 			// 18a09c4:	e3500001 	cmp	r0, #1
// 			// 18a09c8:	13000000 	movwne	r0, #0
// 			// 18a09cc:	e5c4000c 	strb	r0, [r4, #12] // false si qqch passe a 0
// 			// isLoading = ??; un static ou extern ?
// 			//Debug.Log("TODO isLoading");
// 			// 18a09d0:	e8bd8c70 	pop	{r4, r5, r6, sl, fp, pc}
// 			// 18a09d4:	eb130a94 	bl	1d6342c <_ZNSs12_S_constructIN9__gnu_cxx17__normal_iteratorIPcSt6vectorIcSaIcEEEEEES2_T_S7_RKS4_St20forward_iterator_tag+0x7118>
// 			// 18a09d8:	e1a0e00f 	mov	lr, pc
// 			// 18a09dc:	eaff75ae 	b	187e09c <dladdr@plt+0x153efc0> // <ProcMessageCoroutine>c__Iterator691 -> 	internal void <>m__153B(IiconTexture tex); // 0x187E09C
// 			// 18a09e0:	00a38738 	adceq	r8, r3, r8, lsr r7
// 			// 18a09e4:	000e2d0c 	andeq	r2, lr, ip, lsl #26
// 			// 18a09e8:	00a3871c 	adceq	r8, r3, ip, lsl r7
// 			// 18a09ec:	0001b43c 	andeq	fp, r1, ip, lsr r4
// 			// 18a09f0:	00a386f8 	strdeq	r8, [r3], r8	; <UNPREDICTABLE>
// 			// 18a09f4:	0003cac0 	andeq	ip, r3, r0, asr #21
// 		}
// 		// public void UnloadAll(); // 0x18A09F8
// 		// public bool Unload(string path); // 0x18A0DBC
// 		// public bool Unload(int pathHashCode); // 0x18A0C6C
// 		// public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded); // 0x18A0E00
// 		// public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, Dictionary`2<string, string> args, int argValue, bool loadedDispose); // 0x18A0E2C
// 		// public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, Dictionary`2<string, string> args, int argValue); // 0x18A1118
// 		public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, FileLoadedPostProcess failed, Dictionary<string, string> args, int argValue, bool loadedDispose) // 0x18A0E5C
// 		{
// 			Debug.Log("FileLoader request: "+path);
// 			// Caller : 0x18a0e20 in FileLoader -> 	public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded); // 0x18A0E00
// 			// Caller : 0x18a0e50 in FileLoader -> 	public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, Dictionary`2<string, string> args, int argValue, bool loadedDispose); // 0x18A0E2C
// 			// Caller : 0x18a1138 in FileLoader -> 	public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, Dictionary`2<string, string> args, int argValue); // 0x18A1118
// 			// Caller : 0x18a17a8 in FileLoader -> 	public int Load(string path, string withoutPlarformPath, FileLoadedPostProcess callback); // 0x18A1780
// 			// Caller : 0x18a17f0 in FileLoader -> 	public int Load(string path, string withoutPlarformPath, FileLoadedPostProcess callback, Dictionary`2<string, string> args, int argValue); // 0x18A17C4
// 			// Caller : 0x19d10cc in AssetBundleManager -> 	protected static bool LoadAssetBundleInternal(string assetBundleName); // 0x19D0D58
// 			// 18a0e5c:	e92d4ff0 	push	{r4, r5, r6, r7, r8, r9, sl, fp, lr}
// 			// 18a0e60:	e28db01c 	add	fp, sp, #28
// 			// 18a0e64:	e24dd014 	sub	sp, sp, #20
// 			// 18a0e68:	e1a09000 	mov	r9, r0
// 			// 18a0e6c:	e59f0258 	ldr	r0, [pc, #600]	; 18a10cc <dladdr@plt+0x1561ff0>
// 			// 18a0e70:	e59f7258 	ldr	r7, [pc, #600]	; 18a10d0 <dladdr@plt+0x1561ff4>
// 			// 18a0e74:	e1a04002 	mov	r4, r2
// 			// 18a0e78:	e08f0000 	add	r0, pc, r0
// 			// 18a0e7c:	e1a0a001 	mov	sl, r1
// 			// 18a0e80:	e0870000 	add	r0, r7, r0
// 			// 18a0e84:	e58d3010 	str	r3, [sp, #16]
// 			// 18a0e88:	e5d000e4 	ldrb	r0, [r0, #228]	; 0xe4
// 			// 18a0e8c:	e3500000 	cmp	r0, #0
// 			// 18a0e90:	1a000008 	bne	18a0eb8 <dladdr@plt+0x1561ddc>
// 			// 18a0e94:	e59f0238 	ldr	r0, [pc, #568]	; 18a10d4 <dladdr@plt+0x1561ff8>
// 			// 18a0e98:	e59f1238 	ldr	r1, [pc, #568]	; 18a10d8 <dladdr@plt+0x1561ffc>
// 			// 18a0e9c:	e08f5000 	add	r5, pc, r0
// 			// 18a0ea0:	e7910005 	ldr	r0, [r1, r5]
// 			// 18a0ea4:	e5900000 	ldr	r0, [r0]
// 			// 18a0ea8:	eb1251b4 	bl	1d35580 <_ZNSt6vectorIjSaIjEE17_M_default_appendEj+0x2ab4>
// 			// 18a0eac:	e0870005 	add	r0, r7, r5
// 			// 18a0eb0:	e3a01001 	mov	r1, #1
// 			// 18a0eb4:	e5c010e4 	strb	r1, [r0, #228]	; 0xe4
// 			// 18a0eb8:	e35a0000 	cmp	sl, #0
// 			// 18a0ebc:	0a00007f 	beq	18a10c0 <dladdr@plt+0x1561fe4>
// 			// 18a0ec0:	e1a0000a 	mov	r0, sl
// 			// 18a0ec4:	e3a01000 	mov	r1, #0
// 			// 18a0ec8:	ebcd40bf 	bl	bf11cc <dladdr@plt+0x8b20f0> // String -> 	public override int GetHashCode(); // 0xBF11CC
// 			// 18a0ecc:	e1a08000 	mov	r8, r0
// 			int pathHash = path.GetHashCode();
// 			// 18a0ed0:	e5990028 	ldr	r0, [r9, #40]	; 0x28 // fileLoadedDic
// 			// 18a0ed4:	e3500000 	cmp	r0, #0
// 			// 18a0ed8:	0a000078 	beq	18a10c0 <dladdr@plt+0x1561fe4>
// 			// 18a0edc:	e59f11f8 	ldr	r1, [pc, #504]	; 18a10dc <dladdr@plt+0x1562000>
// 			// 18a0ee0:	e59f51f8 	ldr	r5, [pc, #504]	; 18a10e0 <dladdr@plt+0x1562004>
// 			// 18a0ee4:	e08f1001 	add	r1, pc, r1
// 			// 18a0ee8:	e7951001 	ldr	r1, [r5, r1]
// 			// 18a0eec:	e5912000 	ldr	r2, [r1]
// 			// 18a0ef0:	e1a01008 	mov	r1, r8
// 			// 18a0ef4:	ebb21424 	bl	525f8c <dladdr@plt+0x1e6eb0>
// 			// 18a0ef8:	e3500001 	cmp	r0, #1
// 			// 18a0efc:	1a00000b 	bne	18a0f30 <dladdr@plt+0x1561e54>
// 			FileLoadInfo fileinfo = null;
// 			if(fileLoadedDic.ContainsKey(pathHash))
// 			{
// 				// 18a0f00:	e5990028 	ldr	r0, [r9, #40]	; 0x28 // fileLoadedDic
// 				// 18a0f04:	e3500000 	cmp	r0, #0
// 				// 18a0f08:	0a00006c 	beq	18a10c0 <dladdr@plt+0x1561fe4>
// 				// 18a0f0c:	e59f11dc 	ldr	r1, [pc, #476]	; 18a10f0 <dladdr@plt+0x1562014>
// 				// 18a0f10:	e59f21d4 	ldr	r2, [pc, #468]	; 18a10ec <dladdr@plt+0x1562010>
// 				// 18a0f14:	e08f1001 	add	r1, pc, r1
// 				// 18a0f18:	e7921001 	ldr	r1, [r2, r1]
// 				// 18a0f1c:	e5912000 	ldr	r2, [r1]
// 				// 18a0f20:	e1a01008 	mov	r1, r8
// 				// 18a0f24:	ebb20e14 	bl	52477c <dladdr@plt+0x1e56a0>
// 				// 18a0f28:	e1a05000 	mov	r5, r0
// 				fileinfo = fileLoadedDic[pathHash];
// 				// 18a0f2c:	ea00001e 	b	18a0fac <dladdr@plt+0x1561ed0>
// 			}
// 			else
// 			{
// 				// 18a0f30:	e599002c 	ldr	r0, [r9, #44]	; 0x2c // fileLoadingDic
// 				// 18a0f34:	e3500000 	cmp	r0, #0
// 				// 18a0f38:	0a000060 	beq	18a10c0 <dladdr@plt+0x1561fe4>
// 				// 18a0f3c:	e59f11a0 	ldr	r1, [pc, #416]	; 18a10e4 <dladdr@plt+0x1562008>
// 				// 18a0f40:	e08f1001 	add	r1, pc, r1
// 				// 18a0f44:	e7951001 	ldr	r1, [r5, r1]
// 				// 18a0f48:	e5912000 	ldr	r2, [r1]
// 				// 18a0f4c:	e1a01008 	mov	r1, r8
// 				// 18a0f50:	ebb2140d 	bl	525f8c <dladdr@plt+0x1e6eb0>
// 				// 18a0f54:	e3a05000 	mov	r5, #0
// 				// 18a0f58:	e3500001 	cmp	r0, #1
// 				// 18a0f5c:	1a000012 	bne	18a0fac <dladdr@plt+0x1561ed0>
// 				if(fileLoadingDic.ContainsKey(pathHash))
// 				{
// 					// 18a0f60:	e599002c 	ldr	r0, [r9, #44]	; 0x2c // fileLoadingDic
// 					// 18a0f64:	e3500000 	cmp	r0, #0
// 					// 18a0f68:	0a000054 	beq	18a10c0 <dladdr@plt+0x1561fe4>
// 					// 18a0f6c:	e59f1174 	ldr	r1, [pc, #372]	; 18a10e8 <dladdr@plt+0x156200c>
// 					// 18a0f70:	e59f2174 	ldr	r2, [pc, #372]	; 18a10ec <dladdr@plt+0x1562010>
// 					// 18a0f74:	e08f1001 	add	r1, pc, r1
// 					// 18a0f78:	e7921001 	ldr	r1, [r2, r1]
// 					// 18a0f7c:	e5912000 	ldr	r2, [r1]
// 					// 18a0f80:	e1a01008 	mov	r1, r8
// 					// 18a0f84:	ebb20dfc 	bl	52477c <dladdr@plt+0x1e56a0>
// 					// 18a0f88:	e1a05000 	mov	r5, r0
// 					fileinfo = fileLoadingDic[pathHash];
// 					// 18a0f8c:	e3550000 	cmp	r5, #0
// 					// 18a0f90:	1595001c 	ldrne	r0, [r5, #28]
// 					// 18a0f94:	13500000 	cmpne	r0, #0
// 					// 18a0f98:	0a000048 	beq	18a10c0 <dladdr@plt+0x1561fe4>
// 					// 18a0f9c:	e3a01000 	mov	r1, #0
// 					// 18a0fa0:	ebe9e988 	bl	131b5c8 <dladdr@plt+0xfdc4ec> // LBHFILLFAGA -> 	public bool NPFACLDLOCJ(); // 0x131B5C8
// 					// 18a0fa4:	e3500000 	cmp	r0, #0
// 					// 18a0fa8:	0a000040 	beq	18a10b0 <dladdr@plt+0x1561fd4>
// 					if(fileLoadingDic[pathHash].request.NPFACLDLOCJ())
// 					{
// 						return fileLoadingDic[pathHash].pathHashCode;
// 					}
// 				}
// 			}
// 			// 18a0fac:	e59b1010 	ldr	r1, [fp, #16]
// 			// 18a0fb0:	e1a02004 	mov	r2, r4
// 			// 18a0fb4:	e59b300c 	ldr	r3, [fp, #12]
// 			// 18a0fb8:	e59b0014 	ldr	r0, [fp, #20]
// 			// 18a0fbc:	e88d0022 	stm	sp, {r1, r5}
// 			// 18a0fc0:	e1a0100a 	mov	r1, sl
// 			// 18a0fc4:	e58d0008 	str	r0, [sp, #8]
// 			// 18a0fc8:	e1a00009 	mov	r0, r9
// 			// 18a0fcc:	eb00005c 	bl	18a1144 <dladdr@plt+0x1562068> // FileLoader -> 	private LBHFILLFAGA CreateFileRequest(string path, string withoutPlarformPath, Dictionary`2<string, string> args, int argValue, FileLoadInfo fi, bool loadedDispose); // 0x18A1144
// 			LBHFILLFAGA request = CreateFileRequest(path, withoutPlarformPath, args, argValue, fileinfo, loadedDispose);
// 			// 18a0fd0:	e1a06000 	mov	r6, r0
// 			// 18a0fd4:	e59f0118 	ldr	r0, [pc, #280]	; 18a10f4 <dladdr@plt+0x1562018>
// 			// 18a0fd8:	e1a04007 	mov	r4, r7
// 			// 18a0fdc:	e08f0000 	add	r0, pc, r0
// 			// 18a0fe0:	e0840000 	add	r0, r4, r0
// 			// 18a0fe4:	e5d000ce 	ldrb	r0, [r0, #206]	; 0xce
// 			// 18a0fe8:	e3500000 	cmp	r0, #0
// 			// 18a0fec:	1a000008 	bne	18a1014 <dladdr@plt+0x1561f38>
// 			// 18a0ff0:	e59f0100 	ldr	r0, [pc, #256]	; 18a10f8 <dladdr@plt+0x156201c>
// 			// 18a0ff4:	e59f1100 	ldr	r1, [pc, #256]	; 18a10fc <dladdr@plt+0x1562020>
// 			// 18a0ff8:	e08f7000 	add	r7, pc, r0
// 			// 18a0ffc:	e7910007 	ldr	r0, [r1, r7]
// 			// 18a1000:	e5900000 	ldr	r0, [r0]
// 			// 18a1004:	eb12515d 	bl	1d35580 <_ZNSt6vectorIjSaIjEE17_M_default_appendEj+0x2ab4>
// 			// 18a1008:	e0840007 	add	r0, r4, r7
// 			// 18a100c:	e3a01001 	mov	r1, #1
// 			// 18a1010:	e5c010ce 	strb	r1, [r0, #206]	; 0xce
// 			// 18a1014:	e59f00e4 	ldr	r0, [pc, #228]	; 18a1100 <dladdr@plt+0x1562024>
// 			// 18a1018:	e59f10e4 	ldr	r1, [pc, #228]	; 18a1104 <dladdr@plt+0x1562028>
// 			// 18a101c:	e08f0000 	add	r0, pc, r0
// 			// 18a1020:	e7910000 	ldr	r0, [r1, r0]
// 			// 18a1024:	e5900000 	ldr	r0, [r0]
// 			// 18a1028:	e5900050 	ldr	r0, [r0, #80]	; 0x50
// 			// 18a102c:	e5900000 	ldr	r0, [r0]
// 			// 18a1030:	e3500000 	cmp	r0, #0
// 			// 18a1034:	0a000021 	beq	18a10c0 <dladdr@plt+0x1561fe4>
// 			// 18a1038:	e1a01006 	mov	r1, r6
// 			// 18a103c:	ebfff6b5 	bl	189eb18 <dladdr@plt+0x155fa3c> // CriFileRequestManager -> 	public void ELFMKCOKNHK(LBHFILLFAGA COJNCNGHIJC); // 0x189EB18 << ajout dans list
// 			//CriFileRequestManager.
// 			//Debug.Log("TODO Load file or create request inutile?");
// 			// 18a1040:	e3550000 	cmp	r5, #0
// 			// 18a1044:	1a00000c 	bne	18a107c <dladdr@plt+0x1561fa0>
// 			if(fileinfo == null)
// 			{
// 				// 18a1048:	e59f00b8 	ldr	r0, [pc, #184]	; 18a1108 <dladdr@plt+0x156202c>
// 				// 18a104c:	e59f10b8 	ldr	r1, [pc, #184]	; 18a110c <dladdr@plt+0x1562030>
// 				// 18a1050:	e08f0000 	add	r0, pc, r0
// 				// 18a1054:	e59b4008 	ldr	r4, [fp, #8]
// 				// 18a1058:	e7910000 	ldr	r0, [r1, r0]
// 				// 18a105c:	e5900000 	ldr	r0, [r0]
// 				// 18a1060:	eb1321e3 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				// 18a1064:	e59d2010 	ldr	r2, [sp, #16]
// 				// 18a1068:	e1a05000 	mov	r5, r0
// 				// 18a106c:	e1a0100a 	mov	r1, sl
// 				// 18a1070:	e1a03004 	mov	r3, r4
// 				// 18a1074:	e58d6000 	str	r6, [sp]
// 				// 18a1078:	eb000180 	bl	18a1680 <dladdr@plt+0x15625a4> // FileLoadInfo -> 	public void .ctor(string path, FileLoadedPostProcess succeeded, FileLoadedPostProcess failed, LBHFILLFAGA req); // 0x18A1680
// 				fileinfo = new FileLoadInfo(path, succeeded, failed, request);
// 			}
// 			// 18a107c:	e599002c 	ldr	r0, [r9, #44]	; 0x2c // fileLoadingDic
// 			// 18a1080:	e3500000 	cmp	r0, #0
// 			// 18a1084:	0a00000d 	beq	18a10c0 <dladdr@plt+0x1561fe4>
// 			// 18a1088:	e59f1080 	ldr	r1, [pc, #128]	; 18a1110 <dladdr@plt+0x1562034>
// 			// 18a108c:	e59f2080 	ldr	r2, [pc, #128]	; 18a1114 <dladdr@plt+0x1562038>
// 			// 18a1090:	e08f1001 	add	r1, pc, r1
// 			// 18a1094:	e7921001 	ldr	r1, [r2, r1]
// 			// 18a1098:	e1a02005 	mov	r2, r5
// 			// 18a109c:	e5913000 	ldr	r3, [r1]
// 			// 18a10a0:	e1a01008 	mov	r1, r8
// 			// 18a10a4:	ebb21259 	bl	525a10 <dladdr@plt+0x1e6934>
// 			fileLoadingDic[pathHash] = fileinfo;
// 			// 18a10a8:	e3550000 	cmp	r5, #0
// 			// 18a10ac:	0a000003 	beq	18a10c0 <dladdr@plt+0x1561fe4>

// 			// 18a10b0:	e285000c 	add	r0, r5, #12
// 			// 18a10b4:	e5900000 	ldr	r0, [r0]
// 			return fileinfo.pathHashCode;
// 			// 18a10b8:	e24bd01c 	sub	sp, fp, #28
// 			// 18a10bc:	e8bd8ff0 	pop	{r4, r5, r6, r7, r8, r9, sl, fp, pc}
// 			// 18a10c0:	eb1308d9 	bl	1d6342c <_ZNSs12_S_constructIN9__gnu_cxx17__normal_iteratorIPcSt6vectorIcSaIcEEEEEES2_T_S7_RKS4_St20forward_iterator_tag+0x7118>
// 			// 18a10c4:	e1a0e00f 	mov	lr, pc
// 			// 18a10c8:	eaff73f3 	b	187e09c <dladdr@plt+0x153efc0> // <ProcMessageCoroutine>c__Iterator691 -> 	internal void <>m__153B(IiconTexture tex); // 0x187E09C
// 			// 18a10cc:	00a38224 	adceq	r8, r3, r4, lsr #4
// 			// 18a10d0:	000e2d0c 	andeq	r2, lr, ip, lsl #26
// 			// 18a10d4:	00a38200 	adceq	r8, r3, r0, lsl #4
// 			// 18a10d8:	0000aff4 	strdeq	sl, [r0], -r4
// 			// 18a10dc:	00a381b8 	strhteq	r8, [r3], r8
// 			// 18a10e0:	00049414 	andeq	r9, r4, r4, lsl r4
// 			// 18a10e4:	00a3815c 	adceq	r8, r3, ip, asr r1
// 			// 18a10e8:	00a38128 	adceq	r8, r3, r8, lsr #2
// 			// 18a10ec:	0001c390 	muleq	r1, r0, r3
// 			// 18a10f0:	00a38188 	adceq	r8, r3, r8, lsl #3
// 			// 18a10f4:	00a380c0 	adceq	r8, r3, r0, asr #1
// 			// 18a10f8:	00a380a4 	adceq	r8, r3, r4, lsr #1
// 			// 18a10fc:	0001b43c 	andeq	fp, r1, ip, lsr r4
// 			// 18a1100:	00a38080 	adceq	r8, r3, r0, lsl #1
// 			// 18a1104:	0003cac0 	andeq	ip, r3, r0, asr #21
// 			// 18a1108:	00a3804c 	adceq	r8, r3, ip, asr #32
// 			// 18a110c:	00032490 	muleq	r3, r0, r4
// 			// 18a1110:	00a3800c 	adceq	r8, r3, ip
// 			// 18a1114:	000166e4 	andeq	r6, r1, r4, ror #13
// 		}
// 		public void Load() // 0x18A16E4
// 		{
// 			// Caller : 0x136b7e4 in AdvScriptData -> 	public void Load(int id, optional Action onFinish); // 0x136B560
// 			// Caller : 0x17fc568 in <LoadScoreTarFile>c__IteratorCA -> 	public bool MoveNext(); // 0x17FC2BC
// 			// Caller : 0x18a17b4 in FileLoader -> 	public int Load(string path, string withoutPlarformPath, FileLoadedPostProcess callback); // 0x18A1780
// 			// Caller : 0x18a17fc in FileLoader -> 	public int Load(string path, string withoutPlarformPath, FileLoadedPostProcess callback, Dictionary`2<string, string> args, int argValue); // 0x18A17C4
// 			// Caller : 0x19d10d8 in AssetBundleManager -> 	protected static bool LoadAssetBundleInternal(string assetBundleName); // 0x19D0D58
// 			// 18a16e4:	e92d4c70 	push	{r4, r5, r6, sl, fp, lr}
// 			// 18a16e8:	e28db010 	add	fp, sp, #16
// 			// 18a16ec:	e59f1074 	ldr	r1, [pc, #116]	; 18a1768 <dladdr@plt+0x156268c>
// 			// 18a16f0:	e3a05001 	mov	r5, #1
// 			// 18a16f4:	e59f4070 	ldr	r4, [pc, #112]	; 18a176c <dladdr@plt+0x1562690>
// 			// 18a16f8:	e5c0500c 	strb	r5, [r0, #12]
// 			isLoading = true;
// 			// 18a16fc:	e08f0001 	add	r0, pc, r1
// 			// 18a1700:	e0840000 	add	r0, r4, r0
// 			// 18a1704:	e5d000ce 	ldrb	r0, [r0, #206]	; 0xce
// 			// 18a1708:	e3500000 	cmp	r0, #0
// 			// 18a170c:	1a000007 	bne	18a1730 <dladdr@plt+0x1562654>
// 			// 18a1710:	e59f0058 	ldr	r0, [pc, #88]	; 18a1770 <dladdr@plt+0x1562694>
// 			// 18a1714:	e59f1058 	ldr	r1, [pc, #88]	; 18a1774 <dladdr@plt+0x1562698>
// 			// 18a1718:	e08f6000 	add	r6, pc, r0
// 			// 18a171c:	e7910006 	ldr	r0, [r1, r6]
// 			// 18a1720:	e5900000 	ldr	r0, [r0]
// 			// 18a1724:	eb124f95 	bl	1d35580 <_ZNSt6vectorIjSaIjEE17_M_default_appendEj+0x2ab4>
// 			// 18a1728:	e0840006 	add	r0, r4, r6
// 			// 18a172c:	e5c050ce 	strb	r5, [r0, #206]	; 0xce
// 			// 18a1730:	e59f0040 	ldr	r0, [pc, #64]	; 18a1778 <dladdr@plt+0x156269c>
// 			// 18a1734:	e59f1040 	ldr	r1, [pc, #64]	; 18a177c <dladdr@plt+0x15626a0>
// 			// 18a1738:	e08f0000 	add	r0, pc, r0
// 			// 18a173c:	e7910000 	ldr	r0, [r1, r0]
// 			// 18a1740:	e5900000 	ldr	r0, [r0]
// 			// 18a1744:	e5900050 	ldr	r0, [r0, #80]	; 0x50
// 			// 18a1748:	e5900000 	ldr	r0, [r0]
// 			// 18a174c:	e3500000 	cmp	r0, #0
// 			// 18a1750:	0a000001 	beq	18a175c <dladdr@plt+0x1562680>
// 			// 18a1754:	e8bd4c70 	pop	{r4, r5, r6, sl, fp, lr}
// 			// 18a1758:	eafff530 	b	189ec20 <dladdr@plt+0x155fb44> // CriFileRequestManager -> 	public void LFBFKKKCMNM(); // 0x189EC20
// 			//Debug.Log("Faire load");
// 			List<FileLoadInfo> fileLoadingDiccpy = new List<FileLoadInfo>();
// 			foreach(var id in fileLoadingDic)
// 			{
// 				fileLoadingDiccpy.Add(id.Value);
// 			}
// 			foreach(var id in fileLoadingDiccpy)
// 			{
// 				if(id.request.IMGIFJHHEED_resultObject.assetBundle != null)
// 					continue;
// 				if(id.request.LHMDABPNDDH != LBHFILLFAGA.PLINNKMECEF.NFFGMBBNNPH) // none state
// 					continue;
// 				StartCoroutine(LoadAsync(id));
// 			}
// 			//fileLoadingDic.Clear();
// 			// 18a175c:	eb130732 	bl	1d6342c <_ZNSs12_S_constructIN9__gnu_cxx17__normal_iteratorIPcSt6vectorIcSaIcEEEEEES2_T_S7_RKS4_St20forward_iterator_tag+0x7118>
// 			// 18a1760:	e1a0e00f 	mov	lr, pc
// 			// 18a1764:	eaff724c 	b	187e09c <dladdr@plt+0x153efc0> // <ProcMessageCoroutine>c__Iterator691 -> 	internal void <>m__153B(IiconTexture tex); // 0x187E09C
// 			// 18a1768:	00a379a0 	adceq	r7, r3, r0, lsr #19
// 			// 18a176c:	000e2d0c 	andeq	r2, lr, ip, lsl #26
// 			// 18a1770:	00a37984 	adceq	r7, r3, r4, lsl #19
// 			// 18a1774:	0001b43c 	andeq	fp, r1, ip, lsr r4
// 			// 18a1778:	00a37964 	adceq	r7, r3, r4, ror #18
// 			// 18a177c:	0003cac0 	andeq	ip, r3, r0, asr #21
// 		}
// 		private IEnumerator LoadAsync(FileLoadInfo id)
// 		{
// 			LoadAssetBundle.BundleInfoLoad info = new LoadAssetBundle.BundleInfoLoad();
// 			id.request.ODJCMJBNDOK();
// 			Debug.Log("FlieLoader request "+id.path);
// 			yield return LoadAssetBundle.FindAndLoadAsync(id.path, info);
// 			AssetBundle asset = info.bundle;
// 			if(asset)
// 			{
// 				id.request.IMGIFJHHEED_resultObject.assetBundle = asset;
// 				id.request.MLMEOLAEJEL();
// 			}
// 			else
// 			{
// 				Debug.LogError("TODO error");
// 				fileLoadingDic.Remove(id.pathHashCode);
// 				id.failedCallback(null);
// 			}
// 		}
// 		// public int Load(string path, string withoutPlarformPath, FileLoadedPostProcess callback); // 0x18A1780
// 		// public int Load(string path, string withoutPlarformPath, FileLoadedPostProcess callback, Dictionary`2<string, string> args, int argValue); // 0x18A17C4
// 		// public int Load(string path, FileLoadedPostProcess callback); // 0x18A180C
// 		// public int Load(string path, FileLoadedPostProcess callback, Dictionary`2<string, string> args, int argValue); // 0x18A1814
// 		// public void Cancel(); // 0x18A181C
// 		// private bool FailedCallback(FileResultObject fro); // 0x18A192C
// 		private bool FileLoadedCallback(FileResultObject fro) // 0x18A1A70
// 		{
// 			// 18a1a70:	e92d4df0 	push	{r4, r5, r6, r7, r8, sl, fp, lr}
// 			// 18a1a74:	e28db018 	add	fp, sp, #24
// 			// 18a1a78:	e1a04000 	mov	r4, r0
// 			// 18a1a7c:	e59f0160 	ldr	r0, [pc, #352]	; 18a1be4 <dladdr@plt+0x1562b08>
// 			// 18a1a80:	e59f6160 	ldr	r6, [pc, #352]	; 18a1be8 <dladdr@plt+0x1562b0c>
// 			// 18a1a84:	e1a05001 	mov	r5, r1
// 			// 18a1a88:	e08f0000 	add	r0, pc, r0
// 			// 18a1a8c:	e0860000 	add	r0, r6, r0
// 			// 18a1a90:	e5d000e7 	ldrb	r0, [r0, #231]	; 0xe7
// 			// 18a1a94:	e3500000 	cmp	r0, #0
// 			// 18a1a98:	1a000008 	bne	18a1ac0 <dladdr@plt+0x15629e4>
// 			// 18a1a9c:	e59f0148 	ldr	r0, [pc, #328]	; 18a1bec <dladdr@plt+0x1562b10>
// 			// 18a1aa0:	e59f1148 	ldr	r1, [pc, #328]	; 18a1bf0 <dladdr@plt+0x1562b14>
// 			// 18a1aa4:	e08f7000 	add	r7, pc, r0
// 			// 18a1aa8:	e7910007 	ldr	r0, [r1, r7]
// 			// 18a1aac:	e5900000 	ldr	r0, [r0]
// 			// 18a1ab0:	eb124eb2 	bl	1d35580 <_ZNSt6vectorIjSaIjEE17_M_default_appendEj+0x2ab4>
// 			// 18a1ab4:	e0860007 	add	r0, r6, r7
// 			// 18a1ab8:	e3a01001 	mov	r1, #1
// 			// 18a1abc:	e5c010e7 	strb	r1, [r0, #231]	; 0xe7
// 			// 18a1ac0:	e3550000 	cmp	r5, #0
// 			// 18a1ac4:	1594002c 	ldrne	r0, [r4, #44]	; 0x2c // fileLoadingDic
// 			// 18a1ac8:	13500000 	cmpne	r0, #0
// 			// 18a1acc:	0a000041 	beq	18a1bd8 <dladdr@plt+0x1562afc>
// 			// 18a1ad0:	e59f111c 	ldr	r1, [pc, #284]	; 18a1bf4 <dladdr@plt+0x1562b18>
// 			// 18a1ad4:	e59f211c 	ldr	r2, [pc, #284]	; 18a1bf8 <dladdr@plt+0x1562b1c>
// 			// 18a1ad8:	e08f1001 	add	r1, pc, r1
// 			// 18a1adc:	e7922001 	ldr	r2, [r2, r1]
// 			// 18a1ae0:	e5951014 	ldr	r1, [r5, #20] // pathHashCode
// 			// 18a1ae4:	e5922000 	ldr	r2, [r2]
// 			// 18a1ae8:	ebb20b23 	bl	52477c <dladdr@plt+0x1e56a0>
// 			FileLoadInfo fileInfo = fileLoadingDic[fro.pathHashCode];
// 			// 18a1aec:	e1a06000 	mov	r6, r0
// 			// 18a1af0:	e3560000 	cmp	r6, #0
// 			// 18a1af4:	1594002c 	ldrne	r0, [r4, #44]	; 0x2c // fileLoadingDic
// 			// 18a1af8:	13500000 	cmpne	r0, #0
// 			// 18a1afc:	0a000035 	beq	18a1bd8 <dladdr@plt+0x1562afc>
// 			// 18a1b00:	e59f10f4 	ldr	r1, [pc, #244]	; 18a1bfc <dladdr@plt+0x1562b20>
// 			// 18a1b04:	e59f20f4 	ldr	r2, [pc, #244]	; 18a1c00 <dladdr@plt+0x1562b24>
// 			// 18a1b08:	e08f1001 	add	r1, pc, r1
// 			// 18a1b0c:	e7922001 	ldr	r2, [r2, r1]
// 			// 18a1b10:	e596100c 	ldr	r1, [r6, #12]
// 			// 18a1b14:	e5922000 	ldr	r2, [r2]
// 			// 18a1b18:	ebb21376 	bl	5268f8 <dladdr@plt+0x1e781c>
// 			fileLoadingDic.Remove(fileInfo.pathHashCode);
// 			// 18a1b1c:	e5940028 	ldr	r0, [r4, #40]	; 0x28 // fileLoadedDic
// 			// 18a1b20:	e3500000 	cmp	r0, #0
// 			// 18a1b24:	0a00002b 	beq	18a1bd8 <dladdr@plt+0x1562afc>
// 			// 18a1b28:	e59f10d4 	ldr	r1, [pc, #212]	; 18a1c04 <dladdr@plt+0x1562b28>
// 			// 18a1b2c:	e59f20d4 	ldr	r2, [pc, #212]	; 18a1c08 <dladdr@plt+0x1562b2c>
// 			// 18a1b30:	e08f1001 	add	r1, pc, r1
// 			// 18a1b34:	e7922001 	ldr	r2, [r2, r1]
// 			// 18a1b38:	e596100c 	ldr	r1, [r6, #12]
// 			// 18a1b3c:	e5922000 	ldr	r2, [r2]
// 			// 18a1b40:	ebb21111 	bl	525f8c <dladdr@plt+0x1e6eb0>
// 			// 18a1b44:	e5865010 	str	r5, [r6, #16]
// 			fileInfo.resultObject = fro;
// 			// 18a1b48:	e1a08000 	mov	r8, r0
// 			// 18a1b4c:	e5960014 	ldr	r0, [r6, #20]
// 			// 18a1b50:	e3500000 	cmp	r0, #0
// 			// 18a1b54:	0a000005 	beq	18a1b70 <dladdr@plt+0x1562a94>
// 			// 18a1b58:	e1a01005 	mov	r1, r5
// 			// 18a1b5c:	e3a02000 	mov	r2, #0
// 			// 18a1b60:	e3a07000 	mov	r7, #0
// 			fileInfo.succeededCallback(fro);
// 			//Debug.Log("TODO Succeeded callback");
// 			// 18a1b64:	ebfffa89 	bl	18a0590 <dladdr@plt+0x15614b4> // FileLoadedPostProcess -> 	public virtual bool Invoke(FileResultObject fro); // 0x18A0590
// 			// 18a1b68:	e3500001 	cmp	r0, #1
// 			// 18a1b6c:	1a000017 	bne	18a1bd0 <dladdr@plt+0x1562af4>
// 			// 18a1b70:	e5d50018 	ldrb	r0, [r5, #24] // dispose
// 			// 18a1b74:	e3500000 	cmp	r0, #0
// 			// 18a1b78:	0a000006 	beq	18a1b98 <dladdr@plt+0x1562abc>
// 			if(fro.dispose)
// 			{
// 				// 18a1b7c:	e596001c 	ldr	r0, [r6, #28]
// 				// 18a1b80:	e3500000 	cmp	r0, #0
// 				// 18a1b84:	0a000013 	beq	18a1bd8 <dladdr@plt+0x1562afc>
// 				// 18a1b88:	e3a01000 	mov	r1, #0
// 				// 18a1b8c:	ebe9e71b 	bl	131b800 <dladdr@plt+0xfdc724> // LBHFILLFAGA -> 	public void PEFNBFCMIBL(); // 0x131B800
// 				fileInfo.request.PEFNBFCMIBL();
// 				// 18a1b90:	e3a07001 	mov	r7, #1
// 				// 18a1b94:	ea00000d 	b	18a1bd0 <dladdr@plt+0x1562af4>
// 			}
// 			else
// 			{
// 				// 18a1b98:	e3a07001 	mov	r7, #1
// 				// 18a1b9c:	e3580000 	cmp	r8, #0
// 				// 18a1ba0:	1a00000a 	bne	18a1bd0 <dladdr@plt+0x1562af4>
// 				if(!fileLoadedDic.ContainsKey(fileInfo.pathHashCode))
// 				{
// 					// 18a1ba4:	e5940028 	ldr	r0, [r4, #40]	; 0x28 // fileLoadedDic
// 					// 18a1ba8:	e3500000 	cmp	r0, #0
// 					// 18a1bac:	0a000009 	beq	18a1bd8 <dladdr@plt+0x1562afc>
// 					// 18a1bb0:	e59f1054 	ldr	r1, [pc, #84]	; 18a1c0c <dladdr@plt+0x1562b30>
// 					// 18a1bb4:	e59f2054 	ldr	r2, [pc, #84]	; 18a1c10 <dladdr@plt+0x1562b34>
// 					// 18a1bb8:	e08f1001 	add	r1, pc, r1
// 					// 18a1bbc:	e7922001 	ldr	r2, [r2, r1]
// 					// 18a1bc0:	e596100c 	ldr	r1, [r6, #12]
// 					// 18a1bc4:	e5923000 	ldr	r3, [r2]
// 					// 18a1bc8:	e1a02006 	mov	r2, r6
// 					// 18a1bcc:	ebb20f8f 	bl	525a10 <dladdr@plt+0x1e6934>
// 					fileLoadedDic[fileInfo.pathHashCode] = fileInfo;
// 				}
// 			}
// 			return true;
// 			// 18a1bd0:	e1a00007 	mov	r0, r7
// 			// 18a1bd4:	e8bd8df0 	pop	{r4, r5, r6, r7, r8, sl, fp, pc}
// 			// 18a1bd8:	eb130613 	bl	1d6342c <_ZNSs12_S_constructIN9__gnu_cxx17__normal_iteratorIPcSt6vectorIcSaIcEEEEEES2_T_S7_RKS4_St20forward_iterator_tag+0x7118>
// 			// 18a1bdc:	e1a0e00f 	mov	lr, pc
// 			// 18a1be0:	eaff712d 	b	187e09c <dladdr@plt+0x153efc0> // <ProcMessageCoroutine>c__Iterator691 -> 	internal void <>m__153B(IiconTexture tex); // 0x187E09C
// 			// 18a1be4:	00a37614 	adceq	r7, r3, r4, lsl r6
// 			// 18a1be8:	000e2d0c 	andeq	r2, lr, ip, lsl #26
// 			// 18a1bec:	00a375f8 	strdeq	r7, [r3], r8	; <UNPREDICTABLE>
// 			// 18a1bf0:	0003aaac 	andeq	sl, r3, ip, lsr #21
// 			// 18a1bf4:	00a375c4 	adceq	r7, r3, r4, asr #11
// 			// 18a1bf8:	0001c390 	muleq	r1, r0, r3
// 			// 18a1bfc:	00a37594 	umlaleq	r7, r3, r4, r5
// 			// 18a1c00:	0001f4d4 	ldrdeq	pc, [r1], -r4
// 			// 18a1c04:	00a3756c 	adceq	r7, r3, ip, ror #10
// 			// 18a1c08:	00049414 	andeq	r9, r4, r4, lsl r4
// 			// 18a1c0c:	00a374e4 	adceq	r7, r3, r4, ror #9
// 			// 18a1c10:	000166e4 	andeq	r6, r1, r4, ror #13
// 		}
// 		private LBHFILLFAGA CreateFileRequest(string path, string withoutPlarformPath, Dictionary<string, string> args, int argValue, FileLoadInfo fi, bool loadedDispose) // 0x18A1144
// 		{
// 				// Caller : 0x18a0fcc in FileLoader -> 	public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, FileLoadedPostProcess failed, Dictionary`2<string, string> args, int argValue, bool loadedDispose); // 0x18A0E5C
// 			 // 18a1144:	e92d4ff0 	push	{r4, r5, r6, r7, r8, r9, sl, fp, lr}
// 			 // 18a1148:	e28db01c 	add	fp, sp, #28
// 			 // 18a114c:	e24dd02c 	sub	sp, sp, #44	; 0x2c
// 			 // 18a1150:	e1a07000 	mov	r7, r0
// 			 // 18a1154:	e59f04d4 	ldr	r0, [pc, #1236]	; 18a1630 <dladdr@plt+0x1562554>
// 			 // 18a1158:	e59f44d4 	ldr	r4, [pc, #1236]	; 18a1634 <dladdr@plt+0x1562558>
// 			 // 18a115c:	e1a08001 	mov	r8, r1
// 			 // 18a1160:	e08f0000 	add	r0, pc, r0
// 			 // 18a1164:	e58d3024 	str	r3, [sp, #36]	; 0x24
// 			 // 18a1168:	e0840000 	add	r0, r4, r0
// 			 // 18a116c:	e50b2020 	str	r2, [fp, #-32]	; 0xffffffe0
// 			 // 18a1170:	e5d000e8 	ldrb	r0, [r0, #232]	; 0xe8
// 			 // 18a1174:	e3500000 	cmp	r0, #0
// 			 // 18a1178:	1a000008 	bne	18a11a0 <dladdr@plt+0x15620c4>
// 			 // 18a117c:	e59f04b4 	ldr	r0, [pc, #1204]	; 18a1638 <dladdr@plt+0x156255c>
// 			 // 18a1180:	e59f14b4 	ldr	r1, [pc, #1204]	; 18a163c <dladdr@plt+0x1562560>
// 			 // 18a1184:	e08f6000 	add	r6, pc, r0
// 			 // 18a1188:	e7910006 	ldr	r0, [r1, r6]
// 			 // 18a118c:	e5900000 	ldr	r0, [r0]
// 			 // 18a1190:	eb1250fa 	bl	1d35580 <_ZNSt6vectorIjSaIjEE17_M_default_appendEj+0x2ab4>
// 			 // 18a1194:	e0840006 	add	r0, r4, r6
// 			 // 18a1198:	e3a01001 	mov	r1, #1
// 			 // 18a119c:	e5c010e8 	strb	r1, [r0, #232]	; 0xe8
// 			 // 18a11a0:	e3580000 	cmp	r8, #0
// 			 // 18a11a4:	0a00011e 	beq	18a1624 <dladdr@plt+0x1562548>
// 			 // 18a11a8:	e5971014 	ldr	r1, [r7, #20] // textureExtension
// 			 // 18a11ac:	e1a00008 	mov	r0, r8
// 			 // 18a11b0:	e3a02000 	mov	r2, #0
// 			 // 18a11b4:	e59ba008 	ldr	sl, [fp, #8]
// 			 // 18a11b8:	ebcd2b63 	bl	bebf4c <dladdr@plt+0x8ace70> // String -> 	public bool Contains(string value); // 0xBEBF4C
// 			 // 18a11bc:	e3500001 	cmp	r0, #1
// 			 // 18a11c0:	1a00002d 	bne	18a127c <dladdr@plt+0x15621a0>
// 			 LBHFILLFAGA createdReq = null;
// 			 if(path.Contains(textureExtention))
// 			 {
// 				 // 18a11c4:	e59f04ac 	ldr	r0, [pc, #1196]	; 18a1678 <dladdr@plt+0x156259c>
// 				 // 18a11c8:	e59f1474 	ldr	r1, [pc, #1140]	; 18a1644 <dladdr@plt+0x1562568>
// 				 // 18a11cc:	e59f2474 	ldr	r2, [pc, #1140]	; 18a1648 <dladdr@plt+0x156256c>
// 				 // 18a11d0:	e08f6000 	add	r6, pc, r0
// 				 // 18a11d4:	e7910006 	ldr	r0, [r1, r6]
// 				 // 18a11d8:	e7924006 	ldr	r4, [r2, r6]
// 				 // 18a11dc:	e5909000 	ldr	r9, [r0]
// 				 // 18a11e0:	e5940000 	ldr	r0, [r4]
// 				 // 18a11e4:	eb132182 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a11e8:	e1a05000 	mov	r5, r0
// 				 // 18a11ec:	e59f0458 	ldr	r0, [pc, #1112]	; 18a164c <dladdr@plt+0x1562570>
// 				 // 18a11f0:	e5991000 	ldr	r1, [r9]
// 				 // 18a11f4:	e5851008 	str	r1, [r5, #8]
// 				 // 18a11f8:	e7900006 	ldr	r0, [r0, r6]
// 				 // 18a11fc:	e5857010 	str	r7, [r5, #16]
// 				 // 18a1200:	e5859014 	str	r9, [r5, #20]
// 				 // 18a1204:	e1a09008 	mov	r9, r8
// 				 // 18a1208:	e5908000 	ldr	r8, [r0]
// 				 // 18a120c:	e5940000 	ldr	r0, [r4]
// 				 // 18a1210:	e58d7020 	str	r7, [sp, #32]
// 				 // 18a1214:	eb132176 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a1218:	e1a04000 	mov	r4, r0
// 				 // 18a121c:	e59f0458 	ldr	r0, [pc, #1112]	; 18a167c <dladdr@plt+0x15625a0>
// 				 // 18a1220:	e5981000 	ldr	r1, [r8]
// 				 // 18a1224:	e5841008 	str	r1, [r4, #8]
// 				 // 18a1228:	e7900006 	ldr	r0, [r0, r6]
// 				 // 18a122c:	e5847010 	str	r7, [r4, #16]
// 				 // 18a1230:	e5848014 	str	r8, [r4, #20]
// 				 // 18a1234:	e5900000 	ldr	r0, [r0]
// 				 // 18a1238:	eb13216d 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a123c:	e1a06000 	mov	r6, r0
// 				 // 18a1240:	e59d0024 	ldr	r0, [sp, #36]	; 0x24
// 				 // 18a1244:	e58d4000 	str	r4, [sp]
// 				 // 18a1248:	e1a01009 	mov	r1, r9
// 				 // 18a124c:	e98d0401 	stmib	sp, {r0, sl}
// 				 // 18a1250:	e1a03005 	mov	r3, r5
// 				 // 18a1254:	e59b000c 	ldr	r0, [fp, #12]
// 				 // 18a1258:	e58d000c 	str	r0, [sp, #12]
// 				 // 18a125c:	e59b0010 	ldr	r0, [fp, #16]
// 				 // 18a1260:	e51b2020 	ldr	r2, [fp, #-32]	; 0xffffffe0
// 				 // 18a1264:	e58d0010 	str	r0, [sp, #16]
// 				 // 18a1268:	e3a00000 	mov	r0, #0
// 				 // 18a126c:	e58d0014 	str	r0, [sp, #20]
// 				 // 18a1270:	e1a00006 	mov	r0, r6
// 				 // 18a1274:	ebc74afc 	bl	a73e6c <dladdr@plt+0x734d90> // HMHBDNGJIGL -> 	public void .ctor(string CJEKGLGBIHF, string BOPDLODALFD, FileLoadedPostProcess OGLMMENAJFL, FileLoadedPostProcess GOIHDOPGPCE, Dictionary`2<string, string> JBKMAPLCBMO, int HNKPENAFDKA, FileLoadInfo LAMFBMFNOFP, bool ALJGNAPELAH); // 0xA73E6C
// 				 //HMHBDNGJIGL texRequest = new HMHBDNGJIGL(path, withoutPlarformPath, null, null, args, argValue, fi, loadedDispose);
// 				 Debug.LogError("TODO texture loader HMHBDNGJIGL");
// 				 //createdReq = texRequest;
// 				 // 18a1278:	ea0000d5 	b	18a15d4 <dladdr@plt+0x15624f8>
// 			 }
// 			 else if(path.Contains(cpkExtention))// 18a127c:	e5971020 	ldr	r1, [r7, #32] // cpkExtension
// 			 {
// 				 // 18a1280:	e1a00008 	mov	r0, r8
// 				 // 18a1284:	e3a02000 	mov	r2, #0
// 				 // 18a1288:	ebcd2b2f 	bl	bebf4c <dladdr@plt+0x8ace70> // String -> 	public bool Contains(string value); // 0xBEBF4C
// 				 // 18a128c:	e3500000 	cmp	r0, #0
// 				 // 18a1290:	0a000036 	beq	18a1370 <dladdr@plt+0x1562294>
// 				 // 18a1294:	e59f03cc 	ldr	r0, [pc, #972]	; 18a1668 <dladdr@plt+0x156258c>
// 				 // 18a1298:	e59f13a4 	ldr	r1, [pc, #932]	; 18a1644 <dladdr@plt+0x1562568>
// 				 // 18a129c:	e59f23a4 	ldr	r2, [pc, #932]	; 18a1648 <dladdr@plt+0x156256c>
// 				 // 18a12a0:	e08f6000 	add	r6, pc, r0
// 				 // 18a12a4:	e7910006 	ldr	r0, [r1, r6]
// 				 // 18a12a8:	e7924006 	ldr	r4, [r2, r6]
// 				 // 18a12ac:	e5905000 	ldr	r5, [r0]
// 				 // 18a12b0:	e5940000 	ldr	r0, [r4]
// 				 // 18a12b4:	eb13214e 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a12b8:	e1a0a007 	mov	sl, r7
// 				 // 18a12bc:	e1a07000 	mov	r7, r0
// 				 // 18a12c0:	e59f0384 	ldr	r0, [pc, #900]	; 18a164c <dladdr@plt+0x1562570>
// 				 // 18a12c4:	e5951000 	ldr	r1, [r5]
// 				 // 18a12c8:	e5871008 	str	r1, [r7, #8]
// 				 // 18a12cc:	e7900006 	ldr	r0, [r0, r6]
// 				 // 18a12d0:	e587a010 	str	sl, [r7, #16]
// 				 // 18a12d4:	e5875014 	str	r5, [r7, #20]
// 				 // 18a12d8:	e5905000 	ldr	r5, [r0]
// 				 // 18a12dc:	e5940000 	ldr	r0, [r4]
// 				 // 18a12e0:	eb132143 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a12e4:	e1a04000 	mov	r4, r0
// 				 // 18a12e8:	e59f037c 	ldr	r0, [pc, #892]	; 18a166c <dladdr@plt+0x1562590>
// 				 // 18a12ec:	e5951000 	ldr	r1, [r5]
// 				 // 18a12f0:	e1a09008 	mov	r9, r8
// 				 // 18a12f4:	e5841008 	str	r1, [r4, #8] // method_ptr
// 				 // 18a12f8:	e7900006 	ldr	r0, [r0, r6]
// 				 // 18a12fc:	e584a010 	str	sl, [r4, #16] // m_target
// 				 // 18a1300:	e5845014 	str	r5, [r4, #20] // method
// 				 // 18a1304:	e5900000 	ldr	r0, [r0]
// 				 // 18a1308:	eb132139 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a130c:	e1a06000 	mov	r6, r0
// 				 // 18a1310:	e59d0024 	ldr	r0, [sp, #36]	; 0x24
// 				 // 18a1314:	e58d4000 	str	r4, [sp]
// 				 // 18a1318:	e1a01009 	mov	r1, r9
// 				 // 18a131c:	e58d0004 	str	r0, [sp, #4]
// 				 // 18a1320:	e1a03007 	mov	r3, r7
// 				 // 18a1324:	e59b0008 	ldr	r0, [fp, #8]
// 				 // 18a1328:	e1a0400a 	mov	r4, sl
// 				 // 18a132c:	e58d0008 	str	r0, [sp, #8]
// 				 // 18a1330:	e59b000c 	ldr	r0, [fp, #12]
// 				 // 18a1334:	e58d000c 	str	r0, [sp, #12]
// 				 // 18a1338:	e59b0010 	ldr	r0, [fp, #16]
// 				 // 18a133c:	e51b2020 	ldr	r2, [fp, #-32]	; 0xffffffe0
// 				 // 18a1340:	e58d0010 	str	r0, [sp, #16]
// 				 // 18a1344:	e3a00000 	mov	r0, #0
// 				 // 18a1348:	e58d0014 	str	r0, [sp, #20]
// 				 // 18a134c:	e1a00006 	mov	r0, r6
// 				 // 18a1350:	ebfc6587 	bl	17ba974 <dladdr@plt+0x147b898> // PLKCJJECNCK -> 	public void .ctor(string CJEKGLGBIHF, string BOPDLODALFD, FileLoadedPostProcess OGLMMENAJFL, FileLoadedPostProcess GOIHDOPGPCE, Dictionary`2<string, string> JBKMAPLCBMO, int HNKPENAFDKA, FileLoadInfo LAMFBMFNOFP, bool ALJGNAPELAH); // 0x17BA974
// 				 //PLKCJJECNCK cpkReq = new PLKCJJECNCK(path, withoutPlarformPath, null, null, args, argValue, fi, loadedDispose);
// 				 Debug.LogError("TODO cpk loader HMHBDNGJIGL");
// 				 //createdReq = cpkReq;
// 				 // 18a1354:	e5941024 	ldr	r1, [r4, #36]	; 0x24 // m_target.CriFsBinder ???
// 				 // 18a1358:	e3510000 	cmp	r1, #0
// 				 // 18a135c:	0a000073 	beq	18a1530 <dladdr@plt+0x1562454>
// 				 if(false) // LBHFILLFAGA.CriFsBinder == null;
// 				 {
// 					 // 18a1530:	e59f0138 	ldr	r0, [pc, #312]	; 18a1670 <dladdr@plt+0x1562594>
// 					 // 18a1534:	e59f1138 	ldr	r1, [pc, #312]	; 18a1674 <dladdr@plt+0x1562598>
// 					 // 18a1538:	e08f0000 	add	r0, pc, r0
// 					 // 18a153c:	e7910000 	ldr	r0, [r1, r0]
// 					 // 18a1540:	e5900000 	ldr	r0, [r0]
// 					 // 18a1544:	eb1320aa 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 					 // 18a1548:	e1a07000 	mov	r7, r0
// 					 // 18a154c:	e3a01000 	mov	r1, #0
// 					 // 18a1550:	eb09b899 	bl	1b0f7bc <dladdr@plt+0x17d06e0> // CriFsBinder -> 	public void .ctor(); // 0x1B0F7BC
// 					 // 18a1554:	e5847024 	str	r7, [r4, #36]	; 0x24
// 					 // 18a1558:	e3560000 	cmp	r6, #0
// 					 // 18a155c:	0a000030 	beq	18a1624 <dladdr@plt+0x1562548>
// 					 // 18a1560:	e1a00006 	mov	r0, r6
// 					 // 18a1564:	e1a01007 	mov	r1, r7
// 				 }
// 				 // 18a1360:	e3560000 	cmp	r6, #0
// 				 // 18a1364:	0a0000ae 	beq	18a1624 <dladdr@plt+0x1562548>
// 				 // 18a1368:	e1a00006 	mov	r0, r6
// 				 // 18a136c:	ea00007d 	b	18a1568 <dladdr@plt+0x156248c>
// 				 {
// 					 // 18a1568:	e3a02000 	mov	r2, #0
// 					 // 18a156c:	ebe9e809 	bl	131b598 <dladdr@plt+0xfdc4bc> // LBHFILLFAGA -> 	public void GOKEIMCNGHB(CriFsBinder NANNGLGOFKH_value); // 0x131B598
// 					 // cpkReq.GOKEIMCNGHB();
// 					 // 18a1570:	ea00001e 	b	18a15f0 <dladdr@plt+0x1562514>
// 					 // 18a1574:	e59f00d4 	ldr	r0, [pc, #212]	; 18a1650 <dladdr@plt+0x1562574>
// 					 // 18a1578:	e59f10d4 	ldr	r1, [pc, #212]	; 18a1654 <dladdr@plt+0x1562578>
// 					 // 18a157c:	e08f0000 	add	r0, pc, r0
// 					 // 18a1580:	e7910000 	ldr	r0, [r1, r0]
// 					 // 18a1584:	e5900000 	ldr	r0, [r0]
// 					 // 18a1588:	eb132099 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 					 // 18a158c:	e1a06000 	mov	r6, r0
// 					 // 18a1590:	e59d0024 	ldr	r0, [sp, #36]	; 0x24
// 					 // 18a1594:	e58d7000 	str	r7, [sp]
// 					 // 18a1598:	e1a01008 	mov	r1, r8
// 					 // 18a159c:	e58d0004 	str	r0, [sp, #4]
// 					 // 18a15a0:	e1a0300a 	mov	r3, sl
// 					 // 18a15a4:	e59b0008 	ldr	r0, [fp, #8]
// 					 // 18a15a8:	e58d0008 	str	r0, [sp, #8]
// 					 // 18a15ac:	e59b000c 	ldr	r0, [fp, #12]
// 					 // 18a15b0:	e58d000c 	str	r0, [sp, #12]
// 					 // 18a15b4:	e59b0010 	ldr	r0, [fp, #16]
// 					 // 18a15b8:	e51b2020 	ldr	r2, [fp, #-32]	; 0xffffffe0
// 					 // 18a15bc:	e58d0010 	str	r0, [sp, #16]
// 					 // 18a15c0:	e3a00000 	mov	r0, #0
// 					 // 18a15c4:	e58d0014 	str	r0, [sp, #20]
// 					 // 18a15c8:	e1a00006 	mov	r0, r6
// 					 // 18a15cc:	ebd098bc 	bl	cc78c4 <dladdr@plt+0x9887e8> // PFHMOOFJMIM -> 	public void .ctor(string CJEKGLGBIHF, string BOPDLODALFD, FileLoadedPostProcess OGLMMENAJFL, FileLoadedPostProcess GOIHDOPGPCE, Dictionary`2<string, string> JBKMAPLCBMO, int HNKPENAFDKA, FileLoadInfo LAMFBMFNOFP, bool ALJGNAPELAH); // 0xCC78C4
// 					 //PFHMOOFJMIM otherReq = new PFHMOOFJMIM(path, withoutPlarformPath, null, null, args, argValue, fi, loadedDispose);
// 					 //createdReq = otherReq;
// 					 Debug.LogError("TODO cpk loader HMHBDNGJIGL");
// 					 // 18a15d0:	e1a09008 	mov	r9, r8
// 				 }
// 			 }
// 			 else if(path.Contains(assetBundleExtention))
// 			 {
// 				 // 18a1370:	e5971018 	ldr	r1, [r7, #24]
// 				 // 18a1374:	e1a00008 	mov	r0, r8
// 				 // 18a1378:	e3a02000 	mov	r2, #0
// 				 // 18a137c:	ebcd2af2 	bl	bebf4c <dladdr@plt+0x8ace70> // String -> 	public bool Contains(string value); // 0xBEBF4C
// 				 // 18a1380:	e3500001 	cmp	r0, #1
// 				 // 18a1384:	1a00002f 	bne	18a1448 <dladdr@plt+0x156236c>
// 				 // 18a1388:	e59f02d0 	ldr	r0, [pc, #720]	; 18a1660 <dladdr@plt+0x1562584>
// 				 // 18a138c:	e59f12b0 	ldr	r1, [pc, #688]	; 18a1644 <dladdr@plt+0x1562568>
// 				 // 18a1390:	e59f22b0 	ldr	r2, [pc, #688]	; 18a1648 <dladdr@plt+0x156256c>
// 				 // 18a1394:	e08f6000 	add	r6, pc, r0
// 				 // 18a1398:	e7910006 	ldr	r0, [r1, r6]
// 				 // 18a139c:	e7924006 	ldr	r4, [r2, r6]
// 				 // 18a13a0:	e5905000 	ldr	r5, [r0]
// 				 // 18a13a4:	e5940000 	ldr	r0, [r4]
// 				 // 18a13a8:	eb132111 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a13ac:	e1a0a000 	mov	sl, r0
// 				 // 18a13b0:	e59f0294 	ldr	r0, [pc, #660]	; 18a164c <dladdr@plt+0x1562570>
// 				 // 18a13b4:	e5951000 	ldr	r1, [r5]
// 				 // 18a13b8:	e58a1008 	str	r1, [sl, #8]
// 				 // 18a13bc:	e7900006 	ldr	r0, [r0, r6]
// 				 // 18a13c0:	e58a7010 	str	r7, [sl, #16]
// 				 // 18a13c4:	e58a5014 	str	r5, [sl, #20]
// 				 // 18a13c8:	e5905000 	ldr	r5, [r0]
// 				 // 18a13cc:	e5940000 	ldr	r0, [r4]
// 				 // 18a13d0:	e58d7020 	str	r7, [sp, #32]
// 				 // 18a13d4:	eb132106 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a13d8:	e1a04000 	mov	r4, r0
// 				 // 18a13dc:	e59f0280 	ldr	r0, [pc, #640]	; 18a1664 <dladdr@plt+0x1562588>
// 				 // 18a13e0:	e5951000 	ldr	r1, [r5]
// 				 // 18a13e4:	e1a09008 	mov	r9, r8
// 				 // 18a13e8:	e5841008 	str	r1, [r4, #8]
// 				 // 18a13ec:	e7900006 	ldr	r0, [r0, r6]
// 				 // 18a13f0:	e5847010 	str	r7, [r4, #16]
// 				 // 18a13f4:	e5845014 	str	r5, [r4, #20]
// 				 // 18a13f8:	e5900000 	ldr	r0, [r0]
// 				 // 18a13fc:	eb1320fc 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a1400:	e1a06000 	mov	r6, r0
// 				 // 18a1404:	e59d0024 	ldr	r0, [sp, #36]	; 0x24
// 				 // 18a1408:	e58d4000 	str	r4, [sp]
// 				 // 18a140c:	e1a01009 	mov	r1, r9
// 				 // 18a1410:	e58d0004 	str	r0, [sp, #4]
// 				 // 18a1414:	e1a0300a 	mov	r3, sl
// 				 // 18a1418:	e59b0008 	ldr	r0, [fp, #8]
// 				 // 18a141c:	e58d0008 	str	r0, [sp, #8]
// 				 // 18a1420:	e59b000c 	ldr	r0, [fp, #12]
// 				 // 18a1424:	e58d000c 	str	r0, [sp, #12]
// 				 // 18a1428:	e59b0010 	ldr	r0, [fp, #16]
// 				 // 18a142c:	e51b2020 	ldr	r2, [fp, #-32]	; 0xffffffe0
// 				 // 18a1430:	e58d0010 	str	r0, [sp, #16]
// 				 // 18a1434:	e3a00000 	mov	r0, #0
// 				 // 18a1438:	e58d0014 	str	r0, [sp, #20]
// 				 // 18a143c:	e1a00006 	mov	r0, r6
// 				 // 18a1440:	ebdfcf60 	bl	10951c8 <dladdr@plt+0xd560ec> // BDFPCPHIJCN -> 	public void .ctor(string CJEKGLGBIHF, string BOPDLODALFD, FileLoadedPostProcess OGLMMENAJFL, FileLoadedPostProcess GOIHDOPGPCE, Dictionary`2<string, string> JBKMAPLCBMO, int HNKPENAFDKA, FileLoadInfo LAMFBMFNOFP, bool ALJGNAPELAH); // 0x10951C8
// 				 BDFPCPHIJCN assetReq = new BDFPCPHIJCN(path, withoutPlarformPath, FileLoadedCallback, null, args, argValue, fi, loadedDispose);
// 				 createdReq = assetReq;
// 				 // 18a1444:	ea000062 	b	18a15d4 <dladdr@plt+0x15624f8>
// 			}
// 			else
// 			{
// 				 // 18a1448:	e597101c 	ldr	r1, [r7, #28]
// 				 // 18a144c:	e1a00008 	mov	r0, r8
// 				 // 18a1450:	e3a02000 	mov	r2, #0
// 				 // 18a1454:	ebcd2abc 	bl	bebf4c <dladdr@plt+0x8ace70> // String -> 	public bool Contains(string value); // 0xBEBF4C
// 				 // 18a1458:	e58d001c 	str	r0, [sp, #28]
// 				 // 18a145c:	e1a05007 	mov	r5, r7
// 				 // 18a1460:	e59f01d8 	ldr	r0, [pc, #472]	; 18a1640 <dladdr@plt+0x1562564>
// 				 // 18a1464:	e59f11d8 	ldr	r1, [pc, #472]	; 18a1644 <dladdr@plt+0x1562568>
// 				 // 18a1468:	e59f21d8 	ldr	r2, [pc, #472]	; 18a1648 <dladdr@plt+0x156256c>
// 				 // 18a146c:	e08f7000 	add	r7, pc, r0
// 				 // 18a1470:	e58d5020 	str	r5, [sp, #32]
// 				 // 18a1474:	e7910007 	ldr	r0, [r1, r7]
// 				 // 18a1478:	e7924007 	ldr	r4, [r2, r7]
// 				 // 18a147c:	e5909000 	ldr	r9, [r0]
// 				 // 18a1480:	e5940000 	ldr	r0, [r4]
// 				 // 18a1484:	eb1320da 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a1488:	e1a0a000 	mov	sl, r0
// 				 // 18a148c:	e59f01b8 	ldr	r0, [pc, #440]	; 18a164c <dladdr@plt+0x1562570>
// 				 // 18a1490:	e5991000 	ldr	r1, [r9]
// 				 // 18a1494:	e58a1008 	str	r1, [sl, #8]
// 				 // 18a1498:	e7900007 	ldr	r0, [r0, r7]
// 				 // 18a149c:	e58a5010 	str	r5, [sl, #16]
// 				 // 18a14a0:	e58a9014 	str	r9, [sl, #20]
// 				 // 18a14a4:	e5906000 	ldr	r6, [r0]
// 				 // 18a14a8:	e5940000 	ldr	r0, [r4]
// 				 // 18a14ac:	eb1320d0 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a14b0:	e1a07000 	mov	r7, r0
// 				 // 18a14b4:	e5960000 	ldr	r0, [r6]
// 				 // 18a14b8:	e5870008 	str	r0, [r7, #8]
// 				 // 18a14bc:	e59d001c 	ldr	r0, [sp, #28]
// 				 // 18a14c0:	e5875010 	str	r5, [r7, #16]
// 				 // 18a14c4:	e5876014 	str	r6, [r7, #20]
// 				 // 18a14c8:	e3500001 	cmp	r0, #1
// 				 // 18a14cc:	1a000028 	bne	18a1574 <dladdr@plt+0x1562498>
// 				 // 18a14d0:	e59f0180 	ldr	r0, [pc, #384]	; 18a1658 <dladdr@plt+0x156257c>
// 				 // 18a14d4:	e59f1180 	ldr	r1, [pc, #384]	; 18a165c <dladdr@plt+0x1562580>
// 				 // 18a14d8:	e08f0000 	add	r0, pc, r0
// 				 // 18a14dc:	e7910000 	ldr	r0, [r1, r0]
// 				 // 18a14e0:	e5900000 	ldr	r0, [r0]
// 				 // 18a14e4:	eb1320c2 	bl	1d697f4 <_ZNSt8_Rb_treeISsSsSt9_IdentityISsESt4lessISsESaISsEE8_M_eraseEPSt13_Rb_tree_nodeISsE+0x31a4>
// 				 // 18a14e8:	e1a06000 	mov	r6, r0
// 				 // 18a14ec:	e59d0024 	ldr	r0, [sp, #36]	; 0x24
// 				 // 18a14f0:	e58d7000 	str	r7, [sp]
// 				 // 18a14f4:	e1a01008 	mov	r1, r8
// 				 // 18a14f8:	e58d0004 	str	r0, [sp, #4]
// 				 // 18a14fc:	e1a0300a 	mov	r3, sl
// 				 // 18a1500:	e59b0008 	ldr	r0, [fp, #8]
// 				 // 18a1504:	e58d0008 	str	r0, [sp, #8]
// 				 // 18a1508:	e59b000c 	ldr	r0, [fp, #12]
// 				 // 18a150c:	e58d000c 	str	r0, [sp, #12]
// 				 // 18a1510:	e59b0010 	ldr	r0, [fp, #16]
// 				 // 18a1514:	e51b2020 	ldr	r2, [fp, #-32]	; 0xffffffe0
// 				 // 18a1518:	e58d0010 	str	r0, [sp, #16]
// 				 // 18a151c:	e3a00000 	mov	r0, #0
// 				 // 18a1520:	e58d0014 	str	r0, [sp, #20]
// 				 // 18a1524:	e1a00006 	mov	r0, r6
// 				 // 18a1528:	ebe19482 	bl	1106738 <dladdr@plt+0xdc765c> // IPGPAGNBBIK -> 	public void .ctor(string CJEKGLGBIHF, string BOPDLODALFD, FileLoadedPostProcess OGLMMENAJFL, FileLoadedPostProcess GOIHDOPGPCE, Dictionary`2<string, string> JBKMAPLCBMO, int HNKPENAFDKA, FileLoadInfo LAMFBMFNOFP, bool ALJGNAPELAH); // 0x1106738
// 				 //IPGPAGNBBIK otherReq = new IPGPAGNBBIK(path, withoutPlarformPath, null, null, args, argValue, fi, loadedDispose);
// 				 //createdReq = otherReq;
// 				 Debug.LogError("TODO otherReq loader HMHBDNGJIGL");
// 				 // 18a152c:	ea000027 	b	18a15d0 <dladdr@plt+0x15624f4>
// 				 // 18a15d0:	e1a09008 	mov	r9, r8
// 			}
			
// 			//createdReq.GOKEIMCNGHB() ??
// 			// Decrypt
// 			//BEEINMBNKNM NANNGLGOFKH = findDecryptor.Invoke("");
// 			//createdReq.AKNAGKOHHCA(NANNGLGOFKH);
			
// 			return createdReq;
// 		}
// 		// public void DebugLogLoadedList(); // 0x18A1CE0
// 	}
// }
