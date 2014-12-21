using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScreenSaver
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

               if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                    secondArgument = args[1];

                if (firstArgument == "/c") // Ayarlar
                {
                    //Application.Run(new SettingsForm());
                }
                else if (firstArgument == "/p") // Önizleme
                {
                    if (secondArgument == null)
                    {
                        MessageBox.Show("Bir hata oluştu!",
                            "What colour is it", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    IntPtr previewWndHandle = new IntPtr(long.Parse(secondArgument));
                    Application.Run(new ScreenSaverForm(previewWndHandle));
                }
                else if (firstArgument == "/s") // Tam ekran
                {
                    ShowScreenSaver();
                    Application.Run();
                }
                else
                {
                    MessageBox.Show("Bu parametreyle ne yapacağımı bilemedim: \"" + firstArgument +
                        "\".", "What colour is it",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else // Argüman yoksa ayar penceresini aç
            {
                //Application.Run(new SettingsForm());
            }
        }

        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenSaverForm screensaver = new ScreenSaverForm(screen.Bounds);
                screensaver.Show();
            }
        }
    }
}
