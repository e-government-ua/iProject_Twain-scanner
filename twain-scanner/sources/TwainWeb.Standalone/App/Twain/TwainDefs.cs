﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TwainWeb.Standalone.App.Twain
{

    /// <summary>
    /// TWAIN Version.
    /// </summary>
    internal class TwProtocol {									// TWON_PROTOCOL...
        public const short Major=1;
        public const short Minor=9;
    }

    /// <summary>
    /// Data Groups.
    /// </summary>
    [Flags]
    internal enum TwDG:short {									// DG_.....

        /// <summary>
        /// Data pertaining to control.
        /// </summary>
        Control=0x0001,

        /// <summary>
        /// Data pertaining to raster images.
        /// </summary>
        Image=0x0002,

        /// <summary>
        /// Data pertaining to audio.
        /// </summary>
        Audio=0x0004
    }

    /// <summary>
    /// Data codes.
    /// </summary>
    internal enum TwDAT:short {									// DAT_....
        Null=0x0000,
        Capability=0x0001,
        Event=0x0002,
        Identity=0x0003,
        Parent=0x0004,
        PendingXfers=0x0005,
        SetupMemXfer=0x0006,
        SetupFileXfer=0x0007,
        Status=0x0008,
        UserInterface=0x0009,
        XferGroup=0x000a,
        TwunkIdentity=0x000b,
        CustomDSData=0x000c,
        DeviceEvent=0x000d,
        FileSystem=0x000e,
        PassThru=0x000f,

        ImageInfo=0x0101,
        ImageLayout=0x0102,
        ImageMemXfer=0x0103,
        ImageNativeXfer=0x0104,
        ImageFileXfer=0x0105,
        CieColor=0x0106,
        GrayResponse=0x0107,
        RGBResponse=0x0108,
        JpegCompression=0x0109,
        Palette8=0x010a,
        ExtImageInfo=0x010b,

        SetupFileXfer2=0x0301
    }

    /// <summary>
    /// Messages.
    /// </summary>
    internal enum TwMSG:short {									// MSG_.....

        #region Generic messages may be used with any of several DATs.

        /// <summary>
        /// Used in TW_EVENT structure.
        /// </summary>
        Null=0x0000,

        /// <summary>
        /// Get one or more values.
        /// </summary>
        Get=0x0001,

        /// <summary>
        /// Get current value.
        /// </summary>
        GetCurrent=0x0002,

        /// <summary>
        /// Get default (e.g. power up) value.
        /// </summary>
        GetDefault=0x0003,

        /// <summary>
        /// Get first of a series of items, e.g. DSs.
        /// </summary>
        GetFirst=0x0004,

        /// <summary>
        /// Iterate through a series of items.
        /// </summary>
        GetNext=0x0005,

        /// <summary>
        /// Set one or more values.
        /// </summary>
        Set=0x0006,

        /// <summary>
        /// Set current value to default value.
        /// </summary>
        Reset=0x0007,
        MSG_GETLABELENUM = 0x000B,
        /// <summary>
        /// Get supported operations on the cap.
        /// </summary>
        QuerySupport=0x0008,

        #endregion

        #region Messages used with DAT_NULL

        XFerReady=0x0101,
        CloseDSReq=0x0102,
        CloseDSOK=0x0103,
        DeviceEvent=0x0104,

        #endregion

        #region Messages used with a pointer to a DAT_STATUS structure

        /// <summary>
        /// Get status information
        /// </summary>
        CheckStatus=0x0201,

        #endregion

        #region Messages used with a pointer to DAT_PARENT data

        /// <summary>
        /// Open the DSM
        /// </summary>
        OpenDSM=0x0301,

        /// <summary>
        /// Close the DSM
        /// </summary>
        CloseDSM=0x0302,

        #endregion

        #region Messages used with a pointer to a DAT_IDENTITY structure

        /// <summary>
        /// Open a data source
        /// </summary>
        OpenDS=0x0401,

        /// <summary>
        /// Close a data source
        /// </summary>
        CloseDS=0x0402,

        /// <summary>
        /// Put up a dialog of all DS
        /// </summary>
        UserSelect=0x0403,

        #endregion

        #region Messages used with a pointer to a DAT_USERINTERFACE structure

        /// <summary>
        /// Disable data transfer in the DS
        /// </summary>
        DisableDS=0x0501,

        /// <summary>
        /// Enable data transfer in the DS
        /// </summary>
        EnableDS=0x0502,

        /// <summary>
        /// Enable for saving DS state only.
        /// </summary>
        EnableDSUIOnly=0x0503,

        #endregion

        #region Messages used with a pointer to a DAT_EVENT structure

        ProcessEvent=0x0601,

        #endregion

        #region Messages used with a pointer to a DAT_PENDINGXFERS structure

        EndXfer=0x0701,
        StopFeeder=0x0702,

        #endregion

        #region Messages used with a pointer to a DAT_FILESYSTEM structure

        ChangeDirectory=0x0801,
        CreateDirectory=0x0802,
        Delete=0x0803,
        FormatMedia=0x0804,
        GetClose=0x0805,
        GetFirstFile=0x0806,
        GetInfo=0x0807,
        GetNextFile=0x0808,
        Rename=0x0809,
        Copy=0x080A,
        AutoCaptureDir=0x080B,

        #endregion

        #region Messages used with a pointer to a DAT_PASSTHRU structure

        PassThru=0x0901

        #endregion
    }

    /// <summary>
    /// Return Codes
    /// </summary>
    internal enum TwRC:short {									// TWRC_....
        Success=0x0000,
        Failure=0x0001,
        CheckStatus=0x0002,
        Cancel=0x0003,
        DSEvent=0x0004,
        NotDSEvent=0x0005,
        XferDone=0x0006,
        EndOfList=0x0007,
        InfoNotSupported=0x0008,
        DataNotAvailable=0x0009
    }

    /// <summary>
    /// Condition Codes
    /// </summary>
    internal enum TwCC:short {									// TWCC_....
        Success=0x0000,
        Bummer=0x0001,
        LowMemory=0x0002,
        NoDS=0x0003,
        MaxConnections=0x0004,
        OperationError=0x0005,
        BadCap=0x0006,
        BadProtocol=0x0009,
        BadValue=0x000a,
        SeqError=0x000b,
        BadDest=0x000c,
        CapUnsupported=0x000d,
        CapBadOperation=0x000e,
        CapSeqError=0x000f,
        Denied=0x0010,
        FileExists=0x0011,
        FileNotFound=0x0012,
        NotEmpty=0x0013,
        PaperJam=0x0014,
        PaperDoubleFeed=0x0015,
        FileWriteError=0x0016,
        CheckDeviceOnline=0x0017
    }

    /// <summary>
    /// Generic Constants
    /// </summary>
    internal enum TwOn:short {									// TWON_....

        /// <summary>
        /// Indicates TW_ARRAY container
        /// </summary>
        Array=0x0003,

        /// <summary>
        /// Indicates TW_ENUMERATION container
        /// </summary>
        Enum=0x0004,

        /// <summary>
        /// Indicates TW_ONEVALUE container
        /// </summary>
        One=0x0005,

        /// <summary>
        /// Indicates TW_RANGE container
        /// </summary>
        Range=0x0006,
        DontCare=-1
    }

    /// <summary>
    /// Data Types
    /// </summary>
    internal enum TwType:short {									// TWTY_....
        Int8=0x0000,
        Int16=0x0001,
        Int32=0x0002,
        UInt8=0x0003,
        UInt16=0x0004,
        UInt32=0x0005,
        Bool=0x0006,
        Fix32=0x0007,
        Frame=0x0008,
        Str32=0x0009,
        Str64=0x000a,
        Str128=0x000b,
        Str255=0x000c,
        Str1024=0x000d,
        Str512=0x000e
    }

    /// <summary>
    /// Capability Constants
    /// </summary>
    public enum TwCap:short {
        /* image data sources MAY support these caps */
        XferCount=0x0001,			// all data sources are REQUIRED to support these caps
        ICompression=0x0100,		// ICAP_...
        IPixelType=0x0101,
        IUnits=0x0102,              //default is TWUN_INCHES
        IXferMech=0x0103,
        AutoBright=0x1100,
        Brightness=0x1101,
        Contrast=0x1103,
        CustHalfTone=0x1104,
        ExposureTime=0x1105,
        Filter=0x1106,
        Flashused=0x1107,
        Gamma=0x1108,
        HalfTones=0x1109,
        Highlight=0x110a,
        ImageFileFormat=0x110c,
        LampState=0x110d,
        LightSource=0x110e,
        Orientation=0x1110,
        PhysicalWidth=0x1111,
        PhysicalHeight=0x1112,
        Shadow=0x1113,
        Frames=0x1114,
        XNativeResolution=0x1116,
        YNativeResolution=0x1117,
        XResolution=0x1118,
        YResolution=0x1119,
        MaxFrames=0x111a,
        Tiles=0x111b,
        BitOrder=0x111c,
        CCITTKFactor=0x111d,
        LightPath=0x111e,
        PixelFlavor=0x111f,
        PlanarChunky=0x1120,
        Rotation=0x1121,
        SupportedSizes=0x1122,
        Threshold=0x1123,
        XScaling=0x1124,
        YScaling=0x1125,
        BitOrderCodes=0x1126,
        PixelFlavorCodes=0x1127,
        JpegPixelType=0x1128,
        TimeFill=0x112a,
        BitDepth=0x112b,
        BitDepthReduction=0x112c,  /* Added 1.5 */
        UndefinedImageSize=0x112d,  /* Added 1.6 */
        ImageDataSet=0x112e,  /* Added 1.7 */
        ExtImageInfo=0x112f,  /* Added 1.7 */
        MinimumHeight=0x1130,  /* Added 1.7 */
        MinimumWidth=0x1131,  /* Added 1.7 */
        FlipRotation=0x1136,  /* Added 1.8 */
        BarCodeDetectionEnabled=0x1137,  /* Added 1.8 */
        SupportedBarCodeTypes=0x1138,  /* Added 1.8 */
        BarCodeMaxSearchPriorities=0x1139,  /* Added 1.8 */
        BarCodeSearchPriorities=0x113a,  /* Added 1.8 */
        BarCodeSearchMode=0x113b,  /* Added 1.8 */
        BarCodeMaxRetries=0x113c,  /* Added 1.8 */
        BarCodeTimeout=0x113d,  /* Added 1.8 */
        ZoomFactor=0x113e,  /* Added 1.8 */
        PatchCodeDetectionEnabled=0x113f,  /* Added 1.8 */
        SupportedPatchCodeTypes=0x1140,  /* Added 1.8 */
        PatchCodeMaxSearchPriorities=0x1141,  /* Added 1.8 */
        PatchCodeSearchPriorities=0x1142,  /* Added 1.8 */
        PatchCodeSearchMode=0x1143,  /* Added 1.8 */
        PatchCodeMaxRetries=0x1144,  /* Added 1.8 */
        PatchCodeTimeout=0x1145,  /* Added 1.8 */
        FlashUsed2=0x1146,  /* Added 1.8 */
        ImageFilter=0x1147,  /* Added 1.8 */
        NoiseFilter=0x1148,  /* Added 1.8 */
        OverScan=0x1149,  /* Added 1.8 */
        AutomaticBorderDetection=0x1150,  /* Added 1.8 */
        AutomaticDeskew=0x1151,  /* Added 1.8 */
        AutomaticRotate=0x1152,  /* Added 1.8 */
        JpegQuality=0x1153,  /* Added 1.9 */

        /* all data sources MAY support these caps */
        Author=0x1000,
        Caption=0x1001,
        FeederEnabled=0x1002,
        FeederLoaded=0x1003,
        TimeDate=0x1004,
        SupportedCaps=0x1005,
        ExtendedCaps=0x1006,
        AutoFeed=0x1007,
        ClearPage=0x1008,
        FeedPage=0x1009,
        RewindPage=0x100a,
        Indicators=0x100b,   /* Added 1.1 */
        SupportedCapsExt=0x100c,   /* Added 1.6 */
        PaperDetectable=0x100d,   /* Added 1.6 */
        UIControllable=0x100e,   /* Added 1.6 */
        DeviceOnline=0x100f,   /* Added 1.6 */
        AutoScan=0x1010,   /* Added 1.6 */
        ThumbnailsEnabled=0x1011,   /* Added 1.7 */
        Duplex=0x1012,   /* Added 1.7 */
        DuplexEnabled=0x1013,   /* Added 1.7 */
        EnableDSUIOnly=0x1014,   /* Added 1.7 */
        CustomDSData=0x1015,   /* Added 1.7 */
        Endorser=0x1016,   /* Added 1.7 */
        JobControl=0x1017,   /* Added 1.7 */
        Alarms=0x1018,   /* Added 1.8 */
        AlarmVolume=0x1019,   /* Added 1.8 */
        AutomaticCapture=0x101a,   /* Added 1.8 */
        TimeBeforeFirstCapture=0x101b,   /* Added 1.8 */
        TimeBetweenCaptures=0x101c,   /* Added 1.8 */
        ClearBuffers=0x101d,   /* Added 1.8 */
        MaxBatchBuffers=0x101e,   /* Added 1.8 */
        DeviceTimeDate=0x101f,   /* Added 1.8 */
        PowerSupply=0x1020,   /* Added 1.8 */
        CameraPreviewUI=0x1021,   /* Added 1.8 */
        DeviceEvent=0x1022,   /* Added 1.8 */
        SerialNumber=0x1024,   /* Added 1.8 */
        Printer=0x1026,   /* Added 1.8 */
        PrinterEnabled=0x1027,   /* Added 1.8 */
        PrinterIndex=0x1028,   /* Added 1.8 */
        PrinterMode=0x1029,   /* Added 1.8 */
        PrinterString=0x102a,   /* Added 1.8 */
        PrinterSuffix=0x102b,   /* Added 1.8 */
        Language=0x102c,   /* Added 1.8 */
        FeederAlignment=0x102d,   /* Added 1.8 */
        FeederOrder=0x102e,   /* Added 1.8 */
        ReacquireAllowed=0x1030,   /* Added 1.8 */
        BatteryMinutes=0x1032,   /* Added 1.8 */
        BatteryPercentage=0x1033   /* Added 1.8 */
    }

    /// <summary>
    /// Bit patterns: for query the operation that are supported by the data source on a capability
    /// </summary>
    [Flags]
    public enum TwQC:short { //TWQC_...
        Get=0x0001,
        Set=0x0002,
        GetDefault=0x0004,
        GetCurrent=0x0008,
        Reset=0x0010
    }

    /// <summary>
    /// Language Constants
    /// </summary>
    internal enum TwLanguage:short {
        DAN=0,  /* Danish                 */
        DUT=1,  /* Dutch                  */
        ENG=2,  /* International English  */
        FCF=3,  /* French Canadian        */
        FIN=4,  /* Finnish                */
        FRN=5,  /* French                 */
        GER=6,  /* German                 */
        ICE=7,  /* Icelandic              */
        ITN=8,  /* Italian                */
        NOR=9,  /* Norwegian              */
        POR=10, /* Portuguese             */
        SPA=11, /* Spanish                */
        SWE=12, /* Swedish                */
        USA=13  /* U.S. English           */
    }

    /// <summary>
    /// Country Constantsz
    /// </summary>
    internal enum TwCountry:short {
        AFGHANISTAN=1001,
        ALGERIA=213,
        AMERICANSAMOA=684,
        ANDORRA=033,
        ANGOLA=1002,
        ANGUILLA=8090,
        ANTIGUA=8091,
        ARGENTINA=54,
        ARUBA=297,
        ASCENSIONI=247,
        AUSTRALIA=61,
        AUSTRIA=43,
        BAHAMAS=8092,
        BAHRAIN=973,
        BANGLADESH=880,
        BARBADOS=8093,
        BELGIUM=32,
        BELIZE=501,
        BENIN=229,
        BERMUDA=8094,
        BHUTAN=1003,
        BOLIVIA=591,
        BOTSWANA=267,
        BRITAIN=6,
        BRITVIRGINIS=8095,
        BRAZIL=55,
        BRUNEI=673,
        BULGARIA=359,
        BURKINAFASO=1004,
        BURMA=1005,
        BURUNDI=1006,
        CAMAROON=237,
        CANADA=2,
        CAPEVERDEIS=238,
        CAYMANIS=8096,
        CENTRALAFREP=1007,
        CHAD=1008,
        CHILE=56,
        CHINA=86,
        CHRISTMASIS=1009,
        COCOSIS=1009,
        COLOMBIA=57,
        COMOROS=1010,
        CONGO=1011,
        COOKIS=1012,
        COSTARICA=506,
        CUBA=005,
        CYPRUS=357,
        CZECHOSLOVAKIA=42,
        DENMARK=45,
        DJIBOUTI=1013,
        DOMINICA=8097,
        DOMINCANREP=8098,
        EASTERIS=1014,
        ECUADOR=593,
        EGYPT=20,
        ELSALVADOR=503,
        EQGUINEA=1015,
        ETHIOPIA=251,
        FALKLANDIS=1016,
        FAEROEIS=298,
        FIJIISLANDS=679,
        FINLAND=358,
        FRANCE=33,
        FRANTILLES=596,
        FRGUIANA=594,
        FRPOLYNEISA=689,
        FUTANAIS=1043,
        GABON=241,
        GAMBIA=220,
        GERMANY=49,
        GHANA=233,
        GIBRALTER=350,
        GREECE=30,
        GREENLAND=299,
        GRENADA=8099,
        GRENEDINES=8015,
        GUADELOUPE=590,
        GUAM=671,
        GUANTANAMOBAY=5399,
        GUATEMALA=502,
        GUINEA=224,
        GUINEABISSAU=1017,
        GUYANA=592,
        HAITI=509,
        HONDURAS=504,
        HONGKONG=852,
        HUNGARY=36,
        ICELAND=354,
        INDIA=91,
        INDONESIA=62,
        IRAN=98,
        IRAQ=964,
        IRELAND=353,
        ISRAEL=972,
        ITALY=39,
        IVORYCOAST=225,
        JAMAICA=8010,
        JAPAN=81,
        JORDAN=962,
        KENYA=254,
        KIRIBATI=1018,
        KOREA=82,
        KUWAIT=965,
        LAOS=1019,
        LEBANON=1020,
        LIBERIA=231,
        LIBYA=218,
        LIECHTENSTEIN=41,
        LUXENBOURG=352,
        MACAO=853,
        MADAGASCAR=1021,
        MALAWI=265,
        MALAYSIA=60,
        MALDIVES=960,
        MALI=1022,
        MALTA=356,
        MARSHALLIS=692,
        MAURITANIA=1023,
        MAURITIUS=230,
        MEXICO=3,
        MICRONESIA=691,
        MIQUELON=508,
        MONACO=33,
        MONGOLIA=1024,
        MONTSERRAT=8011,
        MOROCCO=212,
        MOZAMBIQUE=1025,
        NAMIBIA=264,
        NAURU=1026,
        NEPAL=977,
        NETHERLANDS=31,
        NETHANTILLES=599,
        NEVIS=8012,
        NEWCALEDONIA=687,
        NEWZEALAND=64,
        NICARAGUA=505,
        NIGER=227,
        NIGERIA=234,
        NIUE=1027,
        NORFOLKI=1028,
        NORWAY=47,
        OMAN=968,
        PAKISTAN=92,
        PALAU=1029,
        PANAMA=507,
        PARAGUAY=595,
        PERU=51,
        PHILLIPPINES=63,
        PITCAIRNIS=1030,
        PNEWGUINEA=675,
        POLAND=48,
        PORTUGAL=351,
        QATAR=974,
        REUNIONI=1031,
        ROMANIA=40,
        RWANDA=250,
        SAIPAN=670,
        SANMARINO=39,
        SAOTOME=1033,
        SAUDIARABIA=966,
        SENEGAL=221,
        SEYCHELLESIS=1034,
        SIERRALEONE=1035,
        SINGAPORE=65,
        SOLOMONIS=1036,
        SOMALI=1037,
        SOUTHAFRICA=27,
        SPAIN=34,
        SRILANKA=94,
        STHELENA=1032,
        STKITTS=8013,
        STLUCIA=8014,
        STPIERRE=508,
        STVINCENT=8015,
        SUDAN=1038,
        SURINAME=597,
        SWAZILAND=268,
        SWEDEN=46,
        SWITZERLAND=41,
        SYRIA=1039,
        TAIWAN=886,
        TANZANIA=255,
        THAILAND=66,
        TOBAGO=8016,
        TOGO=228,
        TONGAIS=676,
        TRINIDAD=8016,
        TUNISIA=216,
        TURKEY=90,
        TURKSCAICOS=8017,
        TUVALU=1040,
        UGANDA=256,
        USSR=7,
        UAEMIRATES=971,
        UNITEDKINGDOM=44,
        USA=1,
        URUGUAY=598,
        VANUATU=1041,
        VATICANCITY=39,
        VENEZUELA=58,
        WAKE=1042,
        WALLISIS=1043,
        WESTERNSAHARA=1044,
        WESTERNSAMOA=1045,
        YEMEN=1046,
        YUGOSLAVIA=38,
        ZAIRE=243,
        ZAMBIA=260,
        ZIMBABWE=263
    }

    /// <summary>
    /// Unit of measure
    /// </summary>
    public enum TwUnits:short { //ICAP_UNITS values (UN_ means UNits)
        Inches=0,
        Centimeters=1,
        Picas=2,
        Points=3,
        Twips=4,
        Pixels=5
    }

    /// <summary>
    /// Pixel types
    /// </summary>
    public enum TwPixelType:short { //ICAP_PIXELTYPE values (PT_ means Pixel Type)

        /// <summary>
        /// Black and white
        /// </summary>
        BW=0, /* Black and White */
        Gray=1,
        RGB=2,
        Palette=3,
        CMY=4,
        CMYK=5,
        YUV=6,
        YUVK=7,
        CIEXYZ=8,
        LAB=9
    }

    /// <summary>
    /// Compression values
    /// </summary>
    internal enum TwCompression:short { //ICAP_COMPRESSION values (CP_ means ComPression )
        None=0,
        PackBits=1,

        /// <summary>
        /// Follows CCITT spec (no End Of Line)
        /// </summary>
        Group31D=2,

        /// <summary>
        /// Follows CCITT spec (has End Of Line)
        /// </summary>
        Group31Deol=3,

        /// <summary>
        /// Follows CCITT spec (use cap for K Factor)
        /// </summary>
        Group32D=4,

        /// <summary>
        /// Follows CCITT spec
        /// </summary>
        Group4=5,

        /// <summary>
        /// Use capability for more info
        /// </summary>
        Jpeg=6,

        /// <summary>
        /// Must license from Unisys and IBM to use
        /// </summary>
        Lzw=7,

        /// <summary>
        /// For Bitonal images  -- Added 1.7 KHL
        /// </summary>
        Jbig=8,

        /* Added 1.8 */
        Png=9,
        Rle4=10,
        Rle8=11,
        BitFields=12
    }

    // ------------------- STRUCTS --------------------------------------------

    /// <summary>
    /// Identifies the program/library/code resource.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2,CharSet=CharSet.Ansi)]
    internal class TwIdentity {									// TW_IDENTITY

        /// <summary>
        /// Unique number.  In Windows, application hWnd.
        /// </summary>
        public IntPtr Id;

        /// <summary>
        /// Identifies the piece of code
        /// </summary>
        public TwVersion Version;

        /// <summary>
        /// Application and DS must set to TWON_PROTOCOLMAJOR
        /// </summary>
        public short ProtocolMajor;

        /// <summary>
        /// Application and DS must set to TWON_PROTOCOLMINOR
        /// </summary>
        public short ProtocolMinor;

        /// <summary>
        /// Bit field OR combination of DG_ constants
        /// </summary>
        public int SupportedGroups;

        /// <summary>
        /// Manufacturer name, e.g. "Hewlett-Packard"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
        public string Manufacturer;
        /// <summary>
        /// Product family name, e.g. "ScanJet"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst=34)]
        public string ProductFamily;

        /// <summary>
        /// Product name, e.g. "ScanJet Plus"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst=34)]
        public string ProductName;

        public override bool Equals(object obj) {
            if(obj is TwIdentity) {
                return ((TwIdentity)obj).Id==this.Id;
            }
            return false;
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }

        public override string ToString() {
            return string.Format("{0} {1}",this.ProductName,this.Version);
        }
    }

    /// <summary>
    /// Describes version of software currently running.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2,CharSet=CharSet.Ansi)]
    internal struct TwVersion {									// TW_VERSION

        /// <summary>
        /// Major revision number of the software.
        /// </summary>
        public short MajorNum;

        /// <summary>
        /// Incremental revision number of the software.
        /// </summary>
        public short MinorNum;

        /// <summary>
        /// e.g. TWLG_SWISSFRENCH
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public TwLanguage Language;

        /// <summary>
        /// e.g. TWCY_SWITZERLAND
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public TwCountry Country;

        /// <summary>
        /// e.g. "1.0b3 Beta release"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst=34)]
        public string Info;

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString() {
            return this.Info;
        }
    }

    /// <summary>
    /// Coordinates UI between application and data source.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class TwUserInterface {						    // TW_USERINTERFACE

        /// <summary>
        /// TRUE if DS should bring up its UI
        /// </summary>
        public short ShowUI;				// bool is strictly 32 bit, so use short

        /// <summary>
        /// For Mac only - true if the DS's UI is modal
        /// </summary>
        public short ModalUI;

        /// <summary>
        /// For windows only - Application window handle
        /// </summary>
        public IntPtr ParentHand;
    }

    /// <summary>
    /// Application gets detailed status info from a data source with this.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class TwStatus {									// TW_STATUS

        /// <summary>
        /// Any TwCC constant
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public TwCC ConditionCode;		// TwCC

        /// <summary>
        /// Future expansion space
        /// </summary>
        public short Reserved;
    }

    /// <summary>
    /// For passing events down from the application to the DS.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal struct TwEvent {									// TW_EVENT

        /// <summary>
        /// Windows pMSG or Mac pEvent.
        /// </summary>
        public IntPtr EventPtr;

        /// <summary>
        /// TwMSG from data source, e.g. TwMSG.XFerReady
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public TwMSG Message;
    }

    /// <summary>
    /// Application gets detailed image info from DS with this.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class TwImageInfo {								// TW_IMAGEINFO

        /// <summary>
        /// Resolution in the horizontal
        /// </summary>
        public int XResolution;

        /// <summary>
        /// Resolution in the vertical
        /// </summary>
        public int YResolution;

        /// <summary>
        /// Columns in the image, -1 if unknown by DS
        /// </summary>
        public int ImageWidth;

        /// <summary>
        /// Rows in the image, -1 if unknown by DS
        /// </summary>
        public int ImageLength;

        /// <summary>
        /// Number of samples per pixel, 3 for RGB
        /// </summary>
        public short SamplesPerPixel;

        /// <summary>
        /// Number of bits for each sample
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=8)]
        public short[] BitsPerSample;

        /// <summary>
        /// Number of bits for each padded pixel
        /// </summary>
        public short BitsPerPixel;

        /// <summary>
        /// True if Planar, False if chunky
        /// </summary>
        public short Planar;

        /// <summary>
        /// How to interp data; photo interp
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public TwPixelType PixelType;

        /// <summary>
        /// How the data is compressed
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public TwCompression Compression;
    }

    /// <summary>
    /// Provides image layout information in current units.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class TwImageLayout {

        /// <summary>
        /// Frame coords within larger document.
        /// </summary>
        [DebuggerDisplay("Left = {Frame.Left.ToFloat()}, Top = {Frame.Top.ToFloat()}, Right = {Frame.Right.ToFloat()}, Bottom = {Frame.Bottom.ToFloat()}")]
        public TwFrame Frame;

        /// <summary>
        /// Номер документа.
        /// </summary>
        public uint DocumentNumber;

        /// <summary>
        /// Номер страницы.
        /// </summary>
        public uint PageNumber; //Reset when you go to next document

        /// <summary>
        /// Номер кадра.
        /// </summary>
        public uint FrameNumber; //Reset when you go to next page
    }

    /// <summary>
    /// Used with TwMSG.EndXfer to indicate additional data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class TwPendingXfers {								// TW_PENDINGXFERS
        public short Count;
        public int EOJ;
    }

    /// <summary>
    /// Fixed point structure type.
    /// </summary>
    [DebuggerDisplay("Whole = {Whole}, Frac = {Frac}")]
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal struct TwFix32 {									// TW_FIX32

        /// <summary>
        /// Целая часть.
        /// </summary>
        public short Whole;

        /// <summary>
        /// Дробная часть.
        /// </summary>
        public ushort Frac;

        /// <summary>
        /// Приводит тип к числу с плавающей запятой.
        /// </summary>
        /// <returns>Число с плавающей точкой.</returns>
        public float ToFloat() {
            return (float)this.Whole+((float)this.Frac/65536.0f);
        }

        /// <summary>
        /// Приводит тип целому числу со знаком.
        /// </summary>
        /// <returns>Целое число со знаком.</returns>
        public int ToInt32() {
            return (int)this.Whole+((int)this.Frac<<16);
        }

        /// <summary>
        /// Создает экземпляр TwFix32 из числа с плавающей точкой.
        /// </summary>
        /// <param name="f">Число с плавающей точкой.</param>
        /// <returns>Экземпляр TwFix32.</returns>
        public static TwFix32 FromFloat(float f) {
            int i=(int)((f*65536.0f)+0.5f);
            return new TwFix32() {
                Whole=(short)(i>>16),
                Frac=(ushort)(i&0x0000ffff)
            };
        }

        /// <summary>
        /// Создает экземпляр TwFix32 из целого числа со знаком.
        /// </summary>
        /// <param name="i">Целое число со знаком.</param>
        /// <returns>Экземпляр TwFix32.</returns>
        public static TwFix32 FromInt32(int i) {
            return new TwFix32() {
                Whole=(short)(i&0x0000ffff),
                Frac=(ushort)(i>>16)
            };
        }
    }

    /// <summary>
    /// Defines a frame rectangle in ICAP_UNITS coordinates.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal struct TwFrame {

        /// <summary>
        /// Gets or sets the x-coordinate of the left edge.
        /// </summary>
        public TwFix32 Left;

        /// <summary>
        /// Gets or sets the y-coordinate of the top edge.
        /// </summary>
        public TwFix32 Top;

        /// <summary>
        /// Gets or sets the x-coordinate that is the sum of TwFrame.Left and width of image.
        /// </summary>
        public TwFix32 Right;

        /// <summary>
        /// Gets or sets the y-coordinate that is the sum of TwFrame.Top and length of image.
        /// </summary>
        public TwFix32 Bottom;
    }

    /// <summary>
    /// Used by application to get/set capability from/in a data source.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class TwCapability:IDisposable {					// TW_CAPABILITY

        /// <summary>
        /// Id of capability to set or get, e.g. TwCap.Brightness
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public TwCap Cap;

        /// <summary>
        /// TwOn.One, TwOn.Range, TwOn.Array or TwOn.Enum
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public TwOn ConType;

        /// <summary>
        /// Handle to container of type Dat
        /// </summary>
        public IntPtr Handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwCapability"/> class.
        /// </summary>
        /// <param name="cap">The cap.</param>
        public TwCapability(TwCap cap) {
            this.Cap=cap;
            this.ConType=TwOn.DontCare;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwCapability"/> class.
        /// </summary>
        /// <param name="cap">The cap.</param>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        public TwCapability(TwCap cap,int value,TwType type) {
            this.Cap=cap;
            this.ConType=TwOn.One;
            _TwOneValue _value=new _TwOneValue() {
                ItemType=type,
                Item=value
            };
            this.Handle=Twain32.GlobalAlloc(0x42,Marshal.SizeOf(typeof(_TwOneValue)));
            IntPtr _pTwOneValue=Twain32.GlobalLock(Handle);
            Marshal.StructureToPtr(_value,_pTwOneValue,true);
            Twain32.GlobalUnlock(Handle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwCapability"/> class.
        /// </summary>
        /// <param name="cap">The cap.</param>
        /// <param name="range">The range.</param>
        public TwCapability(TwCap cap,_TwRange range) {
            this.Cap=cap;
            this.ConType=TwOn.Range;
            this.Handle=Twain32.GlobalAlloc(0x42,Marshal.SizeOf(typeof(_TwRange)));
            IntPtr _pTwRange=Twain32.GlobalLock(Handle);
            Marshal.StructureToPtr(range,_pTwRange,true);
            Twain32.GlobalUnlock(Handle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwCapability"/> class.
        /// </summary>
        /// <param name="cap">The cap.</param>
        /// <param name="array">The array.</param>
        /// <param name="arrayValue">The array value.</param>
        public TwCapability(TwCap cap,_TwArray array,object[] arrayValue) {
            this.Cap=cap;
            this.ConType=TwOn.Array;
            this.Handle=Twain32.GlobalAlloc(0x42,Marshal.SizeOf(typeof(_TwArray))+(Marshal.SizeOf(arrayValue[0])*arrayValue.Length));
            IntPtr _pTwArray=Twain32.GlobalLock(Handle);
            Marshal.StructureToPtr(array,_pTwArray,true);
            for(int i=0,_ptr=_pTwArray.ToInt32()+Marshal.SizeOf(typeof(_TwArray));i<arrayValue.Length;i++,_ptr+=Marshal.SizeOf(arrayValue[0])) {
                Marshal.StructureToPtr(arrayValue[i],(IntPtr)_ptr,true);
            }
            Twain32.GlobalUnlock(Handle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwCapability"/> class.
        /// </summary>
        /// <param name="cap">The cap.</param>
        /// <param name="enumeration">The enumeration.</param>
        /// <param name="enumerationValue">The enumeration value.</param>
        public TwCapability(TwCap cap,_TwEnumeration enumeration,object[] enumerationValue) {
            this.Cap=cap;
            this.ConType=TwOn.Enum;
            this.Handle=Twain32.GlobalAlloc(0x42,Marshal.SizeOf(typeof(_TwEnumeration))+(Marshal.SizeOf(enumerationValue[0])*enumerationValue.Length));
            IntPtr _pTwEnumeration=Twain32.GlobalLock(Handle);
            Marshal.StructureToPtr(enumeration,_pTwEnumeration,true);
            for(int i=0,_ptr=_pTwEnumeration.ToInt32()+Marshal.SizeOf(typeof(_TwEnumeration));i<enumerationValue.Length;i++,_ptr+=Marshal.SizeOf(enumerationValue[0])) {
                Marshal.StructureToPtr(enumerationValue[i],(IntPtr)_ptr,true);
            }
            Twain32.GlobalUnlock(Handle);
        }

        /// <summary>
        /// Возвращает результат для указаной возможности.
        /// </summary>
        /// <returns>Экземпляр TwArray, TwEnumeration, _TwRange или _TwOneValue.</returns>
        public object GetValue() {
            IntPtr _handle=Twain32.GlobalLock(this.Handle);
            try {
                switch(this.ConType) {
                    case TwOn.Array:
                        _TwArray _res=Marshal.PtrToStructure(_handle,typeof(_TwArray)) as _TwArray;
                        switch(_res.ItemType) {
                            case TwType.Int8:
                            case TwType.UInt8: {
                                    byte[] _array=new byte[_res.NumItems];
                                    Marshal.Copy((IntPtr)(_handle.ToInt32()+Marshal.SizeOf(typeof(_TwArray))),_array,0,_array.Length);
                                    return new TwArray<byte>(_res,_array);
                                }
                            case TwType.Int16:
                            case TwType.UInt16:
                            case TwType.Bool: {
                                    short[] _array=new short[_res.NumItems];
                                    Marshal.Copy((IntPtr)(_handle.ToInt32()+Marshal.SizeOf(typeof(_TwArray))),_array,0,_array.Length);
                                    return new TwArray<short>(_res,_array);
                                }
                            case TwType.Int32:
                            case TwType.UInt32:
                            case TwType.Fix32: {
                                    int[] _array=new int[_res.NumItems];
                                    Marshal.Copy((IntPtr)(_handle.ToInt32()+Marshal.SizeOf(typeof(_TwArray))),_array,0,_array.Length);
                                    return new TwArray<int>(_res,_array);
                                }
                        }
                        break;
                    case TwOn.Enum:
                        _TwEnumeration _res2=Marshal.PtrToStructure(_handle,typeof(_TwEnumeration)) as _TwEnumeration;
                        switch(_res2.ItemType) {
                            case TwType.Int8:
                            case TwType.UInt8: {
                                    byte[] _array=new byte[_res2.NumItems];
                                    Marshal.Copy((IntPtr)(_handle.ToInt32()+Marshal.SizeOf(typeof(_TwEnumeration))),_array,0,_array.Length);
                                    return new TwEnumeration<byte>(_res2,_array);
                                }
                            case TwType.Int16:
                            case TwType.UInt16:
                            case TwType.Bool: {
                                    short[] _array=new short[_res2.NumItems];
                                    Marshal.Copy((IntPtr)(_handle.ToInt32()+Marshal.SizeOf(typeof(_TwEnumeration))),_array,0,_array.Length);
                                    return new TwEnumeration<short>(_res2,_array);
                                }
                            case TwType.Int32:
                            case TwType.UInt32:
                            case TwType.Fix32: {
                                    int[] _array=new int[_res2.NumItems];
                                    Marshal.Copy((IntPtr)(_handle.ToInt32()+Marshal.SizeOf(typeof(_TwEnumeration))),_array,0,_array.Length);
                                    return new TwEnumeration<int>(_res2,_array);
                                }
                        }
                        break;
                    case TwOn.Range:
                        return Marshal.PtrToStructure(_handle,typeof(_TwRange));
                    case TwOn.One:
                        return Marshal.PtrToStructure(_handle,typeof(_TwOneValue));
                }
                return null;
            } finally {
                IntPtr _res2=Twain32.GlobalFree(_handle);
            }
        }

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {
            if(this.Handle!=IntPtr.Zero) {
                Twain32.GlobalFree(this.Handle);
                this.Handle=IntPtr.Zero;
            }
        }

        #endregion
    }

    /// <summary>
    /// Container for array of values.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class _TwArray {                                    //TWON_ARRAY. Container for array of values (a simplified TW_ENUMERATION)
        [MarshalAs(UnmanagedType.I2)]
        public TwType ItemType;
        public int NumItems;    /* How many items in ItemList           */
        //[MarshalAs(UnmanagedType.ByValArray,SizeConst=1)]
        //public byte[] ItemList; /* Array of ItemType values starts here */
    }

    /// <summary>
    /// Container for array of values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class TwArray<T> {
        private _TwArray _data;
        private T[] _data2;

        internal TwArray(_TwArray data,T[] data2) {
            this._data=data;
            this._data2=data2;
        }

        public TwType ItemType {
            get {
                return this._data.ItemType;
            }
        }

        public int NumItems {
            get {
                return this._data.NumItems;
            }
        }

        public T[] ItemList {
            get {
                return this._data2;
            }
        }
    }

    /// <summary>
    /// Container for a collection of values.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class _TwEnumeration {                              //TWON_ENUMERATION. Container for a collection of values.
        [MarshalAs(UnmanagedType.I2)]
        public TwType ItemType;
        public int NumItems;     /* How many items in ItemList                 */
        public int CurrentIndex; /* Current value is in ItemList[CurrentIndex] */
        public int DefaultIndex; /* Powerup value is in ItemList[DefaultIndex] */
        //[MarshalAs(UnmanagedType.ByValArray,SizeConst=1)]
        //public byte[] ItemList;  /* Array of ItemType values starts here       */
    }

    /// <summary>
    /// Container for a collection of values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class TwEnumeration<T> {
        private _TwEnumeration _data;
        private T[] _data2;

        internal TwEnumeration(_TwEnumeration data, T[] data2) {
            this._data=data;
            this._data2=data2;
        }

        public TwType ItemType {
            get {
                return this._data.ItemType;
            }
        }

        public int NumItems {
            get {
                return this._data.NumItems;
            }
        }

        public int CurrentIndex {
            get {
                return this._data.CurrentIndex;
            }
        }

        public int DefaultIndex {
            get {
                return this._data.DefaultIndex;
            }
        }

        public T[] ItemList {
            get {
                return this._data2;
            }
        }
    }

    /// <summary>
    /// Container for one value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class _TwOneValue {                                 //TW_ONEVALUE. Container for one value.
        [MarshalAs(UnmanagedType.I2)]
        public TwType ItemType;
        public int Item;
    }

    /// <summary>
    /// Container for a range of values.
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
    internal class _TwRange {                                    //TWON_RANGE. Container for a range of values.
        [MarshalAs(UnmanagedType.I2)]
        public TwType ItemType;
        public int MinValue;     /* Starting value in the range.           */
        public int MaxValue;     /* Final value in the range.              */
        public int StepSize;     /* Increment from MinValue to MaxValue.   */
        public int DefaultValue; /* Power-up value.                        */
        public int CurrentValue; /* The value that is currently in effect. */
    }
}
