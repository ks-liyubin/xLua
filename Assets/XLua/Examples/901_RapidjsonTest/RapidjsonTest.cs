using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using XLua.LuaDLL;

public class RapidjsonTest : MonoBehaviour
{
    void Start()
    {
        LuaEnv luaEnv = new LuaEnv();
        luaEnv.AddBuildin("rapidjson", Lua.LoadRapidJson);

        luaEnv.DoString(@"
local rapidjson = require('rapidjson')

local jsonStr = '{""a"":{""b"":""test text""}}'

local result = rapidjson.decode(jsonStr)
local bValue = result.a.b
CS.UnityEngine.Debug.Log(tostring(bValue))

local eResult = rapidjson.encode(result)
CS.UnityEngine.Debug.Log(eResult)
");

        luaEnv.Dispose();
    }

    void Update()
    {
        
    }
}
