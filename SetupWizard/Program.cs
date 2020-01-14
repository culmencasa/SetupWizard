using SetupWizard.Models;
using SetupWizard.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetupWizard
{
    static class Program
    {
        public static string ProductName = ConfigurationManager.AppSettings["LinkName"];

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!System.Diagnostics.Debugger.IsAttached)
            {
                /* 当前用户是管理员的时候，直接启动应用程序
                 * 如果不是管理员，则使用UAC启动对象启动程序，以确保使用管理员身份运行
                 */
                if (!IsRunningAsAdministrator())
                {
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                    startInfo.Verb = "runas";
                    try
                    {
                        System.Diagnostics.Process.Start(startInfo);
                    }
                    catch (Win32Exception ex)
                    {
                        // 操作被用户取消
                        DialogForm.Show($"{ProductName}安装程序", "需要以管理员身份进行安装");
                    }
                    System.Windows.Forms.Application.Exit();
                    return;
                }
            }

            Application.Run(new WizardForm());
        }



        /// <summary>
        /// 是否以管理员权限运行
        /// </summary>
        /// <returns></returns>
        public static bool IsRunningAsAdministrator()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);

            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);

        }

    }
}
