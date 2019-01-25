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
    /// Represents a command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// The date and time in which the instance was created
        /// </summary>
        DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// The identifier for the user that created this instance
        /// </summary>
        string CreatedBy { get; }
    }

    /// <summary>
    /// Represents a command with a result
    /// </summary>
    /// <typeparam name="TResult">The result type</typeparam>
    // ReSharper disable once UnusedTypeParameter
    public interface ICommand<out TResult>
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// The date and time in which the instance was created
        /// </summary>
        DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// The identifier for the user that created this instance
        /// </summary>
        string CreatedBy { get; }
    }
}