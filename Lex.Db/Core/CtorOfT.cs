﻿using System;
using System.Linq.Expressions;
#if NLOG
using NLog;
#endif

namespace Lex.Db
{
  public static class Ctor<T>
  {
#if NLOG
    static readonly Logger Log = LogManager.GetCurrentClassLogger();

    static Ctor()
    {
      Log.Trace("Constructor for {0} created", typeof(T).Name);
    }
#endif
    public static readonly Func<T> New = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
  }

  public static class ObjectCtor<T>
  {
    public static readonly Func<object> New = Expression.Lambda<Func<object>>(Expression.New(typeof(T))).Compile();
  }
}