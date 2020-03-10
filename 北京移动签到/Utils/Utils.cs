using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using 北京移动签到.Bean;

public class Utils
{
    static readonly byte[] key = System.Text.Encoding.UTF8.GetBytes("jsdoif11SDF222jlkdsfpowk");

    public static string GetTimestamp()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmssFFFF");
    }

    //登录接口的参数加密
    public static string GetEncode(string src)
    {
        byte[] data = System.Text.Encoding.Default.GetBytes(src);       //将 明文 从 string 转为 byte[]
        byte[] miwen = Algorithm3DES.Des3EncodeECB(key, null, data);    //3des加密
        string base64Text = Convert.ToBase64String(miwen);              //做base64编码
        return System.Web.HttpUtility.UrlEncode(base64Text);            //返回url编码后的文本
    }

    //登录接口的参数解密
    public static string GetDecode(string src)
    {
        string base64Text = System.Web.HttpUtility.UrlDecode(src);      //做url解码
        byte[] text = Convert.FromBase64String(base64Text);             //做base64解码
        byte[] mingwen = Algorithm3DES.Des3DecodeECB(key, null, text);  //3des解密
        return System.Text.Encoding.Default.GetString(mingwen);         //将 明文 从 byte[] 转为 string
    }

    //解析签到接口返回json
    public static string ParseSignInResult(string json)
    {
        JObject jo = (JObject)JsonConvert.DeserializeObject(json);
        string result = (string) jo["result"];
        if (result == "0")
        {
            return "签到成功";
        }
        else
        {
            return (string)jo["errmsg"];
        }
    }

    //解析查看卡券接口返回json
    public static List<CardTicket> ParseQueryCardTicketResult(string json)
    {
        JObject jobject = (JObject)JsonConvert.DeserializeObject(json);
        JArray jlist = JArray.Parse(jobject["list"].ToString());

        CardTicket cardTicket = null;               
        List<CardTicket> cardTicketList = new List<CardTicket>();    

        for (int i = 0; i < jlist.Count; ++i)  //遍历JArray
        {
            JObject tempo = JObject.Parse(jlist[i].ToString());
            cardTicket = new CardTicket();

            cardTicket.convertEnd = tempo["convertEnd"].ToString();
            cardTicket.canTrans = tempo["canTrans"].ToString();
            cardTicket.convertStart = tempo["convertStart"].ToString();
            cardTicket.giftInfo = tempo["giftInfo"].ToString();
            cardTicket.shade = tempo["shade"].ToString();
            cardTicket.exchangeType = (int) tempo["exchangeType"];
            cardTicket.expire_days = (int) tempo["expire_days"];
            cardTicket.content = tempo["content"].ToString();
            cardTicket.content2 = tempo["content2"].ToString();
            cardTicket.name = tempo["name"].ToString();
            cardTicket.id = (int) tempo["id"];
            cardTicket.ruleId = (int) tempo["ruleId"];
            cardTicket.goodsDesc = tempo["goodsDesc"].ToString();

            cardTicketList.Add(cardTicket);
        }
        return cardTicketList;
    }

    //解析兑换接口返回json
    public static string ParseExchangeCouponResult(string json)
    {
        JObject jo = (JObject)JsonConvert.DeserializeObject(json);
        string result = (string)jo["result"];
        if (result == "0")
        {
            return "兑换成功";
        }
        else
        {
            return (string)jo["errmsg"];
        }
    }

    


}