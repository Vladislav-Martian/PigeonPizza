﻿using System;

namespace PigeonPizza.Extension
{
    public static class ActionRepeatOnInteger
    {
        public static void Times(this int count, Action action)
        {
            for (int i = 0; i < count; i++)
            {
                action();
            }
        }
    }
}
