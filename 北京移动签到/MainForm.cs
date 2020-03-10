using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using 北京移动签到.Bean;

namespace 北京移动签到
{
    public partial class MainForm : Form
    {
        //全局变量
        int loginType;          //登录类型：0 验证码，1 统一密码
        public string token;    //成功登录后，获得的身份认证信息
        List<CardTicket> cardTicketList;    //签到后获得的卡券列表

        //登录类型定义
        public static int LOGIN_PASSWORD_STATIC = 0;
        public static int LOGIN_PASSWORD_DYNAMIC = 1;


        public MainForm()
        {
            InitializeComponent();
        }

        //初始化程序窗口
        private void Form1_Load(object sender, EventArgs e)
        {

            //加载登录方式选择框
            loginMethodComboBox.Items.AddRange(
                new object[2]{
                    "统一密码",
                    "验 证 码"
                });
            loginMethodComboBox.SelectedIndex = 0;          //这里定义选择框的默认选择项
            if (loginMethodComboBox.SelectedIndex == 0)
            {
                loginType = LOGIN_PASSWORD_STATIC;
                this.dynamicCodeButton.Visible = false;     //隐藏"获得验证码"按钮
            }
            else if (loginMethodComboBox.SelectedIndex == 1) {
                loginType = LOGIN_PASSWORD_DYNAMIC;
            }
            
            this.signInButton.Enabled = false;          //禁用签到按钮
            this.userNameText.Text = "18301612349";
            this.passwordText.Text = "zyx183016123";
        }

        //登录按钮点击事件
        private void loginButton_Click(object sender, EventArgs e)
        {
            //对输入值做简单的校验
            string username = userNameText.Text.Trim();
            string password = passwordText.Text.Trim();
            if (username == String.Empty) {
                MessageBox.Show("请输入手机号码");
                return;
            }
            if (password == String.Empty)
            {
                if (loginType == LOGIN_PASSWORD_STATIC)
                {
                    MessageBox.Show("请输入统一密码");
                }
                else if (loginType == LOGIN_PASSWORD_DYNAMIC) {
                    MessageBox.Show("请输入验证码");
                }
                return;
            }

            //调用登录接口，通过loginType判断登录类型
            string jsonResponse = HTTP.GetLoginResponse(username,password,loginType);
            //解析接口返回的json，并显示相应结果
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonResponse);
            string result = (string)jo["token"];
            if (result == string.Empty)
            {
                MessageBox.Show("登录失败");
            }
            else if ((string)jo["result"] == "0")
            {
                this.token = result;
                MessageBox.Show("登录成功");
                flushListView();
                this.signInButton.Enabled = true;
            }
            else
            {
                MessageBox.Show((string)jo["errmsg"]);
            }
        }

        //签到按钮点击事件
        private void signInButton_Click(object sender, EventArgs e)
        {
            string jsonText = HTTP.GetSignInResponse(this.token);
            string result = Utils.ParseSignInResult(jsonText);
            MessageBox.Show(result);
            flushListView();
        }

        //更新 ListView内容（查询卡券） 
        private void flushListView() {
            string jsonText = HTTP.GetQueryCardTicketResponse(this.token);
            cardTicketList = Utils.ParseQueryCardTicketResult(jsonText);

            //清空 listview 内容
            this.queryCardTicketListView.Items.Clear();

            if (cardTicketList.Count == 0)
            {
                MessageBox.Show("没有可兑换的卡券！", "提示");
            }
            else
            {
                //填充 listview 内容
                foreach (CardTicket cardTicket in cardTicketList)
                {
                    ListViewItem content = new ListViewItem(new string[] { Convert.ToString(cardTicket.id), cardTicket.giftInfo, cardTicket.convertEnd });
                    this.queryCardTicketListView.Items.Add(content);
                }
            }
        }

        //修改登录方式（ComboBox子项变更事件）
        private void loginMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得当前在选择框中选择的字符串
            string loginMethod = this.loginMethodComboBox.SelectedItem.ToString();
            if (loginMethod == "验 证 码")
            {
                //当选择验证码时
                loginType = LOGIN_PASSWORD_DYNAMIC;
                this.passwordLabel.Text = "验 证 码";
                this.dynamicCodeButton.Visible = true;      //显示"获得验证码"按钮
                this.loginButton.Enabled = false;           //停用"登录"按钮，发送验证码后启用
            }
            else if (loginMethod == "统一密码")
            {
                //当选择统一密码时
                loginType = LOGIN_PASSWORD_STATIC;
                this.passwordLabel.Text = "统一密码";
                this.dynamicCodeButton.Visible = false;     //隐藏"获得验证码"按钮
                this.loginButton.Enabled = true;           //启用"登录"按钮
            }
        }

        //listview 点击事件（兑换卡券）
        private void queryCardTicketListView_Click(object sender, EventArgs e)
        {
            //获得当前点击的行数num
            int num = this.queryCardTicketListView.SelectedItems.Count;
            if (num > 0)
            {
                //获得第num行（索引num-1），第1列（索引0）的属性值（id）
                string id = this.queryCardTicketListView.SelectedItems[num - 1].SubItems[0].Text;

                DialogResult dialogResult = MessageBox.Show("是否兑换id为" + id + "的卡券？", "确认", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    //兑换卡券操作
                    string jsonText = HTTP.GetExchangeCouponResponse(this.token, id);
                    string result = Utils.ParseExchangeCouponResult(jsonText);
                    MessageBox.Show(result);
                    flushListView();
                }
            }
        }

        //获取登录验证码
        private void dynamicCodeButton_Click(object sender, EventArgs e)
        {
            //对输入值做简单的校验
            string username = userNameText.Text.Trim();
            if (username == String.Empty)
            {
                MessageBox.Show("请输入手机号码");
                return;
            }

            //调用获取验证码的接口，并对结果进行解析
            string jsonResponse = HTTP.GetDynamicResponse(username);
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonResponse);
            if ((string)jo["result"] == "0")
            {
                MessageBox.Show("验证码发送成功");
                this.loginButton.Enabled = true;     //启用"登录"按钮
            }

        }

    }
}
