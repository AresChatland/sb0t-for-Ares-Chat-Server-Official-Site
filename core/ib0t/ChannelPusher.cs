﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;

namespace core.ib0t
{
    class ChannelPusher
    {
        public static void Push()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("local=" + Settings.LocalIP);
                    sb.Append("&port=" + Settings.Port);
                    sb.Append("&name=" + Uri.EscapeDataString(Settings.Name));
                    sb.Append("&topic=" + Uri.EscapeDataString(Settings.Topic));

                    byte[] data = Encoding.UTF8.GetBytes(sb.ToString());

                    sb.Clear();

                    WebRequest request = WebRequest.Create(Settings.Get<String>("url", "web") + "?proto=2");
                    request.Method = "POST";
                    request.ContentLength = data.Length;
                    request.ContentType = "application/x-www-form-urlencoded";

                    using (Stream stream = request.GetRequestStream())
                        stream.Write(data, 0, data.Length);

                    using (WebResponse response = request.GetResponse()) { }
                }
                catch { }
            }));

            thread.Start();
        }
    }
}
