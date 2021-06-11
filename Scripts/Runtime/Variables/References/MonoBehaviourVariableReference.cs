using DoubTech.EquationEvaluator;
using UnityEngine;

namespace DoubTech.EquationEvaluator.Variables
{
    public class MonoBehaviourVariableReference : MonoBehaviour, IVariableReference
    {
        [SerializeField] public string variableName;
        [SerializeField] public double value;

        public string Name => variableName;
        public double ReferenceValue => value;
    }
}
