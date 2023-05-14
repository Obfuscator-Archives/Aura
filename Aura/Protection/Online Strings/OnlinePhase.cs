﻿using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Aura.Services;
using System;
using System.Linq;

namespace Aura.Protection.StringOnline
{
    public static class OnlinePhase
    {
        public static void Execute(ModuleDef module)
        {
            InjectClass1(module);
            foreach (var type in module.GetTypes())
            {
                if (type.IsGlobalModuleType) continue;
                foreach (var methodDef2 in type.Methods)
                {
                    if (!methodDef2.HasBody || !methodDef2.Body.HasInstructions) continue;
                    if (methodDef2.Name.Contains("Decoder")) continue;
                    for (var i = 0; i < methodDef2.Body.Instructions.Count; i++)
                    {
                        if (methodDef2.Body.Instructions[i].OpCode != OpCodes.Ldstr) continue;
                        var plainText = methodDef2.Body.Instructions[i].Operand.ToString();
                        var operand = ConvertStringToHex(plainText);
                        methodDef2.Body.Instructions[i].Operand = operand;
                        methodDef2.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Call, MainWindow.Init));
                    }
                    methodDef2.Body.SimplifyBranches();
                }
            }
        }

        public static string ConvertStringToHex(string asciiString)
        {
            var hex = string.Empty;
            foreach (var c in asciiString)
            {
                int tmp = c;
                hex += $"{Convert.ToUInt32(tmp.ToString()):x2}";
            }
            return hex;
        }

        public static void InjectClass1(ModuleDef module)
        {
            var typeModule = ModuleDefMD.Load(typeof(OnlineString).Module);
            var typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(OnlineString).MetadataToken));
            var members = InjectHelper.Inject(typeDef, module.GlobalType, module);
            MainWindow.Init = (MethodDef)members.Single(method => method.Name == "Decoder");
            foreach (var md in module.GlobalType.Methods)
            {
                if (md.Name != ".ctor") continue;
                module.GlobalType.Remove(md);
                break;
            }
        }
    }
}