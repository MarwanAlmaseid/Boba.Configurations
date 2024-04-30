namespace Boba.Configurations.Web.Sample.Models;

public class EmailConfig : IConfig
{
    public string DefaultFromEmail { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public SMTPSetting SMTPSetting { get; set; }
}

public class SMTPSetting
{
    public string Host { get; set; }
}