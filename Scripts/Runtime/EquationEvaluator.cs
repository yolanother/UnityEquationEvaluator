using System;
using System.Collections.Generic;
using DoubTech.EquationEvaluator.Functions;
using DoubTech.EquationEvaluator.Variables;
using SimpleExpressionEngine;
using UnityEngine;

namespace DoubTech.EquationEvaluator
{
    public class EquationEvaluator : MonoBehaviour
    {
        [SerializeField] private string equation;
        [SerializeField] private SOVariableReference[] variableReferences;
        [SerializeField] private MonoBehaviourVariableReference[] behaviourVariableReferences;
        [SerializeField] private FunctionReference[] functionReferences;

        private Node evaluator;

        private void OnValidate()
        {
            evaluator = Parser.Parse(equation);
        }

        private void Start()
        {
            evaluator = Parser.Parse(equation);
        }

        public double Evaluate(SOVariableReference[] variables = null, FunctionReference[] functions = null)
        {
            if (null == evaluator && !string.IsNullOrEmpty(equation))
            {
                evaluator = Parser.Parse(equation);
            }

            if (null != evaluator)
            {
                var ctx = new DictionaryContext();
                ctx.AddFunctions(functionReferences);
                ctx.AddVariables(variableReferences);
                ctx.AddVariables(behaviourVariableReferences);
                ctx.AddFunctions(functions);
                ctx.AddVariables(variables);

                return evaluator.Eval(ctx);
            }

            return 0;
        }
    }

    public class DictionaryContext : IContext
    {

        Dictionary<string, IVariableReference> variableMap = new Dictionary<string, IVariableReference>();
        private Dictionary<string, FunctionReference> functionMap = new Dictionary<string,
            FunctionReference>();

        public void AddVariables(IEnumerable<SOVariableReference> variables)
        {
            if (null == variables) return;

            foreach (var variable in variables)
            {
                if (variable)
                {
                    variableMap[variable.Name] = variable;
                }
            }
        }

        public void AddVariables(IEnumerable<MonoBehaviourVariableReference> variables)
        {
            if (null == variables) return;

            foreach (var variable in variables)
            {
                if (variable)
                {
                    variableMap[variable.Name] = variable;
                }
            }
        }

        public void AddFunctions(IEnumerable<FunctionReference> functions)
        {
            if (null == functions) return;

            foreach (var f in functions)
            {
                if (f)
                {
                    functionMap[f.name] = f;
                }
            }
        }

        public double ResolveVariable(string name)
        {
            var value = Double.NaN;
            if(variableMap.TryGetValue(name, out var varRef))
            {
                value = varRef.ReferenceValue;
            }
            else
            {
                throw new Exception($"Variable '{name}' was undefined.");
            }

            return value;
        }

        public double CallFunction(string name, double[] arguments)
        {
            return functionMap[name].Evaluate(arguments);
        }
    }

    public interface IVariableReference
    {
        string Name { get; }
        double ReferenceValue { get; }
    }

    [SerializeField]
    public class ConstantVariable
    {
        public string name;
        public double value;
    }
}
