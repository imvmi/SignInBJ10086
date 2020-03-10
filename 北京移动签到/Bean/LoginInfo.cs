using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 北京移动签到.Bean
{
    public class LoginInfo
    {
        public string misdn { get; set; }       //获取手机登录验证码的接口使用该字段
        public string uinfo { get; set; }

        public string brand { get; set; }
        public string imei { get; set; }
        public string ua { get; set; }

        public string timestamp { get; set; }
        public string transactionid { get; set; }

        public string channelid { get; set; }
        public string systemversion { get; set; }
        public string os { get; set; }
        public string card { get; set; }
        public string pixels { get; set; }

        public string clientid { get; set; }
        public string clientversion { get; set; }


        public LoginInfo(string username,string password) {
            this.misdn = username;
            this.uinfo = Utils.GetEncode(username + "1234" + password);
            this.transactionid = Utils.GetTimestamp();
            this.timestamp = this.transactionid.Substring(0, 14);

            this.ua = "android-25";
            //this.brand = "MZONE";
            this.imei = "000000000000000";
            this.channelid = "bmcc003";
            this.systemversion = "7.1.1";
            this.os = "android";
            //this.card = System.Web.HttpUtility.UrlEncode("动感地带");
            this.pixels = "1920x1080";
            this.clientversion = "bjservice_and_6.9.0";
            this.clientid = System.Web.HttpUtility.UrlDecode(
                Utils.GetEncode(clientversion + "|" + clientversion + "|" + imei + "|" + timestamp));
        }

        //返回登录请求中，ef参数的明文
        public string GetLoginString()
        {
            return "uinfo=" + uinfo +
                    "&brand=" + brand +
                    "&imei=" + imei +
                    "&ua=" + ua +
                    "&timestamp=" + timestamp +
                    "&transactionid=" + transactionid +
                    "&channelid=" + channelid +
                    "&systemversion=" + systemversion +
                    "&os=" + os +
                    "&card=" + card +
                    "&pixels=" + pixels +
                    "&clientid=" + clientid;
        }

        public string GetDynamicString() {
            return "misdn=" + misdn +
                    "&brand=" + brand +
                    "&imei=" + imei +
                    "&ua=" + ua +
                    "&timestamp=" + timestamp +
                    "&transactionid=" + transactionid +
                    "&channelid=" + channelid +
                    "&systemversion=" + systemversion +
                    "&os=" + os +
                    "&card=" + card +
                    "&pixels=" + pixels +
                    "&clientid=" + clientid;
        }

    }
}
