; ModuleID = 'obj\Release\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Release\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [132 x i32] [
	i32 34715100, ; 0: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 60
	i32 57263871, ; 1: Xamarin.Forms.Core.dll => 0x369c6ff => 55
	i32 88799905, ; 2: Acr.UserDialogs => 0x54afaa1 => 3
	i32 182336117, ; 3: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 52
	i32 209399409, ; 4: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 38
	i32 259900074, ; 5: Renci.SshNet.Abstractions.dll => 0xf7dc2aa => 17
	i32 261882112, ; 6: DocumentFormat.OpenXml.Framework.dll => 0xf9c0100 => 7
	i32 318968648, ; 7: Xamarin.AndroidX.Activity.dll => 0x13031348 => 35
	i32 321597661, ; 8: System.Numerics => 0x132b30dd => 31
	i32 331603304, ; 9: SixLabors.Fonts => 0x13c3dd68 => 20
	i32 342366114, ; 10: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 46
	i32 347068432, ; 11: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 24
	i32 442521989, ; 12: Xamarin.Essentials => 0x1a605985 => 54
	i32 450948140, ; 13: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 44
	i32 465846621, ; 14: mscorlib => 0x1bc4415d => 14
	i32 469710990, ; 15: System.dll => 0x1bff388e => 29
	i32 627609679, ; 16: Xamarin.AndroidX.CustomView => 0x2568904f => 42
	i32 690569205, ; 17: System.Xml.Linq.dll => 0x29293ff5 => 34
	i32 691439157, ; 18: Acr.UserDialogs.dll => 0x29368635 => 3
	i32 748832960, ; 19: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 22
	i32 775507847, ; 20: System.IO.Compression => 0x2e394f87 => 63
	i32 809851609, ; 21: System.Drawing.Common.dll => 0x30455ad9 => 62
	i32 928116545, ; 22: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 60
	i32 967690846, ; 23: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 46
	i32 974778368, ; 24: FormsViewGroup.dll => 0x3a19f000 => 10
	i32 1012816738, ; 25: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 51
	i32 1035644815, ; 26: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 37
	i32 1042160112, ; 27: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 57
	i32 1052210849, ; 28: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 48
	i32 1083751839, ; 29: System.IO.Packaging => 0x4098bd9f => 30
	i32 1098259244, ; 30: System => 0x41761b2c => 29
	i32 1209675182, ; 31: SshNet.Security.Cryptography => 0x481a2dae => 26
	i32 1292207520, ; 32: SQLitePCLRaw.core.dll => 0x4d0585a0 => 23
	i32 1292843635, ; 33: DocumentFormat.OpenXml.Framework => 0x4d0f3a73 => 7
	i32 1293217323, ; 34: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 43
	i32 1338318188, ; 35: ExcelNumberFormat.dll => 0x4fc51d6c => 8
	i32 1338781641, ; 36: DocumentFormat.OpenXml.dll => 0x4fcc2fc9 => 6
	i32 1344037063, ; 37: ProyectoAsistencia.Android => 0x501c60c7 => 0
	i32 1360296438, ; 38: ProyectoAsistencia.Android.dll => 0x511479f6 => 0
	i32 1365406463, ; 39: System.ServiceModel.Internals.dll => 0x516272ff => 64
	i32 1376866003, ; 40: Xamarin.AndroidX.SavedState => 0x52114ed3 => 51
	i32 1390396154, ; 41: ClosedXML.Parser.dll => 0x52dfc2fa => 5
	i32 1406073936, ; 42: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 40
	i32 1411638395, ; 43: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 32
	i32 1460219004, ; 44: Xamarin.Forms.Xaml => 0x57092c7c => 58
	i32 1462112819, ; 45: System.IO.Compression.dll => 0x57261233 => 63
	i32 1469204771, ; 46: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 36
	i32 1592978981, ; 47: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1622152042, ; 48: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 49
	i32 1639515021, ; 49: System.Net.Http.dll => 0x61b9038d => 1
	i32 1658251792, ; 50: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 59
	i32 1711441057, ; 51: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 24
	i32 1729485958, ; 52: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 39
	i32 1766324549, ; 53: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 52
	i32 1776026572, ; 54: System.Core.dll => 0x69dc03cc => 28
	i32 1788241197, ; 55: Xamarin.AndroidX.Fragment => 0x6a96652d => 44
	i32 1808609942, ; 56: Xamarin.AndroidX.Loader => 0x6bcd3296 => 49
	i32 1813201214, ; 57: Xamarin.Google.Android.Material => 0x6c13413e => 59
	i32 1866604563, ; 58: RBush.dll => 0x6f422013 => 16
	i32 1867746548, ; 59: Xamarin.Essentials.dll => 0x6f538cf4 => 54
	i32 1878053835, ; 60: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 58
	i32 2011961780, ; 61: System.Buffers.dll => 0x77ec19b4 => 27
	i32 2019465201, ; 62: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 48
	i32 2055257422, ; 63: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 47
	i32 2097448633, ; 64: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 45
	i32 2103459038, ; 65: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 25
	i32 2126786730, ; 66: Xamarin.Forms.Platform.Android => 0x7ec430aa => 56
	i32 2166698602, ; 67: ClosedXML => 0x8125326a => 4
	i32 2201231467, ; 68: System.Net.Http => 0x8334206b => 1
	i32 2279755925, ; 69: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 50
	i32 2465273461, ; 70: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 22
	i32 2475788418, ; 71: Java.Interop.dll => 0x93918882 => 12
	i32 2575163826, ; 72: Renci.SshNet.Async.dll => 0x997de1b2 => 18
	i32 2673807045, ; 73: RBush => 0x9f5f0ec5 => 16
	i32 2732626843, ; 74: Xamarin.AndroidX.Activity => 0xa2e0939b => 35
	i32 2737747696, ; 75: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 36
	i32 2762883799, ; 76: Renci.SshNet.Abstractions => 0xa4ae42d7 => 17
	i32 2766581644, ; 77: Xamarin.Forms.Core => 0xa4e6af8c => 55
	i32 2778768386, ; 78: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 53
	i32 2810250172, ; 79: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 40
	i32 2819470561, ; 80: System.Xml.dll => 0xa80db4e1 => 33
	i32 2853208004, ; 81: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 53
	i32 2877542466, ; 82: ClosedXML.dll => 0xab83d042 => 4
	i32 2905242038, ; 83: mscorlib.dll => 0xad2a79b6 => 14
	i32 2917947938, ; 84: ProyectoAsistencia => 0xadec5a22 => 15
	i32 2978675010, ; 85: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 43
	i32 3034446096, ; 86: SshNet.Security.Cryptography.dll => 0xb4ddf910 => 26
	i32 3044182254, ; 87: FormsViewGroup => 0xb57288ee => 10
	i32 3111772706, ; 88: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3115974355, ; 89: IconFontHelper => 0xb9b9fed3 => 11
	i32 3118851116, ; 90: ExcelNumberFormat => 0xb9e5e42c => 8
	i32 3148095383, ; 91: Renci.SshNet.dll => 0xbba41f97 => 19
	i32 3178908327, ; 92: SixLabors.Fonts.dll => 0xbd7a4aa7 => 20
	i32 3204380047, ; 93: System.Data.dll => 0xbefef58f => 61
	i32 3247949154, ; 94: Mono.Security => 0xc197c562 => 65
	i32 3258312781, ; 95: Xamarin.AndroidX.CardView => 0xc235e84d => 39
	i32 3286872994, ; 96: SQLite-net.dll => 0xc3e9b3a2 => 21
	i32 3317135071, ; 97: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 42
	i32 3317144872, ; 98: System.Data => 0xc5b79d28 => 61
	i32 3353484488, ; 99: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 45
	i32 3360279109, ; 100: SQLitePCLRaw.core => 0xc849ca45 => 23
	i32 3362522851, ; 101: Xamarin.AndroidX.Core => 0xc86c06e3 => 41
	i32 3366347497, ; 102: Java.Interop => 0xc8a662e9 => 12
	i32 3374999561, ; 103: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 50
	i32 3390289853, ; 104: Renci.SshNet => 0xca13b7bd => 19
	i32 3395150330, ; 105: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 32
	i32 3401615630, ; 106: IconFontHelper.dll => 0xcac0890e => 11
	i32 3404865022, ; 107: System.ServiceModel.Internals => 0xcaf21dfe => 64
	i32 3411732934, ; 108: Renci.SshNet.Async => 0xcb5ae9c6 => 18
	i32 3429136800, ; 109: System.Xml => 0xcc6479a0 => 33
	i32 3476120550, ; 110: Mono.Android => 0xcf3163e6 => 13
	i32 3509114376, ; 111: System.Xml.Linq => 0xd128d608 => 34
	i32 3536029504, ; 112: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 56
	i32 3581231576, ; 113: ClosedXML.Parser => 0xd57541d8 => 5
	i32 3615857585, ; 114: FontAwesome.Solid.dll => 0xd7859bb1 => 9
	i32 3630662277, ; 115: FontAwesome.Solid => 0xd8678285 => 9
	i32 3632359727, ; 116: Xamarin.Forms.Platform => 0xd881692f => 57
	i32 3641597786, ; 117: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 47
	i32 3672681054, ; 118: Mono.Android.dll => 0xdae8aa5e => 13
	i32 3682565725, ; 119: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 38
	i32 3689375977, ; 120: System.Drawing.Common => 0xdbe768e9 => 62
	i32 3754567612, ; 121: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 25
	i32 3822443793, ; 122: DocumentFormat.OpenXml => 0xe3d5dd11 => 6
	i32 3829621856, ; 123: System.Numerics.dll => 0xe4436460 => 31
	i32 3876362041, ; 124: SQLite-net => 0xe70c9739 => 21
	i32 3896760992, ; 125: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 41
	i32 3952357212, ; 126: System.IO.Packaging.dll => 0xeb942f5c => 30
	i32 3955647286, ; 127: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 37
	i32 4035653707, ; 128: ProyectoAsistencia.dll => 0xf08b304b => 15
	i32 4105002889, ; 129: Mono.Security.dll => 0xf4ad5f89 => 65
	i32 4151237749, ; 130: System.Core => 0xf76edc75 => 28
	i32 4260525087 ; 131: System.Buffers => 0xfdf2741f => 27
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [132 x i32] [
	i32 60, i32 55, i32 3, i32 52, i32 38, i32 17, i32 7, i32 35, ; 0..7
	i32 31, i32 20, i32 46, i32 24, i32 54, i32 44, i32 14, i32 29, ; 8..15
	i32 42, i32 34, i32 3, i32 22, i32 63, i32 62, i32 60, i32 46, ; 16..23
	i32 10, i32 51, i32 37, i32 57, i32 48, i32 30, i32 29, i32 26, ; 24..31
	i32 23, i32 7, i32 43, i32 8, i32 6, i32 0, i32 0, i32 64, ; 32..39
	i32 51, i32 5, i32 40, i32 32, i32 58, i32 63, i32 36, i32 2, ; 40..47
	i32 49, i32 1, i32 59, i32 24, i32 39, i32 52, i32 28, i32 44, ; 48..55
	i32 49, i32 59, i32 16, i32 54, i32 58, i32 27, i32 48, i32 47, ; 56..63
	i32 45, i32 25, i32 56, i32 4, i32 1, i32 50, i32 22, i32 12, ; 64..71
	i32 18, i32 16, i32 35, i32 36, i32 17, i32 55, i32 53, i32 40, ; 72..79
	i32 33, i32 53, i32 4, i32 14, i32 15, i32 43, i32 26, i32 10, ; 80..87
	i32 2, i32 11, i32 8, i32 19, i32 20, i32 61, i32 65, i32 39, ; 88..95
	i32 21, i32 42, i32 61, i32 45, i32 23, i32 41, i32 12, i32 50, ; 96..103
	i32 19, i32 32, i32 11, i32 64, i32 18, i32 33, i32 13, i32 34, ; 104..111
	i32 56, i32 5, i32 9, i32 9, i32 57, i32 47, i32 13, i32 38, ; 112..119
	i32 62, i32 25, i32 6, i32 31, i32 21, i32 41, i32 30, i32 37, ; 120..127
	i32 15, i32 65, i32 28, i32 27 ; 128..131
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
