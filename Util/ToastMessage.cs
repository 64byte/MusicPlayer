using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Util
{
    public class ToastMessage
    {
        // for singleton
        private static volatile ToastMessage instance;
        private static object syncRoot = new object();

        public static ToastMessage Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ToastMessage();
                    }
                }

                return instance;
            }
        }

        public void Show()
        {

        }
    }
}
