using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace OculusSpecsPatcher
{
    public class Patcher
    {
        public delegate void LogInfoDelegate(string message);

        public delegate void LogErrorDelegate(string message);

        public event LogInfoDelegate OnLogInfo;

        public event LogErrorDelegate OnLogError;

        public void Patch(string oculusHomeDir)
        {
            // Find the CIL assembly file to be patched
            var assemblyFile = Path.Combine(oculusHomeDir, @"OculusVR_Data\Managed\Assembly-CSharp.dll");
            if (!File.Exists(assemblyFile))
            {
                LogError("Could not find assembly file in Oculus Home directory");
                return;
            }

            LogInfo("Located assembly file");

            Environment.CurrentDirectory = Path.GetDirectoryName(assemblyFile) ?? Environment.CurrentDirectory;

            // Load the assembly using Mono.Cecil
            ModuleDefinition module;
            try
            {
                module = ModuleDefinition.ReadModule(assemblyFile);
                LogInfo("Loaded assembly {0}", module.Assembly.Name.Name);
            }
            catch (Exception ex)
            {
                LogError("Error opening assembly file: {0}", ex.Message);
                return;
            }

            // Find the class we expect to be there
            var oafConnectorClass = module.Types
                .FirstOrDefault(t => t.Name == "OafConnector");

            if (oafConnectorClass == null)
            {
                LogError("Could not locate OafConnector class");
                return;
            }

            LogInfo("Located OafConnector class");

            // Find the method that we want to patch
            var minSpecMethod = oafConnectorClass.Methods
                .FirstOrDefault(m => m.Name == "ProcessMinSpecUpdate");

            if (minSpecMethod == null)
            {
                LogError("Could not locate ProcessMinSpecUpdate method");
                return;
            }

            LogInfo("Located ProcessMinSpecUpdate method");
            
            // Find the correct pattern of instructions that we know how to modify
            var instructions = FindInstructions(minSpecMethod.Body);
            if (instructions == null)
            {
                LogError("Could not find the correct instruction pattern in method");
                return;
            }

            LogInfo("Located CIL instructions to patch");

            // Replace "recvIsUnderMinSpecInnerData.under" expression with "false"
            try
            {
                var cil = minSpecMethod.Body.GetILProcessor();
                cil.Remove(instructions.Item1);     // Remove instruction to load recvIsUnderMinSpecInnerData variable onto the stack
                cil.Replace(instructions.Item2, cil.Create(OpCodes.Ldc_I4_0));  // Replace instruction to load field "under" with the boolean constant "false"
            }
            catch (Exception ex)
            {
                LogError("Failed to patch instructions: {0}", ex.Message);
                return;
            }

            LogInfo("Patched instructions");

            // Create a backup copy of the original assembly file
            string backupFile = assemblyFile + ".bak";
            try
            {
                File.Copy(assemblyFile, backupFile, true);
            }
            catch (Exception ex)
            {
                LogError("Could not back up assembly file: {0}", ex.Message);
                LogInfo("Try running the patcher as Administrator");
                return;
            }
            
            LogInfo("Backed up original assembly file");

            // Write the patched assembly back to disk, overwriting the original version
            try
            {
                module.Write(assemblyFile);
            }
            catch (Exception ex)
            {
                LogError("Could not write patched assembly file: {0}", ex.Message);
                try
                {
                    File.Copy(backupFile, assemblyFile, true);
                }
                catch (Exception e)
                {
                    LogError("Could not restore backup file: {0}", e.Message);
                    return;
                }

                LogInfo("Restored backup file");
                return;
            }
            
            LogInfo("Saved patched assembly file");
            LogInfo("All done!");
        }

        private static Tuple<Instruction, Instruction> FindInstructions(MethodBody body)
        {
            Instruction prevInstruction = null;

            foreach (var instruction in body.Instructions)
            {
                var operand = instruction.Operand as FieldDefinition;
                if (prevInstruction != null && prevInstruction.OpCode == OpCodes.Ldloc_0 && instruction.OpCode == OpCodes.Ldfld && operand != null
                    && operand.FieldType.FullName == "System.Boolean" && operand.DeclaringType.Name == "RecvIsUnderMinSpecInnerData" && operand.Name == "under")
                {
                    return Tuple.Create(prevInstruction, instruction);
                }

                prevInstruction = instruction;
            }

            return null;
        }

        private void LogInfo(string message, params object[] args)
        {
            OnLogInfo?.Invoke(string.Format(message, args));
        }

        private void LogError(string message, params object[] args)
        {
            OnLogError?.Invoke(string.Format(message, args));
        }
    }
}
