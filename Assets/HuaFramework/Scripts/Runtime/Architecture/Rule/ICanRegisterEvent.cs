﻿using HuaFramework.TypeEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HuaFramework.Architecture
{
    public interface ICanRegisterEvent : IBelongToArchitecture
    {

    }

    public static class CanRegisterEventExtension
    {

        public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self,Action<T> onEvent)
        {
            return self.GetArchitecture().RegisterEvent<T>(onEvent);
        }
        public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
             self.GetArchitecture().UnRegisterEvent<T>(onEvent);
        }
    }

}
