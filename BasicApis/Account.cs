using System.Net;
using System.Reflection;
using System.Text.Json;
using MethodBox.SimpleCqSDK.Utils;
using static MethodBox.SimpleCqSDK.Utils.AccountJson;

namespace MethodBox.SimpleCqSDK.BasicApis
{
    public static class Account
    {
        /// <summary>
        /// 获取机器人的基本信息。
        /// </summary>
        /// <param name="ipAddress">建立的CQHttp服务的IP地址</param>
        public static (long,string) GetAccountProfile(string ipAddress)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
#endif
            ServicePointManager.SecurityProtocol =
                (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            var uri = $"{ipAddress}/get_login_info";
            var result = Helpers.HttpHelper.Post(uri);
            var jsonInstance = JsonSerializer.Deserialize<Utils.BasicJson>
                (result)??throw new Framework.Exceptions.DataEmptyException("返回数据为空");
            var preData = ((JsonElement)jsonInstance.Data).Deserialize<AccountJson.UserInfo>();
            return (preData.UserId, preData.NickName);
        }

        /// <summary>
        /// 设置登录号资料。
        /// </summary>
        /// <inheritdoc cref="GetAccountProfile"/>
        /// <param name="ipAddress"></param>
        /// <param name="profile">用户资料类，包含用户的全部资料</param>
        public static void SetAccountProfile(string ipAddress,UserProfile profile)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
            ArgumentNullException.ThrowIfNull(profile);
#endif
            var uri = $"{ipAddress}/set_qq_profile";
            var jsonInstance = JsonSerializer.Serialize(profile);
            Helpers.HttpHelper.Post(jsonInstance, uri);
        }

        /// <summary>
        /// 获取在线机型。
        /// </summary>
        /// <inheritdoc cref="GetAccountProfile"/>
        /// <param name="ipAddress"></param>
        /// <param name="model">机型名称</param>
        /// <returns>一个列表，其中每一项都是一个元组，其中分别为机型名称和和是否需付费信息。</returns>
        public static List<(string, bool)>? GetModelShow(string ipAddress, string model)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
            ArgumentNullException.ThrowIfNull(model);
#endif
            var uri = $"{ipAddress}/_get_model_show";
            var postDictionary = new Dictionary<string, string>
                { { "model", model } };
            var result = Helpers.HttpHelper.Post(uri, postDictionary);
            var jsonInstance = JsonSerializer.Deserialize<Utils.BasicJson>
                (result)??throw new Framework.Exceptions.DataEmptyException("返回数据为空");
            var variants = ((JsonElement)jsonInstance.Data).
                Deserialize<PhoneTypeInfo>()?.VariantsArray;

            return variants?.Select(
                tuple => (tuple.ModelShow, tuple.NeedPay)).ToList();
        }

        /// <summary>
        /// 设置登录号资料。
        /// </summary>
        /// <inheritdoc cref="GetModelShow"/>
        /// <param name="ipAddress"></param>
        /// <param name="model"></param>
        /// <param name="modelShow">机型细化名称</param>
        public static void SetModelShow(string ipAddress, string model,string modelShow)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(modelShow);
#endif
            var uri = $"{ipAddress}/_set_model_show";
            var postDictionary = new Dictionary<string, string>
                { { "model", model },{"model_show" , modelShow} };
            Helpers.HttpHelper.Post(uri,postDictionary);
        }

        /// <summary>
        /// 获取当前账号在线客户端列表。
        /// </summary>
        /// <inheritdoc cref="GetAccountProfile"/>
        /// <param name="ipAddress"></param>
        /// <param name="noCache">是否无视缓存（默认为否）</param>
        /// <returns>在线客户端列表。</returns>
        public static Device[]? GetOnlineClients(string ipAddress, bool noCache = false)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
#endif
            var uri = $"{ipAddress}/get_online_clients";
            CacheSettings settings = new()
            {
                NoCache = noCache
            };
            var result = Helpers.HttpHelper.Post(JsonSerializer.Serialize(settings),uri);
            var jsonInstance = System.Text.Json.JsonSerializer.Deserialize<Utils.BasicJson>
                (result)??throw new Framework.Exceptions.DataEmptyException("返回数据为空");
            
            return ((JsonElement)jsonInstance.Data).Deserialize<ClientsInfo>()?.Clients;
        }
    }

}