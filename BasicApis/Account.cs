using static MethodBox.SimpleCqSDK.Utils.AccountJson;

namespace MethodBox.SimpleCqSDK.BasicApis
{
    public class Account
    {
        /// <summary>
        /// 获取机器人的基本信息。
        /// </summary>
        /// <param name="ipAddress">建立的CQHttp服务的IP地址</param>
        /// <returns>一个元组，内容分别为QQ号和昵称。</returns>
        public static (long,string) GetAccountProfile(string ipAddress)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
#endif
            var uri = $"{ipAddress}/get_login_info";
            var result = Helpers.HttpHelper.Post(uri,new Dictionary<string, string>());
            var jsonInstance = System.Text.Json.JsonSerializer.Deserialize<Utils.AccountJson.UserInfo>
                (result)??throw new Framework.Exceptions.DataEmptyException("返回数据为空");
            return (jsonInstance.user_id, jsonInstance.nickname);
        }

        /// <summary>
        /// 设置登录号资料
        /// </summary>
        /// <inheritdoc cref="GetAccountProfile"/>
        /// <param name="ipAddress"></param>
        /// <param name="profile">用户资料类，包含用户的全部资料</param>
        public void SetAccountProfile(string ipAddress,UserProfile profile)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
            ArgumentNullException.ThrowIfNull(profile);
#endif
            var uri = $"{ipAddress}/set_qq_profile";
            var jsonInstance = System.Text.Json.JsonSerializer.Serialize(profile);
            Helpers.HttpHelper.Post(jsonInstance, uri);
        }

        /// <summary>
        /// 获取在线机型
        /// </summary>
        /// <inheritdoc cref="GetAccountProfile"/>
        /// <param name="ipAddress"></param>
        /// <param name="model">机型名称</param>
        /// <returns></returns>
        public (string, bool) GetModelShow(string ipAddress, string model)
        {

        }
    }
}
