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
    }
}
