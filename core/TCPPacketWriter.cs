﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace core
{
    class TCPPacketWriter
    {
        private List<byte> Data = new List<byte>();

        public int GetByteCount()
        {
            return this.Data.Count;
        }

        public void WriteByte(byte b)
        {
            this.Data.Add(b);
        }

        public void WriteBytes(byte[] b)
        {
            this.Data.AddRange(b);
        }

        public void WriteGuid(Guid g)
        {
            this.Data.AddRange(g.ToByteArray());
        }

        public void WriteInt16(ushort i)
        {
            this.Data.AddRange(BitConverter.GetBytes(i));
        }

        public void WriteInt32(uint i)
        {
            this.Data.AddRange(BitConverter.GetBytes(i));
        }

        public void WriteInt64(ulong i)
        {
            this.Data.AddRange(BitConverter.GetBytes(i));
        }

        public void WriteIP(String ip_string)
        {
            this.Data.AddRange(IPAddress.Parse(ip_string).GetAddressBytes());
        }

        public void WriteIP(long ip_numeric)
        {
            byte[] temp = BitConverter.GetBytes((uint)ip_numeric);
            Array.Reverse(temp);
            this.Data.AddRange(new IPAddress(temp).GetAddressBytes());
        }

        public void WriteIP(byte[] ip_bytes)
        {
            if (ip_bytes.Length != 4) return;
            this.Data.AddRange(new IPAddress(ip_bytes).GetAddressBytes());
        }

        public void WriteIP(IPAddress ip_object)
        {
            this.Data.AddRange(ip_object.GetAddressBytes());
        }

        public void WriteString(String text)
        {
            this.Data.AddRange(Encoding.UTF8.GetBytes(text));
            this.Data.Add(0);
        }

        public void WriteString(String text, bool null_terminated)
        {
            this.Data.AddRange(Encoding.UTF8.GetBytes(text.Replace("", "")));

            if (null_terminated)
                this.Data.Add(0);
        }

        public void ReplaceByte(byte b, int i)
        {
            this.Data[i] = b;
        }

        public byte[] ToByteArray()
        {
            return this.Data.ToArray();
        }

        public byte[] ToAresPacket(TCPMsg packet_id)
        {
            List<byte> tmp = new List<byte>(this.Data.ToArray());
            tmp.Insert(0, (byte)packet_id);
            tmp.InsertRange(0, BitConverter.GetBytes((ushort)(tmp.Count - 1)));
            return tmp.ToArray();
        }
    }
}