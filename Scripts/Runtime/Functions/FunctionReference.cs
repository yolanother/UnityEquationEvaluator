using UnityEngine;

namespace DoubTech.EquationEvaluator.Functions
{
    [CreateAssetMenu(fileName = "FunctionReference", menuName = "FunctionReference")]
    public abstract class FunctionReference : ScriptableObject
    {
        public string name;
        public abstract double Evaluate(double[] arguments);
    }
}
