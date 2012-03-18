﻿// Copyright (c) 2010-2011 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace SharpDX
{
    /// <summary>
    /// Generic class to hold a shader compilation results.
    /// </summary>
    /// <typeparam name="T">Type of the class containing the generated bytecode.</typeparam>
    public abstract class CompilationResultBase<T> : DisposeBase where T : class, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompilationResultBase{T}"/> class.
        /// </summary>
        /// <param name="bytecode">The bytecode.</param>
        /// <param name="resultCode">Result code from compilation.</param>
        /// <param name="message">The message.</param>
        protected CompilationResultBase(T bytecode, Result resultCode, string message = null)
        {
            Bytecode = bytecode;
            ResultCode = resultCode;
            Message = message;
        }

        /// <summary>
        /// Gets the Shader bytecode.
        /// </summary>
        public T Bytecode { get; private set; }

        /// <summary>
        /// Gets the result code from the compilation.
        /// </summary>
        public Result ResultCode { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance has errors.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has errors; otherwise, <c>false</c>.
        /// </value>
        public bool HasErrors
        {
            get
            {
                return ResultCode.Failure;
            }
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <remarks>
        /// Message are warning or error messages.
        /// </remarks>
        public string Message { get; private set; }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Bytecode != null)
                {
                    Bytecode.Dispose();
                    Bytecode = null;
                }
            }
        }
    }
}