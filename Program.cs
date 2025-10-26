// file Program.cs (Phiên bản đã làm gọn)

using MiniStore.Commom.Config;
using MiniStore.CoreUI;

namespace MiniStore
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();          
            var app = Bootstrap.BuildApp();  
            Application.Run(app);
        }
    }
}