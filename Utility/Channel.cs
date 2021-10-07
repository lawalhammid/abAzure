using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Utility
{
    public static class Channel  
    {
        public static bool ChannelVal(string channel)
        {
            try
            {
                string[] channelList = { "mobile", "web" };

                foreach (string i in channelList)
                {
                    if (i.Trim() == channel)
                        return true;
                }
            }
            catch(Exception ex)
            {

            }

            return false;
        }
    }
}
