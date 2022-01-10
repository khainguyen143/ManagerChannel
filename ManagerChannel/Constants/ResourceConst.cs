using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerChannel.Constants
{
    public static class ResourceConst
    {
        public static string RootResourceFolderName = "root";
        public static string RootResourceFolderId = "00000000-0000-0000-0000-000000000000";

        public static int ResourceFileIdLength = 36;
        public static string ResourceFileId_AudioPrefix = "HGFA";
        public static string ResourceFileId_ImagePrefix = "HGFI";
        public static string ResourceFileId_VideoPrefix = "HGFV";
        public static string ResourceFileId_ThirdPartyPrefix = "HGTP";
        public static string ResourceFileId_EditorialPrefix = "HGED"; // được tạo từ nhiều tài nguyên vd 1 audio 100p từ  10 audio

        public static string FileServerLocalhostAddress = "localhost";

        public static string Audio_Preview_FileExtension = ".mp3";
        public static string Audio_Preview_Suffix = "preview";

        public static string Video_Preview_FileExtension = ".mp4";
        public static string Video_Preview_Suffix = "preview";
        public static int Video_Preview_MaxHeight = 720;

        public static string Video_Thumb_FileExtension = ".jpg";
        public static string Video_Thumb_SmallSize_Suffix = "thumb_sm";
        public static string Video_Thumb_MediumSize_Suffix = "thumb_md";
        public static int Video_Thumb_SmallSize_Height = 180;
        public static int Video_Thumb_MediumSize_Height = 720;

        public static string Image_Preview_FileExtension = ".jpg";
        public static string Image_Preview_SmallSize_Suffix = "sm";
        public static string Image_Preview_MediumSize_Suffix = "md";
        public static int Image_Preview_SmallSize_Height = 180;
        public static int Image_Preview_MediumSize_Height = 720;

        public static int File_Max_Action = 20;
        public static int File_Deleted_Months = 2;
    }
}
