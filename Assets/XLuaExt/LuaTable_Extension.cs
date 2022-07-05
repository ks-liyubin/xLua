using System;
using SystemObject = System.Object;

namespace XLua
{
    public partial class LuaTable
    {
        public void CallAction(string funcName)
        {
            Action<LuaTable> action = Get<Action<LuaTable>>(funcName);
            action?.Invoke(this);
        }

        public void CallStaticAction(string funcName)
        {
            Action action = Get<Action>(funcName);
            action?.Invoke();
        }

        public void CallAction<T>(string funcName, T value)
        {
            Action<LuaTable, T> action = Get<Action<LuaTable, T>>(funcName);
            action?.Invoke(this, value);
        }

        public void CallStaticAction<T>(string funcName, T value)
        {
            Action<T> action = Get<Action<T>>(funcName);
            action?.Invoke(value);
        }

        public void CallAction<T1, T2>(string funcName, T1 value1, T2 value2)
        {
            Action<LuaTable, T1, T2> action = Get<Action<LuaTable, T1, T2>>(funcName);
            action?.Invoke(this, value1, value2);
        }

        public void CallAction<T1, T2, T3>(string funcName, T1 value1, T2 value2, T3 value3)
        {
            Action<LuaTable, T1, T2, T3> action = Get<Action<LuaTable, T1, T2, T3>>(funcName);
            action?.Invoke(this, value1, value2, value3);
        }
        public void CallAction<T1, T2, T3, T4>(string funcName, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Action<LuaTable, T1, T2, T3, T4> action = Get<Action<LuaTable, T1, T2, T3, T4>>(funcName);
            action?.Invoke(this, value1, value2, value3, value4);
        }
        public void CallAction<T1, T2, T3, T4, T5>(string funcName, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            Action<LuaTable, T1, T2, T3, T4, T5> action = Get<Action<LuaTable, T1, T2, T3, T4, T5>>(funcName);
            action?.Invoke(this, value1, value2, value3, value4, value5);
        }
        public void CallAction<T1, T2, T3, T4, T5, T6>(string funcName, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
            Action<LuaTable, T1, T2, T3, T4, T5, T6> action = Get<Action<LuaTable, T1, T2, T3, T4, T5, T6>>(funcName);
            action?.Invoke(this, value1, value2, value3, value4, value5, value6);
        }
        public void CallStaticAction<T1, T2>(string funcName, T1 value1, T2 value2)
        {
            Action<T1, T2> action = Get<Action<T1, T2>>(funcName);
            action?.Invoke(value1, value2);
        }

        public void CallStaticAction<T1, T2, T3, T4>(string funcName, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Action<T1, T2, T3, T4> action = Get<Action<T1, T2, T3, T4>>(funcName);
            action?.Invoke(value1, value2, value3, value4);
        }

        public void CallStaticAction<T1, T2, T3, T4, T5>(string funcName, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            Action<T1, T2, T3, T4, T5> action = Get<Action<T1, T2, T3, T4, T5>>(funcName);
            action?.Invoke(value1, value2, value3, value4, value5);
        }

        public void CallActionWithParams(string funcName, params LuaParam[] values)
        {
            if (values == null || values.Length == 0)
            {
                CallAction(funcName);
            }
            else
            {
                LuaFunction func = Get<LuaFunction>(funcName);
                if (func == null)
                {
                    return;
                }
                SystemObject[] paramValues = new SystemObject[values.Length + 1];
                paramValues[0] = this;
                for (int i = 0; i < values.Length; ++i)
                {
                    paramValues[i + 1] = values[i].GetValue();
                }
                func.ActionParams(paramValues);
                func.Dispose();
            }
        }

        public void CallStaticActionWithParams(string funcName, params LuaParam[] values)
        {
            if (values == null || values.Length == 0)
            {
                CallStaticAction(funcName);
            }
            else
            {
                LuaFunction func = Get<LuaFunction>(funcName);
                if (func == null)
                {
                    return;
                }
                SystemObject[] paramValues = new SystemObject[values.Length];
                for (int i = 0; i < values.Length; ++i)
                {
                    paramValues[i] = values[i].GetValue();
                }
                func.ActionParams(paramValues);
                func.Dispose();
            }
        }

        public void CallActionWithObjects(string funcName, params SystemObject[] values)
        {
            if (values == null || values.Length == 0)
            {
                Action<LuaTable> action = Get<Action<LuaTable>>(funcName);
                action?.Invoke(this);
            }
            else
            {
                LuaFunction func = Get<LuaFunction>(funcName);
                if (func == null)
                {
                    return;
                }
                SystemObject[] paramValues = new SystemObject[values.Length + 1];
                paramValues[0] = this;
                Array.Copy(values, 0, paramValues, 1, values.Length);
                func.ActionParams(paramValues);
                func.Dispose();
            }
        }

        public void CallStaticActionWithObjects(string funcName, params SystemObject[] values)
        {
            if (values == null || values.Length == 0)
            {
                CallStaticAction(funcName);
            }
            else
            {
                LuaFunction func = Get<LuaFunction>(funcName);
                if (func == null)
                {
                    return;
                }
                func.ActionParams(values);
                func.Dispose();
            }
        }

        public R CallFunc<R>(string funcName)
        {
            Func<LuaTable, R> func = Get<Func<LuaTable, R>>(funcName);
            if (func != null)
            {
                return func.Invoke(this);
            }
            return default(R);
        }

        public R CallStaticFunc<R>(string funcName)
        {
            Func<R> func = Get<Func<R>>(funcName);
            if (func != null)
            {
                return func.Invoke();
            }
            return default(R);
        }

        public R CallFunc<T, R>(string funcName, T value)
        {
            Func<LuaTable, T, R> func = Get<Func<LuaTable, T, R>>(funcName);
            if (func != null)
            {
                return func.Invoke(this, value);
            }
            return default(R);
        }

        public R CallStaticFunc<T, R>(string funcName, T value)
        {
            Func<T, R> func = Get<Func<T, R>>(funcName);
            if (func != null)
            {
                return func.Invoke(value);
            }
            return default(R);
        }

        public R CallFunc<T1, T2, R>(string funcName, T1 value1, T2 value2)
        {
            Func<LuaTable, T1, T2, R> func = Get<Func<LuaTable, T1, T2, R>>(funcName);
            if (func != null)
            {
                return func(this, value1, value2);

            }
            return default(R);
        }

        public R CallStaticFunc<T1, T2, R>(string funcName, T1 value1, T2 value2)
        {
            Func<T1, T2, R> func = Get<Func<T1, T2, R>>(funcName);
            if (func != null)
            {
                return func(value1, value2);

            }
            return default(R);
        }

        public R CallFuncWithParams<R>(string funcName, params LuaParam[] values)
        {
            if (values == null || values.Length == 0)
            {
                return CallFunc<R>(funcName);
            }
            else
            {
                LuaFunction func = Get<LuaFunction>(funcName);
                if (func == null)
                {
                    return default(R);
                }
                SystemObject[] paramValues = new SystemObject[values.Length + 1];
                paramValues[0] = this;
                for (int i = 0; i < values.Length; ++i)
                {
                    paramValues[i + 1] = values[i].GetValue();
                }

                R result = func.Func<R>(paramValues);
                func.Dispose();

                return result;
            }
        }

        public R CallStaticFuncWithParams<R>(string funcName, params LuaParam[] values)
        {
            if (values == null || values.Length == 0)
            {
                return CallStaticFunc<R>(funcName);
            }
            else
            {
                LuaFunction func = Get<LuaFunction>(funcName);
                if (func == null)
                {
                    return default(R);
                }
                SystemObject[] paramValues = new SystemObject[values.Length];
                for (int i = 0; i < values.Length; ++i)
                {
                    paramValues[i] = values[i].GetValue();
                }

                R result = func.Func<R>(paramValues);
                func.Dispose();

                return result;
            }
        }

        public R CallFuncWithObjects<R>(string funcName, params SystemObject[] values)
        {
            if (values == null || values.Length == 0)
            {
                return CallFunc<R>(funcName);
            }
            else
            {
                LuaFunction func = Get<LuaFunction>(funcName);
                if (func == null)
                {
                    return default(R);
                }
                SystemObject[] paramValues = new SystemObject[values.Length + 1];
                paramValues[0] = this;
                Array.Copy(values, 0, paramValues, 1, values.Length);
                R result = func.Func<R>(paramValues);
                func.Dispose();
                return result;
            }
        }

        public R CallStaticFuncWithObjects<R>(string funcName, params SystemObject[] values)
        {
            if (values == null || values.Length == 0)
            {
                return CallStaticFunc<R>(funcName);
            }
            else
            {
                LuaFunction func = Get<LuaFunction>(funcName);
                if (func == null)
                {
                    return default(R);
                }
                R result = func.Func<R>(values);
                func.Dispose();
                return result;
            }
        }
    }
}
