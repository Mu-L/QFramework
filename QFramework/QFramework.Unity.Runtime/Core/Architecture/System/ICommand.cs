﻿/****************************************************************************
 * Copyright (c) 2018 ~ 2020.12 liangxie
 * 
 * https://qframework.cn
 * https://github.com/liangxiegame/QFramework
 * https://gitee.com/liangxiegame/QFramework
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

using System.Collections;

namespace QFramework
{
    public interface ICommand : ICanGetModel, ICanGetSystem, ICanGetUtility, ICanSendEvent, ICanSendCommand,
        ICanGetConfig
    {
        void Execute();
    }

    public abstract class Command<TConfig> : ICommand where TConfig : class, IArchitecture
    {
        public abstract void Execute();
        

        public T GetConfig<T>() where T : class, IArchitecture
        {
            return SingletonProperty<T>.Instance;
        }
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return SingletonProperty<TConfig>.Instance;
        }
    }

    public interface IAsyncCommand
    {
        IEnumerable Execute();
    }
}