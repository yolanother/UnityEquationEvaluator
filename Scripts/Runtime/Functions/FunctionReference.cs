using UnityEngine;

namespace DoubTech.EquationEvaluator.Functions
{
    public abstract class FunctionReference : ScriptableObject
    {
        public string name;
        public abstract double Evaluate(double[] arguments);
    }
}
