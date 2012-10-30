﻿using System;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Jurassic;
using Jurassic.Library;

namespace scripting.Objects
{
    class JSAvatarImage : ObjectInstance, ICallback
    {
        public JSAvatarImage(ObjectInstance prototype)
            : base(prototype)
        {
            this.PopulateFunctions();
        }

        public byte[] Data { get; set; }
        public UserDefinedFunction Callback { get; set; }
        public String ScriptName { get; set; }
        public String Arg { get; set; }

        [JSProperty(Name = "arg")]
        public String GetArgument
        {
            get { return this.Arg; }
            set { }
        }

        [JSProperty(Name = "exists")]
        public bool DoesExist
        {
            get { return this.Data != null; }
            set { }
        }

        [JSFunction(Name = "toScribble", IsWritable = false, IsEnumerable = true)]
        public JSScribbleImage ToScribble()
        {
            if (this.Data != null)
            {
                JSScribbleImage s = new JSScribbleImage(this.Engine.Object.InstancePrototype);
                s.FromAvatar(this.Data);
                return s;
            }

            return null;
        }

        private String[] bad_chars = new String[]
        {
            ".",
            "/",
            "\\",
            " ",
        };

        [JSFunction(Name = "save", IsWritable = false, IsEnumerable = true)]
        public bool Save(object a)
        {
            if (this.Data == null)
                return false;

            if (a is String || a is ConcatenatedString)
            {
                String filename = a.ToString();

                if (filename.Length > 1)
                    if (bad_chars.Count<String>(x => filename.Contains(x)) == 0)
                    {
                        String path = Path.Combine(Server.DataPath, this.Engine.ScriptName, "data");

                        try
                        {
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);

                            path = Path.Combine(path, filename);
                            File.WriteAllBytes(path, this.Data);
                            return true;
                        }
                        catch { }
                    }
            }

            return false;
        }

        public void FromScribble(byte[] data)
        {
            try
            {
                using (Bitmap avatar_raw = new Bitmap(new MemoryStream(data)))
                using (Bitmap avatar_sized = new Bitmap(48, 48))
                using (Graphics g = Graphics.FromImage(avatar_sized))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(avatar_raw, new RectangleF(0, 0, 48, 48));

                    using (MemoryStream ms = new MemoryStream())
                    {
                        avatar_sized.Save(ms, ImageFormat.Jpeg);
                        this.Data = ms.ToArray();
                    }
                }
            }
            catch { }
        }

        public override string ToString()
        {
            return "[object AvatarImage]";
        }
    }
}