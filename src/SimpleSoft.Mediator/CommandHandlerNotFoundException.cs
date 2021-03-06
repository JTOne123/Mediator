﻿#region License
// The MIT License (MIT)
// 
// Copyright (c) 2017 Simplesoft.pt
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;

namespace SimpleSoft.Mediator
{
    /// <summary>
    /// Exception thrown when the handler for a given <see cref="ICommand"/>
    /// or <see cref="ICommand{TResult}"/> can't be found.
    /// </summary>
    public class CommandHandlerNotFoundException : InvalidOperationException
    {
        private const string DefaultMessageFormat = "The command '{0}' does not have any handler";

        private CommandHandlerNotFoundException(Type commandType, object commandData)
            : base(string.Format(DefaultMessageFormat, commandType.Name))
        {
            CommandType = commandType;
            CommandData = commandData;
        }

        /// <summary>
        /// The command type
        /// </summary>
        public Type CommandType { get; }

        /// <summary>
        /// The command name
        /// </summary>
        public string CommandName => CommandType.Name;

        /// <summary>
        /// The command that caused this exception
        /// </summary>
        public object CommandData { get; }

        /// <summary>
        /// Returns the <see cref="CommandData"/> instance as the
        /// given <see cref="ICommand"/>.
        /// </summary>
        /// <typeparam name="TCommand">The command type</typeparam>
        /// <returns>The command</returns>
        public TCommand Command<TCommand>() where TCommand : ICommand
        {
            return (TCommand) CommandData;
        }

        /// <summary>
        /// Returns the <see cref="CommandData"/> instance as the
        /// given <see cref="ICommand{TResult}"/>.
        /// </summary>
        /// <typeparam name="TCommand">The command type</typeparam>
        /// <typeparam name="TResult">The command result type</typeparam>
        /// <returns>The command</returns>
        public TCommand Command<TCommand, TResult>() where TCommand : ICommand<TResult>
        {
            return (TCommand) CommandData;
        }

        /// <summary>
        /// Builds a new exception.
        /// </summary>
        /// <typeparam name="TCommand">The command type</typeparam>
        /// <returns>The exception instance</returns>
        public static CommandHandlerNotFoundException Build<TCommand>(TCommand cmd) 
            where TCommand : ICommand
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));

            return new CommandHandlerNotFoundException(typeof(TCommand), cmd);
        }

        /// <summary>
        /// Builds a new exception.
        /// </summary>
        /// <typeparam name="TCommand">The command type</typeparam>
        /// <typeparam name="TResult">The command result type</typeparam>
        /// <returns>The exception instance</returns>
        public static CommandHandlerNotFoundException Build<TCommand, TResult>(TCommand cmd) 
            where TCommand : ICommand<TResult>
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));

            return new CommandHandlerNotFoundException(typeof(TCommand), cmd);
        }
    }
}