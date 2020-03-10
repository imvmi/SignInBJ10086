using System.Net;
using System.Text;
using 北京移动签到.Bean;

public class HTTP
{
    static string LoginBaseUrl = "https://mobilebj.cn";
    static string BaseUrl = "http://mobilebj.cn:12065";

    static int REQUEST_GET = 1;
    static int REQUEST_POST = 2;

    //获得验证码请求
    public static string GetDynamicResponse(string username) {
        LoginInfo loginInfo = new LoginInfo(username, "");
        string efValue = Utils.GetEncode(loginInfo.GetDynamicString());     //登录请求参数 ef 的值
        string url = LoginBaseUrl + "/app/getdynamic?ver=" + loginInfo.clientversion + "&ef=" + efValue;

        return GetResponse(url, null, REQUEST_GET);
    }

    //登录请求（统一密码/验证码）
    public static string GetLoginResponse(string username,string password,int loginType) {

        LoginInfo loginInfo = new LoginInfo(username, password);
        string efValue = Utils.GetEncode(loginInfo.GetLoginString());     //登录请求参数 ef 的值

        string loginApi = null;
        if (loginType == 北京移动签到.MainForm.LOGIN_PASSWORD_STATIC)
        {
            loginApi = "/app/websitepwdLogin";
        }
        else if (loginType == 北京移动签到.MainForm.LOGIN_PASSWORD_DYNAMIC) {
            loginApi = "/app/dynamicLogin";
        }
        string url = LoginBaseUrl + loginApi + "?ver=" + loginInfo.clientversion + "&ef=" + efValue;

        return GetResponse(url, null, REQUEST_GET);
    }

    //签到请求
    public static string GetSignInResponse(string token) {
        string url = BaseUrl + "/app/signIn";
        string paraUrlCoded = "token=" + token;
        byte[] body = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
        return GetResponse(url, body, REQUEST_POST);
    }

    //查看卡券
    public static string GetQueryCardTicketResponse(string token) {
        string url = BaseUrl + "/app/queryCardTicket";
        string paraUrlCoded = "token=" + token;
        byte[] body = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
        return GetResponse(url, body, REQUEST_POST);
    }

    //兑换卡券
    public static string GetExchangeCouponResponse(string token,string couponId)
    {
        string url = BaseUrl + "/app/exchangeCoupon";
        string paraUrlCoded = "couponId=" + couponId + "&token=" + token;
        byte[] body = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
        return GetResponse(url, body, REQUEST_POST);
    }

    //HTTP请求方法
    private static string GetResponse(string url,byte[] body,int type)
    {
        //设置 Request请求
        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(url);
        if (type == REQUEST_POST)
        {
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = body.Length;
            request.ServicePoint.Expect100Continue = false;
            request.KeepAlive = false;
            //将POST请求参数 写入输出流
            System.IO.Stream writer = request.GetRequestStream();
            writer.Write(body, 0, body.Length);
            writer.Close();
        }
        else if (type == REQUEST_GET) {
            request.Method = "GET";
        }
        
        //获得响应内容
        System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
        System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
        string responseText = myreader.ReadToEnd();
        myreader.Close();

        return responseText;
    }


}