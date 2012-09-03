﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace core
{
    class TCPPacketReader
    {
        private int Position = 0;
        private List<byte> Data = new List<byte>();

        public TCPPacketReader(byte[] bytes)
        {
            this.Data.Clear();
            this.Position = 0;
            this.Data.AddRange(bytes);
        }

        public void SkipByte()
        {
            this.Position++;
        }

        public void SkipBytes(int count)
        {
            this.Position += count;
        }

        public static implicit operator byte(TCPPacketReader p)
        {
            byte tmp = p.Data[p.Position];
            p.Position++;
            return tmp;
        }

        public static implicit operator byte[](TCPPacketReader p)
        {
            byte[] tmp = new byte[p.Data.Count - p.Position];
            Array.Copy(p.Data.ToArray(), p.Position, tmp, 0, tmp.Length);
            p.Position += tmp.Length;
            return tmp;
        }

        public static implicit operator Guid(TCPPacketReader p)
        {
            byte[] tmp = new byte[16];
            Array.Copy(p.Data.ToArray(), p.Position, tmp, 0, tmp.Length);
            p.Position += 16;
            return new Guid(tmp);
        }

        public static implicit operator ushort(TCPPacketReader p)
        {
            ushort tmp = BitConverter.ToUInt16(p.Data.ToArray(), p.Position);
            p.Position += 2;
            return tmp;
        }

        public static implicit operator uint(TCPPacketReader p)
        {
            uint tmp = BitConverter.ToUInt32(p.Data.ToArray(), p.Position);
            p.Position += 4;
            return tmp;
        }

        public static implicit operator ulong(TCPPacketReader p)
        {
            ulong tmp = BitConverter.ToUInt64(p.Data.ToArray(), p.Position);
            p.Position += 8;
            return tmp;
        }

        public static implicit operator IPAddress(TCPPacketReader p)
        {
            byte[] tmp = new byte[4];
            Array.Copy(p.Data.ToArray(), p.Position, tmp, 0, tmp.Length);
            p.Position += 4;
            return new IPAddress(tmp);
        }

        public static implicit operator String(TCPPacketReader p)
        {
            int split = p.Data.IndexOf(0, p.Position);
            byte[] tmp = new byte[split > -1 ? (split - p.Position) : (p.Data.Count - p.Position)];
            Array.Copy(p.Data.ToArray(), p.Position, tmp, 0, tmp.Length);
            p.Position = split > -1 ? (split + 1) : p.Data.Count;
            String str = Encoding.UTF8.GetString(tmp);

            String[] bad_chars = new String[] // skiddy
            {
                "\r\n",
                "\r",
                "\n",
                "",
                "",
                "\x00cc\x00b8",
                "͋"
            };

            foreach (String c in bad_chars)
                str = Regex.Replace(str, Regex.Escape(c), "", RegexOptions.IgnoreCase);

            return str;
        }

        public byte[] ToArray()
        {
            return this.Data.ToArray();
        }
    }
}