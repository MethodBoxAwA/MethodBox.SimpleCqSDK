using MethodBox.SimpleCqSDK.Utils;
using System.Text.Json;
using static MethodBox.SimpleCqSDK.Utils.FriendJson;

namespace MethodBox.SimpleCqSDK.BasicApis
{
    /// <summary>
    /// 用于好友操作的相关类。
    /// </summary>
    public class Friend
    {
        /// <summary>
        /// 获取陌生人的公开信息。
        /// </summary>
        /// <inheritdoc cref="Account.GetOnlineClients"/>
        /// <param name="ipAddress"></param>
        /// <param name="qqNumber">指定用户的的QQ号</param>
        /// <param name="noCache"></param>
        /// <returns></returns>
        public static FriendJson.UserInfo? GetStrangerInfo(string ipAddress, long qqNumber, bool noCache = false)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
            ArgumentNullException.ThrowIfNull(qqNumber);
#endif
            var uri = $"{ipAddress}/get_stranger_info";
            FriendJson.GetUserInfoRequest request = new FriendJson.GetUserInfoRequest
            {
                NoCache = noCache,
                UserId = qqNumber
            };
            var json = JsonSerializer.Serialize(request);
            var result = MethodBox.SimpleCqSDK.Helpers.HttpHelper.Post(json, uri);
            var jsonInstance = JsonSerializer.Deserialize<BasicJson>(result);
            if (jsonInstance != null) 
                return ((JsonElement)jsonInstance.Data).Deserialize<FriendJson.UserInfo>();
            return null;
            //return (FriendJson.UserInfo)jsonInstance.data;
        }

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <inheritdoc cref="Account.GetAccountProfile"/>
        /// <param name="ipAddress"></param>
        /// <returns>好友列表</returns>
        public static FriendJson.BriefUserInfo[]? GetFriendList(string ipAddress)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
#endif
            var uri = $"{ipAddress}/get_friend_list";
            var result = Helpers.HttpHelper.Post(uri);
            var jsonInstance = JsonSerializer.Deserialize<BriefUserInfoRoot>
                (result)??throw new Framework.Exceptions.DataEmptyException("返回数据为空");
            return jsonInstance.Data;
        }

        /// <summary>
        /// 删除指定好友。
        /// </summary>
        /// <param name="ipAddress">建立的CQHttp服务的IP地址</param>
        /// <param name="qqNumber">指定用户的的QQ号</param>
        /// <param name="un">是否为单向</param>
        public static void DeleteFriend(string ipAddress,long qqNumber,bool un = false)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
            ArgumentNullException.ThrowIfNull(qqNumber);
#endif
            var uri = !un ? $"{ipAddress}/delete_friend" 
                : $"{ipAddress}/delete_unidirectional_friend";
            UserIdSignal signal = new()
            {
                UserId = qqNumber
            };
            Helpers.HttpHelper.Post(JsonSerializer.Serialize(signal),uri);
        }

        /// <summary>
        /// 删除指定单向好友。
        /// </summary>
        /// <inheritdoc cref="DeleteFriend"/>
        /// <param name="ipAddress"></param>
        /// <param name="qqNumber"></param>
        public static void DeleteUnidirectionalFriend(string ipAddress, long qqNumber)
        {
            DeleteFriend(ipAddress, qqNumber, true);
        }
    }
}
