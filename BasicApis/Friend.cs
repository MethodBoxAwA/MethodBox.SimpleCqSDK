using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MethodBox.SimpleCqSDK.Utils;
using MethodBox.SimpleCqSDK.Utils.Enums;

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
        /// <param name="qqNumber">要获取信息的陌生人的QQ号</param>
        /// <param name="noCache"></param>
        /// <returns></returns>
        public static FriendJson.UserInfo? GetStrangerInfo(string ipAddress, long qqNumber, bool noCache = false)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(ipAddress);
            ArgumentNullException.ThrowIfNull(qqNumber);
#endif
            var uri = $"{ipAddress}/get_stranger_info";
            FriendJson.GetUserInfoRequest request = new FriendJson.GetUserInfoRequest();
            request.NoCache = noCache;
            request.UserId = qqNumber;
            var json = JsonSerializer.Serialize(request);
            var result = MethodBox.SimpleCqSDK.Helpers.HttpHelper.Post(json, uri);
            var jsonInstance = JsonSerializer.Deserialize
                <MethodBox.SimpleCqSDK.Utils.BasicJson>(result);
            if (jsonInstance != null) 
                return ((JsonElement)jsonInstance.Data).Deserialize<FriendJson.UserInfo>();
            return null;
            //return (FriendJson.UserInfo)jsonInstance.data;
        }

    }
}
