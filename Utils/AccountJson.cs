using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodBox.SimpleCqSDK.Utils
{
    public class AccountJson
    {
        internal class UserInfo:Basics.UserBasic{}

        /// <summary>
        /// 用于表示设置用户资料时的相应类。
        /// </summary>
        public class UserProfile
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string nickname { get; set; } = "myName";

            /// <summary>
            /// 公司
            /// </summary>
            public string company { get; set; } = "myCompany";

            /// <summary>
            /// 邮箱
            /// </summary>
            public string email { get; set; } = "myEmail";

            /// <summary>
            /// 学校
            /// </summary>
            public string collage { get; set; } = "myCollage";

            /// <summary>
            /// 个人说明
            /// </summary>
            public string personal_note { get; set; } = "myNote";
        }

        public class PhoneTypeInfo
        {
            public Variants[] variants { get; set; } = Array.Empty<Variants>();
        }

        public class Variants
        {
            /// <summary>
            /// 机型名称
            /// </summary>
            public string model_show { get; set; } = "model_show";
            /// <summary>
            /// 是否需要付费
            /// </summary>
            public bool need_pay { get; set; } = true;
        }

        public class ClientsInfo
        {
            public Device[] clients { get; set; } = Array.Empty<Device>();
        }

        public class Device
        {
            /// <summary>
            /// 客户端ID
            /// </summary>
            public long app_id { get; set; } = 1919810;
            /// <summary>
            /// 设备名称
            /// </summary>
            public string device_name = "Homoの手机";
            /// <summary>
            /// 设备类型
            /// </summary>
            private string device_kind = "哼哼哼";
        }

        internal class CacheSettings
        {
            public bool no_cache { get; set; } = false;
        }
    }
}
