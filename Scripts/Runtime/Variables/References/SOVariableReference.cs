using UnityEngine;

namespace DoubTech.EquationEvaluator.Variables
{
    public abstract class SOVariableReference : ScriptableObject, IVariableReference
    {
        public virtual string Name => name;
        public abstract double ReferenceValue { get; }

        public override string ToString()
        {
            return name;
        }
    }
}
