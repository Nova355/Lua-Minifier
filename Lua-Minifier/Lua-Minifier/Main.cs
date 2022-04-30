using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Lua_Minifier
{
    public partial class Main : Form
    {
        IWebDriver driver;
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            this.richTextBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            var chrome = ChromeDriverService.CreateDefaultService();
            chrome.HideCommandPromptWindow = true;
            options.AddArgument("--lang=en-US");
            options.AddArgument("--incognito");
            options.AddArguments("--disable-extensions");
            options.AddArgument("--hide-scrollbars");
            options.AddArgument("--headless");
            driver = new ChromeDriver(chrome, options);
            driver.Navigate().GoToUrl("https://mothereff.in/lua-minifier");
            IWebElement textBox = driver.FindElement(By.TagName("textarea"));
            textBox.Clear();
            textBox.SendKeys(richTextBox1.Text);
            IWebElement textresult = driver.FindElement(By.Id("output"));
            richTextBox2.Text = textresult.Text;
            driver.Quit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }
    }
}
