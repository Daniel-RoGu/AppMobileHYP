; ModuleID = 'obj\Release\130\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Release\130\android\marshal_methods.arm64-v8a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [132 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 13
	i64 232391251801502327, ; 1: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 51
	i64 612191770061699990, ; 2: IconFontHelper => 0x87ef12bdcf1fb96 => 11
	i64 702024105029695270, ; 3: System.Drawing.Common => 0x9be17343c0e7726 => 62
	i64 710500338161506772, ; 4: SixLabors.Fonts.dll => 0x9dc344b0ce959d4 => 20
	i64 720058930071658100, ; 5: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 45
	i64 870603111519317375, ; 6: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 24
	i64 872800313462103108, ; 7: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 43
	i64 996343623809489702, ; 8: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 57
	i64 1000557547492888992, ; 9: Mono.Security.dll => 0xde2b1c9cba651a0 => 65
	i64 1120440138749646132, ; 10: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 59
	i64 1301485588176585670, ; 11: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 23
	i64 1425944114962822056, ; 12: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 2
	i64 1518315023656898250, ; 13: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 25
	i64 1624659445732251991, ; 14: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 36
	i64 1795316252682057001, ; 15: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 37
	i64 1836611346387731153, ; 16: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 51
	i64 1847446322536158010, ; 17: DocumentFormat.OpenXml.Framework.dll => 0x19a372a4645e933a => 7
	i64 1981742497975770890, ; 18: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 48
	i64 2165725771938924357, ; 19: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 38
	i64 2207662933261301575, ; 20: DocumentFormat.OpenXml => 0x1ea331bdb8d63747 => 6
	i64 2262844636196693701, ; 21: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 43
	i64 2329709569556905518, ; 22: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 47
	i64 2337758774805907496, ; 23: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 32
	i64 2466404685302267823, ; 24: SshNet.Security.Cryptography.dll => 0x223a6dfe63ccffaf => 26
	i64 2470498323731680442, ; 25: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 40
	i64 2489738558632930771, ; 26: Acr.UserDialogs.dll => 0x228d540722e8add3 => 3
	i64 2547086958574651984, ; 27: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 35
	i64 2592350477072141967, ; 28: System.Xml.dll => 0x23f9e10627330e8f => 33
	i64 2624866290265602282, ; 29: mscorlib.dll => 0x246d65fbde2db8ea => 14
	i64 2646133429690896551, ; 30: Renci.SshNet.dll => 0x24b8f455a10310a7 => 19
	i64 2783046991838674048, ; 31: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 32
	i64 2960931600190307745, ; 32: Xamarin.Forms.Core => 0x2917579a49927da1 => 55
	i64 3017704767998173186, ; 33: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 59
	i64 3289520064315143713, ; 34: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 46
	i64 3522470458906976663, ; 35: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 52
	i64 3531994851595924923, ; 36: System.Numerics => 0x31042a9aade235bb => 31
	i64 3649596011227041021, ; 37: Renci.SshNet.Async.dll => 0x32a5f83c5edeccfd => 18
	i64 3727469159507183293, ; 38: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 50
	i64 4337444564132831293, ; 39: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 22
	i64 4376937205476565312, ; 40: ExcelNumberFormat.dll => 0x3cbe0132c89f2140 => 8
	i64 4525561845656915374, ; 41: System.ServiceModel.Internals => 0x3ece06856b710dae => 64
	i64 4794310189461587505, ; 42: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 35
	i64 4795410492532947900, ; 43: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 52
	i64 4801557006133399896, ; 44: Renci.SshNet.Abstractions.dll => 0x42a28ea8475e9158 => 17
	i64 4918220242611126976, ; 45: Renci.SshNet.Abstractions => 0x44410740b7f8c2c0 => 17
	i64 5142919913060024034, ; 46: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 56
	i64 5203618020066742981, ; 47: Xamarin.Essentials => 0x4836f704f0e652c5 => 54
	i64 5507995362134886206, ; 48: System.Core.dll => 0x4c705499688c873e => 28
	i64 5796442605724717762, ; 49: ExcelNumberFormat => 0x507119d6cb2952c2 => 8
	i64 5891064157251515650, ; 50: FontAwesome.Solid => 0x51c143a38a033502 => 9
	i64 6085203216496545422, ; 51: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 57
	i64 6086316965293125504, ; 52: FormsViewGroup.dll => 0x5476f10882baef80 => 10
	i64 6183170893902868313, ; 53: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 22
	i64 6401687960814735282, ; 54: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 47
	i64 6504860066809920875, ; 55: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 38
	i64 6548213210057960872, ; 56: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 42
	i64 6659513131007730089, ; 57: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 45
	i64 6802026988460721845, ; 58: ClosedXML.Parser => 0x5e65a781dfd246b5 => 5
	i64 6876862101832370452, ; 59: System.Xml.Linq => 0x5f6f85a57d108914 => 34
	i64 7488575175965059935, ; 60: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 34
	i64 7635363394907363464, ; 61: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 55
	i64 7637365915383206639, ; 62: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 54
	i64 7654504624184590948, ; 63: System.Net.Http => 0x6a3a4366801b8264 => 1
	i64 7820441508502274321, ; 64: System.Data => 0x6c87ca1e14ff8111 => 61
	i64 7836164640616011524, ; 65: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 36
	i64 8012566953210257060, ; 66: ClosedXML.dll => 0x6f325b3109219ea4 => 4
	i64 8083354569033831015, ; 67: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 46
	i64 8167236081217502503, ; 68: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 12
	i64 8565268909422235801, ; 69: RBush => 0x76ddf2b13fcf5099 => 16
	i64 8626175481042262068, ; 70: Java.Interop => 0x77b654e585b55834 => 12
	i64 9324707631942237306, ; 71: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 37
	i64 9437276146080163066, ; 72: ProyectoAsistencia.dll => 0x82f7f0a76e6024fa => 15
	i64 9662334977499516867, ; 73: System.Numerics.dll => 0x8617827802b0cfc3 => 31
	i64 9678050649315576968, ; 74: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 40
	i64 9808709177481450983, ; 75: Mono.Android.dll => 0x881f890734e555e7 => 13
	i64 9998632235833408227, ; 76: Mono.Security => 0x8ac2470b209ebae3 => 65
	i64 10038780035334861115, ; 77: System.Net.Http.dll => 0x8b50e941206af13b => 1
	i64 10229024438826829339, ; 78: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 42
	i64 10430153318873392755, ; 79: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 41
	i64 10650478070646097812, ; 80: System.IO.Packaging => 0x93ce196068f2c794 => 30
	i64 10842690581852095141, ; 81: IconFontHelper.dll => 0x9678f9a31cc482a5 => 11
	i64 11023048688141570732, ; 82: System.Core => 0x98f9bc61168392ac => 28
	i64 11037814507248023548, ; 83: System.Xml => 0x992e31d0412bf7fc => 33
	i64 11162124722117608902, ; 84: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 53
	i64 11529969570048099689, ; 85: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 53
	i64 11739066727115742305, ; 86: SQLite-net.dll => 0xa2e98afdf8575c61 => 21
	i64 11806260347154423189, ; 87: SQLite-net => 0xa3d8433bc5eb5d95 => 21
	i64 11857165743280931573, ; 88: ProyectoAsistencia => 0xa48d1d6beb30c2f5 => 15
	i64 12102847907131387746, ; 89: System.Buffers => 0xa7f5f40c43256f62 => 27
	i64 12279246230491828964, ; 90: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 25
	i64 12451044538927396471, ; 91: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 44
	i64 12466513435562512481, ; 92: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 49
	i64 12538491095302438457, ; 93: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 39
	i64 12550732019250633519, ; 94: System.IO.Compression => 0xae2d28465e8e1b2f => 63
	i64 12963446364377008305, ; 95: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 62
	i64 13109727801987935684, ; 96: SixLabors.Fonts => 0xb5ef1bfa438dadc4 => 20
	i64 13153566470908607129, ; 97: SshNet.Security.Cryptography => 0xb68adb03c3fefa99 => 26
	i64 13354776597879105185, ; 98: ProyectoAsistencia.Android.dll => 0xb955b28f2348a6a1 => 0
	i64 13370592475155966277, ; 99: System.Runtime.Serialization => 0xb98de304062ea945 => 2
	i64 13454009404024712428, ; 100: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 60
	i64 13572454107664307259, ; 101: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 50
	i64 13613826926226999557, ; 102: Renci.SshNet.Async => 0xbcee0775d3688905 => 18
	i64 13647894001087880694, ; 103: System.Data.dll => 0xbd670f48cb071df6 => 61
	i64 13959074834287824816, ; 104: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 44
	i64 13967638549803255703, ; 105: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 56
	i64 14065717908940967541, ; 106: RBush.dll => 0xc33377ea3146ce75 => 16
	i64 14124974489674258913, ; 107: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 39
	i64 14148919944076435199, ; 108: DocumentFormat.OpenXml.dll => 0xc45b0fb9961d9eff => 6
	i64 14161076099266624234, ; 109: Acr.UserDialogs => 0xc4863faf060fbaea => 3
	i64 14792063746108907174, ; 110: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 60
	i64 14987728460634540364, ; 111: System.IO.Compression.dll => 0xcfff1ba06622494c => 63
	i64 15044096739141154273, ; 112: Renci.SshNet => 0xd0c75e46f71ef5e1 => 19
	i64 15370334346939861994, ; 113: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 41
	i64 15609085926864131306, ; 114: System.dll => 0xd89e9cf3334914ea => 29
	i64 15690212772238353659, ; 115: ClosedXML.Parser.dll => 0xd9bed562d39064fb => 5
	i64 15810740023422282496, ; 116: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 58
	i64 16154507427712707110, ; 117: System => 0xe03056ea4e39aa26 => 29
	i64 16285414315415854695, ; 118: FontAwesome.Solid.dll => 0xe2016a093a6c5e67 => 9
	i64 16707275818786907238, ; 119: ProyectoAsistencia.Android => 0xe7dc2ad697446466 => 0
	i64 16755018182064898362, ; 120: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 23
	i64 16833383113903931215, ; 121: mscorlib => 0xe99c30c1484d7f4f => 14
	i64 17272529741349494537, ; 122: ClosedXML => 0xefb45a4935819f09 => 4
	i64 17704177640604968747, ; 123: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 49
	i64 17710060891934109755, ; 124: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 48
	i64 17838668724098252521, ; 125: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 27
	i64 17882897186074144999, ; 126: FormsViewGroup => 0xf82cd03e3ac830e7 => 10
	i64 17892495832318972303, ; 127: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 58
	i64 18129453464017766560, ; 128: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 64
	i64 18284618658670613420, ; 129: System.IO.Packaging.dll => 0xfdc003cb438a93ac => 30
	i64 18341799084585866416, ; 130: DocumentFormat.OpenXml.Framework => 0xfe8b2916a25354b0 => 7
	i64 18370042311372477656 ; 131: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 24
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [132 x i32] [
	i32 13, i32 51, i32 11, i32 62, i32 20, i32 45, i32 24, i32 43, ; 0..7
	i32 57, i32 65, i32 59, i32 23, i32 2, i32 25, i32 36, i32 37, ; 8..15
	i32 51, i32 7, i32 48, i32 38, i32 6, i32 43, i32 47, i32 32, ; 16..23
	i32 26, i32 40, i32 3, i32 35, i32 33, i32 14, i32 19, i32 32, ; 24..31
	i32 55, i32 59, i32 46, i32 52, i32 31, i32 18, i32 50, i32 22, ; 32..39
	i32 8, i32 64, i32 35, i32 52, i32 17, i32 17, i32 56, i32 54, ; 40..47
	i32 28, i32 8, i32 9, i32 57, i32 10, i32 22, i32 47, i32 38, ; 48..55
	i32 42, i32 45, i32 5, i32 34, i32 34, i32 55, i32 54, i32 1, ; 56..63
	i32 61, i32 36, i32 4, i32 46, i32 12, i32 16, i32 12, i32 37, ; 64..71
	i32 15, i32 31, i32 40, i32 13, i32 65, i32 1, i32 42, i32 41, ; 72..79
	i32 30, i32 11, i32 28, i32 33, i32 53, i32 53, i32 21, i32 21, ; 80..87
	i32 15, i32 27, i32 25, i32 44, i32 49, i32 39, i32 63, i32 62, ; 88..95
	i32 20, i32 26, i32 0, i32 2, i32 60, i32 50, i32 18, i32 61, ; 96..103
	i32 44, i32 56, i32 16, i32 39, i32 6, i32 3, i32 60, i32 63, ; 104..111
	i32 19, i32 41, i32 29, i32 5, i32 58, i32 29, i32 9, i32 0, ; 112..119
	i32 23, i32 14, i32 4, i32 49, i32 48, i32 27, i32 10, i32 58, ; 120..127
	i32 64, i32 30, i32 7, i32 24 ; 128..131
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
