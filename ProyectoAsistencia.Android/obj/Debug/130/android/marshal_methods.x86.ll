; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


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
@assembly_image_cache_hashes = local_unnamed_addr constant [222 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 70
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 99
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 94
	i32 88799905, ; 3: Acr.UserDialogs => 0x54afaa1 => 6
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 84
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 84
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 51
	i32 182336117, ; 7: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 85
	i32 209399409, ; 8: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 49
	i32 230216969, ; 9: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 65
	i32 232815796, ; 10: System.Web.Services => 0xde07cb4 => 107
	i32 259900074, ; 11: Renci.SshNet.Abstractions.dll => 0xf7dc2aa => 20
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 54
	i32 261882112, ; 13: DocumentFormat.OpenXml.Framework.dll => 0xf9c0100 => 10
	i32 278686392, ; 14: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 69
	i32 280482487, ; 15: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 63
	i32 318968648, ; 16: Xamarin.AndroidX.Activity.dll => 0x13031348 => 41
	i32 321597661, ; 17: System.Numerics => 0x132b30dd => 35
	i32 331603304, ; 18: SixLabors.Fonts => 0x13c3dd68 => 23
	i32 342366114, ; 19: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 67
	i32 347068432, ; 20: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 27
	i32 385762202, ; 21: System.Memory.dll => 0x16fe439a => 34
	i32 441335492, ; 22: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 53
	i32 442521989, ; 23: Xamarin.Essentials => 0x1a605985 => 93
	i32 450948140, ; 24: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 62
	i32 465846621, ; 25: mscorlib => 0x1bc4415d => 17
	i32 469710990, ; 26: System.dll => 0x1bff388e => 32
	i32 476646585, ; 27: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 63
	i32 486930444, ; 28: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 74
	i32 526420162, ; 29: System.Transactions.dll => 0x1f6088c2 => 101
	i32 540030774, ; 30: System.IO.FileSystem.dll => 0x20303736 => 3
	i32 605376203, ; 31: System.IO.Compression.FileSystem => 0x24154ecb => 105
	i32 627609679, ; 32: Xamarin.AndroidX.CustomView => 0x2568904f => 58
	i32 663517072, ; 33: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 90
	i32 666292255, ; 34: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 46
	i32 690569205, ; 35: System.Xml.Linq.dll => 0x29293ff5 => 40
	i32 691439157, ; 36: Acr.UserDialogs.dll => 0x29368635 => 6
	i32 748832960, ; 37: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 25
	i32 775507847, ; 38: System.IO.Compression => 0x2e394f87 => 104
	i32 809851609, ; 39: System.Drawing.Common.dll => 0x30455ad9 => 103
	i32 843511501, ; 40: Xamarin.AndroidX.Print => 0x3246f6cd => 81
	i32 928116545, ; 41: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 99
	i32 967690846, ; 42: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 67
	i32 974778368, ; 43: FormsViewGroup.dll => 0x3a19f000 => 13
	i32 994442037, ; 44: System.IO.FileSystem => 0x3b45fb35 => 3
	i32 1012816738, ; 45: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 83
	i32 1035644815, ; 46: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 45
	i32 1042160112, ; 47: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 96
	i32 1052210849, ; 48: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 71
	i32 1083751839, ; 49: System.IO.Packaging => 0x4098bd9f => 33
	i32 1098259244, ; 50: System => 0x41761b2c => 32
	i32 1175144683, ; 51: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 88
	i32 1178241025, ; 52: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 78
	i32 1204270330, ; 53: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 46
	i32 1209675182, ; 54: SshNet.Security.Cryptography => 0x481a2dae => 29
	i32 1267360935, ; 55: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 89
	i32 1292207520, ; 56: SQLitePCLRaw.core.dll => 0x4d0585a0 => 26
	i32 1292843635, ; 57: DocumentFormat.OpenXml.Framework => 0x4d0f3a73 => 10
	i32 1293217323, ; 58: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 60
	i32 1338318188, ; 59: ExcelNumberFormat.dll => 0x4fc51d6c => 11
	i32 1338781641, ; 60: DocumentFormat.OpenXml.dll => 0x4fcc2fc9 => 9
	i32 1344037063, ; 61: ProyectoAsistencia.Android => 0x501c60c7 => 0
	i32 1360296438, ; 62: ProyectoAsistencia.Android.dll => 0x511479f6 => 0
	i32 1364015309, ; 63: System.IO => 0x514d38cd => 109
	i32 1365406463, ; 64: System.ServiceModel.Internals.dll => 0x516272ff => 108
	i32 1376866003, ; 65: Xamarin.AndroidX.SavedState => 0x52114ed3 => 83
	i32 1390396154, ; 66: ClosedXML.Parser.dll => 0x52dfc2fa => 8
	i32 1395857551, ; 67: Xamarin.AndroidX.Media.dll => 0x5333188f => 75
	i32 1406073936, ; 68: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 55
	i32 1411638395, ; 69: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 37
	i32 1460219004, ; 70: Xamarin.Forms.Xaml => 0x57092c7c => 97
	i32 1462112819, ; 71: System.IO.Compression.dll => 0x57261233 => 104
	i32 1469204771, ; 72: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 44
	i32 1582372066, ; 73: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 59
	i32 1592978981, ; 74: System.Runtime.Serialization.dll => 0x5ef2ee25 => 5
	i32 1622152042, ; 75: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 73
	i32 1624863272, ; 76: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 92
	i32 1636350590, ; 77: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 57
	i32 1639515021, ; 78: System.Net.Http.dll => 0x61b9038d => 4
	i32 1657153582, ; 79: System.Runtime => 0x62c6282e => 38
	i32 1658241508, ; 80: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 86
	i32 1658251792, ; 81: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 98
	i32 1670060433, ; 82: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 54
	i32 1711441057, ; 83: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 27
	i32 1729485958, ; 84: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 50
	i32 1766324549, ; 85: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 85
	i32 1776026572, ; 86: System.Core.dll => 0x69dc03cc => 31
	i32 1788241197, ; 87: Xamarin.AndroidX.Fragment => 0x6a96652d => 62
	i32 1808609942, ; 88: Xamarin.AndroidX.Loader => 0x6bcd3296 => 73
	i32 1813201214, ; 89: Xamarin.Google.Android.Material => 0x6c13413e => 98
	i32 1818569960, ; 90: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 79
	i32 1866604563, ; 91: RBush.dll => 0x6f422013 => 19
	i32 1867746548, ; 92: Xamarin.Essentials.dll => 0x6f538cf4 => 93
	i32 1878053835, ; 93: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 97
	i32 1885316902, ; 94: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 47
	i32 1919157823, ; 95: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 76
	i32 2011961780, ; 96: System.Buffers.dll => 0x77ec19b4 => 30
	i32 2019465201, ; 97: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 71
	i32 2055257422, ; 98: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 68
	i32 2079903147, ; 99: System.Runtime.dll => 0x7bf8cdab => 38
	i32 2090596640, ; 100: System.Numerics.Vectors => 0x7c9bf920 => 36
	i32 2097448633, ; 101: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 64
	i32 2103459038, ; 102: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 28
	i32 2126786730, ; 103: Xamarin.Forms.Platform.Android => 0x7ec430aa => 95
	i32 2166698602, ; 104: ClosedXML => 0x8125326a => 7
	i32 2201231467, ; 105: System.Net.Http => 0x8334206b => 4
	i32 2217644978, ; 106: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 88
	i32 2244775296, ; 107: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 74
	i32 2256548716, ; 108: Xamarin.AndroidX.MultiDex => 0x8680336c => 76
	i32 2261435625, ; 109: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 66
	i32 2279755925, ; 110: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 82
	i32 2315684594, ; 111: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 42
	i32 2409053734, ; 112: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 80
	i32 2465273461, ; 113: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 25
	i32 2465532216, ; 114: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 53
	i32 2471841756, ; 115: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 116: Java.Interop.dll => 0x93918882 => 15
	i32 2501346920, ; 117: System.Data.DataSetExtensions => 0x95178668 => 102
	i32 2505896520, ; 118: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 70
	i32 2575163826, ; 119: Renci.SshNet.Async.dll => 0x997de1b2 => 21
	i32 2581819634, ; 120: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 89
	i32 2620871830, ; 121: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 57
	i32 2624644809, ; 122: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 61
	i32 2633051222, ; 123: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 69
	i32 2673807045, ; 124: RBush => 0x9f5f0ec5 => 19
	i32 2693849962, ; 125: System.IO.dll => 0xa090e36a => 109
	i32 2701096212, ; 126: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 86
	i32 2715334215, ; 127: System.Threading.Tasks.dll => 0xa1d8b647 => 2
	i32 2732626843, ; 128: Xamarin.AndroidX.Activity => 0xa2e0939b => 41
	i32 2737747696, ; 129: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 44
	i32 2762883799, ; 130: Renci.SshNet.Abstractions => 0xa4ae42d7 => 20
	i32 2766581644, ; 131: Xamarin.Forms.Core => 0xa4e6af8c => 94
	i32 2778768386, ; 132: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 91
	i32 2810250172, ; 133: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 55
	i32 2819470561, ; 134: System.Xml.dll => 0xa80db4e1 => 39
	i32 2853208004, ; 135: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 91
	i32 2855708567, ; 136: Xamarin.AndroidX.Transition => 0xaa36a797 => 87
	i32 2877542466, ; 137: ClosedXML.dll => 0xab83d042 => 7
	i32 2903344695, ; 138: System.ComponentModel.Composition => 0xad0d8637 => 106
	i32 2905242038, ; 139: mscorlib.dll => 0xad2a79b6 => 17
	i32 2916838712, ; 140: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 92
	i32 2917947938, ; 141: ProyectoAsistencia => 0xadec5a22 => 18
	i32 2919462931, ; 142: System.Numerics.Vectors.dll => 0xae037813 => 36
	i32 2921128767, ; 143: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 43
	i32 2978675010, ; 144: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 60
	i32 3024354802, ; 145: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 65
	i32 3034446096, ; 146: SshNet.Security.Cryptography.dll => 0xb4ddf910 => 29
	i32 3044182254, ; 147: FormsViewGroup => 0xb57288ee => 13
	i32 3057625584, ; 148: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 77
	i32 3075834255, ; 149: System.Threading.Tasks => 0xb755818f => 2
	i32 3111772706, ; 150: System.Runtime.Serialization => 0xb979e222 => 5
	i32 3115974355, ; 151: IconFontHelper => 0xb9b9fed3 => 14
	i32 3118851116, ; 152: ExcelNumberFormat => 0xb9e5e42c => 11
	i32 3148095383, ; 153: Renci.SshNet.dll => 0xbba41f97 => 22
	i32 3178908327, ; 154: SixLabors.Fonts.dll => 0xbd7a4aa7 => 23
	i32 3204380047, ; 155: System.Data.dll => 0xbefef58f => 100
	i32 3211777861, ; 156: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 59
	i32 3247949154, ; 157: Mono.Security => 0xc197c562 => 110
	i32 3258312781, ; 158: Xamarin.AndroidX.CardView => 0xc235e84d => 50
	i32 3267021929, ; 159: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 48
	i32 3286872994, ; 160: SQLite-net.dll => 0xc3e9b3a2 => 24
	i32 3317135071, ; 161: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 58
	i32 3317144872, ; 162: System.Data => 0xc5b79d28 => 100
	i32 3340431453, ; 163: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 47
	i32 3346324047, ; 164: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 78
	i32 3353484488, ; 165: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 64
	i32 3360279109, ; 166: SQLitePCLRaw.core => 0xc849ca45 => 26
	i32 3362522851, ; 167: Xamarin.AndroidX.Core => 0xc86c06e3 => 56
	i32 3366347497, ; 168: Java.Interop => 0xc8a662e9 => 15
	i32 3374999561, ; 169: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 82
	i32 3390289853, ; 170: Renci.SshNet => 0xca13b7bd => 22
	i32 3395150330, ; 171: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 37
	i32 3401615630, ; 172: IconFontHelper.dll => 0xcac0890e => 14
	i32 3404865022, ; 173: System.ServiceModel.Internals => 0xcaf21dfe => 108
	i32 3411732934, ; 174: Renci.SshNet.Async => 0xcb5ae9c6 => 21
	i32 3429136800, ; 175: System.Xml => 0xcc6479a0 => 39
	i32 3430777524, ; 176: netstandard => 0xcc7d82b4 => 1
	i32 3441283291, ; 177: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 61
	i32 3476120550, ; 178: Mono.Android => 0xcf3163e6 => 16
	i32 3486566296, ; 179: System.Transactions => 0xcfd0c798 => 101
	i32 3493954962, ; 180: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 52
	i32 3501239056, ; 181: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 48
	i32 3509114376, ; 182: System.Xml.Linq => 0xd128d608 => 40
	i32 3536029504, ; 183: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 95
	i32 3567349600, ; 184: System.ComponentModel.Composition.dll => 0xd4a16f60 => 106
	i32 3581231576, ; 185: ClosedXML.Parser => 0xd57541d8 => 8
	i32 3615857585, ; 186: FontAwesome.Solid.dll => 0xd7859bb1 => 12
	i32 3618140916, ; 187: Xamarin.AndroidX.Preference => 0xd7a872f4 => 80
	i32 3627220390, ; 188: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 81
	i32 3630662277, ; 189: FontAwesome.Solid => 0xd8678285 => 12
	i32 3632359727, ; 190: Xamarin.Forms.Platform => 0xd881692f => 96
	i32 3633644679, ; 191: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 43
	i32 3641597786, ; 192: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 68
	i32 3672681054, ; 193: Mono.Android.dll => 0xdae8aa5e => 16
	i32 3676310014, ; 194: System.Web.Services.dll => 0xdb2009fe => 107
	i32 3682565725, ; 195: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 49
	i32 3684561358, ; 196: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 52
	i32 3689375977, ; 197: System.Drawing.Common => 0xdbe768e9 => 103
	i32 3718780102, ; 198: Xamarin.AndroidX.Annotation => 0xdda814c6 => 42
	i32 3724971120, ; 199: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 77
	i32 3754567612, ; 200: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 28
	i32 3758932259, ; 201: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 66
	i32 3786282454, ; 202: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 51
	i32 3822443793, ; 203: DocumentFormat.OpenXml => 0xe3d5dd11 => 9
	i32 3822602673, ; 204: Xamarin.AndroidX.Media => 0xe3d849b1 => 75
	i32 3829621856, ; 205: System.Numerics.dll => 0xe4436460 => 35
	i32 3876362041, ; 206: SQLite-net => 0xe70c9739 => 24
	i32 3885922214, ; 207: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 87
	i32 3896760992, ; 208: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 56
	i32 3920810846, ; 209: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 105
	i32 3921031405, ; 210: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 90
	i32 3931092270, ; 211: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 79
	i32 3945713374, ; 212: System.Data.DataSetExtensions.dll => 0xeb2ecede => 102
	i32 3952357212, ; 213: System.IO.Packaging.dll => 0xeb942f5c => 33
	i32 3955647286, ; 214: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 45
	i32 4025784931, ; 215: System.Memory => 0xeff49a63 => 34
	i32 4035653707, ; 216: ProyectoAsistencia.dll => 0xf08b304b => 18
	i32 4105002889, ; 217: Mono.Security.dll => 0xf4ad5f89 => 110
	i32 4151237749, ; 218: System.Core => 0xf76edc75 => 31
	i32 4182413190, ; 219: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 72
	i32 4260525087, ; 220: System.Buffers => 0xfdf2741f => 30
	i32 4292120959 ; 221: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 72
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [222 x i32] [
	i32 70, i32 99, i32 94, i32 6, i32 84, i32 84, i32 51, i32 85, ; 0..7
	i32 49, i32 65, i32 107, i32 20, i32 54, i32 10, i32 69, i32 63, ; 8..15
	i32 41, i32 35, i32 23, i32 67, i32 27, i32 34, i32 53, i32 93, ; 16..23
	i32 62, i32 17, i32 32, i32 63, i32 74, i32 101, i32 3, i32 105, ; 24..31
	i32 58, i32 90, i32 46, i32 40, i32 6, i32 25, i32 104, i32 103, ; 32..39
	i32 81, i32 99, i32 67, i32 13, i32 3, i32 83, i32 45, i32 96, ; 40..47
	i32 71, i32 33, i32 32, i32 88, i32 78, i32 46, i32 29, i32 89, ; 48..55
	i32 26, i32 10, i32 60, i32 11, i32 9, i32 0, i32 0, i32 109, ; 56..63
	i32 108, i32 83, i32 8, i32 75, i32 55, i32 37, i32 97, i32 104, ; 64..71
	i32 44, i32 59, i32 5, i32 73, i32 92, i32 57, i32 4, i32 38, ; 72..79
	i32 86, i32 98, i32 54, i32 27, i32 50, i32 85, i32 31, i32 62, ; 80..87
	i32 73, i32 98, i32 79, i32 19, i32 93, i32 97, i32 47, i32 76, ; 88..95
	i32 30, i32 71, i32 68, i32 38, i32 36, i32 64, i32 28, i32 95, ; 96..103
	i32 7, i32 4, i32 88, i32 74, i32 76, i32 66, i32 82, i32 42, ; 104..111
	i32 80, i32 25, i32 53, i32 1, i32 15, i32 102, i32 70, i32 21, ; 112..119
	i32 89, i32 57, i32 61, i32 69, i32 19, i32 109, i32 86, i32 2, ; 120..127
	i32 41, i32 44, i32 20, i32 94, i32 91, i32 55, i32 39, i32 91, ; 128..135
	i32 87, i32 7, i32 106, i32 17, i32 92, i32 18, i32 36, i32 43, ; 136..143
	i32 60, i32 65, i32 29, i32 13, i32 77, i32 2, i32 5, i32 14, ; 144..151
	i32 11, i32 22, i32 23, i32 100, i32 59, i32 110, i32 50, i32 48, ; 152..159
	i32 24, i32 58, i32 100, i32 47, i32 78, i32 64, i32 26, i32 56, ; 160..167
	i32 15, i32 82, i32 22, i32 37, i32 14, i32 108, i32 21, i32 39, ; 168..175
	i32 1, i32 61, i32 16, i32 101, i32 52, i32 48, i32 40, i32 95, ; 176..183
	i32 106, i32 8, i32 12, i32 80, i32 81, i32 12, i32 96, i32 43, ; 184..191
	i32 68, i32 16, i32 107, i32 49, i32 52, i32 103, i32 42, i32 77, ; 192..199
	i32 28, i32 66, i32 51, i32 9, i32 75, i32 35, i32 24, i32 87, ; 200..207
	i32 56, i32 105, i32 90, i32 79, i32 102, i32 33, i32 45, i32 34, ; 208..215
	i32 18, i32 110, i32 31, i32 72, i32 30, i32 72 ; 216..221
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
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


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
