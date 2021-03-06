﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iconnect
{
    /// <summary>Server Callback</summary>
    public interface IHostApp
    {
        /// <summary>Channel search helper</summary>
        IChannels Channels { get; }
        /// <summary>Scripting credentials</summary>
        IScripting Scripting { get; }
        /// <summary>User pool</summary>
        IPool Users { get; }
        /// <summary>Folder to save items for this extension</summary>
        String DataPath { get; }
        /// <summary>Chatroom statistics</summary>
        IStats Stats { get; }
        /// <summary>Chatroom properties</summary>
        IRoom Room { get; }
        /// <summary>Hashlink encoder / decoder</summary>
        IHashlink Hashlinks { get; }
        /// <summary>Compression utility</summary>
        ICompression Compression { get; }
        /// <summary>Write to the debug log</summary>
        void WriteLog(String text);
        /// <summary>Write to the chat log</summary>
        void WriteChatLog(String text);
        /// <summary>Get current timestamp</summary>
        uint Timestamp { get; }
        /// <summary>Get a user defined minimum admin level for a default command</summary>
        ILevel GetLevel(String command);
        /// <summary>Clear the ban list</summary>
        void ClearBans();
        /// <summary>Link hub</summary>
        IHub Hub { get; }
        /// <summary>Get current tickcount</summary>
        ulong Ticks { get; }
        /// <summary>Spell Checker</summary>
        ISpell Spelling { get; }
        /// <summary>Password Accounts</summary>
        IAccounts Accounts { get; }
        /// <summary>Send a public message to one user</summary>
        void PublicToTarget(IUser client, String sender, String text);
        /// <summary>Send an emote message to one user</summary>
        void EmoteToTarget(IUser client, String sender, String text);
    }
}
