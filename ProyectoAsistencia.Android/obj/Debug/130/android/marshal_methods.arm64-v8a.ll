; ModuleID = 'obj\Debug\130\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [222 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 61
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 16
	i64 210515253464952879, ; 2: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 51
	i64 232391251801502327, ; 3: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 83
	i64 295915112840604065, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 84
	i64 612191770061699990, ; 5: IconFontHelper => 0x87ef12bdcf1fb96 => 14
	i64 634308326490598313, ; 6: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 70
	i64 702024105029695270, ; 7: System.Drawing.Common => 0x9be17343c0e7726 => 103
	i64 710500338161506772, ; 8: SixLabors.Fonts.dll => 0x9dc344b0ce959d4 => 23
	i64 720058930071658100, ; 9: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 64
	i64 870603111519317375, ; 10: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 27
	i64 872800313462103108, ; 11: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 60
	i64 940822596282819491, ; 12: System.Transactions => 0xd0e792aa81923a3 => 101
	i64 996343623809489702, ; 13: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 96
	i64 1000557547492888992, ; 14: Mono.Security.dll => 0xde2b1c9cba651a0 => 110
	i64 1120440138749646132, ; 15: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 98
	i64 1301485588176585670, ; 16: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 26
	i64 1315114680217950157, ; 17: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 46
	i64 1425944114962822056, ; 18: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 5
	i64 1518315023656898250, ; 19: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 28
	i64 1624659445732251991, ; 20: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 44
	i64 1628611045998245443, ; 21: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 72
	i64 1636321030536304333, ; 22: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 65
	i64 1743969030606105336, ; 23: System.Memory.dll => 0x1833d297e88f2af8 => 34
	i64 1795316252682057001, ; 24: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 45
	i64 1836611346387731153, ; 25: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 83
	i64 1847446322536158010, ; 26: DocumentFormat.OpenXml.Framework.dll => 0x19a372a4645e933a => 10
	i64 1875917498431009007, ; 27: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 42
	i64 1981742497975770890, ; 28: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 71
	i64 2136356949452311481, ; 29: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 76
	i64 2165725771938924357, ; 30: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 49
	i64 2207662933261301575, ; 31: DocumentFormat.OpenXml => 0x1ea331bdb8d63747 => 9
	i64 2262844636196693701, ; 32: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 60
	i64 2284400282711631002, ; 33: System.Web.Services => 0x1fb3d1f42fd4249a => 107
	i64 2315304989185124968, ; 34: System.IO.FileSystem.dll => 0x20219d9ee311aa68 => 3
	i64 2329709569556905518, ; 35: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 68
	i64 2337758774805907496, ; 36: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 37
	i64 2466404685302267823, ; 37: SshNet.Security.Cryptography.dll => 0x223a6dfe63ccffaf => 29
	i64 2470498323731680442, ; 38: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 55
	i64 2479423007379663237, ; 39: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 88
	i64 2489738558632930771, ; 40: Acr.UserDialogs.dll => 0x228d540722e8add3 => 6
	i64 2497223385847772520, ; 41: System.Runtime => 0x22a7eb7046413568 => 38
	i64 2547086958574651984, ; 42: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 41
	i64 2592350477072141967, ; 43: System.Xml.dll => 0x23f9e10627330e8f => 39
	i64 2624866290265602282, ; 44: mscorlib.dll => 0x246d65fbde2db8ea => 17
	i64 2646133429690896551, ; 45: Renci.SshNet.dll => 0x24b8f455a10310a7 => 22
	i64 2694427813909235223, ; 46: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 80
	i64 2783046991838674048, ; 47: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 37
	i64 2960931600190307745, ; 48: Xamarin.Forms.Core => 0x2917579a49927da1 => 94
	i64 3017704767998173186, ; 49: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 98
	i64 3289520064315143713, ; 50: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 67
	i64 3303437397778967116, ; 51: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 43
	i64 3311221304742556517, ; 52: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 36
	i64 3493805808809882663, ; 53: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 86
	i64 3522470458906976663, ; 54: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 85
	i64 3531994851595924923, ; 55: System.Numerics => 0x31042a9aade235bb => 35
	i64 3571415421602489686, ; 56: System.Runtime.dll => 0x319037675df7e556 => 38
	i64 3649596011227041021, ; 57: Renci.SshNet.Async.dll => 0x32a5f83c5edeccfd => 21
	i64 3716579019761409177, ; 58: netstandard.dll => 0x3393f0ed5c8c5c99 => 1
	i64 3727469159507183293, ; 59: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 82
	i64 3772598417116884899, ; 60: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 61
	i64 3966267475168208030, ; 61: System.Memory => 0x370b03412596249e => 34
	i64 4337444564132831293, ; 62: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 25
	i64 4376937205476565312, ; 63: ExcelNumberFormat.dll => 0x3cbe0132c89f2140 => 11
	i64 4525561845656915374, ; 64: System.ServiceModel.Internals => 0x3ece06856b710dae => 108
	i64 4636684751163556186, ; 65: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 90
	i64 4782108999019072045, ; 66: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 48
	i64 4794310189461587505, ; 67: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 41
	i64 4795410492532947900, ; 68: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 85
	i64 4801557006133399896, ; 69: Renci.SshNet.Abstractions.dll => 0x42a28ea8475e9158 => 20
	i64 4918220242611126976, ; 70: Renci.SshNet.Abstractions => 0x44410740b7f8c2c0 => 20
	i64 5142919913060024034, ; 71: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 95
	i64 5203618020066742981, ; 72: Xamarin.Essentials => 0x4836f704f0e652c5 => 93
	i64 5205316157927637098, ; 73: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 74
	i64 5348796042099802469, ; 74: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 75
	i64 5376510917114486089, ; 75: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 88
	i64 5408338804355907810, ; 76: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 87
	i64 5451019430259338467, ; 77: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 54
	i64 5507995362134886206, ; 78: System.Core.dll => 0x4c705499688c873e => 31
	i64 5692067934154308417, ; 79: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 92
	i64 5757522595884336624, ; 80: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 52
	i64 5796442605724717762, ; 81: ExcelNumberFormat => 0x507119d6cb2952c2 => 11
	i64 5814345312393086621, ; 82: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 80
	i64 5891064157251515650, ; 83: FontAwesome.Solid => 0x51c143a38a033502 => 12
	i64 5896680224035167651, ; 84: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 69
	i64 6085203216496545422, ; 85: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 96
	i64 6086316965293125504, ; 86: FormsViewGroup.dll => 0x5476f10882baef80 => 13
	i64 6183170893902868313, ; 87: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 25
	i64 6319713645133255417, ; 88: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 70
	i64 6401687960814735282, ; 89: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 68
	i64 6504860066809920875, ; 90: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 49
	i64 6548213210057960872, ; 91: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 58
	i64 6591024623626361694, ; 92: System.Web.Services.dll => 0x5b7805f9751a1b5e => 107
	i64 6659513131007730089, ; 93: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 64
	i64 6802026988460721845, ; 94: ClosedXML.Parser => 0x5e65a781dfd246b5 => 8
	i64 6876862101832370452, ; 95: System.Xml.Linq => 0x5f6f85a57d108914 => 40
	i64 6894844156784520562, ; 96: System.Numerics.Vectors => 0x5faf683aead1ad72 => 36
	i64 7036436454368433159, ; 97: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 66
	i64 7103753931438454322, ; 98: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 63
	i64 7112547816752919026, ; 99: System.IO.FileSystem => 0x62b4d88e3189b1f2 => 3
	i64 7488575175965059935, ; 100: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 40
	i64 7635363394907363464, ; 101: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 94
	i64 7637365915383206639, ; 102: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 93
	i64 7654504624184590948, ; 103: System.Net.Http => 0x6a3a4366801b8264 => 4
	i64 7820441508502274321, ; 104: System.Data => 0x6c87ca1e14ff8111 => 100
	i64 7836164640616011524, ; 105: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 44
	i64 8012566953210257060, ; 106: ClosedXML.dll => 0x6f325b3109219ea4 => 7
	i64 8044118961405839122, ; 107: System.ComponentModel.Composition => 0x6fa2739369944712 => 106
	i64 8083354569033831015, ; 108: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 67
	i64 8103644804370223335, ; 109: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 102
	i64 8167236081217502503, ; 110: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 15
	i64 8398329775253868912, ; 111: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 53
	i64 8400357532724379117, ; 112: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 79
	i64 8565268909422235801, ; 113: RBush => 0x76ddf2b13fcf5099 => 19
	i64 8601935802264776013, ; 114: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 87
	i64 8626175481042262068, ; 115: Java.Interop => 0x77b654e585b55834 => 15
	i64 8639588376636138208, ; 116: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 78
	i64 8684531736582871431, ; 117: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 105
	i64 9312692141327339315, ; 118: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 92
	i64 9324707631942237306, ; 119: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 45
	i64 9437276146080163066, ; 120: ProyectoAsistencia.dll => 0x82f7f0a76e6024fa => 18
	i64 9584643793929893533, ; 121: System.IO.dll => 0x85037ebfbbd7f69d => 109
	i64 9662334977499516867, ; 122: System.Numerics.dll => 0x8617827802b0cfc3 => 35
	i64 9678050649315576968, ; 123: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 55
	i64 9711637524876806384, ; 124: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 75
	i64 9808709177481450983, ; 125: Mono.Android.dll => 0x881f890734e555e7 => 16
	i64 9825649861376906464, ; 126: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 52
	i64 9834056768316610435, ; 127: System.Transactions.dll => 0x8879968718899783 => 101
	i64 9998632235833408227, ; 128: Mono.Security => 0x8ac2470b209ebae3 => 110
	i64 10038780035334861115, ; 129: System.Net.Http.dll => 0x8b50e941206af13b => 4
	i64 10229024438826829339, ; 130: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 58
	i64 10376576884623852283, ; 131: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 86
	i64 10430153318873392755, ; 132: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 56
	i64 10650478070646097812, ; 133: System.IO.Packaging => 0x93ce196068f2c794 => 33
	i64 10842690581852095141, ; 134: IconFontHelper.dll => 0x9678f9a31cc482a5 => 14
	i64 10847732767863316357, ; 135: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 46
	i64 11023048688141570732, ; 136: System.Core => 0x98f9bc61168392ac => 31
	i64 11037814507248023548, ; 137: System.Xml => 0x992e31d0412bf7fc => 39
	i64 11162124722117608902, ; 138: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 91
	i64 11340910727871153756, ; 139: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 57
	i64 11392833485892708388, ; 140: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 81
	i64 11529969570048099689, ; 141: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 91
	i64 11578238080964724296, ; 142: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 66
	i64 11580057168383206117, ; 143: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 42
	i64 11597940890313164233, ; 144: netstandard => 0xa0f429ca8d1805c9 => 1
	i64 11672361001936329215, ; 145: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 63
	i64 11739066727115742305, ; 146: SQLite-net.dll => 0xa2e98afdf8575c61 => 24
	i64 11743665907891708234, ; 147: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 2
	i64 11806260347154423189, ; 148: SQLite-net => 0xa3d8433bc5eb5d95 => 24
	i64 11857165743280931573, ; 149: ProyectoAsistencia => 0xa48d1d6beb30c2f5 => 18
	i64 12102847907131387746, ; 150: System.Buffers => 0xa7f5f40c43256f62 => 30
	i64 12137774235383566651, ; 151: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 89
	i64 12279246230491828964, ; 152: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 28
	i64 12451044538927396471, ; 153: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 62
	i64 12466513435562512481, ; 154: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 73
	i64 12487638416075308985, ; 155: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 59
	i64 12538491095302438457, ; 156: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 50
	i64 12550732019250633519, ; 157: System.IO.Compression => 0xae2d28465e8e1b2f => 104
	i64 12700543734426720211, ; 158: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 51
	i64 12708238894395270091, ; 159: System.IO => 0xb05cbbf17d3ba3cb => 109
	i64 12963446364377008305, ; 160: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 103
	i64 13109727801987935684, ; 161: SixLabors.Fonts => 0xb5ef1bfa438dadc4 => 23
	i64 13153566470908607129, ; 162: SshNet.Security.Cryptography => 0xb68adb03c3fefa99 => 29
	i64 13354776597879105185, ; 163: ProyectoAsistencia.Android.dll => 0xb955b28f2348a6a1 => 0
	i64 13370592475155966277, ; 164: System.Runtime.Serialization => 0xb98de304062ea945 => 5
	i64 13401370062847626945, ; 165: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 89
	i64 13404347523447273790, ; 166: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 53
	i64 13454009404024712428, ; 167: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 99
	i64 13491513212026656886, ; 168: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 47
	i64 13572454107664307259, ; 169: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 82
	i64 13613826926226999557, ; 170: Renci.SshNet.Async => 0xbcee0775d3688905 => 21
	i64 13647894001087880694, ; 171: System.Data.dll => 0xbd670f48cb071df6 => 100
	i64 13959074834287824816, ; 172: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 62
	i64 13967638549803255703, ; 173: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 95
	i64 14065717908940967541, ; 174: RBush.dll => 0xc33377ea3146ce75 => 19
	i64 14124974489674258913, ; 175: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 50
	i64 14148919944076435199, ; 176: DocumentFormat.OpenXml.dll => 0xc45b0fb9961d9eff => 9
	i64 14161076099266624234, ; 177: Acr.UserDialogs => 0xc4863faf060fbaea => 6
	i64 14172845254133543601, ; 178: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 76
	i64 14261073672896646636, ; 179: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 81
	i64 14486659737292545672, ; 180: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 69
	i64 14644440854989303794, ; 181: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 74
	i64 14792063746108907174, ; 182: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 99
	i64 14852515768018889994, ; 183: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 57
	i64 14987728460634540364, ; 184: System.IO.Compression.dll => 0xcfff1ba06622494c => 104
	i64 14988210264188246988, ; 185: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 59
	i64 15044096739141154273, ; 186: Renci.SshNet => 0xd0c75e46f71ef5e1 => 22
	i64 15370334346939861994, ; 187: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 56
	i64 15582737692548360875, ; 188: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 72
	i64 15609085926864131306, ; 189: System.dll => 0xd89e9cf3334914ea => 32
	i64 15690212772238353659, ; 190: ClosedXML.Parser.dll => 0xd9bed562d39064fb => 8
	i64 15777549416145007739, ; 191: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 84
	i64 15810740023422282496, ; 192: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 97
	i64 15817206913877585035, ; 193: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 2
	i64 16154507427712707110, ; 194: System => 0xe03056ea4e39aa26 => 32
	i64 16285414315415854695, ; 195: FontAwesome.Solid.dll => 0xe2016a093a6c5e67 => 12
	i64 16565028646146589191, ; 196: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 106
	i64 16621146507174665210, ; 197: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 54
	i64 16677317093839702854, ; 198: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 79
	i64 16707275818786907238, ; 199: ProyectoAsistencia.Android => 0xe7dc2ad697446466 => 0
	i64 16755018182064898362, ; 200: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 26
	i64 16822611501064131242, ; 201: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 102
	i64 16833383113903931215, ; 202: mscorlib => 0xe99c30c1484d7f4f => 17
	i64 17024911836938395553, ; 203: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 43
	i64 17031351772568316411, ; 204: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 77
	i64 17037200463775726619, ; 205: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 65
	i64 17272529741349494537, ; 206: ClosedXML => 0xefb45a4935819f09 => 7
	i64 17544493274320527064, ; 207: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 48
	i64 17704177640604968747, ; 208: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 73
	i64 17710060891934109755, ; 209: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 71
	i64 17838668724098252521, ; 210: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 30
	i64 17882897186074144999, ; 211: FormsViewGroup => 0xf82cd03e3ac830e7 => 13
	i64 17892495832318972303, ; 212: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 97
	i64 17928294245072900555, ; 213: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 105
	i64 18116111925905154859, ; 214: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 47
	i64 18121036031235206392, ; 215: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 77
	i64 18129453464017766560, ; 216: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 108
	i64 18284618658670613420, ; 217: System.IO.Packaging.dll => 0xfdc003cb438a93ac => 33
	i64 18305135509493619199, ; 218: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 78
	i64 18341799084585866416, ; 219: DocumentFormat.OpenXml.Framework => 0xfe8b2916a25354b0 => 10
	i64 18370042311372477656, ; 220: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 27
	i64 18380184030268848184 ; 221: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 90
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [222 x i32] [
	i32 61, i32 16, i32 51, i32 83, i32 84, i32 14, i32 70, i32 103, ; 0..7
	i32 23, i32 64, i32 27, i32 60, i32 101, i32 96, i32 110, i32 98, ; 8..15
	i32 26, i32 46, i32 5, i32 28, i32 44, i32 72, i32 65, i32 34, ; 16..23
	i32 45, i32 83, i32 10, i32 42, i32 71, i32 76, i32 49, i32 9, ; 24..31
	i32 60, i32 107, i32 3, i32 68, i32 37, i32 29, i32 55, i32 88, ; 32..39
	i32 6, i32 38, i32 41, i32 39, i32 17, i32 22, i32 80, i32 37, ; 40..47
	i32 94, i32 98, i32 67, i32 43, i32 36, i32 86, i32 85, i32 35, ; 48..55
	i32 38, i32 21, i32 1, i32 82, i32 61, i32 34, i32 25, i32 11, ; 56..63
	i32 108, i32 90, i32 48, i32 41, i32 85, i32 20, i32 20, i32 95, ; 64..71
	i32 93, i32 74, i32 75, i32 88, i32 87, i32 54, i32 31, i32 92, ; 72..79
	i32 52, i32 11, i32 80, i32 12, i32 69, i32 96, i32 13, i32 25, ; 80..87
	i32 70, i32 68, i32 49, i32 58, i32 107, i32 64, i32 8, i32 40, ; 88..95
	i32 36, i32 66, i32 63, i32 3, i32 40, i32 94, i32 93, i32 4, ; 96..103
	i32 100, i32 44, i32 7, i32 106, i32 67, i32 102, i32 15, i32 53, ; 104..111
	i32 79, i32 19, i32 87, i32 15, i32 78, i32 105, i32 92, i32 45, ; 112..119
	i32 18, i32 109, i32 35, i32 55, i32 75, i32 16, i32 52, i32 101, ; 120..127
	i32 110, i32 4, i32 58, i32 86, i32 56, i32 33, i32 14, i32 46, ; 128..135
	i32 31, i32 39, i32 91, i32 57, i32 81, i32 91, i32 66, i32 42, ; 136..143
	i32 1, i32 63, i32 24, i32 2, i32 24, i32 18, i32 30, i32 89, ; 144..151
	i32 28, i32 62, i32 73, i32 59, i32 50, i32 104, i32 51, i32 109, ; 152..159
	i32 103, i32 23, i32 29, i32 0, i32 5, i32 89, i32 53, i32 99, ; 160..167
	i32 47, i32 82, i32 21, i32 100, i32 62, i32 95, i32 19, i32 50, ; 168..175
	i32 9, i32 6, i32 76, i32 81, i32 69, i32 74, i32 99, i32 57, ; 176..183
	i32 104, i32 59, i32 22, i32 56, i32 72, i32 32, i32 8, i32 84, ; 184..191
	i32 97, i32 2, i32 32, i32 12, i32 106, i32 54, i32 79, i32 0, ; 192..199
	i32 26, i32 102, i32 17, i32 43, i32 77, i32 65, i32 7, i32 48, ; 200..207
	i32 73, i32 71, i32 30, i32 13, i32 97, i32 105, i32 47, i32 77, ; 208..215
	i32 108, i32 33, i32 78, i32 10, i32 27, i32 90 ; 216..221
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
