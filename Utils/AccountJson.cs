using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MethodBox.SimpleCqSDK.Utils
{
    /// <summary>
    /// 用于表示用户相关JSON实例结构的导出类。
    /// </summary>
    public class AccountJson
    {
        /// <summary>
        /// 用于表示机器人基本信息的类。
        /// </summary>
        internal class UserInfo:Basics.UserBasic{}

        /// <summary>
        /// 用于表示设置用户资料时的相应类。
        /// </summary>
        [Serializable]
        public class UserProfile
        {
            /// <summary>
            /// 名称
            /// </summary>
            [JsonPropertyName("nickname")]
            public string NickName { get; set; } = "myName";

            /// <summary>
            /// 公司
            /// </summary>
            [JsonPropertyName("company")]
            public string Company { get; set; } = "myCompany";

            /// <summary>
            /// 邮箱
            /// </summary>
            [JsonPropertyName("email")]
            public string Email { get; set; } = "myEmail";

            /// <summary>
            /// 学校
            /// </summary>
            [JsonPropertyName("collage")]
            public string Collage { get; set; } = "myCollage";

            /// <summary>
            /// 个人说明
            /// </summary>
            [JsonPropertyName("personal_note")]
            public string PersonalNote { get; set; } = "myNote";
        }

        /// <summary>
        /// 用于表示设备类型的相关类。
        /// </summary>
        [Serializable]
        public class PhoneTypeInfo
        {
            [JsonPropertyName("variants")]
            public Variants[] VariantsArray { get; set; } = Array.Empty<Variants>();
        }

        /// <summary>
        /// 设备类型具体内容类。
        /// </summary>
        [Serializable]
        public class Variants
        {
            /// <summary>
            /// 机型名称
            /// </summary>
            [JsonPropertyName("model_show")]
            public string ModelShow { get; set; } = "model_show";
            /// <summary>
            /// 是否需要付费
            /// </summary>
            [JsonPropertyName("need_pay")]
            public bool NeedPay { get; set; } = true;
        }

        /// <summary>
        /// 用于表示在线设备的相关类。
        /// </summary>
        [Serializable]
        public class ClientsInfo
        {
            [JsonPropertyName("clients")]
            public Device[]? Clients { get; set; } = Array.Empty<Device>();
        }

        /// <summary>
        /// 设备类型内容具体内容类。
        /// </summary>
        [Serializable]
        public class Device
        {
            /// <summary>
            /// 客户端ID
            /// </summary>
            [JsonPropertyName("app_id")]
            public long AppId { get; set; } = 1919810;
            /// <summary>
            /// 设备名称
            /// </summary>
            [JsonPropertyName("device_name")]
            public string DeviceName { get; set; } = "Homoの手机";
            /// <summary>
            /// 设备类型
            /// </summary>
            [JsonPropertyName("device_kind")]
            public string DeviceKind { get; set; } = "哼哼哼";
        }

        /// <summary>
        /// 缓存信息的设置类。
        /// </summary>
        [Serializable]
        public class CacheSettings
        {
            /// <summary>
            /// 是否不使用缓存。
            /// </summary>
            [JsonPropertyName("no_cache")]
            public bool NoCache { get; set; } = false;
        }
    }
}
