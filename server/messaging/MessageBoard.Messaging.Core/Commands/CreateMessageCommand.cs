﻿using System;
using MediatR;

namespace MessageBoard.Messaging.Core.Commands
{
    public class CreateMessageCommand : IRequest<Message>
    {
        public string Text { get; }

        public CreateMessageCommand(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (text.Length > 250)
                throw new ArgumentException("Text max length is 250 characteres", nameof(text));

            Text = text;
        }
    }
}