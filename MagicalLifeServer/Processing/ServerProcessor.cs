﻿using MagicalLifeAPI.InternalExceptions;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeServer.Processing.Message;
using MagicalLifeServer.Processing.Message_Handlers;
using System.Collections.Generic;

namespace MagicalLifeServer.Processing
{
    public static class ServerProcessor
    {
        /// <summary>
        /// Key: The ID of the message to be handled.
        /// Value: The handler for that ID.
        /// </summary>
        private static Dictionary<int, MessageHandler> MessageHandlers = new Dictionary<int, MessageHandler>();

        public static void Initialize()
        {
            ServerSendRecieve.MessageRecieved += ServerSendRecieve_MessageRecieved;

            //More important messages
            MessageHandlers.Add(9, new DisconnectMessageHandler());
            MessageHandlers.Add(7, new JobCompletedMessageHandler());
            MessageHandlers.Add(10, new WorldModifierMessageHandler());

            //Least important messages
            MessageHandlers.Add(3, new RouteCreatedMessageHandler());
            MessageHandlers.Add(8, new JobCreatedMessageHandler());
            MessageHandlers.Add(6, new LoginMessageHandler());
        }

        private static void ServerSendRecieve_MessageRecieved(object sender, BaseMessage e)
        {
            Process(e);
        }

        public static void Process(BaseMessage msg)
        {
            bool success = MessageHandlers.TryGetValue(msg.ID, out MessageHandler handler);

            if (success)
            {
                handler.HandleMessage(msg);
            }
            else
            {
                throw new UnexpectedMessageException();
            }
        }

        /// <summary>
        /// Properly adds a message handler.
        /// </summary>
        /// <param name="handler"></param>
        public static void AddHandler(MessageHandler handler)
        {
            MessageHandlers.Add(handler.MessageID, handler);
        }
    }
}