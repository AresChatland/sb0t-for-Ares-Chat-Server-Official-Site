﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace iconnect
{
    /// <summary>Server Events</summary>
    public interface IExtension
    {
        /// <summary>Server Event</summary>
        void ServerStarted();
        /// <summary>Server Event</summary>
        void CycleTick();
        /// <summary>Server Event</summary>
        void UnhandledProtocol(IUser client, bool custom, byte msg, byte[] packet);
        /// <summary>Server Event</summary>
        bool Joining(IUser client);
        /// <summary>Server Event</summary>
        void Joined(IUser client);
        /// <summary>Server Event</summary>
        void Rejected(IUser client, RejectedMsg msg);
        /// <summary>Server Event</summary>
        void Parting(IUser client);
        /// <summary>Server Event</summary>
        void Parted(IUser client);
        /// <summary>Server Event</summary>
        bool AvatarReceived(IUser client);
        /// <summary>Server Event</summary>
        bool PersonalMessageReceived(IUser client, String text);
        /// <summary>Server Event</summary>
        void TextReceived(IUser client, String text);
        /// <summary>Server Event</summary>
        String TextSending(IUser client, String text);
        /// <summary>Server Event</summary>
        void TextSent(IUser client, String text);
        /// <summary>Server Event</summary>
        void EmoteReceived(IUser client, String text);
        /// <summary>Server Event</summary>
        String EmoteSending(IUser client, String text);
        /// <summary>Server Event</summary>
        void EmoteSent(IUser client, String text);
        /// <summary>Server Event</summary>
        void PrivateSending(IUser client, IUser target, IPrivateMsg msg);
        /// <summary>Server Event</summary>
        void PrivateSent(IUser client, IUser target);
        /// <summary>Server Event</summary>
        void BotPrivateSent(IUser client, String text);
        /// <summary>Server Event</summary>
        void Command(IUser client, String command, IUser target, String args);
        /// <summary>Server Event</summary>
        bool Nick(IUser client, String name);
        /// <summary>Server Event</summary>
        void Help(IUser client);
        /// <summary>Server Event</summary>
        void FileReceived(IUser client, String filename, String title, MimeType type);
        /// <summary>Server Event</summary>
        bool Ignoring(IUser client, IUser target);
        /// <summary>Server Event</summary>
        void IgnoredStateChanged(IUser client, IUser target, bool ignored);
        /// <summary>Server Event</summary>
        void InvalidLoginAttempt(IUser client);
        /// <summary>Server Event</summary>
        void LoginGranted(IUser client);
        /// <summary>Server Event</summary>
        void AdminLevelChanged(IUser client);
        /// <summary>Server Event</summary>
        void InvalidRegistration(IUser client);
        /// <summary>Server Event</summary>
        bool Registering(IUser client);
        /// <summary>Server Event</summary>
        void Registered(IUser client);
        /// <summary>Server Event</summary>
        void Unregistered(IUser client);
        /// <summary>Server Event</summary>
        void CaptchaSending(IUser client);
        /// <summary>Server Event</summary>
        void CaptchaReply(IUser client, String reply);
        /// <summary>Server Event</summary>
        bool VroomChanging(IUser client, ushort vroom);
        /// <summary>Server Event</summary>
        void VroomChanged(IUser client);
        /// <summary>Server Event</summary>
        bool Flooding(IUser client, byte msg);
        /// <summary>Server Event</summary>
        void Flooded(IUser client);
        /// <summary>Server Event</summary>
        bool ProxyDetected(IUser client);
        /// <summary>Server Event</summary>
        void Logout(IUser client);
        /// <summary>Server Event</summary>
        void Idled(IUser client);
        /// <summary>Server Event</summary>
        void Unidled(IUser client, uint seconds_away);
        /// <summary>Server Event</summary>
        void BansAutoCleared();
        /// <summary>Server Event</summary>
        void Dispose();
        /// <summary>Server Event</summary>
        void Load();
        /// <summary>Server Event</summary>
        void LinkError(ILinkError error);
        /// <summary>Server Event</summary>
        void Linked();
        /// <summary>Server Event</summary>
        void Unlinked();
        /// <summary>Server Event</summary>
        void LeafJoined(ILeaf leaf);
        /// <summary>Server Event</summary>
        void LeafParted(ILeaf leaf);
        /// <summary>Server Event</summary>
        void LinkedAdminDisabled(ILeaf leaf, IUser client);
        /// <summary>Icon</summary>
        BitmapSource Icon { get; }
        /// <summary>GUI</summary>
        UserControl GUI { get; }
    }
}
